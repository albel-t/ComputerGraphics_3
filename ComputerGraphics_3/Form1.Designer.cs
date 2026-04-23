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
            this.richTextBoxMouseLogs = new System.Windows.Forms.RichTextBox();
            this.RKMCheckBox = new System.Windows.Forms.CheckBox();
            this.MKMCheckBox = new System.Windows.Forms.CheckBox();
            this.LKMCheckBox = new System.Windows.Forms.CheckBox();
            this.y_coord_out = new System.Windows.Forms.Label();
            this.x_coord_out = new System.Windows.Forms.Label();
            this.label_Y_coord = new System.Windows.Forms.Label();
            this.label_X_coord = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxCameraZ = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxCameraAngle = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxCameraDistance = new System.Windows.Forms.TextBox();
            this.labelFPS = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxCameraY = new System.Windows.Forms.TextBox();
            this.textBoxCameraX = new System.Windows.Forms.TextBox();
            this.buttonRebuildWindow = new System.Windows.Forms.Button();
            this.textBoxChuncksCountInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxRotateCamera = new System.Windows.Forms.PictureBox();
            this.richTextBoxFigurePropertyOut = new System.Windows.Forms.RichTextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.comboBoxTypeOfObject = new System.Windows.Forms.ComboBox();
            this.labelTypeFigure = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelTextureFileName = new System.Windows.Forms.Label();
            this.buttonTextureOpen = new System.Windows.Forms.Button();
            this.TexturePictureBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog_Texture = new System.Windows.Forms.OpenFileDialog();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.pictureBoxScreen = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonClearAll = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxFigures = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.richTextBoxLogsOut = new System.Windows.Forms.RichTextBox();
            this.pictureBoxAllScreen = new System.Windows.Forms.PictureBox();
            this.pictureBoxVisiblePartAllScreen = new System.Windows.Forms.PictureBox();
            this.pictureBoxVisibleShadow = new System.Windows.Forms.PictureBox();
            this.MouseGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRotateCamera)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TexturePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScreen)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAllScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVisiblePartAllScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVisibleShadow)).BeginInit();
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
            // richTextBoxMouseLogs
            // 
            this.richTextBoxMouseLogs.Location = new System.Drawing.Point(159, 11);
            this.richTextBoxMouseLogs.Name = "richTextBoxMouseLogs";
            this.richTextBoxMouseLogs.Size = new System.Drawing.Size(310, 83);
            this.richTextBoxMouseLogs.TabIndex = 1;
            this.richTextBoxMouseLogs.Text = "";
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
            // y_coord_out
            // 
            this.y_coord_out.AutoSize = true;
            this.y_coord_out.Location = new System.Drawing.Point(32, 62);
            this.y_coord_out.Name = "y_coord_out";
            this.y_coord_out.Size = new System.Drawing.Size(13, 13);
            this.y_coord_out.TabIndex = 3;
            this.y_coord_out.Text = "0";
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
            // label_Y_coord
            // 
            this.label_Y_coord.AutoSize = true;
            this.label_Y_coord.Location = new System.Drawing.Point(6, 62);
            this.label_Y_coord.Name = "label_Y_coord";
            this.label_Y_coord.Size = new System.Drawing.Size(20, 13);
            this.label_Y_coord.TabIndex = 1;
            this.label_Y_coord.Text = "Y: ";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxCameraZ);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.textBoxCameraAngle);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBoxCameraDistance);
            this.groupBox1.Controls.Add(this.labelFPS);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxCameraY);
            this.groupBox1.Controls.Add(this.textBoxCameraX);
            this.groupBox1.Controls.Add(this.buttonRebuildWindow);
            this.groupBox1.Controls.Add(this.textBoxChuncksCountInput);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pictureBoxRotateCamera);
            this.groupBox1.Location = new System.Drawing.Point(727, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(183, 237);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Screen";
            // 
            // textBoxCameraZ
            // 
            this.textBoxCameraZ.Location = new System.Drawing.Point(131, 198);
            this.textBoxCameraZ.Name = "textBoxCameraZ";
            this.textBoxCameraZ.Size = new System.Drawing.Size(38, 20);
            this.textBoxCameraZ.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(107, 201);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Z: ";
            // 
            // textBoxCameraAngle
            // 
            this.textBoxCameraAngle.Location = new System.Drawing.Point(48, 212);
            this.textBoxCameraAngle.Name = "textBoxCameraAngle";
            this.textBoxCameraAngle.Size = new System.Drawing.Size(33, 20);
            this.textBoxCameraAngle.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 215);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Angle:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 192);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Dist:";
            // 
            // textBoxCameraDistance
            // 
            this.textBoxCameraDistance.Location = new System.Drawing.Point(48, 189);
            this.textBoxCameraDistance.Name = "textBoxCameraDistance";
            this.textBoxCameraDistance.Size = new System.Drawing.Size(33, 20);
            this.textBoxCameraDistance.TabIndex = 15;
            // 
            // labelFPS
            // 
            this.labelFPS.AutoSize = true;
            this.labelFPS.Location = new System.Drawing.Point(12, 124);
            this.labelFPS.Name = "labelFPS";
            this.labelFPS.Size = new System.Drawing.Size(49, 13);
            this.labelFPS.TabIndex = 14;
            this.labelFPS.Text = "labelFPS";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Camera";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(107, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Y: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(107, 148);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "X: ";
            // 
            // textBoxCameraY
            // 
            this.textBoxCameraY.Location = new System.Drawing.Point(131, 172);
            this.textBoxCameraY.Name = "textBoxCameraY";
            this.textBoxCameraY.Size = new System.Drawing.Size(38, 20);
            this.textBoxCameraY.TabIndex = 12;
            // 
            // textBoxCameraX
            // 
            this.textBoxCameraX.Location = new System.Drawing.Point(131, 145);
            this.textBoxCameraX.Name = "textBoxCameraX";
            this.textBoxCameraX.Size = new System.Drawing.Size(38, 20);
            this.textBoxCameraX.TabIndex = 11;
            // 
            // buttonRebuildWindow
            // 
            this.buttonRebuildWindow.Location = new System.Drawing.Point(94, 84);
            this.buttonRebuildWindow.Name = "buttonRebuildWindow";
            this.buttonRebuildWindow.Size = new System.Drawing.Size(75, 23);
            this.buttonRebuildWindow.TabIndex = 10;
            this.buttonRebuildWindow.Text = "Rebuild";
            this.buttonRebuildWindow.UseVisualStyleBackColor = true;
            // 
            // textBoxChuncksCountInput
            // 
            this.textBoxChuncksCountInput.Location = new System.Drawing.Point(94, 52);
            this.textBoxChuncksCountInput.Name = "textBoxChuncksCountInput";
            this.textBoxChuncksCountInput.Size = new System.Drawing.Size(63, 20);
            this.textBoxChuncksCountInput.TabIndex = 9;
            this.textBoxChuncksCountInput.Text = "100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "chuncks:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Rotate";
            // 
            // pictureBoxRotateCamera
            // 
            this.pictureBoxRotateCamera.Location = new System.Drawing.Point(18, 37);
            this.pictureBoxRotateCamera.Name = "pictureBoxRotateCamera";
            this.pictureBoxRotateCamera.Size = new System.Drawing.Size(70, 70);
            this.pictureBoxRotateCamera.TabIndex = 0;
            this.pictureBoxRotateCamera.TabStop = false;
            // 
            // richTextBoxFigurePropertyOut
            // 
            this.richTextBoxFigurePropertyOut.Location = new System.Drawing.Point(9, 69);
            this.richTextBoxFigurePropertyOut.Name = "richTextBoxFigurePropertyOut";
            this.richTextBoxFigurePropertyOut.Size = new System.Drawing.Size(460, 99);
            this.richTextBoxFigurePropertyOut.TabIndex = 7;
            this.richTextBoxFigurePropertyOut.Text = "";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(11, 174);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(92, 174);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 2;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            // 
            // comboBoxTypeOfObject
            // 
            this.comboBoxTypeOfObject.FormattingEnabled = true;
            this.comboBoxTypeOfObject.Items.AddRange(new object[] {
            "-NONE-"});
            this.comboBoxTypeOfObject.Location = new System.Drawing.Point(46, 21);
            this.comboBoxTypeOfObject.Name = "comboBoxTypeOfObject";
            this.comboBoxTypeOfObject.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTypeOfObject.TabIndex = 1;
            // 
            // labelTypeFigure
            // 
            this.labelTypeFigure.AutoSize = true;
            this.labelTypeFigure.Location = new System.Drawing.Point(6, 24);
            this.labelTypeFigure.Name = "labelTypeFigure";
            this.labelTypeFigure.Size = new System.Drawing.Size(34, 13);
            this.labelTypeFigure.TabIndex = 0;
            this.labelTypeFigure.Text = "Type:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.richTextBoxFigurePropertyOut);
            this.groupBox2.Controls.Add(this.buttonAdd);
            this.groupBox2.Controls.Add(this.labelTypeFigure);
            this.groupBox2.Controls.Add(this.buttonEdit);
            this.groupBox2.Controls.Add(this.comboBoxTypeOfObject);
            this.groupBox2.Location = new System.Drawing.Point(916, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(475, 204);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Property";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Info";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelTextureFileName);
            this.groupBox3.Controls.Add(this.buttonTextureOpen);
            this.groupBox3.Controls.Add(this.TexturePictureBox);
            this.groupBox3.Location = new System.Drawing.Point(727, 258);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(183, 207);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Texture";
            // 
            // labelTextureFileName
            // 
            this.labelTextureFileName.AutoSize = true;
            this.labelTextureFileName.Location = new System.Drawing.Point(90, 181);
            this.labelTextureFileName.Name = "labelTextureFileName";
            this.labelTextureFileName.Size = new System.Drawing.Size(37, 13);
            this.labelTextureFileName.TabIndex = 21;
            this.labelTextureFileName.Text = "-none-";
            // 
            // buttonTextureOpen
            // 
            this.buttonTextureOpen.Location = new System.Drawing.Point(9, 176);
            this.buttonTextureOpen.Name = "buttonTextureOpen";
            this.buttonTextureOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonTextureOpen.TabIndex = 1;
            this.buttonTextureOpen.Text = "Open";
            this.buttonTextureOpen.UseVisualStyleBackColor = true;
            this.buttonTextureOpen.Click += new System.EventHandler(this.buttonTextureOpen_Click);
            // 
            // TexturePictureBox
            // 
            this.TexturePictureBox.Location = new System.Drawing.Point(9, 19);
            this.TexturePictureBox.Name = "TexturePictureBox";
            this.TexturePictureBox.Size = new System.Drawing.Size(168, 151);
            this.TexturePictureBox.TabIndex = 0;
            this.TexturePictureBox.TabStop = false;
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
            // pictureBoxScreen
            // 
            this.pictureBoxScreen.Location = new System.Drawing.Point(12, 23);
            this.pictureBoxScreen.Name = "pictureBoxScreen";
            this.pictureBoxScreen.Size = new System.Drawing.Size(507, 547);
            this.pictureBoxScreen.TabIndex = 4;
            this.pictureBoxScreen.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonClearAll);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.comboBoxFigures);
            this.groupBox4.Location = new System.Drawing.Point(727, 471);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(183, 99);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Objects";
            // 
            // buttonClearAll
            // 
            this.buttonClearAll.Location = new System.Drawing.Point(6, 68);
            this.buttonClearAll.Name = "buttonClearAll";
            this.buttonClearAll.Size = new System.Drawing.Size(75, 23);
            this.buttonClearAll.TabIndex = 2;
            this.buttonClearAll.Text = "Clear";
            this.buttonClearAll.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "current figure";
            // 
            // comboBoxFigures
            // 
            this.comboBoxFigures.FormattingEnabled = true;
            this.comboBoxFigures.Location = new System.Drawing.Point(6, 41);
            this.comboBoxFigures.Name = "comboBoxFigures";
            this.comboBoxFigures.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFigures.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.buttonLoad);
            this.groupBox5.Controls.Add(this.buttonSave);
            this.groupBox5.Controls.Add(this.richTextBoxLogsOut);
            this.groupBox5.Location = new System.Drawing.Point(916, 328);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(475, 242);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Logs";
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(87, 211);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 2;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(6, 211);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // richTextBoxLogsOut
            // 
            this.richTextBoxLogsOut.Location = new System.Drawing.Point(6, 19);
            this.richTextBoxLogsOut.Name = "richTextBoxLogsOut";
            this.richTextBoxLogsOut.Size = new System.Drawing.Size(463, 186);
            this.richTextBoxLogsOut.TabIndex = 0;
            this.richTextBoxLogsOut.Text = "";
            // 
            // pictureBoxAllScreen
            // 
            this.pictureBoxAllScreen.Location = new System.Drawing.Point(537, 36);
            this.pictureBoxAllScreen.Name = "pictureBoxAllScreen";
            this.pictureBoxAllScreen.Size = new System.Drawing.Size(168, 151);
            this.pictureBoxAllScreen.TabIndex = 2;
            this.pictureBoxAllScreen.TabStop = false;
            // 
            // pictureBoxVisiblePartAllScreen
            // 
            this.pictureBoxVisiblePartAllScreen.Location = new System.Drawing.Point(537, 226);
            this.pictureBoxVisiblePartAllScreen.Name = "pictureBoxVisiblePartAllScreen";
            this.pictureBoxVisiblePartAllScreen.Size = new System.Drawing.Size(168, 151);
            this.pictureBoxVisiblePartAllScreen.TabIndex = 7;
            this.pictureBoxVisiblePartAllScreen.TabStop = false;
            // 
            // pictureBoxVisibleShadow
            // 
            this.pictureBoxVisibleShadow.Location = new System.Drawing.Point(537, 419);
            this.pictureBoxVisibleShadow.Name = "pictureBoxVisibleShadow";
            this.pictureBoxVisibleShadow.Size = new System.Drawing.Size(168, 151);
            this.pictureBoxVisibleShadow.TabIndex = 8;
            this.pictureBoxVisibleShadow.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1403, 582);
            this.Controls.Add(this.pictureBoxVisibleShadow);
            this.Controls.Add(this.pictureBoxVisiblePartAllScreen);
            this.Controls.Add(this.pictureBoxAllScreen);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.pictureBoxScreen);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRotateCamera)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TexturePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScreen)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAllScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVisiblePartAllScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVisibleShadow)).EndInit();
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
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.ComboBox comboBoxTypeOfObject;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBoxFigurePropertyOut;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonTextureOpen;
        private System.Windows.Forms.PictureBox TexturePictureBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog_Texture;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.PictureBox pictureBoxScreen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxRotateCamera;
        private System.Windows.Forms.TextBox textBoxChuncksCountInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonRebuildWindow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBoxCameraY;
        private System.Windows.Forms.TextBox textBoxCameraX;
        private System.Windows.Forms.Button buttonClearAll;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxFigures;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.RichTextBox richTextBoxLogsOut;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.PictureBox pictureBoxAllScreen;
        private System.Windows.Forms.PictureBox pictureBoxVisiblePartAllScreen;
        private System.Windows.Forms.PictureBox pictureBoxVisibleShadow;
        private System.Windows.Forms.Label labelFPS;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxCameraDistance;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxCameraAngle;
        private System.Windows.Forms.TextBox textBoxCameraZ;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelTextureFileName;
    }
}

