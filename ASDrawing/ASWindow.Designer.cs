namespace ASDrawing
{
    partial class ASWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnCapture = new System.Windows.Forms.Button();
            this.CameraImageBox = new Emgu.CV.UI.ImageBox();
            this.colorSelect = new System.Windows.Forms.ComboBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblEyeProp = new System.Windows.Forms.Label();
            this.eyePropSelect = new System.Windows.Forms.ComboBox();
            this.boxWeight = new System.Windows.Forms.HScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBoxWeight = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnFlipV = new System.Windows.Forms.Button();
            this.btnFlipH = new System.Windows.Forms.Button();
            this.selectBlur = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.kernalSize = new System.Windows.Forms.HScrollBar();
            this.sigmaSize = new System.Windows.Forms.HScrollBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblKernel = new System.Windows.Forms.Label();
            this.lblSigma = new System.Windows.Forms.Label();
            this.chkNormalise = new System.Windows.Forms.CheckBox();
            this.scrollAperture = new System.Windows.Forms.HScrollBar();
            this.lblAperture = new System.Windows.Forms.Label();
            this.lblApertureTitle = new System.Windows.Forms.Label();
            this.chkThreshold = new System.Windows.Forms.CheckBox();
            this.thresholdValue = new System.Windows.Forms.HScrollBar();
            this.scrollFalloff = new System.Windows.Forms.HScrollBar();
            this.lblThresholdTitle = new System.Windows.Forms.Label();
            this.lblFallofTitle = new System.Windows.Forms.Label();
            this.lblFalloffVal = new System.Windows.Forms.Label();
            this.lblThresholdVal = new System.Windows.Forms.Label();
            this.selectType = new System.Windows.Forms.ComboBox();
            this.lblThreshType = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.eyeColor = new System.Windows.Forms.ComboBox();
            this.lblEyeSize = new System.Windows.Forms.Label();
            this.scrollEyeSize = new System.Windows.Forms.HScrollBar();
            ((System.ComponentModel.ISupportInitialize)(this.CameraImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(769, 613);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(173, 29);
            this.btnCapture.TabIndex = 3;
            this.btnCapture.Text = "Start Capture";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // CameraImageBox
            // 
            this.CameraImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CameraImageBox.Location = new System.Drawing.Point(12, 12);
            this.CameraImageBox.Name = "CameraImageBox";
            this.CameraImageBox.Size = new System.Drawing.Size(751, 630);
            this.CameraImageBox.TabIndex = 2;
            this.CameraImageBox.TabStop = false;
            // 
            // colorSelect
            // 
            this.colorSelect.FormattingEnabled = true;
            this.colorSelect.Items.AddRange(new object[] {
            "None",
            "Red",
            "Green",
            "Blue",
            "Yellow"});
            this.colorSelect.Location = new System.Drawing.Point(769, 29);
            this.colorSelect.Name = "colorSelect";
            this.colorSelect.Size = new System.Drawing.Size(173, 21);
            this.colorSelect.TabIndex = 4;
            this.colorSelect.SelectedIndexChanged += new System.EventHandler(this.colorSelect_SelectedIndexChanged);
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(769, 8);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(52, 13);
            this.lblColor.TabIndex = 5;
            this.lblColor.Text = "Box Color";
            // 
            // lblEyeProp
            // 
            this.lblEyeProp.AutoSize = true;
            this.lblEyeProp.Location = new System.Drawing.Point(769, 103);
            this.lblEyeProp.Name = "lblEyeProp";
            this.lblEyeProp.Size = new System.Drawing.Size(55, 13);
            this.lblEyeProp.TabIndex = 6;
            this.lblEyeProp.Text = "Eye Props";
            // 
            // eyePropSelect
            // 
            this.eyePropSelect.FormattingEnabled = true;
            this.eyePropSelect.Items.AddRange(new object[] {
            "None",
            "Squares",
            "Circles"});
            this.eyePropSelect.Location = new System.Drawing.Point(769, 121);
            this.eyePropSelect.Name = "eyePropSelect";
            this.eyePropSelect.Size = new System.Drawing.Size(86, 21);
            this.eyePropSelect.TabIndex = 7;
            this.eyePropSelect.SelectedIndexChanged += new System.EventHandler(this.eyePropSelect_SelectedIndexChanged);
            // 
            // boxWeight
            // 
            this.boxWeight.Location = new System.Drawing.Point(771, 75);
            this.boxWeight.Name = "boxWeight";
            this.boxWeight.Size = new System.Drawing.Size(149, 20);
            this.boxWeight.TabIndex = 8;
            this.boxWeight.Value = 3;
            this.boxWeight.Scroll += new System.Windows.Forms.ScrollEventHandler(this.boxWeight_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(770, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Box Size";
            // 
            // lblBoxWeight
            // 
            this.lblBoxWeight.AutoSize = true;
            this.lblBoxWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBoxWeight.Location = new System.Drawing.Point(926, 74);
            this.lblBoxWeight.Name = "lblBoxWeight";
            this.lblBoxWeight.Size = new System.Drawing.Size(19, 20);
            this.lblBoxWeight.TabIndex = 10;
            this.lblBoxWeight.Text = "3";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(769, 577);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(173, 30);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save Frame";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnFlipV
            // 
            this.btnFlipV.Location = new System.Drawing.Point(769, 531);
            this.btnFlipV.Name = "btnFlipV";
            this.btnFlipV.Size = new System.Drawing.Size(86, 40);
            this.btnFlipV.TabIndex = 12;
            this.btnFlipV.Text = "Flip Vertical";
            this.btnFlipV.UseVisualStyleBackColor = true;
            this.btnFlipV.Click += new System.EventHandler(this.btnFlipV_Click);
            // 
            // btnFlipH
            // 
            this.btnFlipH.Location = new System.Drawing.Point(863, 531);
            this.btnFlipH.Name = "btnFlipH";
            this.btnFlipH.Size = new System.Drawing.Size(79, 40);
            this.btnFlipH.TabIndex = 13;
            this.btnFlipH.Text = "Flip Horizontal";
            this.btnFlipH.UseVisualStyleBackColor = true;
            this.btnFlipH.Click += new System.EventHandler(this.btnFlipH_Click);
            // 
            // selectBlur
            // 
            this.selectBlur.FormattingEnabled = true;
            this.selectBlur.Items.AddRange(new object[] {
            "None",
            "Gaussian",
            "Median",
            "Bilateral",
            "Box",
            "Sobel"});
            this.selectBlur.Location = new System.Drawing.Point(769, 208);
            this.selectBlur.Name = "selectBlur";
            this.selectBlur.Size = new System.Drawing.Size(173, 21);
            this.selectBlur.TabIndex = 14;
            this.selectBlur.SelectedIndexChanged += new System.EventHandler(this.selectBlur_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(769, 190);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Blur";
            // 
            // kernalSize
            // 
            this.kernalSize.Location = new System.Drawing.Point(769, 253);
            this.kernalSize.Maximum = 60;
            this.kernalSize.Minimum = 4;
            this.kernalSize.Name = "kernalSize";
            this.kernalSize.Size = new System.Drawing.Size(149, 20);
            this.kernalSize.TabIndex = 16;
            this.kernalSize.Value = 4;
            this.kernalSize.Scroll += new System.Windows.Forms.ScrollEventHandler(this.kernalSize_Scroll);
            // 
            // sigmaSize
            // 
            this.sigmaSize.Location = new System.Drawing.Point(769, 297);
            this.sigmaSize.Minimum = 1;
            this.sigmaSize.Name = "sigmaSize";
            this.sigmaSize.Size = new System.Drawing.Size(149, 20);
            this.sigmaSize.TabIndex = 17;
            this.sigmaSize.Value = 1;
            this.sigmaSize.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sigmaSize_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(769, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Kernel Size";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(770, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Sigma";
            // 
            // lblKernel
            // 
            this.lblKernel.AutoSize = true;
            this.lblKernel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKernel.Location = new System.Drawing.Point(928, 253);
            this.lblKernel.Name = "lblKernel";
            this.lblKernel.Size = new System.Drawing.Size(19, 20);
            this.lblKernel.TabIndex = 20;
            this.lblKernel.Text = "1";
            // 
            // lblSigma
            // 
            this.lblSigma.AutoSize = true;
            this.lblSigma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSigma.Location = new System.Drawing.Point(928, 297);
            this.lblSigma.Name = "lblSigma";
            this.lblSigma.Size = new System.Drawing.Size(19, 20);
            this.lblSigma.TabIndex = 21;
            this.lblSigma.Text = "1";
            // 
            // chkNormalise
            // 
            this.chkNormalise.AutoSize = true;
            this.chkNormalise.Location = new System.Drawing.Point(771, 370);
            this.chkNormalise.Name = "chkNormalise";
            this.chkNormalise.Size = new System.Drawing.Size(72, 17);
            this.chkNormalise.TabIndex = 22;
            this.chkNormalise.Text = "Normalise";
            this.chkNormalise.UseVisualStyleBackColor = true;
            this.chkNormalise.CheckedChanged += new System.EventHandler(this.chkNormalise_CheckedChanged);
            // 
            // scrollAperture
            // 
            this.scrollAperture.Location = new System.Drawing.Point(769, 344);
            this.scrollAperture.Maximum = 70;
            this.scrollAperture.Minimum = 1;
            this.scrollAperture.Name = "scrollAperture";
            this.scrollAperture.Size = new System.Drawing.Size(149, 20);
            this.scrollAperture.SmallChange = 2;
            this.scrollAperture.TabIndex = 30;
            this.scrollAperture.Value = 1;
            this.scrollAperture.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrollAperture_Scroll);
            // 
            // lblAperture
            // 
            this.lblAperture.AutoSize = true;
            this.lblAperture.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAperture.Location = new System.Drawing.Point(928, 344);
            this.lblAperture.Name = "lblAperture";
            this.lblAperture.Size = new System.Drawing.Size(19, 20);
            this.lblAperture.TabIndex = 24;
            this.lblAperture.Text = "1";
            // 
            // lblApertureTitle
            // 
            this.lblApertureTitle.AutoSize = true;
            this.lblApertureTitle.Location = new System.Drawing.Point(770, 327);
            this.lblApertureTitle.Name = "lblApertureTitle";
            this.lblApertureTitle.Size = new System.Drawing.Size(70, 13);
            this.lblApertureTitle.TabIndex = 25;
            this.lblApertureTitle.Text = "Aperture Size";
            // 
            // chkThreshold
            // 
            this.chkThreshold.AutoSize = true;
            this.chkThreshold.Location = new System.Drawing.Point(869, 370);
            this.chkThreshold.Name = "chkThreshold";
            this.chkThreshold.Size = new System.Drawing.Size(73, 17);
            this.chkThreshold.TabIndex = 26;
            this.chkThreshold.Text = "Threshold";
            this.chkThreshold.UseVisualStyleBackColor = true;
            this.chkThreshold.CheckedChanged += new System.EventHandler(this.chkThreshold_CheckedChanged);
            // 
            // thresholdValue
            // 
            this.thresholdValue.Location = new System.Drawing.Point(769, 457);
            this.thresholdValue.Maximum = 255;
            this.thresholdValue.Minimum = 1;
            this.thresholdValue.Name = "thresholdValue";
            this.thresholdValue.Size = new System.Drawing.Size(131, 20);
            this.thresholdValue.SmallChange = 2;
            this.thresholdValue.TabIndex = 31;
            this.thresholdValue.Value = 70;
            this.thresholdValue.Scroll += new System.Windows.Forms.ScrollEventHandler(this.thresholdValue_Scroll);
            // 
            // scrollFalloff
            // 
            this.scrollFalloff.Location = new System.Drawing.Point(769, 500);
            this.scrollFalloff.Maximum = 255;
            this.scrollFalloff.Minimum = 1;
            this.scrollFalloff.Name = "scrollFalloff";
            this.scrollFalloff.Size = new System.Drawing.Size(131, 20);
            this.scrollFalloff.SmallChange = 2;
            this.scrollFalloff.TabIndex = 32;
            this.scrollFalloff.Value = 255;
            this.scrollFalloff.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrollFalloff_Scroll);
            // 
            // lblThresholdTitle
            // 
            this.lblThresholdTitle.AutoSize = true;
            this.lblThresholdTitle.Location = new System.Drawing.Point(768, 439);
            this.lblThresholdTitle.Name = "lblThresholdTitle";
            this.lblThresholdTitle.Size = new System.Drawing.Size(54, 13);
            this.lblThresholdTitle.TabIndex = 33;
            this.lblThresholdTitle.Text = "Threshold";
            // 
            // lblFallofTitle
            // 
            this.lblFallofTitle.AutoSize = true;
            this.lblFallofTitle.Location = new System.Drawing.Point(770, 482);
            this.lblFallofTitle.Name = "lblFallofTitle";
            this.lblFallofTitle.Size = new System.Drawing.Size(35, 13);
            this.lblFallofTitle.TabIndex = 34;
            this.lblFallofTitle.Text = "Falloff";
            // 
            // lblFalloffVal
            // 
            this.lblFalloffVal.AutoSize = true;
            this.lblFalloffVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFalloffVal.Location = new System.Drawing.Point(907, 500);
            this.lblFalloffVal.Name = "lblFalloffVal";
            this.lblFalloffVal.Size = new System.Drawing.Size(39, 20);
            this.lblFalloffVal.TabIndex = 35;
            this.lblFalloffVal.Text = "255";
            // 
            // lblThresholdVal
            // 
            this.lblThresholdVal.AutoSize = true;
            this.lblThresholdVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThresholdVal.Location = new System.Drawing.Point(908, 458);
            this.lblThresholdVal.Name = "lblThresholdVal";
            this.lblThresholdVal.Size = new System.Drawing.Size(29, 20);
            this.lblThresholdVal.TabIndex = 36;
            this.lblThresholdVal.Text = "70";
            // 
            // selectType
            // 
            this.selectType.FormattingEnabled = true;
            this.selectType.Items.AddRange(new object[] {
            "Binary",
            "Inverted"});
            this.selectType.Location = new System.Drawing.Point(768, 412);
            this.selectType.Name = "selectType";
            this.selectType.Size = new System.Drawing.Size(173, 21);
            this.selectType.TabIndex = 37;
            this.selectType.SelectedIndexChanged += new System.EventHandler(this.selectType_SelectedIndexChanged);
            // 
            // lblThreshType
            // 
            this.lblThreshType.AutoSize = true;
            this.lblThreshType.Location = new System.Drawing.Point(769, 393);
            this.lblThreshType.Name = "lblThreshType";
            this.lblThreshType.Size = new System.Drawing.Size(81, 13);
            this.lblThreshType.TabIndex = 38;
            this.lblThreshType.Text = "Threshold Type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(770, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Eye Size";
            // 
            // eyeColor
            // 
            this.eyeColor.FormattingEnabled = true;
            this.eyeColor.Items.AddRange(new object[] {
            "None",
            "Red",
            "Green",
            "Blue",
            "Yellow",
            "White"});
            this.eyeColor.Location = new System.Drawing.Point(859, 121);
            this.eyeColor.Name = "eyeColor";
            this.eyeColor.Size = new System.Drawing.Size(83, 21);
            this.eyeColor.TabIndex = 40;
            this.eyeColor.SelectedIndexChanged += new System.EventHandler(this.eyeColor_SelectedIndexChanged);
            // 
            // lblEyeSize
            // 
            this.lblEyeSize.AutoSize = true;
            this.lblEyeSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEyeSize.Location = new System.Drawing.Point(926, 163);
            this.lblEyeSize.Name = "lblEyeSize";
            this.lblEyeSize.Size = new System.Drawing.Size(19, 20);
            this.lblEyeSize.TabIndex = 42;
            this.lblEyeSize.Text = "3";
            // 
            // scrollEyeSize
            // 
            this.scrollEyeSize.Location = new System.Drawing.Point(771, 164);
            this.scrollEyeSize.Minimum = 1;
            this.scrollEyeSize.Name = "scrollEyeSize";
            this.scrollEyeSize.Size = new System.Drawing.Size(149, 20);
            this.scrollEyeSize.TabIndex = 41;
            this.scrollEyeSize.Value = 3;
            this.scrollEyeSize.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrollEyeSize_Scroll);
            // 
            // ASWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 654);
            this.Controls.Add(this.lblEyeSize);
            this.Controls.Add(this.scrollEyeSize);
            this.Controls.Add(this.eyeColor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblThreshType);
            this.Controls.Add(this.selectType);
            this.Controls.Add(this.lblThresholdVal);
            this.Controls.Add(this.lblFalloffVal);
            this.Controls.Add(this.lblFallofTitle);
            this.Controls.Add(this.lblThresholdTitle);
            this.Controls.Add(this.scrollFalloff);
            this.Controls.Add(this.thresholdValue);
            this.Controls.Add(this.chkThreshold);
            this.Controls.Add(this.lblApertureTitle);
            this.Controls.Add(this.lblAperture);
            this.Controls.Add(this.scrollAperture);
            this.Controls.Add(this.chkNormalise);
            this.Controls.Add(this.lblSigma);
            this.Controls.Add(this.lblKernel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sigmaSize);
            this.Controls.Add(this.kernalSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selectBlur);
            this.Controls.Add(this.btnFlipH);
            this.Controls.Add(this.btnFlipV);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblBoxWeight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.boxWeight);
            this.Controls.Add(this.eyePropSelect);
            this.Controls.Add(this.lblEyeProp);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.colorSelect);
            this.Controls.Add(this.CameraImageBox);
            this.Controls.Add(this.btnCapture);
            this.Name = "ASWindow";
            this.Text = "OpenCV Image Processing";
            ((System.ComponentModel.ISupportInitialize)(this.CameraImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCapture;
        private Emgu.CV.UI.ImageBox CameraImageBox;
        private System.Windows.Forms.ComboBox colorSelect;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblEyeProp;
        private System.Windows.Forms.ComboBox eyePropSelect;
        private System.Windows.Forms.HScrollBar boxWeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBoxWeight;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnFlipV;
        private System.Windows.Forms.Button btnFlipH;
        private System.Windows.Forms.ComboBox selectBlur;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.HScrollBar kernalSize;
        private System.Windows.Forms.HScrollBar sigmaSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblKernel;
        private System.Windows.Forms.Label lblSigma;
        private System.Windows.Forms.CheckBox chkNormalise;
        private System.Windows.Forms.HScrollBar scrollAperture;
        private System.Windows.Forms.Label lblAperture;
        private System.Windows.Forms.Label lblApertureTitle;
        private System.Windows.Forms.CheckBox chkThreshold;
        private System.Windows.Forms.HScrollBar thresholdValue;
        private System.Windows.Forms.HScrollBar scrollFalloff;
        private System.Windows.Forms.Label lblThresholdTitle;
        private System.Windows.Forms.Label lblFallofTitle;
        private System.Windows.Forms.Label lblFalloffVal;
        private System.Windows.Forms.Label lblThresholdVal;
        private System.Windows.Forms.ComboBox selectType;
        private System.Windows.Forms.Label lblThreshType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox eyeColor;
        private System.Windows.Forms.Label lblEyeSize;
        private System.Windows.Forms.HScrollBar scrollEyeSize;
    }
}

