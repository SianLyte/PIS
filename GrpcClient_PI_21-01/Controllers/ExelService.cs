using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;


namespace GrpcClient_PI_21_01.Controllers
{
    internal class ExelService
    {
        static private Dictionary<string, string> _TipeExportToName = new Dictionary<string, string>(){ { "act", "актам" },
            {"report", "отчётам" }, {"contract", "контрактам" }, {"app", "заявкам" }, {"org", "организациям" }, {"hist", "истории" } };
        public static void ExportExel(DataGridView dataGridView, string tipeExport)
        {
            var ExcelApp = new Excel.Application();
            Excel.Workbook ExcelWorkBook;
            Excel.Worksheet ExcelWorkSheet;
            //Книга.
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            //Таблица.
            ExcelWorkSheet = (Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            ExcelWorkSheet.Name = "Отчёт по " + _TipeExportToName[tipeExport];

            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                ExcelApp.Cells[1, i + 1] = dataGridView.Columns[i].HeaderText;
                ExcelApp.Cells[1, i + 1].Font.Bold = true;
            }
            for (int i = 1; i < dataGridView.Rows.Count+1; i++)
            {
                for (int j = 0; j < dataGridView.ColumnCount; j++)
                {
                    ExcelApp.Cells[i + 1, j + 1] = dataGridView[j, i - 1].Value.ToString();
                }
            }
            Excel.Range r = ExcelWorkSheet.get_Range("A1", "S" + dataGridView.Rows.Count+1);
            r.Font.Name = "Calibri";
            r.Cells.Font.Size = 10;
            r.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            r.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            ExcelApp.Columns.AutoFit();
            //Вызываем нашу созданную эксельку.
            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;
        }
    }
}
