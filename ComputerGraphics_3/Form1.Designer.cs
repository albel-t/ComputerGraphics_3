namespace ComputerGraphics_3
{
    partial class Form1
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
            this.MouseGroupBox = new System.Windows.Forms.GroupBox();
            this.label_X_coord = new System.Windows.Forms.Label();
            this.label_Y_coord = new System.Windows.Forms.Label();
            this.x_coord_out = new System.Windows.Forms.Label();
            this.y_coord_out = new System.Windows.Forms.Label();
            this.LKMCheckBox = new System.Windows.Forms.CheckBox();
            this.MKMCheckBox = new System.Windows.Forms.CheckBox();
            this.RKMCheckBox = new System.Windows.Forms.CheckBox();
            this.richTextBoxMouseLogs = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelTypeFigure = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBoxFigureOut = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Texture = new System.Windows.Forms.PictureBox();
            this.buttonTextureOpen = new System.Windows.Forms.Button();
            this.openFileDialog_Texture = new System.Windows.Forms.OpenFileDialog();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.MouseGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Texture)).BeginInit();
            this.SuspendLayout();
            // 
            // MouseGroupBox
            // 
            this.MouseGroupBox.Controls.Add(this.richTextBoxMouseLogs);
            this.MouseGroupBox.Controls.Add(this.RKMCheckBox);
            this.MouseGroupBox.Controls.Add(this.MKMCheckBox);
            this.MouseGroupBox.Controls.Add(this.LKMCheckBox);
            this.MouseGroupBox.Controls.Add(this.y_coord_out);
            this.MouseGroupBox.Controls.Add(this.x_coord_out);
            this.MouseGroupBox.Controls.Add(this.label_Y_coord);
            this.MouseGroupBox.Controls.Add(this.label_X_coord);
            this.MouseGroupBox.Location = new System.Drawing.Point(916, 12);
            this.MouseGroupBox.Name = "MouseGroupBox";
            this.MouseGroupBox.Size = new System.Drawing.Size(475, 100);
            this.MouseGroupBox.TabIndex = 0;
            this.MouseGroupBox.TabStop = false;
            this.MouseGroupBox.Text = "Mouse";
            // 
            // label_X_coord
            // 
            this.label_X_coord.AutoSize = true;
            this.label_X_coord.Location = new System.Drawing.Point(6, 40);
            this.label_X_coord.Name = "label_X_coord";
            this.label_X_coord.Size = new System.Drawing.Size(20, 13);
            this.label_X_coord.TabIndex = 0;
            this.label_X_coord.Text = "X: ";
            // 
            // label_Y_coord
            // 
            this.label_Y_coord.AutoSize = true;
            this.label_Y_coord.Location = new System.Drawing.Point(6, 62);
            this.label_Y_coord.Name = "label_Y_coord";
            this.label_Y_coord.Size = new System.Drawing.Size(20, 13);
            this.label_Y_coord.TabIndex = 1;
            this.label_Y_coord.Text = "Y: ";
            // 
            // x_coord_out
            // 
            this.x_coord_out.AutoSize = true;
            this.x_coord_out.Location = new System.Drawing.Point(32, 40);
            this.x_coord_out.Name = "x_coord_out";
            this.x_coord_out.Size = new System.Drawing.Size(13, 13);
            this.x_coord_out.TabIndex = 2;
            this.x_coord_out.Text = "0";
            // 
            // y_coord_out
            // 
            this.y_coord_out.AutoSize = true;
            this.y_coord_out.Location = new System.Drawing.Point(32, 62);
            this.y_coord_out.Name = "y_coord_out";
            this.y_coord_out.Size = new System.Drawing.Size(13, 13);
            this.y_coord_out.TabIndex = 3;
            this.y_coord_out.Text = "0";
            // 
            // LKMCheckBox
            // 
            this.LKMCheckBox.AutoSize = true;
            this.LKMCheckBox.Location = new System.Drawing.Point(83, 13);
            this.LKMCheckBox.Name = "LKMCheckBox";
            this.LKMCheckBox.Size = new System.Drawing.Size(44, 17);
            this.LKMCheckBox.TabIndex = 4;
            this.LKMCheckBox.Text = "Left";
            this.LKMCheckBox.UseVisualStyleBackColor = true;
            // 
            // MKMCheckBox
            // 
            this.MKMCheckBox.AutoSize = true;
            this.MKMCheckBox.Location = new System.Drawing.Point(83, 36);
            this.MKMCheckBox.Name = "MKMCheckBox";
            this.MKMCheckBox.Size = new System.Drawing.Size(57, 17);
            this.MKMCheckBox.TabIndex = 5;
            this.MKMCheckBox.Text = "Middle";
            this.MKMCheckBox.UseVisualStyleBackColor = true;
            // 
            // RKMCheckBox
            // 
            this.RKMCheckBox.AutoSize = true;
            this.RKMCheckBox.Location = new System.Drawing.Point(83, 59);
            this.RKMCheckBox.Name = "RKMCheckBox";
            this.RKMCheckBox.Size = new System.Drawing.Size(51, 17);
            this.RKMCheckBox.TabIndex = 6;
            this.RKMCheckBox.Text = "Right";
            this.RKMCheckBox.UseVisualStyleBackColor = true;
            // 
            // richTextBoxMouseLogs
            // 
            this.richTextBoxMouseLogs.Location = new System.Drawing.Point(159, 11);
            this.richTextBoxMouseLogs.Name = "richTextBoxMouseLogs";
            this.richTextBoxMouseLogs.Size = new System.Drawing.Size(310, 83);
            this.richTextBoxMouseLogs.TabIndex = 1;
            this.richTextBoxMouseLogs.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBoxFigureOut);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.buttonEdit);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.labelTypeFigure);
            this.groupBox1.Location = new System.Drawing.Point(727, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(183, 277);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tools";
            // 
            // labelTypeFigure
            // 
            this.labelTypeFigure.AutoSize = true;
            this.labelTypeFigure.Location = new System.Drawing.Point(6, 33);
            this.labelTypeFigure.Name = "labelTypeFigure";
            this.labelTypeFigure.Size = new System.Drawing.Size(34, 13);
            this.labelTypeFigure.TabIndex = 0;
            this.labelTypeFigure.Text = "Type:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "-NONE-"});
            this.comboBox1.Location = new System.Drawing.Point(46, 30);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(92, 248);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 2;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(11, 248);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Add";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(916, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(475, 446);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Property";
            // 
            // richTextBoxFigureOut
            // 
            this.richTextBoxFigureOut.Location = new System.Drawing.Point(9, 59);
            this.richTextBoxFigureOut.Name = "richTextBoxFigureOut";
            this.richTextBoxFigureOut.Size = new System.Drawing.Size(168, 183);
            this.richTextBoxFigureOut.TabIndex = 7;
            this.richTextBoxFigureOut.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonTextureOpen);
            this.groupBox3.Controls.Add(this.Texture);
            this.groupBox3.Location = new System.Drawing.Point(727, 298);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(183, 266);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Texture";
            // 
            // Texture
            // 
            this.Texture.Location = new System.Drawing.Point(9, 19);
            this.Texture.Name = "Texture";
            this.Texture.Size = new System.Drawing.Size(168, 155);
            this.Texture.TabIndex = 0;
            this.Texture.TabStop = false;
            // 
            // buttonTextureOpen
            // 
            this.buttonTextureOpen.Location = new System.Drawing.Point(9, 180);
            this.buttonTextureOpen.Name = "buttonTextureOpen";
            this.buttonTextureOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonTextureOpen.TabIndex = 1;
            this.buttonTextureOpen.Text = "Open";
            this.buttonTextureOpen.UseVisualStyleBackColor = true;
            this.buttonTextureOpen.Click += new System.EventHandler(this.buttonTextureOpen_Click);
            // 
            // openFileDialog_Texture
            // 
            this.openFileDialog_Texture.FileName = "openFileDialogTexture";
            this.openFileDialog_Texture.InitialDirectory = "C:";
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1403, 582);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.MouseGroupBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseGroupBox.ResumeLayout(false);
            this.MouseGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Texture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox MouseGroupBox;
        private System.Windows.Forms.Label label_X_coord;
        private System.Windows.Forms.Label y_coord_out;
        private System.Windows.Forms.Label x_coord_out;
        private System.Windows.Forms.Label label_Y_coord;
        private System.Windows.Forms.CheckBox RKMCheckBox;
        private System.Windows.Forms.CheckBox MKMCheckBox;
        private System.Windows.Forms.CheckBox LKMCheckBox;
        private System.Windows.Forms.RichTextBox richTextBoxMouseLogs;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelTypeFigure;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBoxFigureOut;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonTextureOpen;
        private System.Windows.Forms.PictureBox Texture;
        private System.Windows.Forms.OpenFileDialog openFileDialog_Texture;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
    }
}

