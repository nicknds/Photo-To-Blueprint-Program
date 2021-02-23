namespace Photo_To_Blueprint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stretchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxShipName = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.labelResize = new System.Windows.Forms.Label();
            this.labelImageWidth = new System.Windows.Forms.Label();
            this.labelImageHeight = new System.Windows.Forms.Label();
            this.labelImageCount = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.labelResizeBlocks = new System.Windows.Forms.Label();
            this.labelResizeHeight = new System.Windows.Forms.Label();
            this.labelResizeWidth = new System.Windows.Forms.Label();
            this.numericUpDownRed = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownGreen = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownBlue = new System.Windows.Forms.NumericUpDown();
            this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownColorThreshold = new System.Windows.Forms.NumericUpDown();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.radioButtonSmallGrid = new System.Windows.Forms.RadioButton();
            this.radioButtonLargeGrid = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numericUpDownResize = new System.Windows.Forms.NumericUpDown();
            this.labelColor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColorThreshold)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownResize)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Open";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(6, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 28);
            this.button2.TabIndex = 1;
            this.button2.Text = "Generate";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBox1.Location = new System.Drawing.Point(581, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(439, 439);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalToolStripMenuItem,
            this.stretchToolStripMenuItem,
            this.autoSizeToolStripMenuItem,
            this.centerToolStripMenuItem,
            this.zoomToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(124, 114);
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.normalToolStripMenuItem.Text = "Normal";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.normalToolStripMenuItem_Click);
            // 
            // stretchToolStripMenuItem
            // 
            this.stretchToolStripMenuItem.Name = "stretchToolStripMenuItem";
            this.stretchToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.stretchToolStripMenuItem.Text = "Stretch";
            this.stretchToolStripMenuItem.Click += new System.EventHandler(this.stretchToolStripMenuItem_Click);
            // 
            // autoSizeToolStripMenuItem
            // 
            this.autoSizeToolStripMenuItem.Name = "autoSizeToolStripMenuItem";
            this.autoSizeToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.autoSizeToolStripMenuItem.Text = "Auto Size";
            this.autoSizeToolStripMenuItem.Click += new System.EventHandler(this.autoSizeToolStripMenuItem_Click);
            // 
            // centerToolStripMenuItem
            // 
            this.centerToolStripMenuItem.Name = "centerToolStripMenuItem";
            this.centerToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.centerToolStripMenuItem.Text = "Center";
            this.centerToolStripMenuItem.Click += new System.EventHandler(this.centerToolStripMenuItem_Click);
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.zoomToolStripMenuItem.Text = "Zoom";
            this.zoomToolStripMenuItem.Click += new System.EventHandler(this.zoomToolStripMenuItem_Click);
            // 
            // textBoxShipName
            // 
            this.textBoxShipName.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxShipName.Location = new System.Drawing.Point(136, 44);
            this.textBoxShipName.Name = "textBoxShipName";
            this.textBoxShipName.Size = new System.Drawing.Size(263, 24);
            this.textBoxShipName.TabIndex = 3;
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUserName.Location = new System.Drawing.Point(136, 92);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(263, 24);
            this.textBoxUserName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(133, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Ship Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(133, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "User Name";
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.BackColor = System.Drawing.SystemColors.Control;
            this.trackBar1.Location = new System.Drawing.Point(6, 155);
            this.trackBar1.Maximum = 10000;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(393, 45);
            this.trackBar1.TabIndex = 8;
            this.trackBar1.Value = 10000;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // labelResize
            // 
            this.labelResize.AutoSize = true;
            this.labelResize.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResize.Location = new System.Drawing.Point(6, 80);
            this.labelResize.Name = "labelResize";
            this.labelResize.Size = new System.Drawing.Size(202, 18);
            this.labelResize.TabIndex = 9;
            this.labelResize.Text = "Resize Percentage: 100.0%";
            // 
            // labelImageWidth
            // 
            this.labelImageWidth.AutoSize = true;
            this.labelImageWidth.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImageWidth.Location = new System.Drawing.Point(6, 110);
            this.labelImageWidth.Name = "labelImageWidth";
            this.labelImageWidth.Size = new System.Drawing.Size(70, 18);
            this.labelImageWidth.TabIndex = 10;
            this.labelImageWidth.Text = "Width: 0";
            // 
            // labelImageHeight
            // 
            this.labelImageHeight.AutoSize = true;
            this.labelImageHeight.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImageHeight.Location = new System.Drawing.Point(6, 128);
            this.labelImageHeight.Name = "labelImageHeight";
            this.labelImageHeight.Size = new System.Drawing.Size(73, 18);
            this.labelImageHeight.TabIndex = 11;
            this.labelImageHeight.Text = "Height: 0";
            // 
            // labelImageCount
            // 
            this.labelImageCount.AutoSize = true;
            this.labelImageCount.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImageCount.Location = new System.Drawing.Point(6, 146);
            this.labelImageCount.Name = "labelImageCount";
            this.labelImageCount.Size = new System.Drawing.Size(73, 18);
            this.labelImageCount.TabIndex = 12;
            this.labelImageCount.Text = "Blocks: 0";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(6, 23);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 28);
            this.button3.TabIndex = 13;
            this.button3.Text = "Resize";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // labelResizeBlocks
            // 
            this.labelResizeBlocks.AutoSize = true;
            this.labelResizeBlocks.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResizeBlocks.Location = new System.Drawing.Point(6, 134);
            this.labelResizeBlocks.Name = "labelResizeBlocks";
            this.labelResizeBlocks.Size = new System.Drawing.Size(73, 18);
            this.labelResizeBlocks.TabIndex = 16;
            this.labelResizeBlocks.Text = "Blocks: 0";
            // 
            // labelResizeHeight
            // 
            this.labelResizeHeight.AutoSize = true;
            this.labelResizeHeight.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResizeHeight.Location = new System.Drawing.Point(6, 116);
            this.labelResizeHeight.Name = "labelResizeHeight";
            this.labelResizeHeight.Size = new System.Drawing.Size(73, 18);
            this.labelResizeHeight.TabIndex = 15;
            this.labelResizeHeight.Text = "Height: 0";
            // 
            // labelResizeWidth
            // 
            this.labelResizeWidth.AutoSize = true;
            this.labelResizeWidth.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResizeWidth.Location = new System.Drawing.Point(6, 98);
            this.labelResizeWidth.Name = "labelResizeWidth";
            this.labelResizeWidth.Size = new System.Drawing.Size(70, 18);
            this.labelResizeWidth.TabIndex = 14;
            this.labelResizeWidth.Text = "Width: 0";
            // 
            // numericUpDownRed
            // 
            this.numericUpDownRed.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownRed.Location = new System.Drawing.Point(6, 71);
            this.numericUpDownRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownRed.Name = "numericUpDownRed";
            this.numericUpDownRed.Size = new System.Drawing.Size(140, 24);
            this.numericUpDownRed.TabIndex = 17;
            this.numericUpDownRed.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownRed.ValueChanged += new System.EventHandler(this.numericUpDownRed_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 18);
            this.label3.TabIndex = 20;
            this.label3.Text = "Color: R";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 18);
            this.label4.TabIndex = 22;
            this.label4.Text = "Color: G";
            // 
            // numericUpDownGreen
            // 
            this.numericUpDownGreen.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownGreen.Location = new System.Drawing.Point(6, 119);
            this.numericUpDownGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownGreen.Name = "numericUpDownGreen";
            this.numericUpDownGreen.Size = new System.Drawing.Size(140, 24);
            this.numericUpDownGreen.TabIndex = 21;
            this.numericUpDownGreen.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownGreen.ValueChanged += new System.EventHandler(this.numericUpDownGreen_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 18);
            this.label5.TabIndex = 24;
            this.label5.Text = "Color: B";
            // 
            // numericUpDownBlue
            // 
            this.numericUpDownBlue.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownBlue.Location = new System.Drawing.Point(6, 167);
            this.numericUpDownBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownBlue.Name = "numericUpDownBlue";
            this.numericUpDownBlue.Size = new System.Drawing.Size(140, 24);
            this.numericUpDownBlue.TabIndex = 23;
            this.numericUpDownBlue.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownBlue.ValueChanged += new System.EventHandler(this.numericUpDownBlue_ValueChanged);
            // 
            // domainUpDown1
            // 
            this.domainUpDown1.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.domainUpDown1.Items.Add("White");
            this.domainUpDown1.Items.Add("Black");
            this.domainUpDown1.Items.Add("Red");
            this.domainUpDown1.Items.Add("Blue");
            this.domainUpDown1.Items.Add("Green");
            this.domainUpDown1.Items.Add("Yellow");
            this.domainUpDown1.Items.Add("Pink");
            this.domainUpDown1.Location = new System.Drawing.Point(6, 23);
            this.domainUpDown1.Name = "domainUpDown1";
            this.domainUpDown1.Size = new System.Drawing.Size(140, 24);
            this.domainUpDown1.TabIndex = 25;
            this.domainUpDown1.Text = "Default Colors";
            this.domainUpDown1.SelectedItemChanged += new System.EventHandler(this.domainUpDown1_SelectedItemChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 18);
            this.label6.TabIndex = 27;
            this.label6.Text = "Color Threshold";
            // 
            // numericUpDownColorThreshold
            // 
            this.numericUpDownColorThreshold.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownColorThreshold.Location = new System.Drawing.Point(6, 215);
            this.numericUpDownColorThreshold.Maximum = new decimal(new int[] {
            765,
            0,
            0,
            0});
            this.numericUpDownColorThreshold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDownColorThreshold.Name = "numericUpDownColorThreshold";
            this.numericUpDownColorThreshold.Size = new System.Drawing.Size(140, 24);
            this.numericUpDownColorThreshold.TabIndex = 26;
            this.toolTip1.SetToolTip(this.numericUpDownColorThreshold, "Set to -1 to disable color exclusion");
            this.numericUpDownColorThreshold.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDownColorThreshold.ValueChanged += new System.EventHandler(this.numericUpDownColorThreshold_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.numericUpDownRed);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.numericUpDownGreen);
            this.groupBox1.Controls.Add(this.numericUpDownColorThreshold);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.domainUpDown1);
            this.groupBox1.Controls.Add(this.numericUpDownBlue);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(423, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(152, 245);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Color Exclusions";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 167);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(393, 23);
            this.progressBar1.TabIndex = 31;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Lucida Bright", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(6, 57);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(114, 20);
            this.checkBox1.TabIndex = 32;
            this.checkBox1.Text = "Basic Resize";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(319, 128);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(80, 28);
            this.button4.TabIndex = 33;
            this.button4.Text = "Recount";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // radioButtonSmallGrid
            // 
            this.radioButtonSmallGrid.AutoSize = true;
            this.radioButtonSmallGrid.Checked = true;
            this.radioButtonSmallGrid.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonSmallGrid.Location = new System.Drawing.Point(6, 85);
            this.radioButtonSmallGrid.Name = "radioButtonSmallGrid";
            this.radioButtonSmallGrid.Size = new System.Drawing.Size(97, 22);
            this.radioButtonSmallGrid.TabIndex = 1;
            this.radioButtonSmallGrid.TabStop = true;
            this.radioButtonSmallGrid.Text = "Small Grid";
            this.radioButtonSmallGrid.UseVisualStyleBackColor = true;
            // 
            // radioButtonLargeGrid
            // 
            this.radioButtonLargeGrid.AutoSize = true;
            this.radioButtonLargeGrid.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonLargeGrid.Location = new System.Drawing.Point(6, 57);
            this.radioButtonLargeGrid.Name = "radioButtonLargeGrid";
            this.radioButtonLargeGrid.Size = new System.Drawing.Size(99, 22);
            this.radioButtonLargeGrid.TabIndex = 0;
            this.radioButtonLargeGrid.Text = "Large Grid";
            this.radioButtonLargeGrid.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.radioButtonSmallGrid);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.radioButtonLargeGrid);
            this.groupBox2.Controls.Add(this.labelImageHeight);
            this.groupBox2.Controls.Add(this.labelImageCount);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.labelImageWidth);
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Controls.Add(this.textBoxUserName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxShipName);
            this.groupBox2.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(405, 197);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Blueprint Generation";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox3.Controls.Add(this.numericUpDownResize);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.labelResizeHeight);
            this.groupBox3.Controls.Add(this.labelResize);
            this.groupBox3.Controls.Add(this.labelResizeBlocks);
            this.groupBox3.Controls.Add(this.trackBar1);
            this.groupBox3.Controls.Add(this.labelResizeWidth);
            this.groupBox3.Font = new System.Drawing.Font("MS Reference Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 249);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(405, 236);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Image Resizing";
            // 
            // numericUpDownResize
            // 
            this.numericUpDownResize.DecimalPlaces = 6;
            this.numericUpDownResize.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numericUpDownResize.Location = new System.Drawing.Point(6, 206);
            this.numericUpDownResize.Name = "numericUpDownResize";
            this.numericUpDownResize.Size = new System.Drawing.Size(120, 24);
            this.numericUpDownResize.TabIndex = 33;
            this.numericUpDownResize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownResize.ValueChanged += new System.EventHandler(this.numericUpDownResize_ValueChanged);
            // 
            // labelColor
            // 
            this.labelColor.AutoSize = true;
            this.labelColor.Location = new System.Drawing.Point(578, 30);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(37, 13);
            this.labelColor.TabIndex = 39;
            this.labelColor.Text = "Color: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 497);
            this.Controls.Add(this.labelColor);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(495, 400);
            this.Name = "Form1";
            this.Text = "NickNDS\' Picture To Blueprint Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColorThreshold)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownResize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxShipName;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stretchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem centerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label labelResize;
        private System.Windows.Forms.Label labelImageWidth;
        private System.Windows.Forms.Label labelImageHeight;
        private System.Windows.Forms.Label labelImageCount;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label labelResizeBlocks;
        private System.Windows.Forms.Label labelResizeHeight;
        private System.Windows.Forms.Label labelResizeWidth;
        private System.Windows.Forms.NumericUpDown numericUpDownRed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownGreen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownBlue;
        private System.Windows.Forms.DomainUpDown domainUpDown1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownColorThreshold;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RadioButton radioButtonSmallGrid;
        private System.Windows.Forms.RadioButton radioButtonLargeGrid;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numericUpDownResize;
        private System.Windows.Forms.Label labelColor;
    }
}

