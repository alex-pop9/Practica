namespace ProiectPractica
{
    partial class ConfigForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            minAcceptablePrice = new Label();
            minPricePerKm = new Label();
            numberOfCars = new Label();
            reservationCheckInterval = new Label();
            phoneNumber = new Label();
            minPriceForShortTrips = new Label();
            shortTripDistanceThreshold = new Label();
            startBusinessHour = new Label();
            endBusinessHour = new Label();
            textMinAcceptablePrice = new TextBox();
            textMinPricePerKm = new TextBox();
            textNumberOfCars = new TextBox();
            textReservationCheckInterval = new TextBox();
            textPhoneNumber = new TextBox();
            textMinPriceForShortTrips = new TextBox();
            textShortTripDistanceThreshold = new TextBox();
            textStartBusinessHour = new TextBox();
            textEndBusinessHour = new TextBox();
            buttonSave = new Button();
            buttonReset = new Button();
            toolTipForConfigurationJson = new ToolTip(components);
            errorProviderForConfiguration = new ErrorProvider(components);
            errorLabelMinAcceptablePrice = new Label();
            errorLabelMinPricePerKm = new Label();
            errorLabelNumberOfCars = new Label();
            errorLabelReservationCheckInterval = new Label();
            errorLabelPhoneNumber = new Label();
            errorLabelMinPriceForShortTrips = new Label();
            errorLabelShortTripDistanceThreshold = new Label();
            errorLabelStartBusinessHour = new Label();
            errorLabelEndBusinessHour = new Label();
            buttonFileSelect = new Button();
            openConfigurationFileDialog = new OpenFileDialog();
            buttonPreviousConfiguration = new Button();
            buttonNextConfiguration = new Button();
            labelCurrentFileInfo = new Label();
            labelCurrentFile = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProviderForConfiguration).BeginInit();
            SuspendLayout();
            // 
            // minAcceptablePrice
            // 
            minAcceptablePrice.AutoSize = true;
            minAcceptablePrice.Location = new Point(103, 219);
            minAcceptablePrice.Name = "minAcceptablePrice";
            minAcceptablePrice.Size = new Size(379, 41);
            minAcceptablePrice.TabIndex = 0;
            minAcceptablePrice.Text = "Minimum Acceptable Price:";
            toolTipForConfigurationJson.SetToolTip(minAcceptablePrice, "MinAcceptablePrice");
            // 
            // minPricePerKm
            // 
            minPricePerKm.AutoSize = true;
            minPricePerKm.Location = new Point(103, 337);
            minPricePerKm.Name = "minPricePerKm";
            minPricePerKm.Size = new Size(390, 41);
            minPricePerKm.TabIndex = 1;
            minPricePerKm.Text = "Minimum Price For One Km:";
            toolTipForConfigurationJson.SetToolTip(minPricePerKm, "MinPricePerKm");
            // 
            // numberOfCars
            // 
            numberOfCars.AutoSize = true;
            numberOfCars.Location = new Point(103, 456);
            numberOfCars.Name = "numberOfCars";
            numberOfCars.Size = new Size(239, 41);
            numberOfCars.TabIndex = 2;
            numberOfCars.Text = "Number Of Cars:";
            toolTipForConfigurationJson.SetToolTip(numberOfCars, "NumberOfCars");
            // 
            // reservationCheckInterval
            // 
            reservationCheckInterval.AutoSize = true;
            reservationCheckInterval.Location = new Point(103, 574);
            reservationCheckInterval.Name = "reservationCheckInterval";
            reservationCheckInterval.Size = new Size(423, 41);
            reservationCheckInterval.TabIndex = 3;
            reservationCheckInterval.Text = "Interval For Reservation Check:";
            toolTipForConfigurationJson.SetToolTip(reservationCheckInterval, "ReservationCheckInterval");
            // 
            // phoneNumber
            // 
            phoneNumber.AutoSize = true;
            phoneNumber.Location = new Point(103, 698);
            phoneNumber.Name = "phoneNumber";
            phoneNumber.Size = new Size(227, 41);
            phoneNumber.TabIndex = 4;
            phoneNumber.Text = "Phone Number:";
            toolTipForConfigurationJson.SetToolTip(phoneNumber, "PhoneNumber");
            // 
            // minPriceForShortTrips
            // 
            minPriceForShortTrips.AutoSize = true;
            minPriceForShortTrips.Location = new Point(937, 219);
            minPriceForShortTrips.Name = "minPriceForShortTrips";
            minPriceForShortTrips.Size = new Size(423, 41);
            minPriceForShortTrips.TabIndex = 5;
            minPriceForShortTrips.Text = "Minimum Price For Short Trips:";
            toolTipForConfigurationJson.SetToolTip(minPriceForShortTrips, "MinPriceForShortTrips");
            // 
            // shortTripDistanceThreshold
            // 
            shortTripDistanceThreshold.AutoSize = true;
            shortTripDistanceThreshold.Location = new Point(937, 337);
            shortTripDistanceThreshold.Name = "shortTripDistanceThreshold";
            shortTripDistanceThreshold.Size = new Size(477, 41);
            shortTripDistanceThreshold.TabIndex = 6;
            shortTripDistanceThreshold.Text = "Threshold For Short Distance Trips:";
            toolTipForConfigurationJson.SetToolTip(shortTripDistanceThreshold, "ShortTripDistanceThreshold");
            // 
            // startBusinessHour
            // 
            startBusinessHour.AutoSize = true;
            startBusinessHour.Location = new Point(937, 459);
            startBusinessHour.Name = "startBusinessHour";
            startBusinessHour.Size = new Size(368, 41);
            startBusinessHour.TabIndex = 7;
            startBusinessHour.Text = "Start Of Business Program:";
            toolTipForConfigurationJson.SetToolTip(startBusinessHour, "StartBusinessHour");
            // 
            // endBusinessHour
            // 
            endBusinessHour.AutoSize = true;
            endBusinessHour.Location = new Point(937, 574);
            endBusinessHour.Name = "endBusinessHour";
            endBusinessHour.Size = new Size(358, 41);
            endBusinessHour.TabIndex = 8;
            endBusinessHour.Text = "End Of Business Program:";
            toolTipForConfigurationJson.SetToolTip(endBusinessHour, "EndBusinessHour");
            // 
            // textMinAcceptablePrice
            // 
            textMinAcceptablePrice.Location = new Point(549, 213);
            textMinAcceptablePrice.Name = "textMinAcceptablePrice";
            textMinAcceptablePrice.Size = new Size(250, 47);
            textMinAcceptablePrice.TabIndex = 9;
            // 
            // textMinPricePerKm
            // 
            textMinPricePerKm.Location = new Point(549, 331);
            textMinPricePerKm.Name = "textMinPricePerKm";
            textMinPricePerKm.Size = new Size(250, 47);
            textMinPricePerKm.TabIndex = 10;
            // 
            // textNumberOfCars
            // 
            textNumberOfCars.Location = new Point(549, 450);
            textNumberOfCars.Name = "textNumberOfCars";
            textNumberOfCars.Size = new Size(250, 47);
            textNumberOfCars.TabIndex = 11;
            // 
            // textReservationCheckInterval
            // 
            textReservationCheckInterval.Location = new Point(549, 571);
            textReservationCheckInterval.Name = "textReservationCheckInterval";
            textReservationCheckInterval.Size = new Size(250, 47);
            textReservationCheckInterval.TabIndex = 12;
            // 
            // textPhoneNumber
            // 
            textPhoneNumber.Location = new Point(549, 692);
            textPhoneNumber.Name = "textPhoneNumber";
            textPhoneNumber.Size = new Size(250, 47);
            textPhoneNumber.TabIndex = 13;
            // 
            // textMinPriceForShortTrips
            // 
            textMinPriceForShortTrips.Location = new Point(1452, 216);
            textMinPriceForShortTrips.Name = "textMinPriceForShortTrips";
            textMinPriceForShortTrips.Size = new Size(250, 47);
            textMinPriceForShortTrips.TabIndex = 14;
            // 
            // textShortTripDistanceThreshold
            // 
            textShortTripDistanceThreshold.Location = new Point(1452, 331);
            textShortTripDistanceThreshold.Name = "textShortTripDistanceThreshold";
            textShortTripDistanceThreshold.Size = new Size(250, 47);
            textShortTripDistanceThreshold.TabIndex = 15;
            // 
            // textStartBusinessHour
            // 
            textStartBusinessHour.Location = new Point(1452, 450);
            textStartBusinessHour.Name = "textStartBusinessHour";
            textStartBusinessHour.Size = new Size(250, 47);
            textStartBusinessHour.TabIndex = 16;
            // 
            // textEndBusinessHour
            // 
            textEndBusinessHour.Location = new Point(1452, 571);
            textEndBusinessHour.Name = "textEndBusinessHour";
            textEndBusinessHour.Size = new Size(250, 47);
            textEndBusinessHour.TabIndex = 17;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(1020, 735);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(218, 110);
            buttonSave.TabIndex = 18;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(1413, 735);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(218, 110);
            buttonReset.TabIndex = 19;
            buttonReset.Text = "Reset";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += buttonReset_Click;
            // 
            // errorProviderForConfiguration
            // 
            errorProviderForConfiguration.ContainerControl = this;
            // 
            // errorLabelMinAcceptablePrice
            // 
            errorLabelMinAcceptablePrice.AutoSize = true;
            errorLabelMinAcceptablePrice.Location = new Point(440, 280);
            errorLabelMinAcceptablePrice.Name = "errorLabelMinAcceptablePrice";
            errorLabelMinAcceptablePrice.Size = new Size(0, 41);
            errorLabelMinAcceptablePrice.TabIndex = 20;
            // 
            // errorLabelMinPricePerKm
            // 
            errorLabelMinPricePerKm.AutoSize = true;
            errorLabelMinPricePerKm.Location = new Point(440, 400);
            errorLabelMinPricePerKm.Name = "errorLabelMinPricePerKm";
            errorLabelMinPricePerKm.Size = new Size(0, 41);
            errorLabelMinPricePerKm.TabIndex = 21;
            // 
            // errorLabelNumberOfCars
            // 
            errorLabelNumberOfCars.AutoSize = true;
            errorLabelNumberOfCars.Location = new Point(440, 510);
            errorLabelNumberOfCars.Name = "errorLabelNumberOfCars";
            errorLabelNumberOfCars.Size = new Size(0, 41);
            errorLabelNumberOfCars.TabIndex = 22;
            // 
            // errorLabelReservationCheckInterval
            // 
            errorLabelReservationCheckInterval.AutoSize = true;
            errorLabelReservationCheckInterval.Location = new Point(440, 640);
            errorLabelReservationCheckInterval.Name = "errorLabelReservationCheckInterval";
            errorLabelReservationCheckInterval.Size = new Size(0, 41);
            errorLabelReservationCheckInterval.TabIndex = 23;
            // 
            // errorLabelPhoneNumber
            // 
            errorLabelPhoneNumber.AutoSize = true;
            errorLabelPhoneNumber.Location = new Point(440, 770);
            errorLabelPhoneNumber.Name = "errorLabelPhoneNumber";
            errorLabelPhoneNumber.Size = new Size(0, 41);
            errorLabelPhoneNumber.TabIndex = 24;
            // 
            // errorLabelMinPriceForShortTrips
            // 
            errorLabelMinPriceForShortTrips.AutoSize = true;
            errorLabelMinPriceForShortTrips.Location = new Point(1340, 280);
            errorLabelMinPriceForShortTrips.Name = "errorLabelMinPriceForShortTrips";
            errorLabelMinPriceForShortTrips.Size = new Size(0, 41);
            errorLabelMinPriceForShortTrips.TabIndex = 25;
            // 
            // errorLabelShortTripDistanceThreshold
            // 
            errorLabelShortTripDistanceThreshold.AutoSize = true;
            errorLabelShortTripDistanceThreshold.Location = new Point(1340, 400);
            errorLabelShortTripDistanceThreshold.Name = "errorLabelShortTripDistanceThreshold";
            errorLabelShortTripDistanceThreshold.Size = new Size(0, 41);
            errorLabelShortTripDistanceThreshold.TabIndex = 26;
            // 
            // errorLabelStartBusinessHour
            // 
            errorLabelStartBusinessHour.AutoSize = true;
            errorLabelStartBusinessHour.Location = new Point(1340, 520);
            errorLabelStartBusinessHour.Name = "errorLabelStartBusinessHour";
            errorLabelStartBusinessHour.Size = new Size(0, 41);
            errorLabelStartBusinessHour.TabIndex = 27;
            // 
            // errorLabelEndBusinessHour
            // 
            errorLabelEndBusinessHour.AutoSize = true;
            errorLabelEndBusinessHour.Location = new Point(1340, 640);
            errorLabelEndBusinessHour.Name = "errorLabelEndBusinessHour";
            errorLabelEndBusinessHour.Size = new Size(0, 41);
            errorLabelEndBusinessHour.TabIndex = 28;
            // 
            // buttonFileSelect
            // 
            buttonFileSelect.Location = new Point(103, 105);
            buttonFileSelect.Name = "buttonFileSelect";
            buttonFileSelect.Size = new Size(188, 58);
            buttonFileSelect.TabIndex = 29;
            buttonFileSelect.Text = "Select File";
            buttonFileSelect.UseVisualStyleBackColor = true;
            buttonFileSelect.Click += buttonFileSelect_Click;
            // 
            // openConfigurationFileDialog
            // 
            openConfigurationFileDialog.FileName = "openFileDialog1";
            // 
            // buttonPreviousConfiguration
            // 
            buttonPreviousConfiguration.Location = new Point(85, 820);
            buttonPreviousConfiguration.Name = "buttonPreviousConfiguration";
            buttonPreviousConfiguration.Size = new Size(355, 58);
            buttonPreviousConfiguration.TabIndex = 30;
            buttonPreviousConfiguration.Text = "Previous Configuration";
            buttonPreviousConfiguration.UseVisualStyleBackColor = true;
            buttonPreviousConfiguration.Click += buttonPreviousConfiguration_Click;
            // 
            // buttonNextConfiguration
            // 
            buttonNextConfiguration.Location = new Point(549, 820);
            buttonNextConfiguration.Name = "buttonNextConfiguration";
            buttonNextConfiguration.Size = new Size(355, 58);
            buttonNextConfiguration.TabIndex = 31;
            buttonNextConfiguration.Text = "Next Configuration";
            buttonNextConfiguration.UseVisualStyleBackColor = true;
            buttonNextConfiguration.Click += buttonNextConfiguration_Click;
            // 
            // labelCurrentFileInfo
            // 
            labelCurrentFileInfo.AutoSize = true;
            labelCurrentFileInfo.Location = new Point(356, 114);
            labelCurrentFileInfo.Name = "labelCurrentFileInfo";
            labelCurrentFileInfo.Size = new Size(179, 41);
            labelCurrentFileInfo.TabIndex = 32;
            labelCurrentFileInfo.Text = "Current file: ";
            // 
            // labelCurrentFile
            // 
            labelCurrentFile.AutoSize = true;
            labelCurrentFile.Location = new Point(549, 114);
            labelCurrentFile.Name = "labelCurrentFile";
            labelCurrentFile.Size = new Size(0, 41);
            labelCurrentFile.TabIndex = 33;
            // 
            // ConfigForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(1942, 951);
            Controls.Add(labelCurrentFile);
            Controls.Add(labelCurrentFileInfo);
            Controls.Add(buttonNextConfiguration);
            Controls.Add(buttonPreviousConfiguration);
            Controls.Add(buttonFileSelect);
            Controls.Add(errorLabelEndBusinessHour);
            Controls.Add(errorLabelStartBusinessHour);
            Controls.Add(errorLabelShortTripDistanceThreshold);
            Controls.Add(errorLabelMinPriceForShortTrips);
            Controls.Add(errorLabelPhoneNumber);
            Controls.Add(errorLabelReservationCheckInterval);
            Controls.Add(errorLabelNumberOfCars);
            Controls.Add(errorLabelMinPricePerKm);
            Controls.Add(errorLabelMinAcceptablePrice);
            Controls.Add(buttonReset);
            Controls.Add(buttonSave);
            Controls.Add(textEndBusinessHour);
            Controls.Add(textStartBusinessHour);
            Controls.Add(textShortTripDistanceThreshold);
            Controls.Add(textMinPriceForShortTrips);
            Controls.Add(textPhoneNumber);
            Controls.Add(textReservationCheckInterval);
            Controls.Add(textNumberOfCars);
            Controls.Add(textMinPricePerKm);
            Controls.Add(textMinAcceptablePrice);
            Controls.Add(endBusinessHour);
            Controls.Add(startBusinessHour);
            Controls.Add(shortTripDistanceThreshold);
            Controls.Add(minPriceForShortTrips);
            Controls.Add(phoneNumber);
            Controls.Add(reservationCheckInterval);
            Controls.Add(numberOfCars);
            Controls.Add(minPricePerKm);
            Controls.Add(minAcceptablePrice);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "ConfigForm";
            Text = "Configurator";
            ((System.ComponentModel.ISupportInitialize)errorProviderForConfiguration).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label minAcceptablePrice;
        private Label minPricePerKm;
        private Label numberOfCars;
        private Label reservationCheckInterval;
        private Label phoneNumber;
        private Label minPriceForShortTrips;
        private Label shortTripDistanceThreshold;
        private Label startBusinessHour;
        private Label endBusinessHour;
        private TextBox textMinAcceptablePrice;
        private TextBox textMinPricePerKm;
        private TextBox textNumberOfCars;
        private TextBox textReservationCheckInterval;
        private TextBox textPhoneNumber;
        private TextBox textMinPriceForShortTrips;
        private TextBox textShortTripDistanceThreshold;
        private TextBox textStartBusinessHour;
        private TextBox textEndBusinessHour;
        private Button buttonSave;
        private Button buttonReset;
        private ToolTip toolTipForConfigurationJson;
        private ErrorProvider errorProviderForConfiguration;
        private Label errorLabelEndBusinessHour;
        private Label errorLabelStartBusinessHour;
        private Label errorLabelShortTripDistanceThreshold;
        private Label errorLabelMinPriceForShortTrips;
        private Label errorLabelPhoneNumber;
        private Label errorLabelReservationCheckInterval;
        private Label errorLabelNumberOfCars;
        private Label errorLabelMinPricePerKm;
        private Label errorLabelMinAcceptablePrice;
        private Button buttonFileSelect;
        private OpenFileDialog openConfigurationFileDialog;
        private Button buttonNextConfiguration;
        private Button buttonPreviousConfiguration;
        private Label labelCurrentFile;
        private Label labelCurrentFileInfo;
    }
}
