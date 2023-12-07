using GrpcClient_PI_21_01.Controllers;
//using GrpcClient_PI_21_01.Data;
using GrpcClient_PI_21_01.Models;
using GrpcClient_PI_21_01.Views;
using GrpcClient_PI_21_01.Views.Filters;
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

            // Только сейчас заметил, что это?!
            // где?
            dateTimePickerAct.ValueChanged += dateTimePickerAct_ValueChanged;

            OrgAdd.Click += OrgAdd_Click;
            OrgEdit.Click += OrgEdit_Click;
            OrgDelete.Click += OrgDelete_Click;

            AppAdd.Click += AppAdd_Click;
            AppEdit.Click += AppEdit_Click;
            AppDelete.Click += AppDelete_Click;

            AddActButton.Click += AddButton_Click;
            UpdateActButton.Click += UpdateButton_Click;
            DeleteActButton.Click += DeleteActButton_Click;
            buttonAnimalCard.Click += buttonAnimalCard_Click;

            AddButton.Click += AddButton_Click_1;
            EditButton.Click += EditButton_Click;
            DeleteButton.Click += DeleteButton_Click;
            ContractTable.CellMouseDoubleClick += ContractTable_CellMouseDoubleClick;

            button1.Click += button1_Click;

            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;

            historyButton.Click += History_button_Click;
            //History_button.Click += History_button_Click;

            contractFiltersButton.Click += OpenContractFilters;

            Task.Run(Setup);
        }
        readonly DataSet dsApplication = new();
        readonly DataSet dsOrganization = new();
        readonly Filter<Act> actFilter = new();
        readonly Filter<App> appFilter = new();
        readonly Filter<Organization> orgFilter = new();
        readonly Filter<Contract> contrFilter = new();

        private async Task Setup()
        {
            await SetDataGridAct();
            await ShowContract();

            await SetDataGridApp();
            await SetDataGridOrg();
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

        #region Related: Act Capture
        /* -----------------------------------ACT----------------------------------------------------- */

        private readonly SemaphoreSlim actGridSemaphore = new(1, 1);
        private async Task SetDataGridAct()
        {
            await actGridSemaphore.WaitAsync();
            try
            {
                int page = -1; // to do: сделать пагинацию

                DataGridViewActs.Rows.Clear();
                var acts = await ActService.GetActs(page, actFilter);
                foreach (var act in acts.Select(a => ActService.ToDataArray(a)))
                    DataGridViewActs.Rows.Add(act);
            }
            finally
            {
                actGridSemaphore.Release();
            }
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

        private void OpenActFilters(object sender, EventArgs e) =>
            new ActFilter(actFilter, SetDataGridAct).Show();
        #endregion
        #region Related: Organizations
        private async Task SetDataGridOrg()
        {
            int page = -1; // сделать пагинацию

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
            var orgs = await OrgService.GetOrganizations(page, orgFilter);
            foreach (var org in orgs.Select(o => OrgService.ToDataArray(o)))
            {
                dsOrganization.Tables[0].Rows.Add(org);
            }
            dataGridViewOrg.DataSource = dsOrganization.Tables[0];
        }

        private async void OrgDelete_Click(object sender, EventArgs e)
        {
            if (await CheckPrivilege(NameMdels.Org))
                if (dataGridViewOrg.CurrentRow != null)
                {
                    var org = int.Parse(dataGridViewOrg.CurrentRow.Cells[0].Value.ToString());
                    var a = await OrgService.RemoveOrganization(org);
                    if (!a)
                    {
                        MessageBox.Show("Произошла ошибка");
                    }
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

        private void OpenOrganizationFilters(object sender, EventArgs e)
        {

        }
        #endregion
        #region Related: Applications
        private async Task SetDataGridApp()
        {
            int page = -1; // to do: сделать пагинацию

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
            var apps = await AppService.GetApplications(page, appFilter);
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

        private async void AppAdd_Click(object sender, EventArgs e)
        {
            if (await CheckPrivilege(NameMdels.App))
            {
                var appAdd = new AppAdd();
                appAdd.ShowDialog();
                await SetDataGridApp();
            }
        }

        private void OpenApplicationFilters(object sender, EventArgs e)
        {

        }
        #endregion
        #region Related: Contracts
        private readonly SemaphoreSlim contrGridSemaphore = new(1, 1);
        private async Task ShowContract()
        {
            await contrGridSemaphore.WaitAsync();
            try
            {
                int page = -1; // to do: сделать пагинацию

                ContractTable.Rows.Clear();
                var cont = await ContractService.GetContracts(page, contrFilter);
                foreach (var i in cont.Select(c => ContractService.ToDataArray(c)))
                    ContractTable.Rows.Add(i);
            }
            finally
            {
                contrGridSemaphore.Release();
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

        private async void ContractTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var contAdd = new AddContractForm(int.Parse(ContractTable.CurrentRow.Cells[0].Value.ToString()));
            contAdd.ShowDialog();
            await ShowContract();
        }
        private void OpenContractFilters(object sender, EventArgs e) =>
            new ContractFilter(contrFilter, ShowContract).Show();
        #endregion
        #region Related: Reports
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
        #endregion
        #region Related: Operation History
        private async void History_button_Click(object sender, EventArgs e)
        {
            if (await CheckPrivilege(NameMdels.History))
            {
                var data = await OperationService.GetOperations();
                var historyForm = new HistoryForm(data);

                historyForm.ShowDialog();
            }
            else MessageBox.Show("У вас недостаточно прав, чтобы просматривать историю операций");
        }
        #endregion
    }
}
