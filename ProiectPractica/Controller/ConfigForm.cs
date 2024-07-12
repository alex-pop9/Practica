using ProiectPractica.Model;

namespace ProiectPractica
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Still in progress
        /// </summary>
        public void SetRepository()
        {
            // aici ar trebui sa initializez repo-ul si sa i-au obiectul Configurare
            // pentru testare am folosit am initializat un obiect Configurare
            var testConfig = new Configurare
            {
                MinAcceptablePrice = 60,
                MinPricePerKm = 1.7F,
                NumberOfCars = 2,
                ReservationCheckInterval = 2,
                PhoneNumber = "+40747633357",
                MinPriceForShortTrips = 50,
                ShortTripDistanceThreshold = 15,
                StartBusinessHour = 9,
                EndBusinessHour = 19
            };

            SetValuesInTextBoxes(testConfig);
            MakeButtonsUnavailable();
        }

        /// <summary>
        /// Auxiliary function that prevents duplicate code.
        /// Instead of putting values in text boxes like this: textBoxName.Text = value; nine times,
        /// I iterated through all the properties of configurare and found the textbox with the property name in which,
        /// it will put the value associated.
        /// </summary>
        /// <param name="configurare"></param>
        private void SetValuesInTextBoxes(Configurare configurare)
        {
            foreach (var attr in configurare.GetType().GetProperties())
            {
                var textBox = this.Controls.Find("text" + attr.Name, true).FirstOrDefault() as TextBox;
                if (textBox != null)
                {
                    textBox.Text = attr.GetValue(configurare)?.ToString();
                }
            }
        }

        private void MakeButtonsUnavailable()
        {
            buttonReset.Enabled = false;
            buttonSave.Enabled = false;
        }

        /// <summary>
        /// This function handles all text boxes .TextChanged event so that I don't have 9 identical functions.
        /// I got the idea from here: https://stackoverflow.com/a/12460227
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnableButtonsWhenTextChanged(object sender, EventArgs e)
        {
            buttonReset.Enabled = true;
            buttonSave.Enabled = true;
        }
    }
}

