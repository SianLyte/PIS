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
    public partial class HistoryForm : Form
    {
        //List<string> _data = new List<string>();
        public HistoryForm(List<string> data)
        {
            InitializeComponent();
            //_data = data;
            ParceData(data);
        }

        private void ParceData(List<string> data)
        {
            surnameTextBox.Text = data[0].ToString();
            nameTextBox.Text = data[1].ToString();
            patronymicTextBox.Text = data[2].ToString();
            numberTextBox.Text = data[3].ToString();
            mailTextBox.Text = data[4].ToString();
            OrganisationTextBox.Text = data[5].ToString();
            nameStructureTextBox.Text = data[6].ToString();
            postTextBox.Text = data[7].ToString();
            trueNumberTextBox.Text = data[8].ToString();
            trueMailTextBox.Text = data[9].ToString();
            loginTextBox.Text = data[10].ToString();
            dateTimeTextBox.Text = data[11].ToString();
            objectNumberTextBox.Text = data[12].ToString();
            descriptionTextBox.Text = data[13].ToString();
            fileObjectextBox.Text = data[14].ToString();
        }
    }
}
