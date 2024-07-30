using ProiectPractica.Model;
using ProiectPractica.Repository;
using System.Globalization;
using ProiectPractica.Validator;
using ProiectPractica.SettingsHandler;
using ProiectPractica.Persistance;

namespace ProiectPractica
{
    public partial class ConfigForm : Form
    {
        private ConfigurationRepository _repository;
        private FileSettingsHandler _fileSettingsHandler;
        private ConfigurationPersistence _configurationPersistence;
        private int _currentId;
        public ConfigForm()
        {
            InitializeComponent();
        }

        public void SetFileSettingsHandler(FileSettingsHandler fileSettingsHandler)
        {
            _fileSettingsHandler = fileSettingsHandler;
        }

        public void SetDbPersistence(ConfigurationPersistence configurationPersistence)
        {
            _configurationPersistence = configurationPersistence;
        }

        public void SetRepository(ConfigurationRepository configurationRepository)
        {
            _repository = configurationRepository;
            SetFileConfigurationInTextBoxes();
            SetCurrentFileInLabel();
            SetValidation();
        }

        /// <summary>
        /// Reads the configuration from the file and puts the configuration values in text boxes
        /// </summary>
        private void SetFileConfigurationInTextBoxes()
        {
            var filePath = _fileSettingsHandler.GetFileSettings().FilePath;
            _repository.FilePath = filePath;
            var configurationFromRepo = _repository.GetConfigurationFromFile();
            FirstFileSetupConfigurationInDB(filePath, configurationFromRepo);
            if (configurationFromRepo != null)
            {
                SetConfigurationValuesInTextBoxes(configurationFromRepo);
            }
            else
            {
                MessageBox.Show("Error loading the Configuration from the file, please select a file from the explorer!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            MakeButtonsDisabled();
        }

        /// <summary>
        /// If the file is not in the DB, save the configuration in DB
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="configuration"></param>
        private void FirstFileSetupConfigurationInDB(string filePath, Configuration configuration)
        {   
            _currentId = _configurationPersistence.GetLastConfigurationIndexByFile(filePath);
            if (_currentId == 0) 
            { 
                _configurationPersistence.Save(configuration, filePath);
                _currentId = _configurationPersistence.GetLastConfigurationIndexByFile(filePath);
            }
            EnablingNextAndPreviousButtons(filePath);
        }

        /// <summary>
        /// This sets the validation for text boxes
        /// </summary>
        private void SetValidation()
        {
            textMinAcceptablePrice.TextChanged += EnableButtonsWhenTextChanged;
            textMinAcceptablePrice.TextChanged += TextChangedInt;
            textMinAcceptablePrice.Validating += ValidatingInt;
            textMinAcceptablePrice.Validated += ValidatedInt;

            textMinPricePerKm.TextChanged += TextChangedFloat;
            textMinPricePerKm.TextChanged += EnableButtonsWhenTextChanged;
            textMinPricePerKm.Validating += ValidatingFloat;
            textMinPricePerKm.Validated += ValidatedFloat;

            textNumberOfCars.TextChanged += TextChangedInt;
            textNumberOfCars.TextChanged += EnableButtonsWhenTextChanged;
            textNumberOfCars.Validating += ValidatingInt;
            textNumberOfCars.Validated += ValidatedInt;

            textReservationCheckInterval.TextChanged += TextChangedInt;
            textReservationCheckInterval.TextChanged += EnableButtonsWhenTextChanged;
            textReservationCheckInterval.Validating += ValidatingInt;
            textReservationCheckInterval.Validated += ValidatedInt;

            textPhoneNumber.TextChanged += EnableButtonsWhenTextChanged;

            textMinPriceForShortTrips.TextChanged += TextChangedInt;
            textMinPriceForShortTrips.TextChanged += EnableButtonsWhenTextChanged;
            textMinPriceForShortTrips.Validating += ValidatingInt;
            textMinPriceForShortTrips.Validated += ValidatedInt;

            textShortTripDistanceThreshold.TextChanged += TextChangedInt;
            textShortTripDistanceThreshold.TextChanged += EnableButtonsWhenTextChanged;
            textShortTripDistanceThreshold.Validating += ValidatingInt;
            textShortTripDistanceThreshold.Validated += ValidatedInt;

            textStartBusinessHour.TextChanged += EndBusinessHourTextChanged;
            textStartBusinessHour.TextChanged += StartBusinessHourTextChanged;
            textStartBusinessHour.TextChanged += EnableButtonsWhenTextChanged;
            textStartBusinessHour.Validating += StartBusinessHourValidating;
            textStartBusinessHour.Validated += StartBusinessHourValidated;

            textEndBusinessHour.TextChanged += StartBusinessHourTextChanged;
            textEndBusinessHour.TextChanged += EndBusinessHourTextChanged;
            textEndBusinessHour.TextChanged += EnableButtonsWhenTextChanged;
            textEndBusinessHour.Validating += EndBusinessHourValidating;
            textEndBusinessHour.Validated += EndBusinessHourValidated;
        }

        private void SetCurrentFileInLabel()
        {
            labelCurrentFile.Text = _fileSettingsHandler.GetFileSettings().FilePath;
        }

        /// <summary>
        /// Puts the values from configuration object into the text boxes.
        /// </summary>
        /// <param name="configuration"></param>
        private void SetConfigurationValuesInTextBoxes(Configuration configuration)
        {
            textMinAcceptablePrice.Text = configuration.MinAcceptablePrice.ToString();
            textMinPricePerKm.Text = configuration.MinPricePerKm.ToString(CultureInfo.GetCultureInfo("de-DE"));
            textNumberOfCars.Text = configuration.NumberOfCars.ToString();
            textReservationCheckInterval.Text = configuration.ReservationCheckInterval.ToString();
            textPhoneNumber.Text = configuration.PhoneNumber;
            textMinPriceForShortTrips.Text = configuration.MinPriceForShortTrips.ToString();
            textShortTripDistanceThreshold.Text = configuration.ShortTripDistanceThreshold.ToString();
            textStartBusinessHour.Text = configuration.StartBusinessHour.ToString();
            textEndBusinessHour.Text = configuration.EndBusinessHour.ToString();
        }

        private void MakeButtonsDisabled()
        {
            buttonReset.Enabled = false;
            buttonSave.Enabled = false;
        }

        /// <summary>
        /// Enables or disables the buttons 
        /// I got the idea from here: https://stackoverflow.com/a/12460227
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnableButtonsWhenTextChanged(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                buttonSave.Enabled = false;
                buttonReset.Enabled = true;
            }
            else
            {
                EnableResetButton();
            }
        }

        /// <summary>
        /// If the configuratio from the file is the same as the one from text boxes it disables the buttons
        /// </summary>
        private void EnableResetButton()
        {
            if (!GetConfigurationFromTextBox().Equals(_repository.GetConfigurationFromFile()))
            {
                buttonReset.Enabled = true;
                buttonSave.Enabled = true;
            }
            else
            {
                buttonReset.Enabled = false;
                buttonSave.Enabled = false;
            }
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
                _configurationPersistence.Save(configuration, _repository.FilePath);
                _currentId = _configurationPersistence.GetLastConfigurationIndexByFile(_repository.FilePath);
                MessageBox.Show("Changes saved successfully!");
            }
            MakeButtonsDisabled();
            EnablingNextAndPreviousButtons(_repository.FilePath);
        }

