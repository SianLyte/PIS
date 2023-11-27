using GrpcClient_PI_21_01.Controllers;
using GrpcClient_PI_21_01.Models;
//using GrpcClient_PI_21_01.Data;

namespace GrpcClient_PI_21_01.Views
{
    public partial class AnimalCardForm : Form
    {
        private readonly int actId;
        public AnimalCard? returnAnime;
        private readonly bool animalToEdit;
        public AnimalCardForm(string act)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            GITLER.Text = act;
            actId = -1;
            animalToEdit = true;
            InicilisateAll();
        }
        public AnimalCardForm(int actIdi, string act)
        {
            InitializeComponent();
            GITLER.Text = act;
            actId = actIdi;
            animalToEdit = false;
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
            else
            {
                var locs = await LocationService.GetLocations();
                //var index = AnimalRepository.animalCards.FindIndex(x => x.ActCapture.ActNumber == actId & x.Category == GITLER.Text);
                //var animalCard = AnimalRepository.animalCards[index];
                var animalCards = await AnimalCardService.GetAnimalCards();
                var animalCard = animalCards
                    .FirstOrDefault(ac => ac.ActCapture.ActNumber == actId && ac.Category.ToLower() == GITLER.Text.ToLower());
                if (animalCard is null)
                {
                    MessageBox.Show("The form could not load:\n" +
                        "no act captures were found with id=" + actId + " or/and " +
                        "no act captures were found with category=" + GITLER.Text,
                        "Internal error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    return;
                }
                textBoxKategori.Text = animalCard.Category;
                textBoxGender.Text = animalCard.Gender;
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
            textBoxGender.Enabled = false;
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
                if (ChekOtvet())
                {
                    //var otp = new string[] { textBoxKategori.Text, textBoxGender.Text,
                    //                        textBoxPoroda.Text, numericUpDownSize.Value.ToString(),
                    //                        textBoxFurType.Text, textBoxColor.Text, textBoxEars.Text,
                    //                        textBoxTail.Text, textBoxSpicialSigns.Text, textBoxIdentificationLabel.Text,
                    //                        comboBoxLocation.SelectedValue.ToString(), actId.ToString(),null};
                    var animalCard = new AnimalCard(-1, textBoxKategori.Text, textBoxGender.Text,
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

        private bool ChekOtvet()
        {
            if (textBoxPoroda.Text == "")
            {
                MessageBox.Show("Вы не ввели породу ", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
