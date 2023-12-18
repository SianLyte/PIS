using GrpcClient_PI_21_01.Controllers;
using GrpcClient_PI_21_01.Models;

namespace GrpcClient_PI_21_01.Views
{
    public partial class ReportForm : Form
    {
        Report? editableReport;
        readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);

        public ReportForm()
        {
            InitializeComponent();

            InitNew();
        }

        public ReportForm(Report editableReport)
        {
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
        }

        public void InitWatch()
        {
            InitBase();
            if (editableReport == null)
                throw new Exception("Editable report was null");

            if (!CanEditReport(editableReport))
            {
                dateTimePickerEnd.Enabled = false;
                dateTimePickerStart.Enabled = false;
            }

            var user = UserService.CurrentUser;
            if (user is null) throw new Exception("User is null");

            saveButton.Enabled = false;
            if (user.PrivelegeLevel == "Operator_Po_Otlovy")
            {
                saveButton.Text = "Сохранить";
                saveButton.Enabled = editableReport.Status == ReportStatus.Draft
                    || editableReport.Status == ReportStatus.Revision
                    || editableReport.Status == ReportStatus.ApprovalFromMunicipalContractExecutor;
            }
            else if (user.PrivelegeLevel == "Curator_Po_Otlovy")
            {
                saveButton.Text = "Согласовать";
                saveButton.Enabled = editableReport.Status == ReportStatus.ApprovalFromMunicipalContractExecutor;
            }
            else if (user.PrivelegeLevel == "Podpisant_Po_Otlovy")
            {
                saveButton.Text = "Утвердить";
                saveButton.Enabled = editableReport.Status == ReportStatus.ApprovedByMunicipalContractExecutor;
            }
            else if (user.PrivelegeLevel == "Curator_OMSY")
            {
                saveButton.Text = "Согласовать в ОМСУ";
                saveButton.Enabled = editableReport.Status == ReportStatus.AgreedWithMunicipalContractExecutor;
            }
            else if (user.PrivelegeLevel == "Admin")
            {
                saveButton.Text = "Кнопка админа";
                saveButton.Enabled = editableReport.Status != ReportStatus.ApprovedByOmsy;
            }
            else
            {
                MessageBox.Show("You are not allowed to edit this report.",
                    "Caution", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        static bool CanEditReport(Report report)
        {
            var user = UserService.CurrentUser;
            if (user is null) throw new Exception("User is null");

            if (report.Status == ReportStatus.Revision ||
                report.Status == ReportStatus.Draft ||
                report.Status == ReportStatus.ApprovalFromMunicipalContractExecutor)
            {
                return user.PrivelegeLevel == "Operator_Po_Otlovy";
            }
            return false;
        }

        public async void GenereteReport()
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
                    editableReport.Status = ReportStatus.ApprovalFromMunicipalContractExecutor;
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
                    var status = GetNewReportStatus(editableReport);
                    editableReport.Status = status;
                    var successful = await ReportService.UpdateReport(editableReport);
                    if (successful)
                        InitWatch();
                    else MessageBox.Show("Internal error has occured. Please contract the administrator.",
                        "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                semaphore.Release();
            }
        }

        static ReportStatus GetNewReportStatus(Report report)
        {
            var user = UserService.CurrentUser;
            if (user is null)
                throw new Exception("User is null");

            if (report.Status == ReportStatus.ApprovalFromMunicipalContractExecutor
                && user.PrivelegeLevel == "Curator_Po_Otlovy")
                return ReportStatus.ApprovedByMunicipalContractExecutor;

            if (report.Status == ReportStatus.ApprovedByMunicipalContractExecutor
                && user.PrivelegeLevel == "Podpisant_Po_Otlovy")
                return ReportStatus.AgreedWithMunicipalContractExecutor;

            if (report.Status == ReportStatus.AgreedWithMunicipalContractExecutor
                && user.PrivelegeLevel == "Curator_OMSY")
                return ReportStatus.ApprovedByOmsy;

            if (report.Status == ReportStatus.Draft || report.Status == ReportStatus.Revision
                || report.Status == ReportStatus.ApprovalFromMunicipalContractExecutor)
            {
                if (user.PrivelegeLevel == "Operator_Po_Otlovy")
                    return ReportStatus.ApprovalFromMunicipalContractExecutor;
            }

            throw new Exception($"User with role {user.PrivelegeLevel} cannot change report status");
        }

        private void dateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            GenereteReport();
        }
    }
}
