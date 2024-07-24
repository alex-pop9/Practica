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
            SuspendLayout();
            // 
            // minAcceptablePrice
            // 
            minAcceptablePrice.AutoSize = true;
            minAcceptablePrice.Location = new Point(113, 127);
            minAcceptablePrice.Name = "minAcceptablePrice";
            minAcceptablePrice.Size = new Size(379, 41);
            minAcceptablePrice.TabIndex = 0;
            minAcceptablePrice.Text = "Minimum Acceptable Price:";
            toolTipForConfigurationJson.SetToolTip(minAcceptablePrice, "MinAcceptablePrice");
            // 
            // minPricePerKm
            // 
            minPricePerKm.AutoSize = true;
            minPricePerKm.Location = new Point(113, 245);
            minPricePerKm.Name = "minPricePerKm";
            minPricePerKm.Size = new Size(390, 41);
            minPricePerKm.TabIndex = 1;
            minPricePerKm.Text = "Minimum Price For One Km:";
            toolTipForConfigurationJson.SetToolTip(minPricePerKm, "MinPricePerKm");
            // 
            // numberOfCars
            // 
            numberOfCars.AutoSize = true;
            numberOfCars.Location = new Point(113, 364);
            numberOfCars.Name = "numberOfCars";
            numberOfCars.Size = new Size(239, 41);
            numberOfCars.TabIndex = 2;
            numberOfCars.Text = "Number Of Cars:";
            toolTipForConfigurationJson.SetToolTip(numberOfCars, "NumberOfCars");
            // 
            // reservationCheckInterval
            // 
            reservationCheckInterval.AutoSize = true;
            reservationCheckInterval.Location = new Point(113, 482);
            reservationCheckInterval.Name = "reservationCheckInterval";
            reservationCheckInterval.Size = new Size(423, 41);
            reservationCheckInterval.TabIndex = 3;
            reservationCheckInterval.Text = "Interval For Reservation Check:";
            toolTipForConfigurationJson.SetToolTip(reservationCheckInterval, "ReservationCheckInterval");
            // 
            // phoneNumber
            // 
            phoneNumber.AutoSize = true;
            phoneNumber.Location = new Point(113, 606);
            phoneNumber.Name = "phoneNumber";
            phoneNumber.Size = new Size(227, 41);
            phoneNumber.TabIndex = 4;
            phoneNumber.Text = "Phone Number:";
            toolTipForConfigurationJson.SetToolTip(phoneNumber, "PhoneNumber");
            // 
            // minPriceForShortTrips
            // 
            minPriceForShortTrips.AutoSize = true;
            minPriceForShortTrips.Location = new Point(947, 127);
            minPriceForShortTrips.Name = "minPriceForShortTrips";
            minPriceForShortTrips.Size = new Size(423, 41);
            minPriceForShortTrips.TabIndex = 5;
            minPriceForShortTrips.Text = "Minimum Price For Short Trips:";
            toolTipForConfigurationJson.SetToolTip(minPriceForShortTrips, "MinPriceForShortTrips");
            // 
            // shortTripDistanceThreshold
            // 
            shortTripDistanceThreshold.AutoSize = true;
            shortTripDistanceThreshold.Location = new Point(947, 245);
            shortTripDistanceThreshold.Name = "shortTripDistanceThreshold";
            shortTripDistanceThreshold.Size = new Size(477, 41);
            shortTripDistanceThreshold.TabIndex = 6;
            shortTripDistanceThreshold.Text = "Threshold For Short Distance Trips:";
            toolTipForConfigurationJson.SetToolTip(shortTripDistanceThreshold, "ShortTripDistanceThreshold");
            // 
            // startBusinessHour
            // 
            startBusinessHour.AutoSize = true;
            startBusinessHour.Location = new Point(947, 367);
            startBusinessHour.Name = "startBusinessHour";
            startBusinessHour.Size = new Size(368, 41);
            startBusinessHour.TabIndex = 7;
            startBusinessHour.Text = "Start Of Business Program:";
            toolTipForConfigurationJson.SetToolTip(startBusinessHour, "StartBusinessHour");
            // 
            // endBusinessHour
            // 
            endBusinessHour.AutoSize = true;
            endBusinessHour.Location = new Point(947, 482);
            endBusinessHour.Name = "endBusinessHour";
            endBusinessHour.Size = new Size(358, 41);
            endBusinessHour.TabIndex = 8;
            endBusinessHour.Text = "End Of Business Program:";
            toolTipForConfigurationJson.SetToolTip(endBusinessHour, "EndBusinessHour");
            // 
            // textMinAcceptablePrice
            // 
            textMinAcceptablePrice.Location = new Point(559, 121);
            textMinAcceptablePrice.Name = "textMinAcceptablePrice";
            textMinAcceptablePrice.Size = new Size(250, 47);
            textMinAcceptablePrice.TabIndex = 9;
            textMinAcceptablePrice.TextChanged += TextChangedInt;
            textMinAcceptablePrice.TextChanged += EnableButtonsWhenTextChanged;
            textMinAcceptablePrice.Validating += ValidatingInt;
            textMinAcceptablePrice.Validated += ValidatedInt;
            // 
            // textMinPricePerKm
            // 
            textMinPricePerKm.Location = new Point(559, 239);
            textMinPricePerKm.Name = "textMinPricePerKm";
            textMinPricePerKm.Size = new Size(250, 47);
            textMinPricePerKm.TabIndex = 10;
            textMinPricePerKm.TextChanged += EnableButtonsWhenTextChanged;
            textMinPricePerKm.TextChanged += TextChangedFloat;
            textMinPricePerKm.Validating += ValidatingFloat;
            textMinPricePerKm.Validated += ValidatedFloat;
            // 
            // textNumberOfCars
            // 
            textNumberOfCars.Location = new Point(559, 358);
            textNumberOfCars.Name = "textNumberOfCars";
            textNumberOfCars.Size = new Size(250, 47);
            textNumberOfCars.TabIndex = 11;
            textNumberOfCars.TextChanged += EnableButtonsWhenTextChanged;
            textNumberOfCars.TextChanged += TextChangedInt;
            textNumberOfCars.Validated += ValidatedInt;
            textNumberOfCars.Validating += ValidatingInt;
            // 
            // textReservationCheckInterval
            // 
            textReservationCheckInterval.Location = new Point(559, 479);
            textReservationCheckInterval.Name = "textReservationCheckInterval";
            textReservationCheckInterval.Size = new Size(250, 47);
            textReservationCheckInterval.TabIndex = 12;
            textReservationCheckInterval.TextChanged += EnableButtonsWhenTextChanged;
            textReservationCheckInterval.TextChanged += TextChangedInt;
            textReservationCheckInterval.Validated += ValidatedInt;
            textReservationCheckInterval.Validating += ValidatingInt;
            // 
            // textPhoneNumber
            // 
            textPhoneNumber.Location = new Point(559, 600);
            textPhoneNumber.Name = "textPhoneNumber";
            textPhoneNumber.Size = new Size(250, 47);
            textPhoneNumber.TabIndex = 13;
            textPhoneNumber.TextChanged += EnableButtonsWhenTextChanged;
            // 
            // textMinPriceForShortTrips
            // 
            textMinPriceForShortTrips.Location = new Point(1462, 124);
            textMinPriceForShortTrips.Name = "textMinPriceForShortTrips";
            textMinPriceForShortTrips.Size = new Size(250, 47);
            textMinPriceForShortTrips.TabIndex = 14;
            textMinPriceForShortTrips.TextChanged += EnableButtonsWhenTextChanged;
            textMinPriceForShortTrips.TextChanged += TextChangedInt;
            textMinPriceForShortTrips.Validated += ValidatedInt;
            textMinPriceForShortTrips.Validating += ValidatingInt;
            // 
            // textShortTripDistanceThreshold
            // 
            textShortTripDistanceThreshold.Location = new Point(1462, 239);
            textShortTripDistanceThreshold.Name = "textShortTripDistanceThreshold";
            textShortTripDistanceThreshold.Size = new Size(250, 47);
            textShortTripDistanceThreshold.TabIndex = 15;
            textShortTripDistanceThreshold.TextChanged += EnableButtonsWhenTextChanged;
            textShortTripDistanceThreshold.TextChanged += TextChangedInt;
            textShortTripDistanceThreshold.Validated += ValidatedInt;
            textShortTripDistanceThreshold.Validating += ValidatingInt;
            // 
            // textStartBusinessHour
            // 
            textStartBusinessHour.Location = new Point(1462, 358);
            textStartBusinessHour.Name = "textStartBusinessHour";
            textStartBusinessHour.Size = new Size(250, 47);
            textStartBusinessHour.TabIndex = 16;
            textStartBusinessHour.TextChanged += EnableButtonsWhenTextChanged;
            textStartBusinessHour.TextChanged += StartBusinessHourTextChanged;
            textStartBusinessHour.TextChanged += EndBusinessHourTextChanged;
            textStartBusinessHour.Validated += StartBusinessHourValidated;
            textStartBusinessHour.Validating += StartBusinessHourValidating;
            // 
            // textEndBusinessHour
            // 
            textEndBusinessHour.Location = new Point(1462, 479);
            textEndBusinessHour.Name = "textEndBusinessHour";
            textEndBusinessHour.Size = new Size(250, 47);
            textEndBusinessHour.TabIndex = 17;
            textEndBusinessHour.TextChanged += EnableButtonsWhenTextChanged;
            textEndBusinessHour.TextChanged += EndBusinessHourTextChanged;
            textEndBusinessHour.TextChanged += StartBusinessHourTextChanged;
            textEndBusinessHour.Validated += EndBusinessHourValidated;
            textEndBusinessHour.Validating += EndBusinessHourValidating;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(1031, 634);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(218, 110);
            buttonSave.TabIndex = 18;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(1424, 634);
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
            errorLabelMinAcceptablePrice.Location = new Point(450, 181);
            errorLabelMinAcceptablePrice.Name = "errorLabelMinAcceptablePrice";
            errorLabelMinAcceptablePrice.Size = new Size(0, 41);
            errorLabelMinAcceptablePrice.TabIndex = 20;
            // 
            // errorLabelMinPricePerKm
            // 
            errorLabelMinPricePerKm.AutoSize = true;
            errorLabelMinPricePerKm.Location = new Point(450, 303);
            errorLabelMinPricePerKm.Name = "errorLabelMinPricePerKm";
            errorLabelMinPricePerKm.Size = new Size(0, 41);
            errorLabelMinPricePerKm.TabIndex = 21;
            // 
            // errorLabelNumberOfCars
            // 
            errorLabelNumberOfCars.AutoSize = true;
            errorLabelNumberOfCars.Location = new Point(450, 415);
            errorLabelNumberOfCars.Name = "errorLabelNumberOfCars";
            errorLabelNumberOfCars.Size = new Size(0, 41);
            errorLabelNumberOfCars.TabIndex = 22;
            // 
            // errorLabelReservationCheckInterval
            // 
            errorLabelReservationCheckInterval.AutoSize = true;
            errorLabelReservationCheckInterval.Location = new Point(450, 544);
            errorLabelReservationCheckInterval.Name = "errorLabelReservationCheckInterval";
            errorLabelReservationCheckInterval.Size = new Size(0, 41);
            errorLabelReservationCheckInterval.TabIndex = 23;
            // 
            // errorLabelPhoneNumber
            // 
            errorLabelPhoneNumber.AutoSize = true;
            errorLabelPhoneNumber.Location = new Point(450, 669);
            errorLabelPhoneNumber.Name = "errorLabelPhoneNumber";
            errorLabelPhoneNumber.Size = new Size(0, 41);
            errorLabelPhoneNumber.TabIndex = 24;
            // 
            // errorLabelMinPriceForShortTrips
            // 
            errorLabelMinPriceForShortTrips.AutoSize = true;
            errorLabelMinPriceForShortTrips.Location = new Point(1350, 181);
            errorLabelMinPriceForShortTrips.Name = "errorLabelMinPriceForShortTrips";
            errorLabelMinPriceForShortTrips.Size = new Size(0, 41);
            errorLabelMinPriceForShortTrips.TabIndex = 25;
            // 
            // errorLabelShortTripDistanceThreshold
            // 
            errorLabelShortTripDistanceThreshold.AutoSize = true;
            errorLabelShortTripDistanceThreshold.Location = new Point(1350, 303);
            errorLabelShortTripDistanceThreshold.Name = "errorLabelShortTripDistanceThreshold";
            errorLabelShortTripDistanceThreshold.Size = new Size(0, 41);
            errorLabelShortTripDistanceThreshold.TabIndex = 26;
            // 
            // errorLabelStartBusinessHour
            // 
            errorLabelStartBusinessHour.AutoSize = true;
            errorLabelStartBusinessHour.Location = new Point(1350, 415);
            errorLabelStartBusinessHour.Name = "errorLabelStartBusinessHour";
            errorLabelStartBusinessHour.Size = new Size(0, 41);
            errorLabelStartBusinessHour.TabIndex = 27;
            // 
            // errorLabelEndBusinessHour
            // 
            errorLabelEndBusinessHour.AutoSize = true;
            errorLabelEndBusinessHour.Location = new Point(1350, 544);
            errorLabelEndBusinessHour.Name = "errorLabelEndBusinessHour";
            errorLabelEndBusinessHour.Size = new Size(0, 41);
            errorLabelEndBusinessHour.TabIndex = 28;
            // 
            // ConfigForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            ClientSize = new Size(1942, 852);
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
    }
}
