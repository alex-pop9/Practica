using ProiectPractica.Model;
using ProiectPractica.Repository;

namespace ProiectPractica
{
    public partial class ConfigForm : Form
    {
        private RepositoryConfiguration _repository;
        public ConfigForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This function sets the repository, takes the configuration from the file, and puts the object values into text boxes.
        /// If there is an error it shows a Message box and unables all text boxes.
        /// </summary>
        /// <param name="repositoryConfiguration">Injected repository</param>
        public void SetRepository(RepositoryConfiguration repositoryConfiguration)
        {
            try
            {
                _repository = repositoryConfiguration;
                var configurationFromRepo = _repository.GetConfigurationFromFile();
                if (configurationFromRepo != null)
                {
                    SetValuesInTextBoxes(configurationFromRepo);
                }
                else
                {
                    throw new Exception("Error loading the Configuration from the file!");
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
        /// Puts the values from configuration object into the text boxes.
        /// </summary>
        /// <param name="configuration"></param>
        private void SetValuesInTextBoxes(Configuration configuration)
        {
            textMinAcceptablePrice.Text = configuration.MinAcceptablePrice.ToString();
            textMinPricePerKm.Text = configuration.MinPricePerKm.ToString();
            textNumberOfCars.Text = configuration.NumberOfCars.ToString();
            textReservationCheckInterval.Text = configuration.ReservationCheckInterval.ToString();
            textPhoneNumber.Text = configuration.PhoneNumber;
            textMinPriceForShortTrips.Text = configuration.MinPriceForShortTrips.ToString();
            textShortTripDistanceThreshold.Text = configuration.ShortTripDistanceThreshold.ToString();
            textStartBusinessHour.Text = configuration.StartBusinessHour.ToString();
            textEndBusinessHour.Text = configuration.EndBusinessHour.ToString();
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
        /// It gets the configuration from text boxes, validates it and saves the configuration in the file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                var configuration = GetconfigurationFromTextBox();
                Validateconfiguration(configuration);
                if (_repository.SaveConfiguration(configuration) != null)
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
        /// Reads the text boxes and tries to parse the text into the configuration attributes types.
        /// </summary>
        /// <returns></returns>
        private Configuration GetconfigurationFromTextBox()
        {
            var configuration = new Configuration();
            configuration.MinAcceptablePrice = int.Parse(textMinAcceptablePrice.Text);
            configuration.MinPricePerKm = float.Parse(textMinPricePerKm.Text);
            configuration.NumberOfCars = int.Parse(textNumberOfCars.Text);
            configuration.ReservationCheckInterval = int.Parse(textReservationCheckInterval.Text);
            configuration.PhoneNumber = textPhoneNumber.Text;
            configuration.MinPriceForShortTrips = int.Parse(textMinPriceForShortTrips.Text);
            configuration.ShortTripDistanceThreshold = int.Parse(textShortTripDistanceThreshold.Text);
            configuration.StartBusinessHour = int.Parse(textStartBusinessHour.Text);
            configuration.EndBusinessHour = int.Parse(textEndBusinessHour.Text);
            return configuration;
        }

        /// <summary>
        /// Extra validations to test if phone number, start hour, and end hour are in the correct format.
        /// </summary>
        /// <param name="configuration"></param>
        /// <exception cref="Exception"></exception>
        private void Validateconfiguration(Configuration configuration)
        {
            var messages = new List<string>();
            if (!configuration.PhoneNumber[0].Equals('+'))
            {
                messages.Add("A phone number should start with '+'!\n");
            }
            if (configuration.StartBusinessHour < 0 || configuration.StartBusinessHour > 24)
            {
                messages.Add("Invalid Start hour!\n");
            }
            if (configuration.EndBusinessHour < 0 || configuration.EndBusinessHour > 24)
            {
                messages.Add("Invalid End hour!\n");
            }
            if (configuration.StartBusinessHour >= configuration.EndBusinessHour)
            {
                messages.Add("End hour should be greater than Start hour!\n");
            }

            if (messages.Any())
            {
                throw new Exception(string.Join('\n', messages));
            }
        }

        /// <summary>
        /// Resets the values from the text boxes to the initial configuration values from the file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReset_Click(object sender, EventArgs e)
        {
            var configuration = _repository.GetConfigurationFromFile();
            if (configuration != null)
            {
                SetValuesInTextBoxes(configuration);
            }
            MakeButtonsUnavailable();
        }
    }
}
