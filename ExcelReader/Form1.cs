
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
            
                if (isActiveExtra)
                {
                    var sheet2 = workbook.GetSheet("정보 시트");
                    //var sheet2 = workbook.GetSheetAt(2);
                    GetNames(sheet2);
                }

                string boxText = sheet.SheetName + " / " + sheet.LastRowNum;
          

                using (StreamWriter newTask = new StreamWriter(@"./" + fileName + ".txt", false))
                {
                    for (int i = 0; i <= sheet.LastRowNum; i++)
                    {
                        IRow curRow = sheet.GetRow(i);
                        List<ICell> cellList = curRow.Cells;
                        if(cellList.Count > 0 && cellList.Count > originalIndex && cellList.Count > transIndex )
                        {
                            if(cellList[originalIndex].CellType != CellType.String)
                            {
                                continue;
                            }
                            string original = cellList[originalIndex].StringCellValue;
                            string translate = original;
                         

                             
                            string value = cellList[transIndex].StringCellValue;

                            if (value.Trim() != "")
                            {
                                translate = value;
                            }
                            else if(googleIndex != -1)
                            {
                                translate = cellList[googleIndex].StringCellValue;
                               
                                if(isShowTransMissing)
                                {
                                    translate = "[미번역]" + translate;
                                }
                            }

                            //이름 붙이기 기능.
                            if (isActiveExtra)
                            {
                                string[] keys = original.Split(':');

                                if (keys.Length > 1)
                                {
                                    string name = keys[0];

                                    if (nameDic.ContainsKey(name))
                                    {
                                        name = nameDic[name];
                                    }
                                    else
                                    {
                                        if (!missingList.Contains(name))
                                        {
                                            missingList.Add(name + " / " + original);
                                        }

                                    }

                                    translate = name + ": " + translate;
                                }
                            }

                            if (original.Trim() != "")
                            {
                                newTask.WriteLine(@"/s");
                                newTask.WriteLine(original);
                                newTask.WriteLine(@"/t");
                                newTask.WriteLine(translate);
                                newTask.WriteLine(@"/e" + System.Environment.NewLine);


                                boxText += "\n" + original + "   " + translate;
                            }
                        }
                
                    }
                }

                if(isActiveExtra)
                {
                    
                    boxText = "";

                    for(int i = 0; i < missingList.Count; i++)
                    {
                        boxText = boxText + missingList[i] + System.Environment.NewLine;
                    }
                    
                }


                richTextBox1.Text = boxText;
                MessageBox.Show("성공! " + fileName + ".txt를 확인하세요");


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