        /// <summary>
        /// Reads the text boxes and tries to parse the text into the configuration attributes types.
        /// </summary>
        /// <returns></returns>
        private Configuration GetConfigurationFromTextBox()
        {
            var configuration = new Configuration();
            configuration.MinAcceptablePrice = int.Parse(textMinAcceptablePrice.Text);
            configuration.MinPricePerKm = float.Parse(textMinPricePerKm.Text, CultureInfo.GetCultureInfo("de-DE"));
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
            var configuration = _configurationPersistence.GetLastConfigurationFromFile(_repository.FilePath, out int lastId);
            _currentId = lastId;
            if (configuration != null)
            {
                SetConfigurationValuesInTextBoxes(configuration);
            }
            MakeButtonsDisabled();
            EnablingNextAndPreviousButtons(_repository.FilePath);
        }

        private void ValidatingInt(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (!ConfigurationValidator.ValidateInt(textBox.Text, out string errorMessage))
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
            if (!ConfigurationValidator.ValidateInt(textBox.Text, out string errorMessage))
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
            if (!ConfigurationValidator.ValidateFloat(textBox.Text, out string errorMessage))
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
            if (!ConfigurationValidator.ValidateFloat(textBox.Text, out string errorMessage))
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
            if (!ConfigurationValidator.ValidateHour(textStartBusinessHour.Text, out errorMessage) || !CheckEndHourGreaterThanStartHour(out errorMessage))
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
            if (!ConfigurationValidator.ValidateHour(textStartBusinessHour.Text, out errorMessage) || !CheckEndHourGreaterThanStartHour(out errorMessage))
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
            if (!ConfigurationValidator.ValidateHour(textEndBusinessHour.Text, out errorMessage) || !CheckEndHourGreaterThanStartHour(out errorMessage))
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
            if (!ConfigurationValidator.ValidateHour(textEndBusinessHour.Text, out errorMessage) || !CheckEndHourGreaterThanStartHour(out errorMessage))
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
            if (ConfigurationValidator.ValidateHour(textStartBusinessHour.Text, out errorMessage) && ConfigurationValidator.ValidateHour(textEndBusinessHour.Text, out errorMessage))
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

        /// <summary>
        /// Handles the selection of files from the explorer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFileSelect_Click(object sender, EventArgs e)
        {
            if (CheckUnsavedData()) return;
            var fileContent = string.Empty;
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                var userName = Environment.UserName;
                openFileDialog.InitialDirectory = "c:\\Users\\" + userName;
                openFileDialog.Filter = "json files (*.json)|*.json";
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                filePath = openFileDialog.FileName;
                var fileStream = openFileDialog.OpenFile();
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }
                var fileSettings = new FileSettings();
                fileSettings.FilePath = filePath;
                _fileSettingsHandler.Save(fileSettings);
                SetFileConfigurationInTextBoxes();
                SetCurrentFileInLabel();
            }
        }

