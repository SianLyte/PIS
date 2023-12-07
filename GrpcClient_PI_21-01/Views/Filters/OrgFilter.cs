using System.Linq;
using GrpcClient_PI_21_01.Controllers;
using GrpcClient_PI_21_01.Models;

namespace GrpcClient_PI_21_01.Views.Filters
{
    public partial class OrgFilter : Form
    {
        public OrgFilter(Filter<Organization> filter, Func<Task> reloadGridCallback)
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

        public Filter<Organization> Filter { get; }
        public Func<Task> Apply { get; }

        public async void InitBoxes()
        {
            const string unselected_combo_box_default_value = "< не выбрано >";

            // registartion address box
            var localities = await LocationService.GetLocations();
            regComboBox.Items.Clear();
            regComboBox.Items.Add(unselected_combo_box_default_value);
            regComboBox.Items.AddRange(localities.ToArray());
            regComboBox.DisplayMember = "City";
            regComboBox.SelectedIndexChanged += (s, e) => ApplyFilter();

            // organization type box
            var types = Enum.GetValues<OrganizationType>();
            typeComboBox.Format += (s, e) =>
            {
                if (Enum.TryParse<OrganizationType>(e.ListItem?.ToString(), out var ot))
                    e.Value = ot.Translate();
            };
            typeComboBox.Items.Clear();
            typeComboBox.Items.Add(unselected_combo_box_default_value);
            typeComboBox.Items.AddRange(types.Select(t => t.ToString()).ToArray());
            typeComboBox.SelectedIndexChanged += (s, e) => ApplyFilter();

            // status box
            statusAll.CheckedChanged += (s, e) => ApplyFilter();
            statusIndividual.CheckedChanged += (s, e) => ApplyFilter();
            statusJuridical.CheckedChanged += (s, e) => ApplyFilter();

            Reset(this, EventArgs.Empty);
        }

        public void ApplyFilter()
        {
            Filter.Clear();

            Apply();
        }

        private void Reset(object sender, EventArgs e)
        {
            regComboBox.SelectedIndex = 0;
            typeComboBox.SelectedIndex = 0;
            statusAll.Checked = true;

            ApplyFilter();
        }
    }
}
