using ProiectPractica.Model;
using ProiectPractica.Repository;
using System.Globalization;

namespace ProiectPractica
{
    public partial class ConfigForm : Form
    {
        private ConfigurationRepository _repository;
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
            try
            {
                _repository = configurationRepository;
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
        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                var configuration = GetConfigurationFromTextBox();
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

        private void MinAcceptablePriceValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidateInt(textMinAcceptablePrice.Text, out errorMsg))
            {
                e.Cancel = true;
                errorProviderForConfiguration.SetError(textMinAcceptablePrice, errorMsg);
            }
        }

        private void MinAcceptablePriceValidated(object sender, EventArgs e)
        {
            errorProviderForConfiguration.SetError(textMinAcceptablePrice,"");
        }

        private void MinAcceptablePriceTextChanged(object sender, EventArgs e)
        {
            var errorMessage = String.Empty;
            if (!ValidateInt(textMinAcceptablePrice.Text, out errorMessage))
            {
                errorLabelMinAcceptablePrice.Text = errorMessage;
                errorLabelMinAcceptablePrice.ForeColor = Color.Red;
            }
            else
            {
                errorLabelMinAcceptablePrice.Text = String.Empty;
            }
        }

        private void MinPricePerKmValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidateFloat(textMinPricePerKm.Text, out errorMsg))
            {
                e.Cancel = true; 
                errorProviderForConfiguration.SetError(textMinPricePerKm, errorMsg);
            }
        }

        private void MinPricePerKmValidated(object sender, EventArgs e)
        {
            errorProviderForConfiguration.SetError(textMinPricePerKm, "");
        }

        private void MinPricePerKmTextChanged(object sender, EventArgs e)
        {
            var errorMessage = String.Empty;
            if (!ValidateFloat(textMinPricePerKm.Text, out errorMessage))
            {
                errorLabelMinPricePerKm.Text = errorMessage;
                errorLabelMinPricePerKm.ForeColor = Color.Red;
            }
            else
            {
                errorLabelMinPricePerKm.Text = String.Empty;
            }
        }

        private void NumberOfCarsValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidateInt(textNumberOfCars.Text, out errorMsg))
            {
                e.Cancel = true;
                errorProviderForConfiguration.SetError(textNumberOfCars, errorMsg);
            }
        }

        private void NumberOfCarsValidated(object sender, EventArgs e)
        {
            errorProviderForConfiguration.SetError(textNumberOfCars, "");
        }

        private void NumberOfCarsTextChanged(object sender, EventArgs e)
        {
            var errorMessage = String.Empty;
            if (!ValidateInt(textNumberOfCars.Text, out errorMessage))
            {
                errorLabelNumberOfCars.Text = errorMessage;
                errorLabelNumberOfCars.ForeColor = Color.Red;
            }
            else
            {
                errorLabelNumberOfCars.Text = String.Empty;
            }
        }

        private void ReservationCheckIntervalValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidateInt(textReservationCheckInterval.Text, out errorMsg))
            {
                e.Cancel = true;
                errorProviderForConfiguration.SetError(textReservationCheckInterval, errorMsg);
            }
        }

        private void ReservationCheckIntervalValidated(object sender, EventArgs e)
        {
            errorProviderForConfiguration.SetError(textReservationCheckInterval, "");
        }

        private void ReservationCheckIntervalTextChanged(object sender, EventArgs e)
        {
            var errorMessage = String.Empty;
            if (!ValidateInt(textReservationCheckInterval.Text, out errorMessage))
            {
                errorLabelReservationCheckInterval.Text = errorMessage;
                errorLabelReservationCheckInterval.ForeColor = Color.Red;
            }
            else
            {
                errorLabelReservationCheckInterval.Text = String.Empty;
            }
        }

        private void MinPriceForShortTripsValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidateInt(textMinPriceForShortTrips.Text, out errorMsg))
            {
                e.Cancel = true;
                errorProviderForConfiguration.SetError(textMinPriceForShortTrips, errorMsg);
            }
        }

        private void MinPriceForShortTripsValidated(object sender, EventArgs e)
        {
            errorProviderForConfiguration.SetError(textMinPriceForShortTrips, "");
        }

        private void MinPriceForShortTripsTextChanged(object sender, EventArgs e)
        {
            var errorMessage = String.Empty;
            if (!ValidateInt(textMinPriceForShortTrips.Text, out errorMessage))
            {
                errorLabelMinPriceForShortTrips.Text = errorMessage;
                errorLabelMinPriceForShortTrips.ForeColor = Color.Red;
            }
            else
            {
                errorLabelMinPriceForShortTrips.Text = String.Empty;
            }
        }

        private void ShortTripDistanceThresholdValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidateInt(textShortTripDistanceThreshold.Text, out errorMsg))
            {
                e.Cancel = true;
                errorProviderForConfiguration.SetError(textShortTripDistanceThreshold, errorMsg);
            }
        }

        private void ShortTripDistanceThresholdValidated(object sender, EventArgs e)
        {
            errorProviderForConfiguration.SetError(textShortTripDistanceThreshold, "");
        }

        private void ShortTripDistanceThresholdTextChanged(object sender, EventArgs e)
        {
            var errorMessage = String.Empty;
            if (!ValidateInt(textShortTripDistanceThreshold.Text, out errorMessage))
            {
                errorLabelShortTripDistanceThreshold.Text = errorMessage;
                errorLabelShortTripDistanceThreshold.ForeColor = Color.Red;
            }
            else
            {
                errorLabelShortTripDistanceThreshold.Text = String.Empty;
            }
        }

        private void StartBusinessHourValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidateHour(textStartBusinessHour.Text, out errorMsg))
            {
                e.Cancel = true;
                errorProviderForConfiguration.SetError(textStartBusinessHour, errorMsg);
            }
        }

        private void StartBusinessHourValidated(object sender, EventArgs e)
        {
            errorProviderForConfiguration.SetError(textStartBusinessHour, "");
        }

        private void StartBusinessHourTextChanged(object sender, EventArgs e)
        {
            var errorMessage = String.Empty;
            if (!ValidateHour(textStartBusinessHour.Text, out errorMessage))
            {
                errorLabelStartBusinessHour.Text = errorMessage;
                errorLabelStartBusinessHour.ForeColor = Color.Red;
            }
            else
            {
                errorLabelStartBusinessHour.Text = String.Empty;
            }
        }

        private void EndBusinessHourValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidateHour(textEndBusinessHour.Text, out errorMsg))
            {
                e.Cancel = true;
                errorProviderForConfiguration.SetError(textEndBusinessHour, errorMsg);
            }
        }

        private void EndBusinessHourValidated(object sender, EventArgs e)
        {
            errorProviderForConfiguration.SetError(textEndBusinessHour, "");
        }

        private void EndBusinessHourTextChanged(object sender, EventArgs e)
        {
            var errorMessage = String.Empty;
            if (!ValidateHour(textEndBusinessHour.Text, out errorMessage))
            {
                errorLabelEndBusinessHour.Text = errorMessage;
                errorLabelEndBusinessHour.ForeColor = Color.Red;
            }
            else
            {
                errorLabelEndBusinessHour.Text = String.Empty;
            }
        }

        /// <summary>
        /// Validates a string so that it can be parsed into an integer.
        /// Returns true if the string can be parsed as an integer,
        /// and returns false otherwise.
        /// </summary>
        /// <param name="textToBeValidated"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        private bool ValidateInt(string textToBeValidated, out string errorMessage)
        {
            if (textToBeValidated.Length == 0)
            {
                errorMessage = "Field should not be empty!";
                return false;
            }
            try
            {
               var integer = int.Parse(textToBeValidated);
                if (integer < 0)
                {
                    errorMessage = "The number should be positive!";
                    return false;
                }
            }
            catch (FormatException)
            {
                errorMessage = "This should be a number!";
                return false;
            }
            catch (OverflowException)
            {
                errorMessage = "The number is to big!";
                return false;
            }
            errorMessage = "";
            return true;
        }

        /// <summary>
        /// Validates a string so that it can be parsed into a float.
        /// Returns true if the string can be parsed as a float,
        /// and it returns false otherwise.
        /// </summary>
        /// <param name="textToBeValidated"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        private bool ValidateFloat(string textToBeValidated, out string errorMessage)
        {
            if (textToBeValidated.Length == 0)
            {
                errorMessage = "Field should not be empty!";
                return false;
            }
            try
            {
                var floatNumber = float.Parse(textToBeValidated);
                if (floatNumber < 0)
                {
                    errorMessage = "The number should be positive!";
                    return false;
                }
                if (floatNumber > float.MaxValue)
                {
                    errorMessage = "The number is to big!";
                    return false;
                }
            }
            catch (FormatException)
            {
                errorMessage = "This should be a number!";
                return false;
            }
            errorMessage = "";
            return true;
        }

        /// <summary>
        /// Validates a string so that it can be parsed into an integer that represents an hour.
        /// Returns true if the string can be parsed as an hour,
        /// and it returns false otherwise.
        /// It also checks if the end hour is greater than start hour
        /// </summary>
        /// <param name="textToBeValidated"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        private bool ValidateHour(string textToBeValidated, out string errorMessage)
        {
            if (textToBeValidated.Length == 0)
            {
                errorMessage = "Field should not be empty!";
                return false;
            }
            try
            {
                var hour = int.Parse(textToBeValidated);
                if (hour < 0 || hour > 23)
                {
                    errorMessage = "Invalid hour!";
                    return false;
                }
            }
            catch (FormatException)
            {
                errorMessage = "This should be a number!";
                return false;
            }
            catch (OverflowException)
            {
                errorMessage = "The number is to big!";
                return false;
            }
            try // when loading the text boxes for the first time or at reset, the start hour is loaded
                // first, so it tries to compare start hour with end hour, but end hour is empty, raising an error 
            {
                if (int.Parse(textEndBusinessHour.Text) <= int.Parse(textStartBusinessHour.Text))
                {
                    errorMessage = "End hour should be greater than Start hour!";
                    return false;
                }
            }
            catch
            {
                errorMessage = "";
                return true;
            }
            errorMessage = "";
            return true;
        }
    }
}
