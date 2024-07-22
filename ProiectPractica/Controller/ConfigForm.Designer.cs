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
            textMinAcceptablePrice.TextChanged += EnableButtonsWhenTextChanged;
            // 
            // textMinPricePerKm
            // 
            textMinPricePerKm.Location = new Point(559, 239);
            textMinPricePerKm.Name = "textMinPricePerKm";
            textMinPricePerKm.Size = new Size(250, 47);
            textMinPricePerKm.TabIndex = 10;
            textMinPricePerKm.TextChanged += EnableButtonsWhenTextChanged;
            // 
            // textNumberOfCars
            // 
            textNumberOfCars.Location = new Point(559, 358);
            textNumberOfCars.Name = "textNumberOfCars";
            textNumberOfCars.Size = new Size(250, 47);
            textNumberOfCars.TabIndex = 11;
            textNumberOfCars.TextChanged += EnableButtonsWhenTextChanged;
            // 
            // textReservationCheckInterval
            // 
            textReservationCheckInterval.Location = new Point(559, 479);
            textReservationCheckInterval.Name = "textReservationCheckInterval";
            textReservationCheckInterval.Size = new Size(250, 47);
            textReservationCheckInterval.TabIndex = 12;
            textReservationCheckInterval.TextChanged += EnableButtonsWhenTextChanged;
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
            // 
            // textShortTripDistanceThreshold
            // 
            textShortTripDistanceThreshold.Location = new Point(1462, 239);
            textShortTripDistanceThreshold.Name = "textShortTripDistanceThreshold";
            textShortTripDistanceThreshold.Size = new Size(250, 47);
            textShortTripDistanceThreshold.TabIndex = 15;
            textShortTripDistanceThreshold.TextChanged += EnableButtonsWhenTextChanged;
            // 
            // textStartBusinessHour
            // 
            textStartBusinessHour.Location = new Point(1462, 358);
            textStartBusinessHour.Name = "textStartBusinessHour";
            textStartBusinessHour.Size = new Size(250, 47);
            textStartBusinessHour.TabIndex = 16;
            textStartBusinessHour.TextChanged += EnableButtonsWhenTextChanged;
            // 
            // textEndBusinessHour
            // 
            textEndBusinessHour.Location = new Point(1462, 479);
            textEndBusinessHour.Name = "textEndBusinessHour";
            textEndBusinessHour.Size = new Size(250, 47);
            textEndBusinessHour.TabIndex = 17;
            textEndBusinessHour.TextChanged += EnableButtonsWhenTextChanged;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(1029, 600);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(218, 110);
            buttonSave.TabIndex = 18;
            buttonSave.Text = "Save";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonReset
            // 
            buttonReset.Location = new Point(1419, 600);
            buttonReset.Name = "buttonReset";
            buttonReset.Size = new Size(218, 110);
            buttonReset.TabIndex = 19;
            buttonReset.Text = "Reset";
            buttonReset.UseVisualStyleBackColor = true;
            buttonReset.Click += buttonReset_Click;
            // 
            // ConfigForm
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1863, 785);
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
    }
}
