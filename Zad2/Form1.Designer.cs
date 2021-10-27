
namespace Zad2
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.heightSegmentsInput = new System.Windows.Forms.NumericUpDown();
            this.widthSegmentsInput = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.triangulatedFillColorButton = new System.Windows.Forms.RadioButton();
            this.exactFillColorButton = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.definedNVectorButton = new System.Windows.Forms.RadioButton();
            this.constantNVectorButton = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.animatedLightVersorButton = new System.Windows.Forms.RadioButton();
            this.constLightVersorButton = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.lightColorPictureBox = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.mValueSlider = new System.Windows.Forms.TrackBar();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.objectColorPictureBox = new System.Windows.Forms.PictureBox();
            this.objectColorTextureRadioButton = new System.Windows.Forms.RadioButton();
            this.objectColorSolidRadioButton = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.kdValueSlider = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ksValueSlider = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heightSegmentsInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthSegmentsInput)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lightColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mValueSlider)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kdValueSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksValueSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(650, 650);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.heightSegmentsInput);
            this.groupBox1.Controls.Add(this.widthSegmentsInput);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lightColorPictureBox);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.mValueSlider);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.kdValueSlider);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ksValueSlider);
            this.groupBox1.Location = new System.Drawing.Point(678, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 658);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // heightSegmentsInput
            // 
            this.heightSegmentsInput.Location = new System.Drawing.Point(163, 568);
            this.heightSegmentsInput.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.heightSegmentsInput.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.heightSegmentsInput.Name = "heightSegmentsInput";
            this.heightSegmentsInput.Size = new System.Drawing.Size(72, 27);
            this.heightSegmentsInput.TabIndex = 25;
            this.heightSegmentsInput.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.heightSegmentsInput.ValueChanged += new System.EventHandler(this.heightSegmentsInput_ValueChanged);
            // 
            // widthSegmentsInput
            // 
            this.widthSegmentsInput.Location = new System.Drawing.Point(163, 529);
            this.widthSegmentsInput.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.widthSegmentsInput.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.widthSegmentsInput.Name = "widthSegmentsInput";
            this.widthSegmentsInput.Size = new System.Drawing.Size(72, 27);
            this.widthSegmentsInput.TabIndex = 24;
            this.widthSegmentsInput.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.widthSegmentsInput.ValueChanged += new System.EventHandler(this.widthSegmentsInput_ValueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(24, 570);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(124, 20);
            this.label16.TabIndex = 23;
            this.label16.Text = "Height segments:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(24, 529);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(119, 20);
            this.label15.TabIndex = 22;
            this.label15.Text = "Width segments:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.triangulatedFillColorButton);
            this.panel4.Controls.Add(this.exactFillColorButton);
            this.panel4.Location = new System.Drawing.Point(118, 451);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(254, 63);
            this.panel4.TabIndex = 21;
            // 
            // triangulatedFillColorButton
            // 
            this.triangulatedFillColorButton.AutoSize = true;
            this.triangulatedFillColorButton.Location = new System.Drawing.Point(6, 36);
            this.triangulatedFillColorButton.Name = "triangulatedFillColorButton";
            this.triangulatedFillColorButton.Size = new System.Drawing.Size(111, 24);
            this.triangulatedFillColorButton.TabIndex = 1;
            this.triangulatedFillColorButton.Text = "triangulated";
            this.triangulatedFillColorButton.UseVisualStyleBackColor = true;
            // 
            // exactFillColorButton
            // 
            this.exactFillColorButton.AutoSize = true;
            this.exactFillColorButton.Checked = true;
            this.exactFillColorButton.Location = new System.Drawing.Point(6, 6);
            this.exactFillColorButton.Name = "exactFillColorButton";
            this.exactFillColorButton.Size = new System.Drawing.Size(65, 24);
            this.exactFillColorButton.TabIndex = 0;
            this.exactFillColorButton.TabStop = true;
            this.exactFillColorButton.Text = "exact";
            this.exactFillColorButton.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(24, 459);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 20);
            this.label14.TabIndex = 20;
            this.label14.Text = "Fill color:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.definedNVectorButton);
            this.panel3.Controls.Add(this.constantNVectorButton);
            this.panel3.Location = new System.Drawing.Point(118, 394);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(255, 62);
            this.panel3.TabIndex = 19;
            // 
            // definedNVectorButton
            // 
            this.definedNVectorButton.AutoSize = true;
            this.definedNVectorButton.Enabled = false;
            this.definedNVectorButton.Location = new System.Drawing.Point(6, 33);
            this.definedNVectorButton.Name = "definedNVectorButton";
            this.definedNVectorButton.Size = new System.Drawing.Size(107, 24);
            this.definedNVectorButton.TabIndex = 2;
            this.definedNVectorButton.TabStop = true;
            this.definedNVectorButton.Text = "define own:";
            this.definedNVectorButton.UseVisualStyleBackColor = true;
            // 
            // constantNVectorButton
            // 
            this.constantNVectorButton.AutoSize = true;
            this.constantNVectorButton.Checked = true;
            this.constantNVectorButton.Location = new System.Drawing.Point(6, 3);
            this.constantNVectorButton.Name = "constantNVectorButton";
            this.constantNVectorButton.Size = new System.Drawing.Size(156, 24);
            this.constantNVectorButton.TabIndex = 1;
            this.constantNVectorButton.TabStop = true;
            this.constantNVectorButton.Text = "constant   ([0, 0, 1])";
            this.constantNVectorButton.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 396);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 20);
            this.label13.TabIndex = 18;
            this.label13.Text = "N vector:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.animatedLightVersorButton);
            this.panel2.Controls.Add(this.constLightVersorButton);
            this.panel2.Location = new System.Drawing.Point(118, 332);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(256, 56);
            this.panel2.TabIndex = 17;
            // 
            // animatedLightVersorButton
            // 
            this.animatedLightVersorButton.AutoSize = true;
            this.animatedLightVersorButton.Enabled = false;
            this.animatedLightVersorButton.Location = new System.Drawing.Point(6, 33);
            this.animatedLightVersorButton.Name = "animatedLightVersorButton";
            this.animatedLightVersorButton.Size = new System.Drawing.Size(93, 24);
            this.animatedLightVersorButton.TabIndex = 1;
            this.animatedLightVersorButton.Text = "animated";
            this.animatedLightVersorButton.UseVisualStyleBackColor = true;
            // 
            // constLightVersorButton
            // 
            this.constLightVersorButton.AutoSize = true;
            this.constLightVersorButton.Checked = true;
            this.constLightVersorButton.Location = new System.Drawing.Point(6, 3);
            this.constLightVersorButton.Name = "constLightVersorButton";
            this.constLightVersorButton.Size = new System.Drawing.Size(156, 24);
            this.constLightVersorButton.TabIndex = 0;
            this.constLightVersorButton.TabStop = true;
            this.constLightVersorButton.Text = "constant   ([0, 0, 1])";
            this.constLightVersorButton.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(24, 335);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 20);
            this.label12.TabIndex = 16;
            this.label12.Text = "Light versor:";
            // 
            // lightColorPictureBox
            // 
            this.lightColorPictureBox.Location = new System.Drawing.Point(113, 209);
            this.lightColorPictureBox.Name = "lightColorPictureBox";
            this.lightColorPictureBox.Size = new System.Drawing.Size(46, 32);
            this.lightColorPictureBox.TabIndex = 9;
            this.lightColorPictureBox.TabStop = false;
            this.lightColorPictureBox.Click += new System.EventHandler(this.colorPictureBox_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(375, 143);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 20);
            this.label11.TabIndex = 15;
            this.label11.Text = "1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(111, 143);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 20);
            this.label10.TabIndex = 14;
            this.label10.Text = "0";
            // 
            // mValueSlider
            // 
            this.mValueSlider.Location = new System.Drawing.Point(102, 167);
            this.mValueSlider.Maximum = 1000;
            this.mValueSlider.Name = "mValueSlider";
            this.mValueSlider.Size = new System.Drawing.Size(300, 56);
            this.mValueSlider.TabIndex = 13;
            this.mValueSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.mValueSlider.ValueChanged += new System.EventHandler(this.mValueSlider_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 166);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 20);
            this.label9.TabIndex = 12;
            this.label9.Text = "M value:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.objectColorPictureBox);
            this.panel1.Controls.Add(this.objectColorTextureRadioButton);
            this.panel1.Controls.Add(this.objectColorSolidRadioButton);
            this.panel1.Location = new System.Drawing.Point(118, 257);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(257, 71);
            this.panel1.TabIndex = 11;
            // 
            // objectColorPictureBox
            // 
            this.objectColorPictureBox.Location = new System.Drawing.Point(116, 14);
            this.objectColorPictureBox.Name = "objectColorPictureBox";
            this.objectColorPictureBox.Size = new System.Drawing.Size(46, 32);
            this.objectColorPictureBox.TabIndex = 12;
            this.objectColorPictureBox.TabStop = false;
            this.objectColorPictureBox.Click += new System.EventHandler(this.objectColorPictureBox_Click);
            // 
            // objectColorTextureRadioButton
            // 
            this.objectColorTextureRadioButton.AutoSize = true;
            this.objectColorTextureRadioButton.Enabled = false;
            this.objectColorTextureRadioButton.Location = new System.Drawing.Point(6, 46);
            this.objectColorTextureRadioButton.Name = "objectColorTextureRadioButton";
            this.objectColorTextureRadioButton.Size = new System.Drawing.Size(76, 24);
            this.objectColorTextureRadioButton.TabIndex = 1;
            this.objectColorTextureRadioButton.Text = "texture";
            this.objectColorTextureRadioButton.UseVisualStyleBackColor = true;
            // 
            // objectColorSolidRadioButton
            // 
            this.objectColorSolidRadioButton.AutoSize = true;
            this.objectColorSolidRadioButton.Checked = true;
            this.objectColorSolidRadioButton.Location = new System.Drawing.Point(6, 16);
            this.objectColorSolidRadioButton.Name = "objectColorSolidRadioButton";
            this.objectColorSolidRadioButton.Size = new System.Drawing.Size(100, 24);
            this.objectColorSolidRadioButton.TabIndex = 0;
            this.objectColorSolidRadioButton.TabStop = true;
            this.objectColorSolidRadioButton.Text = "solid color";
            this.objectColorSolidRadioButton.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 273);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 20);
            this.label8.TabIndex = 10;
            this.label8.Text = "Object color:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "Light color:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(375, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(111, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "0";
            // 
            // kdValueSlider
            // 
            this.kdValueSlider.Location = new System.Drawing.Point(102, 113);
            this.kdValueSlider.Maximum = 1000;
            this.kdValueSlider.Name = "kdValueSlider";
            this.kdValueSlider.Size = new System.Drawing.Size(300, 56);
            this.kdValueSlider.TabIndex = 5;
            this.kdValueSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.kdValueSlider.ValueChanged += new System.EventHandler(this.kdValueSlider_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "K_d value:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(375, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "K_s value:";
            // 
            // ksValueSlider
            // 
            this.ksValueSlider.Location = new System.Drawing.Point(102, 53);
            this.ksValueSlider.Maximum = 1000;
            this.ksValueSlider.Name = "ksValueSlider";
            this.ksValueSlider.Size = new System.Drawing.Size(300, 56);
            this.ksValueSlider.TabIndex = 0;
            this.ksValueSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.ksValueSlider.ValueChanged += new System.EventHandler(this.ksValueSlider_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 679);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1128, 726);
            this.MinimumSize = new System.Drawing.Size(1128, 726);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heightSegmentsInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.widthSegmentsInput)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lightColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mValueSlider)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kdValueSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ksValueSlider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar ksValueSlider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar kdValueSlider;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox lightColorPictureBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox objectColorPictureBox;
        private System.Windows.Forms.RadioButton objectColorTextureRadioButton;
        private System.Windows.Forms.RadioButton objectColorSolidRadioButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar mValueSlider;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton constLightVersorButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton animatedLightVersorButton;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.RadioButton triangulatedFillColorButton;
        private System.Windows.Forms.RadioButton exactFillColorButton;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton definedNVectorButton;
        private System.Windows.Forms.RadioButton constantNVectorButton;
        private System.Windows.Forms.NumericUpDown heightSegmentsInput;
        private System.Windows.Forms.NumericUpDown widthSegmentsInput;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
    }
}

