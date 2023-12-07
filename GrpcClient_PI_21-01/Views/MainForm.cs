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
using System.Xml.Linq;

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

            contractFiltersButton.Click += OpenContractFilters;
            applicationFiltersButton.Click += OpenApplicationFilters;
            organizationFiltersButton.Click += OpenOrganizationFilters;

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
            await InicilisationHistory();
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

        private int _ActPage = 1;
        private int _ActPageMax = 1;
        private readonly SemaphoreSlim actGridSemaphore = new(1, 1);
        private async Task SetDataGridAct()
        {
            await actGridSemaphore.WaitAsync();
            try
            {
                CheckPageButton(buttonPriviosPageAct, buttonNextPageAct, _ActPage, _ActPageMax);
                DataGridViewActs.Rows.Clear();
                var acts = await ActService.GetActs(_ActPage, actFilter);
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

        private void buttonNextPage_Click(object sender, EventArgs e)
        {
            _ActPage++;
            CheckPageButton(buttonPriviosPageAct, buttonNextPageAct, _ActPage, _ActPageMax);
        }
        private void buttonPriviosPage_Click(object sender, EventArgs e)
        {
            _ActPage--;
            CheckPageButton(buttonPriviosPageAct, buttonNextPageAct, _ActPage, _ActPageMax);
        }

        private void OpenActFilters(object sender, EventArgs e) =>
            new ActFilter(actFilter, SetDataGridAct).Show();
        #endregion
        #region Related: Organizations
        private readonly SemaphoreSlim orgGridSemaphore = new(1, 1);
        private async Task SetDataGridOrg()
        {
            await orgGridSemaphore.WaitAsync();
            try
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
            finally { orgGridSemaphore.Release(); }
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
                    var orgId = int.Parse(dataGridViewOrg.CurrentRow.Cells[0].Value.ToString());
                    var org = await OrgService.GetOrganization(orgId);
                    var orgEdit = new OrgAdd(org);
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
            => new OrgFilter(orgFilter, SetDataGridOrg).Show();
        #endregion
        #region Related: Applications
        private readonly SemaphoreSlim appGridSemaphore = new(1, 1);
        private async Task SetDataGridApp()
        {
            await appGridSemaphore.WaitAsync();
            try
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
            finally { appGridSemaphore.Release(); }
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
                    var app = await AppService.GetApplication(appId);
                    var appEdit = new AppEdit(app);
                    appEdit.ShowDialog();
                    await SetDataGridApp();
                }
        }

        private async void AppAdd_Click(object sender, EventArgs e)
        {
            if (await CheckPrivilege(NameMdels.App))
            {
                var appAdd = new AppEdit();
                appAdd.ShowDialog();
                await SetDataGridApp();
            }
        }

        private void OpenApplicationFilters(object sender, EventArgs e) =>
            new AppFilter(appFilter, SetDataGridApp).Show();
        #endregion
        #region Related: Contracts
        private int _PageContract = 1;
        private int _PageContractMax = 1;
        private readonly SemaphoreSlim contrGridSemaphore = new(1, 1);
        private async Task ShowContract()
        {
            await contrGridSemaphore.WaitAsync();
            try
            {
                CheckPageButton(buttonPreviousContracts, buttonNextContracts, _PageContract, _PageContractMax);

                ContractTable.Rows.Clear();
                var cont = await ContractService.GetContracts(_PageContract, contrFilter);
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
        
        private void buttonPreviousContracts_Click(object sender, EventArgs e)
        {
            _PageContract--;
            CheckPageButton(buttonPreviousContracts, buttonNextContracts, _PageContract, _PageContractMax);
        }

        private void buttonNextContracts_Click(object sender, EventArgs e)
        {
            _PageContract++;
            CheckPageButton(buttonPreviousContracts, buttonNextContracts, _PageContract, _PageContractMax);
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
        private List<OperationReply>? _data;
        readonly DataSet _dbHistory = new();

        public async Task InicilisationHistory()
        {
            if (await CheckPrivilege(NameMdels.History))
            {
                _data = await OperationService.GetOperations();
                CreateDataSet();
                ParceDataToDataGrid();
            }
            else MessageBox.Show("У вас недостаточно прав, чтобы просматривать историю операций", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            dataGridViewHistory.DataSource = _dbHistory.Tables[0];
        }
        #endregion

        private static void CheckPageButton(Button buttonPrevious, Button buttonNext, int page, int pageMax)
        {
            buttonPrevious.Enabled = true;
            buttonNext.Enabled = true;
            if (page == 1)
            {
                buttonPrevious.Enabled = false;
            }
            if (page == pageMax)
            {
                buttonNext.Enabled = false;
            }
        }
    }
}
