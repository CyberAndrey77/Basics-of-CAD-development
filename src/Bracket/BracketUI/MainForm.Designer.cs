
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openDrawingButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // plateWidthTextBox
            // 
            this.plateWidthTextBox.Location = new System.Drawing.Point(216, 12);
            this.plateWidthTextBox.Name = "plateWidthTextBox";
            this.plateWidthTextBox.Size = new System.Drawing.Size(100, 22);
            this.plateWidthTextBox.TabIndex = 0;
            this.plateWidthTextBox.Click += new System.EventHandler(this.textBox_Click);
            this.plateWidthTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // plateWidthLabel
            // 
            this.plateWidthLabel.AutoSize = true;
            this.plateWidthLabel.Location = new System.Drawing.Point(12, 15);
            this.plateWidthLabel.Name = "plateWidthLabel";
            this.plateWidthLabel.Size = new System.Drawing.Size(80, 17);
            this.plateWidthLabel.TabIndex = 1;
            this.plateWidthLabel.Text = "Plate Width";
            // 
            // plateLengthLabel
            // 
            this.plateLengthLabel.AutoSize = true;
            this.plateLengthLabel.Location = new System.Drawing.Point(10, 65);
            this.plateLengthLabel.Name = "plateLengthLabel";
            this.plateLengthLabel.Size = new System.Drawing.Size(88, 17);
            this.plateLengthLabel.TabIndex = 2;
            this.plateLengthLabel.Text = "Plate Length";
            // 
            // plateLengthTextBox
            // 
            this.plateLengthTextBox.Location = new System.Drawing.Point(216, 62);
            this.plateLengthTextBox.Name = "plateLengthTextBox";
            this.plateLengthTextBox.Size = new System.Drawing.Size(100, 22);
            this.plateLengthTextBox.TabIndex = 3;
            this.plateLengthTextBox.Click += new System.EventHandler(this.textBox_Click);
            this.plateLengthTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // outerTubeDiameterTextBox
            // 
            this.outerTubeDiameterTextBox.Location = new System.Drawing.Point(216, 112);
            this.outerTubeDiameterTextBox.Name = "outerTubeDiameterTextBox";
            this.outerTubeDiameterTextBox.Size = new System.Drawing.Size(100, 22);
            this.outerTubeDiameterTextBox.TabIndex = 4;
            this.outerTubeDiameterTextBox.Click += new System.EventHandler(this.textBox_Click);
            this.outerTubeDiameterTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // outerTubeDiameterLabel
            // 
            this.outerTubeDiameterLabel.AutoSize = true;
            this.outerTubeDiameterLabel.Location = new System.Drawing.Point(10, 115);
            this.outerTubeDiameterLabel.Name = "outerTubeDiameterLabel";
            this.outerTubeDiameterLabel.Size = new System.Drawing.Size(142, 17);
            this.outerTubeDiameterLabel.TabIndex = 5;
            this.outerTubeDiameterLabel.Text = "Outer Tube Diameter";
            // 
            // mountingHoleDiameterLabel
            // 
            this.mountingHoleDiameterLabel.AutoSize = true;
            this.mountingHoleDiameterLabel.Location = new System.Drawing.Point(10, 165);
            this.mountingHoleDiameterLabel.Name = "mountingHoleDiameterLabel";
            this.mountingHoleDiameterLabel.Size = new System.Drawing.Size(160, 17);
            this.mountingHoleDiameterLabel.TabIndex = 6;
            this.mountingHoleDiameterLabel.Text = "Mounting Hole Diameter";
            // 
            // mountingHoleDiameterTextBox
            // 
            this.mountingHoleDiameterTextBox.Location = new System.Drawing.Point(216, 162);
            this.mountingHoleDiameterTextBox.Name = "mountingHoleDiameterTextBox";
            this.mountingHoleDiameterTextBox.Size = new System.Drawing.Size(100, 22);
            this.mountingHoleDiameterTextBox.TabIndex = 7;
            this.mountingHoleDiameterTextBox.Click += new System.EventHandler(this.textBox_Click);
            this.mountingHoleDiameterTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // holeHeightTextBox
            // 
            this.holeHeightTextBox.Location = new System.Drawing.Point(216, 212);
            this.holeHeightTextBox.Name = "holeHeightTextBox";
            this.holeHeightTextBox.Size = new System.Drawing.Size(100, 22);
            this.holeHeightTextBox.TabIndex = 9;
            this.holeHeightTextBox.Click += new System.EventHandler(this.textBox_Click);
            this.holeHeightTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // holeHeightLabel
            // 
            this.holeHeightLabel.AutoSize = true;
            this.holeHeightLabel.Location = new System.Drawing.Point(12, 215);
            this.holeHeightLabel.Name = "holeHeightLabel";
            this.holeHeightLabel.Size = new System.Drawing.Size(82, 17);
            this.holeHeightLabel.TabIndex = 8;
            this.holeHeightLabel.Text = "Hole Height";
            // 
            // sideWallHeightTextBox
            // 
            this.sideWallHeightTextBox.Location = new System.Drawing.Point(216, 262);
            this.sideWallHeightTextBox.Name = "sideWallHeightTextBox";
            this.sideWallHeightTextBox.Size = new System.Drawing.Size(100, 22);
            this.sideWallHeightTextBox.TabIndex = 11;
            this.sideWallHeightTextBox.Click += new System.EventHandler(this.textBox_Click);
            this.sideWallHeightTextBox.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // sideWallHeightLabel
            // 
            this.sideWallHeightLabel.AutoSize = true;
            this.sideWallHeightLabel.Location = new System.Drawing.Point(12, 265);
            this.sideWallHeightLabel.Name = "sideWallHeightLabel";
            this.sideWallHeightLabel.Size = new System.Drawing.Size(112, 17);
            this.sideWallHeightLabel.TabIndex = 10;
            this.sideWallHeightLabel.Text = "Side Wall Height";
            // 
            // buildButton
            // 
            this.buildButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buildButton.Location = new System.Drawing.Point(540, 251);
            this.buildButton.Name = "buildButton";
            this.buildButton.Size = new System.Drawing.Size(114, 35);
            this.buildButton.TabIndex = 12;
            this.buildButton.Text = "Build";
            this.buildButton.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(365, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(289, 222);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // openDrawingButton
            // 
            this.openDrawingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.openDrawingButton.Location = new System.Drawing.Point(365, 251);
            this.openDrawingButton.Name = "openDrawingButton";
            this.openDrawingButton.Size = new System.Drawing.Size(114, 35);
            this.openDrawingButton.TabIndex = 14;
            this.openDrawingButton.Text = "Open drawing";
            this.openDrawingButton.UseVisualStyleBackColor = true;
            this.openDrawingButton.Click += new System.EventHandler(this.openDrawingButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 298);
            this.Controls.Add(this.openDrawingButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buildButton);
            this.Controls.Add(this.sideWallHeightTextBox);
            this.Controls.Add(this.sideWallHeightLabel);
            this.Controls.Add(this.holeHeightTextBox);
            this.Controls.Add(this.holeHeightLabel);
            this.Controls.Add(this.mountingHoleDiameterTextBox);
            this.Controls.Add(this.mountingHoleDiameterLabel);
            this.Controls.Add(this.outerTubeDiameterLabel);
            this.Controls.Add(this.outerTubeDiameterTextBox);
            this.Controls.Add(this.plateLengthTextBox);
            this.Controls.Add(this.plateLengthLabel);
            this.Controls.Add(this.plateWidthLabel);
            this.Controls.Add(this.plateWidthTextBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(684, 345);
            this.MinimumSize = new System.Drawing.Size(684, 345);
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
    }
}

