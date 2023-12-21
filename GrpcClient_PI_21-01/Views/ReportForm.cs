using GrpcClient_PI_21_01.Controllers;
using GrpcClient_PI_21_01.Models;
using System.Linq;

namespace GrpcClient_PI_21_01.Views
{
    public partial class ReportForm : Form
    {
        Report? editableReport;
        readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
        ReportDataClass reportData;

        public ReportForm(ReportDataClass reportData)
        {
            this.reportData = reportData;
            InitializeComponent();
            InitNew();
        }

        public ReportForm(Report editableReport, ReportDataClass reportData)
        {
            this.reportData = reportData;
            InitializeComponent();
            this.editableReport = editableReport;
            InitWatch();
        }

        public void InitBase()
        {
            saveButton.Click += SaveReport;
            closeButton.Click += (s, e) => Close();
        }

        public void InitNew()
        {
            InitBase();
            var user = UserService.CurrentUser;
            actorName.Text = string.Join(" ", user?.Surname, user?.Name, user?.Patronymic);
            reportStatus.Text = ReportStatus.Draft.Translate();

            dateTimePickerStart.ValueChanged += dateTimePickerStart_ValueChanged;
            dateTimePickerEnd.ValueChanged += dateTimePickerStart_ValueChanged;

            reportStatuses.Items.Clear();

            List<StatusTranslate<ReportStatus>> statusComboboxList = new();
            statusComboboxList = statusComboboxList.Concat(reportData.availableStatuses
                .Select(status => new StatusTranslate<ReportStatus>(Enum.Parse<ReportStatus>(status), Enum.Parse<ReportStatus>(status).Translate()))).ToList();

            reportStatuses.DataSource = new BindingSource(statusComboboxList, null);
            reportStatuses.DropDownStyle = ComboBoxStyle.DropDownList;
            reportStatuses.DisplayMember = "StatusTranslate";
            reportStatuses.ValueMember = "Status";
        }

        public async void InitWatch()
        {
            InitBase();
            if (editableReport == null)
                throw new Exception("Editable report was null");

            if (!reportData.availableStatuses.Contains(ReportStatus.ApprovalFromMunicipalContractExecutor.ToString()))
            {
                dateTimePickerEnd.Enabled = false;
                dateTimePickerStart.Enabled = false;
            }


            var user = UserService.CurrentUser;
            if (user is null) throw new Exception("User is null");

            //saveButton.Enabled = false;
            reportStatuses.Items.Clear();

            List<StatusTranslate<ReportStatus>> statusComboboxList = new();
            statusComboboxList = statusComboboxList.Concat(reportData.availableStatuses
                .Select(status => new StatusTranslate<ReportStatus>(Enum.Parse<ReportStatus>(status), Enum.Parse<ReportStatus>(status).Translate()))).ToList();
            if (reportData.availableStatuses.Count == 0)
            {
                reportStatuses.Enabled = false;
                reportStatuses.Text = editableReport.Status.Translate();
                saveButton.Enabled = false;
            }
            else
            {
                reportStatuses.DataSource = new BindingSource(statusComboboxList, null);
                reportStatuses.DropDownStyle = ComboBoxStyle.DropDownList;
                reportStatuses.DisplayMember = "StatusTranslate";
                reportStatuses.ValueMember = "Status";
                reportStatuses.Text = editableReport.Status.Translate();
            }

            actorName.Text = String.Join(" ", editableReport.User.Surname, editableReport.User.Name, editableReport.User.Patronymic);
            textBoxSum.Text = editableReport.Profit + " ₽";
            dateTimePickerEnd.Value = editableReport.EndDate;
            dateTimePickerStart.Value = editableReport.StartDate;
            closedAppsCount.Value = editableReport.ClosedAppsCount;
            animalCount.Value = editableReport.AnimalsCount;
            createdAt.Text = editableReport.CreatedAt.ToString("dd/MM/yyyy");
            updatedAt.Text = editableReport.UpdatedAt.ToString("dd/MM/yyyy");
            reportStatus.Text = editableReport.Status.Translate();
        }

        public async Task GenereteReport()
        {
            var report = await ReportService.GenereteReport(dateTimePickerStart.Value, dateTimePickerEnd.Value);
            report.Id = -1;
            textBoxSum.Text = report.Profit + " ₽";
            closedAppsCount.Value = report.ClosedAppsCount;
            animalCount.Value = report.AnimalsCount;
            updatedAt.Text = report.UpdatedAt.ToString("dd/MM/yyyy");
            createdAt.Text = report.CreatedAt.ToString("dd/MM/yyyy");
            reportStatus.Text = report.Status.Translate();

            editableReport = report;
        }

        public async void SaveReport(object sender, EventArgs e)
        {
            await semaphore.WaitAsync();
            try
            {
                if (editableReport?.Id == -1)
                {
                    editableReport.Status = Enum.Parse<ReportStatus>(reportStatuses.SelectedValue.ToString());
                    var successful = await ReportService.AddReport(editableReport);
                    if (successful)
                    {
                        Text = "Отчёт [ID: " + editableReport.Id + "]";
                        reportStatus.Text = editableReport.Status.Translate();
                    }
                    else MessageBox.Show("Internal error has occured. Please contract the administrator.",
                        "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //var status = GetNewReportStatus(editableReport);
                    editableReport.Status = Enum.Parse<ReportStatus>(reportStatuses.SelectedValue.ToString());
                    var successful = await ReportService.UpdateReport(editableReport);
                    if (successful)
                    {
                        Close();
                    }
                    else MessageBox.Show("Internal error has occured. Please contract the administrator.",
                        "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                semaphore.Release();
            }
        }

        private async void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            await semaphore.WaitAsync();
            try
            {
                await GenereteReport();
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
    public class StatusTranslate<T>
    {
        public T Status { get; set; }
        public string Translate { get; set; }

        public StatusTranslate(T status, string Translate)
        {
            Status = status;
            this.Translate = Translate;
        }
    }
}