        /// <summary>
        /// Return true if there is unsaved data
        /// </summary>
        /// <returns></returns>
        private bool CheckUnsavedData()
        {
            // when you have uncommited data it shows a warning message
            if (buttonReset.Enabled == true)
            {
                var result = MessageBox.Show("You have unsaved data!\nDo you wish to contiune?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    return true;
                }
            }
            return false;
        }

        private void EnablingNextAndPreviousButtons(string filePath)
        {
            buttonNextConfiguration.Enabled = false;
            buttonPreviousConfiguration.Enabled = false;
            if (_configurationPersistence.GetFirstConfigurationIndexByFile(filePath) < _currentId)
                buttonPreviousConfiguration.Enabled = true;
            if (_configurationPersistence.GetLastConfigurationIndexByFile(filePath) > _currentId)
                buttonNextConfiguration.Enabled = true;
        }

        private void buttonPreviousConfiguration_Click(object sender, EventArgs e)
        {
            var configuration = _configurationPersistence.GetPreviousConfiguration(_repository.FilePath, _currentId, out int idPrevious);
            _currentId = idPrevious;
            SetConfigurationValuesInTextBoxes(configuration);
            EnablingNextAndPreviousButtons(_repository.FilePath);
        }

        private void buttonNextConfiguration_Click(object sender, EventArgs e)
        {
            var configuration = _configurationPersistence.GetNextConfiguration(_repository.FilePath, _currentId, out int idNext);
            _currentId = idNext;
            SetConfigurationValuesInTextBoxes(configuration);
            EnablingNextAndPreviousButtons(_repository.FilePath);
        }
    }
}
