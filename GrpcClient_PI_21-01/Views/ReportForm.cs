using GrpcClient_PI_21_01.Controllers;
//using GrpcClient_PI_21_01.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcClient_PI_21_01.Views
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            GenereteReport();
        }

        public async void GenereteReport()
        {
            dataGridViewR.Rows.Clear();
            var reports = await ReportService.GenereteReport(dateTimePickerStart.Value, dateTimePickerEnd.Value);
            int sum = 0;
            foreach (var rep in reports)
            {
                dataGridViewR.Rows.Add(rep);
                sum += int.Parse(rep[3].Split(',')[0]);
            }
            textBoxSum.Text = sum.ToString();
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            GenereteReport();
        }

        private void ReportForm_Load(object sender, EventArgs e)
        {

        }
    }
}
