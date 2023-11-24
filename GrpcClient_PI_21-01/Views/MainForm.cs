using GrpcClient_PI_21_01.Controllers;
//using GrpcClient_PI_21_01.Data;
using GrpcClient_PI_21_01.Models;
using GrpcClient_PI_21_01.Views;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Task.Run(Setup);
        }
        readonly DataSet dsApplication = new();
        readonly DataSet dsOrganization = new();

        private async Task Setup()
        {
            await CreateData();
            await SetDataGridAct();
            await ShowContract();

            await SetDataGridApp();
            await SetDataGridOrg();
        }

        private async Task CreateData()
        {
            ContractTable.Rows.Clear();
            var cont = await ContractService.GetContracts();
            //var cont = ContractRepository.ShowCont(dateTimePicker3.Value.ToString(), dateTimePicker1.Value.ToString());
            foreach (var i in cont.Where(c => c.DateConclusion >= dateTimePicker3.Value
            && c.DateConclusion <= dateTimePicker1.Value).Select(c => ContractService.ToDataArray(c)))
                ContractTable.Rows.Add(i);
        }
        private static async Task<bool> CheckPrivilege(NameMdels model)
        {
            if (!await PreveligeService.IsUserPrevilegedFor(model))
            {
                MessageBox.Show("У вас недостаточно прав!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
            return true;
        }


        /* -----------------------------------ACT----------------------------------------------------- */

        private async Task SetDataGridAct()
        {
            DataGridViewActs.Rows.Clear();
            var actss = await ActService.GetActs();
            //var actss = ActService.ShowAct(dateTimePickerAct.Value.ToString());
            foreach (var act in actss.Where(a => a.Date >= dateTimePickerAct.Value)
                .Select(a => ActService.ToDataArray(a)))
            {










                // Типо так лучше работет? :)
                // Ахахахаа, а как так вышло
























                DataGridViewActs.Rows.Add(act);
                int b = 5;
            }
            int a = 5;
        }

        private async void AddButton_Click(object sender, EventArgs e)
        {
            if (await CheckPrivilege(NameMdels.Act))
            {
                var editWindow = new ActEdit();
                editWindow.ShowDialog();
                await SetDataGridAct();
            }
        }

        private async void UpdateButton_Click(object sender, EventArgs e)
        {
            if (await CheckPrivilege(NameMdels.Act))
                if (DataGridViewActs.CurrentRow != null)
                {
                    var editWindow = new ActEdit(int.Parse(DataGridViewActs.CurrentRow.Cells[0].Value.ToString()));
                    editWindow.ShowDialog();
                    await SetDataGridAct();
                }
        }

        private async void DeleteActButton_Click(object sender, EventArgs e)
        {
            if (await CheckPrivilege(NameMdels.Act))
                if (DataGridViewActs.CurrentRow != null)
                {
                    await ActService.RemoveAct(int.Parse(DataGridViewActs.CurrentRow.Cells[0].Value.ToString()));
                    await SetDataGridAct();
                }
        }

        private async void buttonAnimalCard_Click(object sender, EventArgs e)
        {
            if (await CheckPrivilege(NameMdels.Act))
                if (DataGridViewActs.CurrentRow != null)
                {
                    bool IsDog = int.Parse(DataGridViewActs.CurrentRow.Cells[1].Value.ToString()) > 0;
                    bool IsCat = int.Parse(DataGridViewActs.CurrentRow.Cells[2].Value.ToString()) > 0;

                    if (IsDog)
                    {
                        var otvet = new AnimalCardForm(int.Parse(DataGridViewActs.CurrentRow.Cells[0].Value.ToString()), "Собака");
                        otvet.ShowDialog();
                    }
                    if (IsCat)
                    {
                        var otvet = new AnimalCardForm(int.Parse(DataGridViewActs.CurrentRow.Cells[0].Value.ToString()), "Кот");
                        otvet.ShowDialog();
                    }
                }
        }

        private async void dateTimePickerAct_ValueChanged(object sender, EventArgs e)
        {
            await SetDataGridAct();
        }


        private async Task SetDataGridOrg()
        {
            /*-Organization-------------------------*/
            dsOrganization.Tables.Clear();
            dsOrganization.Tables.Add("Score");
            dsOrganization.Tables[0].Columns.Add("Номер");
            dsOrganization.Tables[0].Columns.Add("Наименование");
            dsOrganization.Tables[0].Columns.Add("ИНН");
            dsOrganization.Tables[0].Columns.Add("КПП");
            dsOrganization.Tables[0].Columns.Add("Адрес регистрации");
            dsOrganization.Tables[0].Columns.Add("Тип");
            dsOrganization.Tables[0].Columns.Add("Статус");
            var orgs = await OrgService.GetOrganizations();
            //var orgs = OrgService.ShowOrganizations();
            foreach (var org in orgs.Select(o => OrgService.ToDataArray(o)))
            {
                dsOrganization.Tables[0].Rows.Add(org);
            }
            dataGridViewOrg.DataSource = dsOrganization.Tables[0];
        }
        private async Task SetDataGridApp()
        {
            /*-Applications-------------------------*/
            dsApplication.Tables.Clear();
            dsApplication.Tables.Add("Score");
            dsApplication.Tables[0].Columns.Add("Дата подачи");
            dsApplication.Tables[0].Columns.Add("Номер");
            dsApplication.Tables[0].Columns.Add("Населенный пункт");
            dsApplication.Tables[0].Columns.Add("Территория");
            dsApplication.Tables[0].Columns.Add("Место обитания");
            dsApplication.Tables[0].Columns.Add("Срочность исполнения");
            dsApplication.Tables[0].Columns.Add("Описание животного");
            dsApplication.Tables[0].Columns.Add("Категория заявителя");
            var apps = await AppService.GetApplications();
            foreach (var app in apps.Select(a => AppService.ToDataArray(a)))
            {
                dsApplication.Tables[0].Rows.Add(app);
            }
            dataGridViewApp.DataSource = dsApplication.Tables[0];
        }

        /*------------------------------------------------------------------*/
        private async void AppDelete_Click(object sender, EventArgs e)
        {
            if (await CheckPrivilege(NameMdels.App))
                if (dataGridViewApp.CurrentRow != null)
                {
                    int app = Convert.ToInt32(dataGridViewApp.CurrentRow.Cells[1].Value.ToString());
                    await AppService.RemoveApplication(app);
                    await SetDataGridApp();
                }
        }

        private async void AppEdit_Click(object sender, EventArgs e)
        {
            if (await CheckPrivilege(NameMdels.App))
                if (dataGridViewApp.CurrentRow != null)
                {
                    var appId = int.Parse(dataGridViewApp.CurrentRow.Cells[1].Value.ToString());
                    var appEdit = new AppEdit(appId);
                    appEdit.ShowDialog();
                    await SetDataGridApp();
                }
        }

        private async void OrgDelete_Click(object sender, EventArgs e)
        {
            if (await CheckPrivilege(NameMdels.Org))
                if (dataGridViewOrg.CurrentRow != null)
                {
                    var org = int.Parse(dataGridViewOrg.CurrentRow.Cells[2].Value.ToString());
                    await OrgService.RemoveOrganization(org);
                    await SetDataGridOrg();
                }
        }

        private async void OrgEdit_Click(object sender, EventArgs e)
        {
            if (await CheckPrivilege(NameMdels.Org))
                if (dataGridViewOrg.CurrentRow != null)
                {
                    var org = int.Parse(dataGridViewOrg.CurrentRow.Cells[0].Value.ToString());
                    var orgEdit = new OrgEdit(org);
                    orgEdit.ShowDialog();
                    await SetDataGridOrg();
                }
        }

        private async void OrgAdd_Click(object sender, EventArgs e)
        {
            if (await CheckPrivilege(NameMdels.Org))
            {
                var orgAdd = new OrgAdd();
                orgAdd.ShowDialog();
                await SetDataGridOrg();
            }
        }

        private async void AppAdd_Click(object sender, EventArgs e)
        {
            if (await CheckPrivilege(NameMdels.App))
            {
                var appAdd = new AppAdd();
                appAdd.ShowDialog();
                await SetDataGridApp();
            }
        }

        private async Task ShowContract()
        {
            ContractTable.Rows.Clear();
            var cont = await ContractService.GetContracts();
            //var contract = ContractService.ShowContract(dateTimePicker3.Value.ToString(), dateTimePicker1.Value.ToString());
            foreach (var i in cont.Where(c => c.DateConclusion >= dateTimePicker3.Value
            && c.DateConclusion <= dateTimePicker1.Value).Select(c => ContractService.ToDataArray(c)))
            {
                ContractTable.Rows.Add(i);
            }
        }
        private async void AddButton_Click_1(object sender, EventArgs e)
        {
            if (await CheckPrivilege(NameMdels.Contract))
            {
                var contAdd = new AddContractForm();
                contAdd.ShowDialog();
                await ShowContract();
            }
        }

        private async void EditButton_Click(object sender, EventArgs e)
        {
            if (await CheckPrivilege(NameMdels.Contract))
                if (ContractTable.CurrentRow != null)
                {
                    var contAdd = new AddContractForm(int.Parse(ContractTable.CurrentRow.Cells[0].Value.ToString()));
                    contAdd.ShowDialog();
                    await ShowContract();
                }
        }

        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            if (await CheckPrivilege(NameMdels.Contract))
                if (ContractTable.CurrentRow != null)
                {
                    await ContractService.RemoveContract(int.Parse(ContractTable.CurrentRow.Cells[0].Value.ToString()));
                    await ShowContract();
                }
        }

        private async void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            await ShowContract();
        }

        private async void ContractTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var contAdd = new AddContractForm(int.Parse(ContractTable.CurrentRow.Cells[0].Value.ToString()));
            contAdd.ShowDialog();
            await ShowContract();
        }

        private async void filterAppDate_ValueChanged(object sender, EventArgs e)
        {
            dsApplication.Tables[0].Rows.Clear();
            var apps = (await AppService.GetApplications())
                .Where(x => x.date >= filterAppDate.Value && x.date <= filterAppDate2.Value)
                .Select(app => AppService.ToDataArray(app));
            foreach (var app in apps)
                dsApplication.Tables[0].Rows.Add(app);
            dataGridViewApp.DataSource = dsApplication.Tables[0];
        }

        private void filterAppDate2_ValueChanged(object sender, EventArgs e)
        {
            filterAppDate_ValueChanged(sender, e);
        }

        private async void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            await ShowContract();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenReport();
        }

        private static async void OpenReport()
        {
            if (await CheckPrivilege(NameMdels.Report))
            {
                var rep = new ReportForm();
                rep.ShowDialog();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage2)
            {
                tabControl1.SelectedTab = tabPage1;
                OpenReport();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private async void History_button_Click(object sender, EventArgs e)
        {
            if (await CheckPrivilege(NameMdels.History))
            {
                // var data = await OperationService.GetOperations();
                // var historyForm = new HistoryForm(data);

                // это переписать так, чтобы можно было заменить кодом сверху
                var data = new List<string>() { "Фамилия", "Имя", "Отчество.", "Телефон",
                                    "Электронная почта", "Организация", "Наименование структурного подразделения",
                                    "Должность", "Рабочий телефон", "Рабочий адрес электронной почты подразделения",
                                    "Логин", "Дата и время", "Идентификационный номер экземпляра объекта.", "Описание экземпляра объекта после совершения действия",
                                    "Идентификационный номер загруженного файла"};
                var historyForm = new HistoryForm(data);

                historyForm.ShowDialog();
            }
            else MessageBox.Show("У вас недостаточно прав, чтобы просматривать историю операций");
        }

        private void closeMainForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
