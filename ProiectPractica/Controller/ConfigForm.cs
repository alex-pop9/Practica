using ProiectPractica.Model;
using ProiectPractica.Repository;
using System.Globalization;
using ProiectPractica.Validator;

namespace ProiectPractica
{
    public partial class ConfigForm : Form
    {
        private ConfigurationRepository _repository;
        private ConfigurationValidator _validator;
        public ConfigForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This function sets the repository, takes the configuration from the file, and puts the object values into text boxes.
        /// If there is an error it shows a Message box and unables all text boxes.
        /// </summary>
        /// <param name="configurationRepository">Injected repository</param>
        public void SetRepository(ConfigurationRepository configurationRepository)
        {
            _repository = configurationRepository;
            var configurationFromRepo = _repository.GetConfigurationFromFile();
            if (configurationFromRepo != null)
            {
                SetValuesInTextBoxes(configurationFromRepo);
            }
            else
            {     
                MessageBox.Show("Error loading the Configuration from the file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MakeTextBoxesUnavailable();
            }
            MakeButtonsUnavailable();
        }

        public void SetValidator(ConfigurationValidator configurationValidator)
        {
            _validator = configurationValidator;
        }

        /// <summary>
        /// Puts the values from configuration object into the text boxes.
        /// </summary>
        /// <param name="configuration"></param>
        private void SetValuesInTextBoxes(Configuration configuration)
        {
            textMinAcceptablePrice.Text = configuration.MinAcceptablePrice.ToString();
            textMinPricePerKm.Text = configuration.MinPricePerKm.ToString(CultureInfo.CreateSpecificCulture("de-DE"));
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
        /// Enables the Reset button at change text and Save button if all validations are passed at text change.
        /// I got the idea from here: https://stackoverflow.com/a/12460227
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnableButtonsWhenTextChanged(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                buttonSave.Enabled = false;
            }
            else
            {
                buttonSave.Enabled = true;
            }
            buttonReset.Enabled = true;
        }

        /// <summary>
        /// It gets the configuration from text boxes  and saves the configuration in the file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void buttonSave_Click(object sender, EventArgs e)
        {
            var configuration = GetConfigurationFromTextBox();
            if (_repository.SaveConfiguration(configuration) != null)
            {
                MessageBox.Show("Changes saved successfully!");
            }
            MakeButtonsUnavailable();
        }

        /// <summary>
        /// Reads the text boxes and tries to parse the text into the configuration attributes types.
        /// </summary>
        /// <returns></returns>
        private Configuration GetConfigurationFromTextBox()
        {
            var configuration = new Configuration();
            configuration.MinAcceptablePrice = int.Parse(textMinAcceptablePrice.Text);
            configuration.MinPricePerKm = float.Parse(textMinPricePerKm.Text, CultureInfo.CreateSpecificCulture("de-DE"));
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

        private void ValidatingInt(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (!_validator.ValidateInt(textBox.Text, out string errorMessage))
            {
                e.Cancel = true;
                errorProviderForConfiguration.SetError(textBox, errorMessage);
            }
        }

        private void ValidatedInt(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            errorProviderForConfiguration.SetError(textBox, "");
        }

        private void TextChangedInt(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            var errorLabel = Controls.Find("errorLabel" + textBox.Name[4..], true).FirstOrDefault() as Label;
            if (!_validator.ValidateInt(textBox.Text, out string errorMessage))
            {
                errorLabel.Text = errorMessage;
                errorLabel.ForeColor = Color.Red;
            }
            else
            {
                errorLabel.Text = string.Empty;
            }
        }

        private void ValidatingFloat(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (!_validator.ValidateFloat(textBox.Text, out string errorMessage))
            {
                e.Cancel = true;
                errorProviderForConfiguration.SetError(textBox, errorMessage);
            }
        }

        private void ValidatedFloat(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            errorProviderForConfiguration.SetError(textBox, "");
        }

        private void TextChangedFloat(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            var errorLabel = Controls.Find("errorLabel" + textBox.Name[4..], true).FirstOrDefault() as Label;
            if (!_validator.ValidateFloat(textBox.Text, out string errorMessage))
            {
                errorLabel.Text = errorMessage;
                errorLabel.ForeColor = Color.Red;
            }
            else
            {
                errorLabel.Text = string.Empty;
            }
        }

        private void StartBusinessHourValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMessage;
            if (!_validator.ValidateHour(textStartBusinessHour.Text, out errorMessage) || !CheckEndHourGreaterThanStartHour(out errorMessage))
            {
                e.Cancel = true;
                errorProviderForConfiguration.SetError(textStartBusinessHour, errorMessage);
            }
        }
        private void StartBusinessHourValidated(object sender, EventArgs e)
        {
            errorProviderForConfiguration.SetError(textStartBusinessHour, "");
        }

        private void StartBusinessHourTextChanged(object sender, EventArgs e)
        {
            var errorMessage = string.Empty;
            if (!_validator.ValidateHour(textStartBusinessHour.Text, out errorMessage) || !CheckEndHourGreaterThanStartHour(out errorMessage))
            {
                errorLabelStartBusinessHour.Text = errorMessage;
                errorLabelStartBusinessHour.ForeColor = Color.Red;
            }
            else
            {
                errorLabelStartBusinessHour.Text = string.Empty;
            }
        }

        private void EndBusinessHourValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var errorMessage = string.Empty;
            if (!_validator.ValidateHour(textEndBusinessHour.Text, out errorMessage) || !CheckEndHourGreaterThanStartHour(out errorMessage))
            {
                e.Cancel = true;
                errorProviderForConfiguration.SetError(textEndBusinessHour, errorMessage);
            }
        }

        private void EndBusinessHourValidated(object sender, EventArgs e)
        {
            errorProviderForConfiguration.SetError(textEndBusinessHour, "");
        }

        private void EndBusinessHourTextChanged(object sender, EventArgs e)
        {
            var errorMessage = string.Empty;
            if (!_validator.ValidateHour(textEndBusinessHour.Text, out errorMessage) || !CheckEndHourGreaterThanStartHour(out errorMessage))
            {
                errorLabelEndBusinessHour.Text = errorMessage;
                errorLabelEndBusinessHour.ForeColor = Color.Red;
            }
            else
            {
                errorLabelEndBusinessHour.Text = string.Empty;
            }
        }

        private bool CheckEndHourGreaterThanStartHour(out string errorMessage)
        {
            if(_validator.ValidateHour(textStartBusinessHour.Text,out errorMessage) && _validator.ValidateHour(textEndBusinessHour.Text, out errorMessage))
            {
                if (int.Parse(textEndBusinessHour.Text) <= int.Parse(textStartBusinessHour.Text))
                {
                    errorMessage = "End hour should be greater than Start hour!";
                    return false;
                }
            }
            errorMessage = string.Empty;
            return true;
        }
    }
}
