﻿
namespace BracketUI
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.plateWidthTextBox = new System.Windows.Forms.TextBox();
            this.plateWidthLabel = new System.Windows.Forms.Label();
            this.plateLengthLabel = new System.Windows.Forms.Label();
            this.plateLengthTextBox = new System.Windows.Forms.TextBox();
            this.outerTubeDiameterTextBox = new System.Windows.Forms.TextBox();
            this.outerTubeDiameterLabel = new System.Windows.Forms.Label();
            this.mountingHoleDiameterLabel = new System.Windows.Forms.Label();
            this.mountingHoleDiameterTextBox = new System.Windows.Forms.TextBox();
            this.holeHeightTextBox = new System.Windows.Forms.TextBox();
            this.holeHeightLabel = new System.Windows.Forms.Label();
            this.sideWallHeightTextBox = new System.Windows.Forms.TextBox();
            this.sideWallHeightLabel = new System.Windows.Forms.Label();
            this.buildButton = new System.Windows.Forms.Button();
            this.openDrawingButton = new System.Windows.Forms.Button();
            this.minMaxPlateWidthLabel = new System.Windows.Forms.Label();
            this.minMaxPlateLengthLabel = new System.Windows.Forms.Label();
            this.minMaxOuterTubeDiameterLabel = new System.Windows.Forms.Label();
            this.minMaxMountingHoleDiameterLabel = new System.Windows.Forms.Label();
            this.minMaxHoleHeightLabel = new System.Windows.Forms.Label();
            this.minMaxSideWallHeightLabel = new System.Windows.Forms.Label();
            this.minMaxPlaneThicknessLabel = new System.Windows.Forms.Label();
            this.planeThicknessLabel = new System.Windows.Forms.Label();
            this.planeThicknessTextBox = new System.Windows.Forms.TextBox();
            this.minMaxTubeHieghtLabel = new System.Windows.Forms.Label();
            this.tubeHeightLabel = new System.Windows.Forms.Label();
            this.tubeHeightTextBox = new System.Windows.Forms.TextBox();
            this.minMaxDistanceFromWallLabel = new System.Windows.Forms.Label();
            this.distanceFromWallLabel = new System.Windows.Forms.Label();
            this.distanceFromWallTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // plateWidthTextBox
            // 
            this.plateWidthTextBox.Location = new System.Drawing.Point(207, 12);
            this.plateWidthTextBox.Name = "plateWidthTextBox";
            this.plateWidthTextBox.Size = new System.Drawing.Size(100, 22);
            this.plateWidthTextBox.TabIndex = 0;
            this.plateWidthTextBox.Click += new System.EventHandler(this.TextBox_Click);
            this.plateWidthTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // plateWidthLabel
            // 
            this.plateWidthLabel.AutoSize = true;
            this.plateWidthLabel.Location = new System.Drawing.Point(12, 15);
            this.plateWidthLabel.Name = "plateWidthLabel";
            this.plateWidthLabel.Size = new System.Drawing.Size(103, 17);
            this.plateWidthLabel.TabIndex = 1;
            this.plateWidthLabel.Text = "Plate Width (A)";
            // 
            // plateLengthLabel
            // 
            this.plateLengthLabel.AutoSize = true;
            this.plateLengthLabel.Location = new System.Drawing.Point(12, 56);
            this.plateLengthLabel.Name = "plateLengthLabel";
            this.plateLengthLabel.Size = new System.Drawing.Size(111, 17);
            this.plateLengthLabel.TabIndex = 2;
            this.plateLengthLabel.Text = "Plate Length (B)";
            // 
            // plateLengthTextBox
            // 
            this.plateLengthTextBox.Location = new System.Drawing.Point(207, 53);
            this.plateLengthTextBox.Name = "plateLengthTextBox";
            this.plateLengthTextBox.Size = new System.Drawing.Size(100, 22);
            this.plateLengthTextBox.TabIndex = 3;
            this.plateLengthTextBox.Click += new System.EventHandler(this.TextBox_Click);
            this.plateLengthTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // outerTubeDiameterTextBox
            // 
            this.outerTubeDiameterTextBox.Location = new System.Drawing.Point(207, 94);
            this.outerTubeDiameterTextBox.Name = "outerTubeDiameterTextBox";
            this.outerTubeDiameterTextBox.Size = new System.Drawing.Size(100, 22);
            this.outerTubeDiameterTextBox.TabIndex = 4;
            this.outerTubeDiameterTextBox.Click += new System.EventHandler(this.TextBox_Click);
            this.outerTubeDiameterTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // outerTubeDiameterLabel
            // 
            this.outerTubeDiameterLabel.AutoSize = true;
            this.outerTubeDiameterLabel.Location = new System.Drawing.Point(12, 97);
            this.outerTubeDiameterLabel.Name = "outerTubeDiameterLabel";
            this.outerTubeDiameterLabel.Size = new System.Drawing.Size(165, 17);
            this.outerTubeDiameterLabel.TabIndex = 5;
            this.outerTubeDiameterLabel.Text = "Outer Tube Diameter (C)";
            // 
            // mountingHoleDiameterLabel
            // 
            this.mountingHoleDiameterLabel.AutoSize = true;
            this.mountingHoleDiameterLabel.Location = new System.Drawing.Point(12, 138);
            this.mountingHoleDiameterLabel.Name = "mountingHoleDiameterLabel";
            this.mountingHoleDiameterLabel.Size = new System.Drawing.Size(170, 17);
            this.mountingHoleDiameterLabel.TabIndex = 6;
            this.mountingHoleDiameterLabel.Text = "Mounting Hole Radius (E)";
            // 
            // mountingHoleDiameterTextBox
            // 
            this.mountingHoleDiameterTextBox.Location = new System.Drawing.Point(207, 135);
            this.mountingHoleDiameterTextBox.Name = "mountingHoleDiameterTextBox";
            this.mountingHoleDiameterTextBox.Size = new System.Drawing.Size(100, 22);
            this.mountingHoleDiameterTextBox.TabIndex = 7;
            this.mountingHoleDiameterTextBox.Click += new System.EventHandler(this.TextBox_Click);
            this.mountingHoleDiameterTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // holeHeightTextBox
            // 
            this.holeHeightTextBox.Location = new System.Drawing.Point(207, 176);
            this.holeHeightTextBox.Name = "holeHeightTextBox";
            this.holeHeightTextBox.Size = new System.Drawing.Size(100, 22);
            this.holeHeightTextBox.TabIndex = 9;
            this.holeHeightTextBox.Click += new System.EventHandler(this.TextBox_Click);
            this.holeHeightTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // holeHeightLabel
            // 
            this.holeHeightLabel.AutoSize = true;
            this.holeHeightLabel.Location = new System.Drawing.Point(12, 179);
            this.holeHeightLabel.Name = "holeHeightLabel";
            this.holeHeightLabel.Size = new System.Drawing.Size(106, 17);
            this.holeHeightLabel.TabIndex = 8;
            this.holeHeightLabel.Text = "Hole Height (D)";
            // 
            // sideWallHeightTextBox
            // 
            this.sideWallHeightTextBox.Location = new System.Drawing.Point(207, 217);
            this.sideWallHeightTextBox.Name = "sideWallHeightTextBox";
            this.sideWallHeightTextBox.Size = new System.Drawing.Size(100, 22);
            this.sideWallHeightTextBox.TabIndex = 11;
            this.sideWallHeightTextBox.Click += new System.EventHandler(this.TextBox_Click);
            this.sideWallHeightTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // sideWallHeightLabel
            // 
            this.sideWallHeightLabel.AutoSize = true;
            this.sideWallHeightLabel.Location = new System.Drawing.Point(12, 220);
            this.sideWallHeightLabel.Name = "sideWallHeightLabel";
            this.sideWallHeightLabel.Size = new System.Drawing.Size(134, 17);
            this.sideWallHeightLabel.TabIndex = 10;
            this.sideWallHeightLabel.Text = "Side Wall Height (F)";
            // 
            // buildButton
            // 
            this.buildButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buildButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buildButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buildButton.Location = new System.Drawing.Point(706, 322);
            this.buildButton.Name = "buildButton";
            this.buildButton.Size = new System.Drawing.Size(114, 35);
            this.buildButton.TabIndex = 12;
            this.buildButton.Text = "Build";
            this.buildButton.UseVisualStyleBackColor = true;
            this.buildButton.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // openDrawingButton
            // 
            this.openDrawingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.openDrawingButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openDrawingButton.Location = new System.Drawing.Point(497, 322);
            this.openDrawingButton.Name = "openDrawingButton";
            this.openDrawingButton.Size = new System.Drawing.Size(114, 35);
            this.openDrawingButton.TabIndex = 14;
            this.openDrawingButton.Text = "Open drawing";
            this.openDrawingButton.UseVisualStyleBackColor = true;
            this.openDrawingButton.Click += new System.EventHandler(this.OpenDrawingButton_Click);
            // 
            // minMaxPlateWidthLabel
            // 
            this.minMaxPlateWidthLabel.AutoSize = true;
            this.minMaxPlateWidthLabel.Location = new System.Drawing.Point(325, 15);
            this.minMaxPlateWidthLabel.Name = "minMaxPlateWidthLabel";
            this.minMaxPlateWidthLabel.Size = new System.Drawing.Size(46, 17);
            this.minMaxPlateWidthLabel.TabIndex = 15;
            this.minMaxPlateWidthLabel.Text = "label1";
            // 
            // minMaxPlateLengthLabel
            // 
            this.minMaxPlateLengthLabel.AutoSize = true;
            this.minMaxPlateLengthLabel.Location = new System.Drawing.Point(325, 56);
            this.minMaxPlateLengthLabel.Name = "minMaxPlateLengthLabel";
            this.minMaxPlateLengthLabel.Size = new System.Drawing.Size(46, 17);
            this.minMaxPlateLengthLabel.TabIndex = 16;
            this.minMaxPlateLengthLabel.Text = "label1";
            // 
            // minMaxOuterTubeDiameterLabel
            // 
            this.minMaxOuterTubeDiameterLabel.AutoSize = true;
            this.minMaxOuterTubeDiameterLabel.Location = new System.Drawing.Point(325, 97);
            this.minMaxOuterTubeDiameterLabel.Name = "minMaxOuterTubeDiameterLabel";
            this.minMaxOuterTubeDiameterLabel.Size = new System.Drawing.Size(46, 17);
            this.minMaxOuterTubeDiameterLabel.TabIndex = 17;
            this.minMaxOuterTubeDiameterLabel.Text = "label1";
            // 
            // minMaxMountingHoleDiameterLabel
            // 
            this.minMaxMountingHoleDiameterLabel.AutoSize = true;
            this.minMaxMountingHoleDiameterLabel.Location = new System.Drawing.Point(325, 138);
            this.minMaxMountingHoleDiameterLabel.Name = "minMaxMountingHoleDiameterLabel";
            this.minMaxMountingHoleDiameterLabel.Size = new System.Drawing.Size(46, 17);
            this.minMaxMountingHoleDiameterLabel.TabIndex = 18;
            this.minMaxMountingHoleDiameterLabel.Text = "label1";
            // 
            // minMaxHoleHeightLabel
            // 
            this.minMaxHoleHeightLabel.AutoSize = true;
            this.minMaxHoleHeightLabel.Location = new System.Drawing.Point(325, 179);
            this.minMaxHoleHeightLabel.Name = "minMaxHoleHeightLabel";
            this.minMaxHoleHeightLabel.Size = new System.Drawing.Size(46, 17);
            this.minMaxHoleHeightLabel.TabIndex = 19;
            this.minMaxHoleHeightLabel.Text = "label1";
            // 
            // minMaxSideWallHeightLabel
            // 
            this.minMaxSideWallHeightLabel.AutoSize = true;
            this.minMaxSideWallHeightLabel.Location = new System.Drawing.Point(325, 220);
            this.minMaxSideWallHeightLabel.Name = "minMaxSideWallHeightLabel";
            this.minMaxSideWallHeightLabel.Size = new System.Drawing.Size(46, 17);
            this.minMaxSideWallHeightLabel.TabIndex = 20;
            this.minMaxSideWallHeightLabel.Text = "label1";
            // 
            // minMaxPlaneThicknessLabel
            // 
            this.minMaxPlaneThicknessLabel.AutoSize = true;
            this.minMaxPlaneThicknessLabel.Location = new System.Drawing.Point(325, 260);
            this.minMaxPlaneThicknessLabel.Name = "minMaxPlaneThicknessLabel";
            this.minMaxPlaneThicknessLabel.Size = new System.Drawing.Size(46, 17);
            this.minMaxPlaneThicknessLabel.TabIndex = 23;
            this.minMaxPlaneThicknessLabel.Text = "label1";
            // 
            // planeThicknessLabel
            // 
            this.planeThicknessLabel.AutoSize = true;
            this.planeThicknessLabel.Location = new System.Drawing.Point(12, 260);
            this.planeThicknessLabel.Name = "planeThicknessLabel";
            this.planeThicknessLabel.Size = new System.Drawing.Size(137, 17);
            this.planeThicknessLabel.TabIndex = 21;
            this.planeThicknessLabel.Text = "Plane Thickness (G)";
            // 
            // planeThicknessTextBox
            // 
            this.planeThicknessTextBox.Location = new System.Drawing.Point(207, 257);
            this.planeThicknessTextBox.Name = "planeThicknessTextBox";
            this.planeThicknessTextBox.Size = new System.Drawing.Size(100, 22);
            this.planeThicknessTextBox.TabIndex = 22;
            this.planeThicknessTextBox.Click += new System.EventHandler(this.TextBox_Click);
            this.planeThicknessTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // minMaxTubeHieghtLabel
            // 
            this.minMaxTubeHieghtLabel.AutoSize = true;
            this.minMaxTubeHieghtLabel.Location = new System.Drawing.Point(325, 298);
            this.minMaxTubeHieghtLabel.Name = "minMaxTubeHieghtLabel";
            this.minMaxTubeHieghtLabel.Size = new System.Drawing.Size(46, 17);
            this.minMaxTubeHieghtLabel.TabIndex = 26;
            this.minMaxTubeHieghtLabel.Text = "label1";
            // 
            // tubeHeightLabel
            // 
            this.tubeHeightLabel.AutoSize = true;
            this.tubeHeightLabel.Location = new System.Drawing.Point(12, 298);
            this.tubeHeightLabel.Name = "tubeHeightLabel";
            this.tubeHeightLabel.Size = new System.Drawing.Size(110, 17);
            this.tubeHeightLabel.TabIndex = 24;
            this.tubeHeightLabel.Text = "Tube Height (H)";
            // 
            // tubeHeightTextBox
            // 
            this.tubeHeightTextBox.Location = new System.Drawing.Point(207, 295);
            this.tubeHeightTextBox.Name = "tubeHeightTextBox";
            this.tubeHeightTextBox.Size = new System.Drawing.Size(100, 22);
            this.tubeHeightTextBox.TabIndex = 25;
            this.tubeHeightTextBox.Click += new System.EventHandler(this.TextBox_Click);
            this.tubeHeightTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // minMaxDistanceFromWallLabel
            // 
            this.minMaxDistanceFromWallLabel.AutoSize = true;
            this.minMaxDistanceFromWallLabel.Location = new System.Drawing.Point(325, 335);
            this.minMaxDistanceFromWallLabel.Name = "minMaxDistanceFromWallLabel";
            this.minMaxDistanceFromWallLabel.Size = new System.Drawing.Size(46, 17);
            this.minMaxDistanceFromWallLabel.TabIndex = 29;
            this.minMaxDistanceFromWallLabel.Text = "label1";
            // 
            // distanceFromWallLabel
            // 
            this.distanceFromWallLabel.AutoSize = true;
            this.distanceFromWallLabel.Location = new System.Drawing.Point(12, 335);
            this.distanceFromWallLabel.Name = "distanceFromWallLabel";
            this.distanceFromWallLabel.Size = new System.Drawing.Size(147, 17);
            this.distanceFromWallLabel.TabIndex = 27;
            this.distanceFromWallLabel.Text = "Distance From Wall (I)";
            // 
            // distanceFromWallTextBox
            // 
            this.distanceFromWallTextBox.Location = new System.Drawing.Point(207, 332);
            this.distanceFromWallTextBox.Name = "distanceFromWallTextBox";
            this.distanceFromWallTextBox.Size = new System.Drawing.Size(100, 22);
            this.distanceFromWallTextBox.TabIndex = 28;
            this.distanceFromWallTextBox.Click += new System.EventHandler(this.TextBox_Click);
            this.distanceFromWallTextBox.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(497, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(323, 225);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 369);
            this.Controls.Add(this.minMaxDistanceFromWallLabel);
            this.Controls.Add(this.distanceFromWallLabel);
            this.Controls.Add(this.distanceFromWallTextBox);
            this.Controls.Add(this.minMaxTubeHieghtLabel);
            this.Controls.Add(this.tubeHeightLabel);
            this.Controls.Add(this.tubeHeightTextBox);
            this.Controls.Add(this.minMaxPlaneThicknessLabel);
            this.Controls.Add(this.planeThicknessLabel);
            this.Controls.Add(this.planeThicknessTextBox);
            this.Controls.Add(this.openDrawingButton);
            this.Controls.Add(this.plateWidthLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.minMaxSideWallHeightLabel);
            this.Controls.Add(this.buildButton);
            this.Controls.Add(this.sideWallHeightLabel);
            this.Controls.Add(this.plateWidthTextBox);
            this.Controls.Add(this.sideWallHeightTextBox);
            this.Controls.Add(this.minMaxHoleHeightLabel);
            this.Controls.Add(this.holeHeightTextBox);
            this.Controls.Add(this.plateLengthLabel);
            this.Controls.Add(this.holeHeightLabel);
            this.Controls.Add(this.minMaxMountingHoleDiameterLabel);
            this.Controls.Add(this.mountingHoleDiameterTextBox);
            this.Controls.Add(this.plateLengthTextBox);
            this.Controls.Add(this.mountingHoleDiameterLabel);
            this.Controls.Add(this.minMaxOuterTubeDiameterLabel);
            this.Controls.Add(this.minMaxPlateWidthLabel);
            this.Controls.Add(this.outerTubeDiameterTextBox);
            this.Controls.Add(this.outerTubeDiameterLabel);
            this.Controls.Add(this.minMaxPlateLengthLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "MainFrom";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox plateWidthTextBox;
        private System.Windows.Forms.Label plateWidthLabel;
        private System.Windows.Forms.Label plateLengthLabel;
        private System.Windows.Forms.TextBox plateLengthTextBox;
        private System.Windows.Forms.TextBox outerTubeDiameterTextBox;
        private System.Windows.Forms.Label outerTubeDiameterLabel;
        private System.Windows.Forms.Label mountingHoleDiameterLabel;
        private System.Windows.Forms.TextBox mountingHoleDiameterTextBox;
        private System.Windows.Forms.TextBox holeHeightTextBox;
        private System.Windows.Forms.Label holeHeightLabel;
        private System.Windows.Forms.TextBox sideWallHeightTextBox;
        private System.Windows.Forms.Label sideWallHeightLabel;
        private System.Windows.Forms.Button buildButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button openDrawingButton;
        private System.Windows.Forms.Label minMaxPlateWidthLabel;
        private System.Windows.Forms.Label minMaxPlateLengthLabel;
        private System.Windows.Forms.Label minMaxOuterTubeDiameterLabel;
        private System.Windows.Forms.Label minMaxMountingHoleDiameterLabel;
        private System.Windows.Forms.Label minMaxHoleHeightLabel;
        private System.Windows.Forms.Label minMaxSideWallHeightLabel;
        private System.Windows.Forms.Label minMaxPlaneThicknessLabel;
        private System.Windows.Forms.Label planeThicknessLabel;
        private System.Windows.Forms.TextBox planeThicknessTextBox;
        private System.Windows.Forms.Label minMaxTubeHieghtLabel;
        private System.Windows.Forms.Label tubeHeightLabel;
        private System.Windows.Forms.TextBox tubeHeightTextBox;
        private System.Windows.Forms.Label minMaxDistanceFromWallLabel;
        private System.Windows.Forms.Label distanceFromWallLabel;
        private System.Windows.Forms.TextBox distanceFromWallTextBox;
    }
}

