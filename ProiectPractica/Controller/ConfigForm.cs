using ProiectPractica.Model;
using ProiectPractica.Repository;

namespace ProiectPractica
{
    public partial class ConfigForm : Form
    {
        private RepositoryConfigurare? _repository;
        public ConfigForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This function sets the repository, takes the configurare from the file, and puts the object values into text boxes.
        /// If there is an error it shows a Message box and unables all text boxes.
        /// </summary>
        /// <param name="repositoryConfigurare">Injected repository</param>
        public void SetRepository(RepositoryConfigurare repositoryConfigurare)
        {
            try
            {
                _repository = repositoryConfigurare;
                var configurareFromRepo = _repository.GetConfigurareFromFile();
                if (configurareFromRepo != null)
                {
                    SetValuesInTextBoxes(configurareFromRepo);
                }
                else
                {
                    throw new Exception("Configuration is null");
                }
                MakeButtonsUnavailable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MakeTextBoxesUnavailable();
            }
        }

        /// <summary>
        /// Puts the values from configurare object into the text boxes.
        /// </summary>
        /// <param name="configurare"></param>
        private void SetValuesInTextBoxes(Configurare configurare)
        {
            textMinAcceptablePrice.Text = configurare.MinAcceptablePrice.ToString();
            textMinPricePerKm.Text = configurare.MinPricePerKm.ToString();
            textNumberOfCars.Text = configurare.NumberOfCars.ToString();
            textReservationCheckInterval.Text = configurare.ReservationCheckInterval.ToString();
            textPhoneNumber.Text = configurare.PhoneNumber;
            textMinPriceForShortTrips.Text = configurare.MinPriceForShortTrips.ToString();
            textShortTripDistanceThreshold.Text = configurare.ShortTripDistanceThreshold.ToString();
            textStartBusinessHour.Text = configurare.StartBusinessHour.ToString();
            textEndBusinessHour.Text = configurare.EndBusinessHour.ToString();
        }

        private void MakeButtonsUnavailable()
        {
            buttonReset.Enabled = false;
            buttonSave.Enabled = false;
        }

        private void MakeTextBoxesUnavailable()
        {
            textMinAcceptablePrice.Enabled = false;
            textMinPricePerKm.Enabled = false;
            textNumberOfCars.Enabled = false;
            textReservationCheckInterval.Enabled = false;
            textPhoneNumber.Enabled = false;
            textMinPriceForShortTrips.Enabled = false;
            textShortTripDistanceThreshold.Enabled = false;
            textStartBusinessHour.Enabled = false;
            textEndBusinessHour.Enabled = false;
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

        /// <summary>
        /// It gets the configurare from text boxes, validates it and saves the configurare in the file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                var configurare = GetConfigurareFromTextBox();
                ValidateConfigurare(configurare);
                if (_repository.SaveConfigurare(configurare) != null)
                {
                    MessageBox.Show("Changes saved successfully!");
                }
                MakeButtonsUnavailable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Reads the text boxes and tries to parse the text into the configurare attributes types.
        /// </summary>
        /// <returns></returns>
        private Configurare GetConfigurareFromTextBox()
        {
            var configurare = new Configurare();
            configurare.MinAcceptablePrice = int.Parse(textMinAcceptablePrice.Text);
            configurare.MinPricePerKm = float.Parse(textMinPricePerKm.Text);
            configurare.NumberOfCars = int.Parse(textNumberOfCars.Text);
            configurare.ReservationCheckInterval = int.Parse(textReservationCheckInterval.Text);
            configurare.PhoneNumber = textPhoneNumber.Text;
            configurare.MinPriceForShortTrips = int.Parse(textMinPriceForShortTrips.Text);
            configurare.ShortTripDistanceThreshold = int.Parse(textShortTripDistanceThreshold.Text);
            configurare.StartBusinessHour = int.Parse(textStartBusinessHour.Text);
            configurare.EndBusinessHour = int.Parse(textEndBusinessHour.Text);
            return configurare;
        }

        /// <summary>
        /// Extra validations to test if phone number, start hour, and end hour are in the correct format.
        /// </summary>
        /// <param name="configurare"></param>
        /// <exception cref="Exception"></exception>
        private void ValidateConfigurare(Configurare configurare)
        {
            var messages = "";
            if (!configurare.PhoneNumber[0].Equals('+'))
            {
                messages += "A phone number should start with '+'!\n";
            }
            if (configurare.StartBusinessHour < 0 || configurare.StartBusinessHour > 24)
            {
                messages += "Invalid Start hour!\n";
            }
            if (configurare.EndBusinessHour < 0 || configurare.EndBusinessHour > 24)
            {
                messages += "Invalid End hour!\n";
            }
            if (configurare.StartBusinessHour >= configurare.EndBusinessHour)
            {
                messages += "End hour should be greater than Start hour!\n";
            }

            if (messages != "")
            {
                throw new Exception(messages);
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            var configurare = _repository.GetConfigurareFromFile();
            if (configurare != null)
            {
                SetValuesInTextBoxes(configurare);
            }
            MakeButtonsUnavailable();
        }
    }
}
