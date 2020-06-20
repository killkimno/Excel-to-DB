
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

        private void MakeDB(string path, string filter)
        {
            if (path != "")
            {
                var workbook = GetWorkbook(path, filter);
                var sheet = workbook.GetSheetAt(0);



                richTextBox1.Text = sheet.SheetName + " / " + sheet.LastRowNum;


                for(int i = 0; i < sheet.LastRowNum; i++)
                {
                    IRow curRow = sheet.GetRow(i);
                    List<ICell> cellList = curRow.Cells;

                    string original = curRow.GetCell(0).StringCellValue;

                    

                    
                    richTextBox1.Text += "\n" + curRow.GetCell(0).StringCellValue + "   " + curRow.GetCell(1).StringCellValue;
                }

                using (StreamReader r = new StreamReader(path))
                {
                    using (StreamWriter newTask = new StreamWriter(@"./resultDB.txt", false))
                    {
                        string line = "";
                        while ((line = r.ReadLine()) != null)
                        {
                            string[] words = line.Split('\t');
                        }
                    }
                }
           
            }
        }

        

    }
}
