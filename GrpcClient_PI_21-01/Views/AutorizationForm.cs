using GrpcClient_PI_21_01.Controllers;
using GrpcClient_PI_21_01.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrpcClient_PI_21_01
{
    public partial class AutorizationForm : Form
    {
        public AutorizationForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private async void LogInButton(object sender, EventArgs e)
        {
            string login = loginTextBox.Text;
            string password = passwordTextBox.Text;
            var user = await UserService.CheckUser(login, password);
            if (user != null)
            {
                this.Hide();
                UserService.LogIn(user);
                MainForm mainForm = new MainForm();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Enter.Enabled = true;
            }

        }

        private void CredentialKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (sender is TextBox credentialBox)
                {
                    if (credentialBox == loginTextBox)
                        passwordTextBox.Select();
                    else
                    {
                        Enter.Enabled = false;
                        LogInButton(Enter, e);
                    }
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
