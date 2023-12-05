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
        private int _i = 0;
        private List<OperationReply> _data;
        readonly DataSet _dbHistory = new();

        public HistoryForm(List<OperationReply> data)
        {
            InitializeComponent();
            _data = data;
            //ParceData();
            CreateDataSet();
            ParceDataToDataGrid();
        }


        public void CreateDataSet()
        {
            _dbHistory.Tables.Clear();
            _dbHistory.Tables.Add("History");
            _dbHistory.Tables[0].Columns.Add("Фамилия");
            _dbHistory.Tables[0].Columns.Add("Имя");
            _dbHistory.Tables[0].Columns.Add("Отчество");
            _dbHistory.Tables[0].Columns.Add("Организация");
            _dbHistory.Tables[0].Columns.Add("Должность");
            _dbHistory.Tables[0].Columns.Add("Логин");
            _dbHistory.Tables[0].Columns.Add("Дата и время");
            _dbHistory.Tables[0].Columns.Add("Вид действия");
            _dbHistory.Tables[0].Columns.Add("Идетификационный номер экземляра объекта");
            _dbHistory.Tables[0].Columns.Add("Наименование таблицы, в которой произошло изменение");
        }

        private void ParceDataToDataGrid()
        {
            foreach (var data in _data)
            {
                var allDataParts = new string[10] { data.User.Surname.ToString(),
                                                    data.User.Name.ToString(),
                                                    data.User.Patronymic.ToString(),
                                                    data.User.Organization.Name.ToString(),
                                                    data.User.PrivelegeLevel.ToString(),
                                                    data.User.Login.ToString(),
                                                    data.Date.ToDateTime().ToString(),
                                                    data.ModifiedObjectId.ToString(),
                                                    data.Action.ToString(),
                                                    data.ModifiedTableName.ToString()};
                _dbHistory.Tables[0].Rows.Add(allDataParts);
            }
            dataGridView1.DataSource = _dbHistory.Tables[0];
        }

    }
}
