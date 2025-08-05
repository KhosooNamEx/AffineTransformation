namespace Affine_Transformer
{
    partial class Form1
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
            if (disposing && (components != null)) {
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            this.picBox = new System.Windows.Forms.PictureBox();
            this.btnInsertImage = new System.Windows.Forms.Button();
            this.btnAffineTransform = new System.Windows.Forms.Button();
            this.lblXCoordinate = new System.Windows.Forms.Label();
            this.lblYcoordinate = new System.Windows.Forms.Label();
            this.lblAngle = new System.Windows.Forms.Label();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.listInvalidDatacoordinate = new System.Windows.Forms.ListView();
            this.cHeadNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadInvalidDataXcoordinate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeadInvalidDataYcoordinate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblFraction = new System.Windows.Forms.Label();
            this.txtBoxFractionValue = new System.Windows.Forms.TextBox();
            this.numericCenterXcoordinate = new System.Windows.Forms.NumericUpDown();
            this.numericCenterYcoordinate = new System.Windows.Forms.NumericUpDown();
            this.numericAngle = new System.Windows.Forms.NumericUpDown();
            this.lblOutputValueA = new System.Windows.Forms.Label();
            this.txtBoxOutputA = new System.Windows.Forms.TextBox();
            this.lblOutputValueB = new System.Windows.Forms.Label();
            this.txtBoxOutputB = new System.Windows.Forms.TextBox();
            this.txtBoxOutputC = new System.Windows.Forms.TextBox();
            this.lblOutputValueC = new System.Windows.Forms.Label();
            this.lblOutputValueD = new System.Windows.Forms.Label();
            this.txtBoxOutputD = new System.Windows.Forms.TextBox();
            this.txtBoxOutputXcoordinate = new System.Windows.Forms.TextBox();
            this.txtBoxOutputYcoordinate = new System.Windows.Forms.TextBox();
            this.lblOutputXcoordinate = new System.Windows.Forms.Label();
            this.lblOutputYcoordinate = new System.Windows.Forms.Label();
            this.txtBoxFractionShiftedValue = new System.Windows.Forms.TextBox();
            this.txtBoxShiftedAValue = new System.Windows.Forms.TextBox();
            this.txtBoxShiftedBValue = new System.Windows.Forms.TextBox();
            this.txtBoxShiftedCValue = new System.Windows.Forms.TextBox();
            this.txtBoxShiftedDValue = new System.Windows.Forms.TextBox();
            this.txtBoxShiftedXcoordinate = new System.Windows.Forms.TextBox();
            this.txtBoxShiftedYcoordinate = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCenterXcoordinate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCenterYcoordinate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAngle)).BeginInit();
            this.SuspendLayout();
            // 
            // picBox
            // 
            this.picBox.Location = new System.Drawing.Point(12, 12);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(1031, 584);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox.TabIndex = 0;
            this.picBox.TabStop = false;
            // 
            // btnInsertImage
            // 
            this.btnInsertImage.Location = new System.Drawing.Point(1071, 552);
            this.btnInsertImage.Name = "btnInsertImage";
            this.btnInsertImage.Size = new System.Drawing.Size(98, 33);
            this.btnInsertImage.TabIndex = 1;
            this.btnInsertImage.Text = "Insert Image";
            this.btnInsertImage.UseVisualStyleBackColor = true;
            this.btnInsertImage.Click += new System.EventHandler(this.btnInsertImage_Click);
            // 
            // btnAffineTransform
            // 
            this.btnAffineTransform.Location = new System.Drawing.Point(1194, 552);
            this.btnAffineTransform.Name = "btnAffineTransform";
            this.btnAffineTransform.Size = new System.Drawing.Size(102, 33);
            this.btnAffineTransform.TabIndex = 2;
            this.btnAffineTransform.Text = "Start Processing";
            this.btnAffineTransform.UseVisualStyleBackColor = true;
            this.btnAffineTransform.Click += new System.EventHandler(this.btnAffineTransform_Click);
            // 
            // lblXCoordinate
            // 
            this.lblXCoordinate.AutoSize = true;
            this.lblXCoordinate.Location = new System.Drawing.Point(1069, 50);
            this.lblXCoordinate.Name = "lblXCoordinate";
            this.lblXCoordinate.Size = new System.Drawing.Size(119, 12);
            this.lblXCoordinate.TabIndex = 3;
            this.lblXCoordinate.Text = "Center X Coordinate : ";
            // 
            // lblYcoordinate
            // 
            this.lblYcoordinate.AutoSize = true;
            this.lblYcoordinate.Location = new System.Drawing.Point(1069, 81);
            this.lblYcoordinate.Name = "lblYcoordinate";
            this.lblYcoordinate.Size = new System.Drawing.Size(119, 12);
            this.lblYcoordinate.TabIndex = 4;
            this.lblYcoordinate.Text = "Center Y Coordinate : ";
            // 
            // lblAngle
            // 
            this.lblAngle.AutoSize = true;
            this.lblAngle.Location = new System.Drawing.Point(1144, 113);
            this.lblAngle.Name = "lblAngle";
            this.lblAngle.Size = new System.Drawing.Size(44, 12);
            this.lblAngle.TabIndex = 5;
            this.lblAngle.Text = "Angle : ";
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Location = new System.Drawing.Point(1317, 552);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(91, 33);
            this.btnSaveImage.TabIndex = 9;
            this.btnSaveImage.Text = "Save Image";
            this.btnSaveImage.UseVisualStyleBackColor = true;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // listInvalidDatacoordinate
            // 
            this.listInvalidDatacoordinate.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cHeadNumber,
            this.colHeadInvalidDataXcoordinate,
            this.colHeadInvalidDataYcoordinate});
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = "listViewGroup1";
            this.listInvalidDatacoordinate.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.listInvalidDatacoordinate.HideSelection = false;
            this.listInvalidDatacoordinate.Location = new System.Drawing.Point(1136, 317);
            this.listInvalidDatacoordinate.Name = "listInvalidDatacoordinate";
            this.listInvalidDatacoordinate.Size = new System.Drawing.Size(272, 137);
            this.listInvalidDatacoordinate.TabIndex = 10;
            this.listInvalidDatacoordinate.UseCompatibleStateImageBehavior = false;
            this.listInvalidDatacoordinate.View = System.Windows.Forms.View.Details;
            // 
            // cHeadNumber
            // 
            this.cHeadNumber.Text = "No";
            this.cHeadNumber.Width = 75;
            // 
            // colHeadInvalidDataXcoordinate
            // 
            this.colHeadInvalidDataXcoordinate.Text = "X Coordinate";
            this.colHeadInvalidDataXcoordinate.Width = 92;
            // 
            // colHeadInvalidDataYcoordinate
            // 
            this.colHeadInvalidDataYcoordinate.Text = "Y Coordinate";
            this.colHeadInvalidDataYcoordinate.Width = 95;
            // 
            // lblFraction
            // 
            this.lblFraction.AutoSize = true;
            this.lblFraction.Location = new System.Drawing.Point(1098, 145);
            this.lblFraction.Name = "lblFraction";
            this.lblFraction.Size = new System.Drawing.Size(90, 12);
            this.lblFraction.TabIndex = 11;
            this.lblFraction.Text = "Fraction Value : ";
            // 
            // txtBoxFractionValue
            // 
            this.txtBoxFractionValue.Location = new System.Drawing.Point(1194, 142);
            this.txtBoxFractionValue.Name = "txtBoxFractionValue";
            this.txtBoxFractionValue.Size = new System.Drawing.Size(100, 19);
            this.txtBoxFractionValue.TabIndex = 12;
            // 
            // numericCenterXcoordinate
            // 
            this.numericCenterXcoordinate.Location = new System.Drawing.Point(1194, 48);
            this.numericCenterXcoordinate.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.numericCenterXcoordinate.Name = "numericCenterXcoordinate";
            this.numericCenterXcoordinate.Size = new System.Drawing.Size(102, 19);
            this.numericCenterXcoordinate.TabIndex = 13;
            // 
            // numericCenterYcoordinate
            // 
            this.numericCenterYcoordinate.Location = new System.Drawing.Point(1194, 79);
            this.numericCenterYcoordinate.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.numericCenterYcoordinate.Name = "numericCenterYcoordinate";
            this.numericCenterYcoordinate.Size = new System.Drawing.Size(102, 19);
            this.numericCenterYcoordinate.TabIndex = 14;
            // 
            // numericAngle
            // 
            this.numericAngle.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericAngle.Location = new System.Drawing.Point(1194, 111);
            this.numericAngle.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericAngle.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.numericAngle.Name = "numericAngle";
            this.numericAngle.Size = new System.Drawing.Size(102, 19);
            this.numericAngle.TabIndex = 15;
            // 
            // lblOutputValueA
            // 
            this.lblOutputValueA.AutoSize = true;
            this.lblOutputValueA.Location = new System.Drawing.Point(1134, 170);
            this.lblOutputValueA.Name = "lblOutputValueA";
            this.lblOutputValueA.Size = new System.Drawing.Size(54, 12);
            this.lblOutputValueA.TabIndex = 16;
            this.lblOutputValueA.Text = "Value a : ";
            // 
            // txtBoxOutputA
            // 
            this.txtBoxOutputA.Location = new System.Drawing.Point(1194, 167);
            this.txtBoxOutputA.Name = "txtBoxOutputA";
            this.txtBoxOutputA.Size = new System.Drawing.Size(100, 19);
            this.txtBoxOutputA.TabIndex = 17;
            // 
            // lblOutputValueB
            // 
            this.lblOutputValueB.AutoSize = true;
            this.lblOutputValueB.Location = new System.Drawing.Point(1134, 195);
            this.lblOutputValueB.Name = "lblOutputValueB";
            this.lblOutputValueB.Size = new System.Drawing.Size(54, 12);
            this.lblOutputValueB.TabIndex = 18;
            this.lblOutputValueB.Text = "Value b : ";
            // 
            // txtBoxOutputB
            // 
            this.txtBoxOutputB.Location = new System.Drawing.Point(1194, 192);
            this.txtBoxOutputB.Name = "txtBoxOutputB";
            this.txtBoxOutputB.Size = new System.Drawing.Size(100, 19);
            this.txtBoxOutputB.TabIndex = 19;
            // 
            // txtBoxOutputC
            // 
            this.txtBoxOutputC.Location = new System.Drawing.Point(1194, 217);
            this.txtBoxOutputC.Name = "txtBoxOutputC";
            this.txtBoxOutputC.Size = new System.Drawing.Size(100, 19);
            this.txtBoxOutputC.TabIndex = 20;
            // 
            // lblOutputValueC
            // 
            this.lblOutputValueC.AutoSize = true;
            this.lblOutputValueC.Location = new System.Drawing.Point(1134, 220);
            this.lblOutputValueC.Name = "lblOutputValueC";
            this.lblOutputValueC.Size = new System.Drawing.Size(54, 12);
            this.lblOutputValueC.TabIndex = 21;
            this.lblOutputValueC.Text = "Value c : ";
            // 
            // lblOutputValueD
            // 
            this.lblOutputValueD.AutoSize = true;
            this.lblOutputValueD.Location = new System.Drawing.Point(1134, 245);
            this.lblOutputValueD.Name = "lblOutputValueD";
            this.lblOutputValueD.Size = new System.Drawing.Size(54, 12);
            this.lblOutputValueD.TabIndex = 22;
            this.lblOutputValueD.Text = "Value d : ";
            // 
            // txtBoxOutputD
            // 
            this.txtBoxOutputD.Location = new System.Drawing.Point(1194, 242);
            this.txtBoxOutputD.Name = "txtBoxOutputD";
            this.txtBoxOutputD.Size = new System.Drawing.Size(100, 19);
            this.txtBoxOutputD.TabIndex = 23;
            // 
            // txtBoxOutputXcoordinate
            // 
            this.txtBoxOutputXcoordinate.Location = new System.Drawing.Point(1194, 267);
            this.txtBoxOutputXcoordinate.Name = "txtBoxOutputXcoordinate";
            this.txtBoxOutputXcoordinate.Size = new System.Drawing.Size(100, 19);
            this.txtBoxOutputXcoordinate.TabIndex = 24;
            // 
            // txtBoxOutputYcoordinate
            // 
            this.txtBoxOutputYcoordinate.Location = new System.Drawing.Point(1194, 292);
            this.txtBoxOutputYcoordinate.Name = "txtBoxOutputYcoordinate";
            this.txtBoxOutputYcoordinate.Size = new System.Drawing.Size(100, 19);
            this.txtBoxOutputYcoordinate.TabIndex = 25;
            // 
            // lblOutputXcoordinate
            // 
            this.lblOutputXcoordinate.AutoSize = true;
            this.lblOutputXcoordinate.Location = new System.Drawing.Point(1107, 270);
            this.lblOutputXcoordinate.Name = "lblOutputXcoordinate";
            this.lblOutputXcoordinate.Size = new System.Drawing.Size(81, 12);
            this.lblOutputXcoordinate.TabIndex = 26;
            this.lblOutputXcoordinate.Text = "X Coordinate : ";
            // 
            // lblOutputYcoordinate
            // 
            this.lblOutputYcoordinate.AutoSize = true;
            this.lblOutputYcoordinate.Location = new System.Drawing.Point(1107, 295);
            this.lblOutputYcoordinate.Name = "lblOutputYcoordinate";
            this.lblOutputYcoordinate.Size = new System.Drawing.Size(81, 12);
            this.lblOutputYcoordinate.TabIndex = 27;
            this.lblOutputYcoordinate.Text = "Y Coordinate : ";
            // 
            // txtBoxFractionShiftedValue
            // 
            this.txtBoxFractionShiftedValue.Location = new System.Drawing.Point(1308, 142);
            this.txtBoxFractionShiftedValue.Name = "txtBoxFractionShiftedValue";
            this.txtBoxFractionShiftedValue.Size = new System.Drawing.Size(100, 19);
            this.txtBoxFractionShiftedValue.TabIndex = 28;
            // 
            // txtBoxShiftedAValue
            // 
            this.txtBoxShiftedAValue.Location = new System.Drawing.Point(1308, 167);
            this.txtBoxShiftedAValue.Name = "txtBoxShiftedAValue";
            this.txtBoxShiftedAValue.Size = new System.Drawing.Size(100, 19);
            this.txtBoxShiftedAValue.TabIndex = 29;
            // 
            // txtBoxShiftedBValue
            // 
            this.txtBoxShiftedBValue.Location = new System.Drawing.Point(1308, 192);
            this.txtBoxShiftedBValue.Name = "txtBoxShiftedBValue";
            this.txtBoxShiftedBValue.Size = new System.Drawing.Size(100, 19);
            this.txtBoxShiftedBValue.TabIndex = 30;
            // 
            // txtBoxShiftedCValue
            // 
            this.txtBoxShiftedCValue.Location = new System.Drawing.Point(1308, 217);
            this.txtBoxShiftedCValue.Name = "txtBoxShiftedCValue";
            this.txtBoxShiftedCValue.Size = new System.Drawing.Size(100, 19);
            this.txtBoxShiftedCValue.TabIndex = 31;
            // 
            // txtBoxShiftedDValue
            // 
            this.txtBoxShiftedDValue.Location = new System.Drawing.Point(1308, 242);
            this.txtBoxShiftedDValue.Name = "txtBoxShiftedDValue";
            this.txtBoxShiftedDValue.Size = new System.Drawing.Size(100, 19);
            this.txtBoxShiftedDValue.TabIndex = 32;
            // 
            // txtBoxShiftedXcoordinate
            // 
            this.txtBoxShiftedXcoordinate.Location = new System.Drawing.Point(1308, 267);
            this.txtBoxShiftedXcoordinate.Name = "txtBoxShiftedXcoordinate";
            this.txtBoxShiftedXcoordinate.Size = new System.Drawing.Size(100, 19);
            this.txtBoxShiftedXcoordinate.TabIndex = 33;
            // 
            // txtBoxShiftedYcoordinate
            // 
            this.txtBoxShiftedYcoordinate.Location = new System.Drawing.Point(1308, 292);
            this.txtBoxShiftedYcoordinate.Name = "txtBoxShiftedYcoordinate";
            this.txtBoxShiftedYcoordinate.Size = new System.Drawing.Size(100, 19);
            this.txtBoxShiftedYcoordinate.TabIndex = 34;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1426, 607);
            this.Controls.Add(this.txtBoxShiftedYcoordinate);
            this.Controls.Add(this.txtBoxShiftedXcoordinate);
            this.Controls.Add(this.txtBoxShiftedDValue);
            this.Controls.Add(this.txtBoxShiftedCValue);
            this.Controls.Add(this.txtBoxShiftedBValue);
            this.Controls.Add(this.txtBoxShiftedAValue);
            this.Controls.Add(this.txtBoxFractionShiftedValue);
            this.Controls.Add(this.lblOutputYcoordinate);
            this.Controls.Add(this.lblOutputXcoordinate);
            this.Controls.Add(this.txtBoxOutputYcoordinate);
            this.Controls.Add(this.txtBoxOutputXcoordinate);
            this.Controls.Add(this.txtBoxOutputD);
            this.Controls.Add(this.lblOutputValueD);
            this.Controls.Add(this.lblOutputValueC);
            this.Controls.Add(this.txtBoxOutputC);
            this.Controls.Add(this.txtBoxOutputB);
            this.Controls.Add(this.lblOutputValueB);
            this.Controls.Add(this.txtBoxOutputA);
            this.Controls.Add(this.lblOutputValueA);
            this.Controls.Add(this.numericAngle);
            this.Controls.Add(this.numericCenterYcoordinate);
            this.Controls.Add(this.numericCenterXcoordinate);
            this.Controls.Add(this.txtBoxFractionValue);
            this.Controls.Add(this.lblFraction);
            this.Controls.Add(this.listInvalidDatacoordinate);
            this.Controls.Add(this.btnSaveImage);
            this.Controls.Add(this.lblAngle);
            this.Controls.Add(this.lblYcoordinate);
            this.Controls.Add(this.lblXCoordinate);
            this.Controls.Add(this.btnAffineTransform);
            this.Controls.Add(this.btnInsertImage);
            this.Controls.Add(this.picBox);
            this.Name = "Form1";
            this.Text = "Affine Transformer";
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCenterXcoordinate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCenterYcoordinate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAngle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Button btnInsertImage;
        private System.Windows.Forms.Button btnAffineTransform;
        private System.Windows.Forms.Label lblXCoordinate;
        private System.Windows.Forms.Label lblYcoordinate;
        private System.Windows.Forms.Label lblAngle;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.ListView listInvalidDatacoordinate;
        private System.Windows.Forms.ColumnHeader cHeadNumber;
        private System.Windows.Forms.ColumnHeader colHeadInvalidDataXcoordinate;
        private System.Windows.Forms.ColumnHeader colHeadInvalidDataYcoordinate;
        private System.Windows.Forms.Label lblFraction;
        private System.Windows.Forms.TextBox txtBoxFractionValue;
        private System.Windows.Forms.NumericUpDown numericCenterXcoordinate;
        private System.Windows.Forms.NumericUpDown numericCenterYcoordinate;
        private System.Windows.Forms.NumericUpDown numericAngle;
        private System.Windows.Forms.Label lblOutputValueA;
        private System.Windows.Forms.TextBox txtBoxOutputA;
        private System.Windows.Forms.Label lblOutputValueB;
        private System.Windows.Forms.TextBox txtBoxOutputB;
        private System.Windows.Forms.TextBox txtBoxOutputC;
        private System.Windows.Forms.Label lblOutputValueC;
        private System.Windows.Forms.Label lblOutputValueD;
        private System.Windows.Forms.TextBox txtBoxOutputD;
        private System.Windows.Forms.TextBox txtBoxOutputXcoordinate;
        private System.Windows.Forms.TextBox txtBoxOutputYcoordinate;
        private System.Windows.Forms.Label lblOutputXcoordinate;
        private System.Windows.Forms.Label lblOutputYcoordinate;
        private System.Windows.Forms.TextBox txtBoxFractionShiftedValue;
        private System.Windows.Forms.TextBox txtBoxShiftedAValue;
        private System.Windows.Forms.TextBox txtBoxShiftedBValue;
        private System.Windows.Forms.TextBox txtBoxShiftedCValue;
        private System.Windows.Forms.TextBox txtBoxShiftedDValue;
        private System.Windows.Forms.TextBox txtBoxShiftedXcoordinate;
        private System.Windows.Forms.TextBox txtBoxShiftedYcoordinate;
    }
}

