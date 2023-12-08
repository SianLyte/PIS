using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
//using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GrpcClient_PI_21_01.Controllers;
//using GrpcClient_PI_21_01.Data;
using GrpcClient_PI_21_01.Models;

namespace GrpcClient_PI_21_01.Views
{
    public partial class LocationAdd : Form
    {
        public LocationAdd()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private async void OKcontAdd_Click(object sender, EventArgs e)
        {
            var cityCheckFilter = new Filter<Location>();
            cityCheckFilter.AddFilter(loc => loc.City, CityText.Text);

            if (CityText.Text == "")
                MessageBox.Show("Вы не указали город.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if ((await LocationService.GetLocations(-1, cityCheckFilter)).Count > 0)
                MessageBox.Show("Указанный город уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            else
            {
                var loc = new Location(-1, CityText.Text);
                await LocationService.AddLocation(loc);
                this.Close();
            }
        }

        private void CancelcontEdit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
