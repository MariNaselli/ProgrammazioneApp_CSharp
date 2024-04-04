using OPPClassLibrary.Fiscal;
using System.Windows.Forms.VisualStyles;

namespace FiscalWinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtFirstName.Text = "Mariana";
            txtLastName.Text = "Naselli";
            txtPlaceOfBirth.Text = "Argentina";
            comboBoxMaritalStatus.SelectedIndex = 0;
            dateTimePickerDateOfBirth.Value = new DateTime(1989, 1, 8);
            comboBox1Opciones.SelectedIndex = 2;
            radioButtonFemale.Checked = true;
        }

        private void btnCreateCodice_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            DateOnly dateOfBirth = DateOnly.FromDateTime(dateTimePickerDateOfBirth.Value);
            string placeOfBirth = txtPlaceOfBirth.Text;
            Gender gender = Gender.Male;
            if (radioButtonFemale.Checked)
            {
                gender = Gender.Female;
            }
            MaritalStatus maritalStatus = MaritalStatus.Married;
            switch (comboBoxMaritalStatus.SelectedItem)
            {
                case "Married":
                    maritalStatus = MaritalStatus.Married;
                    break;
                case "Unmarried":
                    maritalStatus = MaritalStatus.Unmarried;
                    break;
                case "Divorced":
                    maritalStatus = MaritalStatus.Divorced;
                    break;
            }


            Person person = new Person(firstName, lastName, dateOfBirth, placeOfBirth,
                gender, maritalStatus);


            switch (comboBox1Opciones.SelectedItem)
            {
                case "Saludar":
                    MessageBox.Show(person.Saludar());
                    break;
                case "Saludar Formalmente":
                    MessageBox.Show(person.SaludarFormalmente());
                    break;
                case "Create Fiscal Code":
                    string codiceFiscal = FiscalCodeBuilder.BuildFiscalCode(person);
                    MessageBox.Show(codiceFiscal);
                    break;
            }

        }

        private void radioButtonFemale_Click(object sender, EventArgs e)
        {
            if (radioButtonMale.Checked)
            {
                radioButtonMale.Checked = false;
            }
        }

        private void radioButtonMale_Click(object sender, EventArgs e)
        {
            if (radioButtonFemale.Checked)
            {
                radioButtonFemale.Checked = false;
            }
        }

        private void comboBox1Opciones_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
