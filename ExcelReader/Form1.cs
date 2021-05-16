
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



//공통 NPOI
using NPOI;
using NPOI.SS.UserModel;
//표준 xls 버젼 excel시트
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
//확장 xlsx 버젼 excel 시트
using NPOI.XSSF;
using NPOI.XSSF.UserModel;


namespace ExcelReader
{

    
    public partial class Form1 : Form
    {
        public string fileName = "result";
        public string dataSheet = "시트1";

        public string filePath;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            if (OFD.ShowDialog() == DialogResult.OK)
            {

                isActiveExtra = cbTitanfall.Checked;
                isShowTransMissing = cbShowTrans.Checked;

                //구글 번역기 설정
                if(!string.IsNullOrEmpty( tbGoogleTransIndex.Text))
                {
                    try
                    {
                        googleIndex = Convert.ToInt32(tbGoogleTransIndex.Text);
                        googleIndex = googleIndex - 1;
                    }
                    catch
                    {
                        googleIndex = -1;
                    }
                 
                }

                //시트 이름.
                if (!string.IsNullOrEmpty(tbSheetName.Text))
                {
                    dataSheet = tbSheetName.Text;

                }
                else
                {
                    dataSheet = "";
                }

                //원문 설정
                if (!string.IsNullOrEmpty(tbOriginal.Text))
                {
                    try
                    {
                        originalIndex = Convert.ToInt32(tbOriginal.Text);
                        originalIndex = originalIndex - 1;
                    }
                    catch
                    {
                        originalIndex = 1;
                    }
                }

                //번역문 설정
                if (!string.IsNullOrEmpty(tbTransIndex.Text))
                {
                    try
                    {
                        transIndex = Convert.ToInt32(tbTransIndex.Text);
                        transIndex = transIndex - 1;
                    }
                    catch
                    {
                        transIndex = 2;
                    }
                }

                filePath = OFD.FileName;
                MakeDB(filePath, Path.GetExtension(filePath));
            }
        }

        public IWorkbook GetWorkbook(string filename, string version)
        {
            using (var stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                //표준 xls 버젼
                if (".xls".Equals(version))
                {
                    return new HSSFWorkbook(stream);
                }
                //확장 xlsx 버젼
                else if (".xlsx".Equals(version))
                {
                    return new XSSFWorkbook(stream);
                }
                throw new NotSupportedException();
            }
        }

        private int GetDataIndex(int value)
        {
            return value + 1;
        }

        private void ChangeToke(ref string value)
        {
            value = value.Replace("\'\"" , "\"");
        }

        private void SaveFile(string value, string file)
        {
            using (StreamWriter newTask = new StreamWriter(@"./File/" + file , false, Encoding.Default))
            {
                newTask.Write(value);
            }
        }

        private void GetString(ref string value , IRow row, int index)
        {
            var cell = row.GetCell(index);

            if(cell != null && cell.CellType == CellType.String)
            {
                value = cell.StringCellValue;
            }
        }

        private void MakeDB(string path, string filter)
        {
            List<string> missingList = new List<string>();

            
            if (path != "")
            {
                var workbook = GetWorkbook(path, filter);

                //var sheet = workbook.GetSheetAt(0);

                ISheet sheet = null;

                //시트 가져오기.
                if(string.IsNullOrEmpty(dataSheet))
                {
                    sheet = workbook.GetSheetAt(0);
                }
                else
                {
                    sheet = workbook.GetSheet(dataSheet);
                }
            

                string boxText = sheet.SheetName + " / " + sheet.LastRowNum;



                string result = "";
                bool isFirst = true;
                string file = "";

                try
                {
                    for (int i = 1; i <= sheet.LastRowNum; i++)
                    {
                        IRow curRow = sheet.GetRow(i);
                        List<ICell> cellList = curRow.Cells;

                        string original = "";

                        GetString(ref original, curRow, originalIndex);
                   

                        ChangeToke(ref original);
                        string translate = original;

                        string value = "";
                        GetString(ref value, curRow, transIndex);

                        if (value.Trim() != "")
                        {
                            translate = value;
                        }

                        ChangeToke(ref translate);



                        var cell = curRow.GetCell(2);


                        if (cell != null)
                        {
                            if (cell.StringCellValue != file)
                            {
                                if (file != "")
                                {
                                    SaveFile(result, file);
                                }

                                file = cell.StringCellValue;
                                result = translate;
                                boxText += "\n" + file;
                            }
                            else
                            {
                                result += System.Environment.NewLine + translate;
                            }

                        }
                        else
                        {
                            break;
                        }




                    }

                    //마지막 결과를 저장한다.
                    if (file != "")
                    {
                        boxText += "\n" + file;
                        SaveFile(result, file);
                    }
                    richTextBox1.Text = boxText;
                    MessageBox.Show("성공! File 폴더에서 확인하세요");
                }
                catch(Exception e)
                {
                    richTextBox1.Text = boxText;
                    MessageBox.Show("에러발생 ! " + e.ToString());
                }
                
            


            }
        }



        #region ::::::::: 엑스트라 기능 :::::::::

        private bool isActiveExtra = false;
        private bool isShowTransMissing = false;
        private int googleIndex = -1;
        private int transIndex = 1;
        public int originalIndex = 0;

        Dictionary<string, string> nameDic = new Dictionary<string, string>();

        private void GetNames(ISheet sheet)
        {
            nameDic.Clear();
            for (int i = 0; i <= sheet.LastRowNum; i++)
            {
                IRow curRow = sheet.GetRow(i);
                List<ICell> cellList = curRow.Cells;

                string original = cellList[0].StringCellValue;
                string translate = original; 
                if (cellList.Count > 1)
                {
                    translate=cellList[1].StringCellValue;
                }
            


                if(translate.Trim() != "")
                {
                    nameDic.Add(original, translate);
                }


            }
        }


        #endregion

    }
}
