using GrpcClient_PI_21_01.Controllers;
using GrpcClient_PI_21_01.Models;

namespace GrpcClient_PI_21_01.Views
{
    public partial class AnimalCardForm : Form
    {
        private readonly int actId;
        public AnimalCard? returnAnime;
        private readonly bool animalToEdit;
        private AnimalCard? AnimalCardShowcase { get; }
        public AnimalCardForm(string act)
        {
            InitializeComponent();
            GITLER.Text = act;
            actId = -1;
            animalToEdit = true;
            InicilisateAll();
        }
        public AnimalCardForm(AnimalCard animalCard)
        {
            InitializeComponent();
            GITLER.Text = animalCard.ActCapture.ActNumber.ToString();
            actId = animalCard.ActCapture.ActNumber;
            animalToEdit = false;
            AnimalCardShowcase = animalCard;
            InicilisateAll();
        }

        private async void InicilisateAll()
        {
            if (animalToEdit)
            {
                var locs = await LocationService.GetLocations();
                textBoxKategori.Text = GITLER.Text;
                God.Text = "Акт:" + actId;
                comboBoxLocation.DataSource = new BindingSource(locs, null);
                comboBoxLocation.DisplayMember = "City";
                comboBoxLocation.ValueMember = "IdLocation";
            }
            else if (AnimalCardShowcase != null)
            {
                var animalCard = AnimalCardShowcase;
                var locs = await LocationService.GetLocations();
                textBoxKategori.Text = animalCard.Category;
                if (animalCard.Gender == "Ж") female.Checked = true;
                textBoxPoroda.Text = animalCard.Breed;
                numericUpDownSize.Value = animalCard.Size;
                textBoxFurType.Text = animalCard.FurType;
                textBoxColor.Text = animalCard.Color;
                textBoxEars.Text = animalCard.Ears;
                textBoxTail.Text = animalCard.Tail;
                textBoxSpicialSigns.Text = animalCard.SpicialSigns;
                textBoxIdentificationLabel.Text = animalCard.IdentificationLabel;
                God.Text = "Акт:" + actId;
                comboBoxLocation.DataSource = new BindingSource(locs, null);
                comboBoxLocation.DisplayMember = "City";
                comboBoxLocation.ValueMember = "IdLocation";
                KillEdit();
            }
        }

        private void KillEdit()
        {
            textBoxKategori.Enabled = false;
            male.Enabled = false;
            female.Enabled = false;
            numericUpDownSize.Enabled = false;
            textBoxKategori.Enabled = false;
            textBoxPoroda.Enabled = false;
            textBoxFurType.Enabled = false;
            textBoxColor.Enabled = false;
            textBoxEars.Enabled = false;
            textBoxTail.Enabled = false;
            textBoxSpicialSigns.Enabled = false;
            textBoxIdentificationLabel.Enabled = false;
            comboBoxLocation.Enabled = false;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (animalToEdit)
            {
                if (AreFieldsValid())
                {
                    var animalCard = new AnimalCard(-1, textBoxKategori.Text, male.Checked ? "М" : "Ж",
                        textBoxPoroda.Text, (int)numericUpDownSize.Value, textBoxFurType.Text,
                        textBoxColor.Text, textBoxEars.Text, textBoxTail.Text,
                        textBoxSpicialSigns.Text, textBoxIdentificationLabel.Text,
                        comboBoxLocation.SelectedItem as Location,
                        Act.Empty, null);
                    returnAnime = animalCard;
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private bool AreFieldsValid()
        {
            static void printError(string errorMessage) { MessageBox.Show(errorMessage, "Ошибка", 0, MessageBoxIcon.Error); }

            if (textBoxPoroda.Text == "")
                printError("Вы не заполнили поле \"Порода\".");
            else if (numericUpDownSize.Value <= 0)
                printError("Размер животного не может быть меньше или равен нулю.");
            else if (textBoxFurType.Text.Length <= 0)
                printError("Вы не заполнили поле \"Шерсть\".");
            else if (textBoxColor.Text.Length <= 0)
                printError("Вы не заполнили поле \"Окрас\".");
            else if (textBoxEars.Text.Length <= 0)
                printError("Вы не заполнили поле \"Уши\".");
            else if (!int.TryParse(textBoxIdentificationLabel.Text, out int _))
                printError("Идентификационная метка животного должна быть целым числом.");
            else if (comboBoxLocation.SelectedItem is not Models.Location)
                printError("Вы не выбрали населённый пункт, в котором был произведён отлов.");
            else return true;

            return false;
        }
    }
}
