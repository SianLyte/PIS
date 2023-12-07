using GrpcClient_PI_21_01.Controllers;
using GrpcClient_PI_21_01.Models;

namespace GrpcClient_PI_21_01.Views.Filters
{
    public partial class AppFilter : Form
    {
        public AppFilter(Filter<App> filter, Func<Task> reloadGridCallback)
        {
            InitializeComponent();
            Filter = filter;
            apply.Click += async (s, e) => await reloadGridCallback();
            reset.Click += Reset;
            close.Click += (s, e) => Close();
            Apply = reloadGridCallback;
            Location = new Point(Location.X, -55);

            InitBoxes();
        }

        public Filter<App> Filter { get; }
        public Func<Task> Apply { get; }

        public async void InitBoxes()
        {
            const string unselected_combo_box_default_value = "< не выбрано >";

            // date box
            fromDate.ValueChanged += (s, e) => ApplyFilter();
            toDate.ValueChanged += (s, e) => ApplyFilter();

            // locality box
            var localities = await LocationService.GetLocations();
            localityComboBox.Items.Clear();
            localityComboBox.Items.Add(unselected_combo_box_default_value);
            localityComboBox.Items.AddRange(localities.ToArray());
            localityComboBox.DisplayMember = "City";
            localityComboBox.SelectedIndexChanged += (s, e) => ApplyFilter();

            // applicant category box
            var applicantTypes = AppService.GetApplicantTypes();
            applicantComboBox.Items.Clear();
            applicantComboBox.Items.Add(unselected_combo_box_default_value);
            applicantComboBox.Items.AddRange(applicantTypes);
            applicantComboBox.SelectedIndexChanged += (s, e) => ApplyFilter();

            // status box
            var statuses = Enum.GetValues<AppStatus>();
            statusComboBox.Format += (s, e) =>
            {
                if (Enum.TryParse<AppStatus>(e.ListItem?.ToString(), out var status))
                    e.Value = status.Translate();
            };
            statusComboBox.Items.Clear();
            statusComboBox.Items.Add(unselected_combo_box_default_value);
            statusComboBox.Items.AddRange(statuses.Select(s => s.ToString()).ToArray());
            statusComboBox.SelectedIndexChanged += (s, e) => ApplyFilter();

            Reset(this, EventArgs.Empty);
        }

        public void ApplyFilter()
        {
            Filter.Clear();

            if (localityComboBox.SelectedItem is Location locality)
                Filter.AddFilter(app => app.locality, locality.IdLocation.ToString());

            if (applicantComboBox.SelectedIndex > 0)
                Filter.AddFilter(app => app.applicantCategory, applicantComboBox.SelectedItem.ToString());

            if (statusComboBox.SelectedIndex > 0)
                Filter.AddFilter(app => app.status, statusComboBox.SelectedItem.ToString());

            Filter.AddFilter(app => app.date, fromDate.Value.ToString(), FilterType.GreaterThan);
            Filter.AddFilter(app => app.date, toDate.Value.ToString(), FilterType.LesserThan);

            Apply();
        }

        private void Reset(object sender, EventArgs e)
        {
            fromDate.Value = new DateTime(2020, 1, 1);
            toDate.Value = DateTime.Now;
            localityComboBox.SelectedIndex = 0;
            applicantComboBox.SelectedIndex = 0;
            statusComboBox.SelectedIndex = 0;

            ApplyFilter();
        }
    }
}
