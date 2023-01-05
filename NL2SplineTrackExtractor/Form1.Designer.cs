namespace NL2SplineTrackExtractor
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.inputPathTextBox = new System.Windows.Forms.TextBox();
            this.inputPathChangeBtn = new System.Windows.Forms.Button();
            this.caluclateBtn = new System.Windows.Forms.Button();
            this.leftChkbx = new System.Windows.Forms.CheckBox();
            this.topChkbx = new System.Windows.Forms.CheckBox();
            this.rightChkbx = new System.Windows.Forms.CheckBox();
            this.bottomChkbx = new System.Windows.Forms.CheckBox();
            this.centerChkbx = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.outputPathChangeBtn = new System.Windows.Forms.Button();
            this.outputPathTextbox = new System.Windows.Forms.TextBox();
            this.splitTypeSelector = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.nodesPerSplitSelector = new System.Windows.Forms.NumericUpDown();
            this.xLabel = new System.Windows.Forms.Label();
            this.piecesSelector = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.roundTripChkbx = new System.Windows.Forms.CheckBox();
            this.numSplinePointsLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.bottomDistanceTextBox = new System.Windows.Forms.TextBox();
            this.rightDistanceTextBox = new System.Windows.Forms.TextBox();
            this.topDistanceTextBox = new System.Windows.Forms.TextBox();
            this.leftDistanceTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.xRotationTextbox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.yRotationTextbox = new System.Windows.Forms.TextBox();
            this.zRotationTextbox = new System.Windows.Forms.TextBox();
            this.affectDistancesCheckbox = new System.Windows.Forms.CheckBox();
            this.scalingTextbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.affectOffsetCheckbox = new System.Windows.Forms.CheckBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.zOffsetTextbox = new System.Windows.Forms.TextBox();
            this.yOffsetTextbox = new System.Windows.Forms.TextBox();
            this.xOffsetTextbox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nodesPerSplitSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.piecesSelector)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputPathTextBox
            // 
            this.inputPathTextBox.Location = new System.Drawing.Point(17, 27);
            this.inputPathTextBox.Name = "inputPathTextBox";
            this.inputPathTextBox.Size = new System.Drawing.Size(396, 22);
            this.inputPathTextBox.TabIndex = 0;
            this.inputPathTextBox.Text = "Select path...";
            this.inputPathTextBox.TextChanged += new System.EventHandler(this.inputPathTextBox_TextChanged);
            this.inputPathTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textField_KeyDown);
            // 
            // inputPathChangeBtn
            // 
            this.inputPathChangeBtn.Location = new System.Drawing.Point(420, 25);
            this.inputPathChangeBtn.Name = "inputPathChangeBtn";
            this.inputPathChangeBtn.Size = new System.Drawing.Size(75, 24);
            this.inputPathChangeBtn.TabIndex = 1;
            this.inputPathChangeBtn.Text = "Browse";
            this.inputPathChangeBtn.UseVisualStyleBackColor = true;
            this.inputPathChangeBtn.Click += new System.EventHandler(this.inputPathChangeBtn_Click);
            // 
            // caluclateBtn
            // 
            this.caluclateBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.caluclateBtn.Location = new System.Drawing.Point(12, 289);
            this.caluclateBtn.Name = "caluclateBtn";
            this.caluclateBtn.Size = new System.Drawing.Size(89, 101);
            this.caluclateBtn.TabIndex = 3;
            this.caluclateBtn.Text = "Calculate";
            this.caluclateBtn.UseVisualStyleBackColor = true;
            this.caluclateBtn.Click += new System.EventHandler(this.caluclateBtn_Click);
            // 
            // leftChkbx
            // 
            this.leftChkbx.AutoSize = true;
            this.leftChkbx.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.leftChkbx.Location = new System.Drawing.Point(530, 96);
            this.leftChkbx.Name = "leftChkbx";
            this.leftChkbx.Size = new System.Drawing.Size(50, 20);
            this.leftChkbx.TabIndex = 4;
            this.leftChkbx.Text = "Left";
            this.leftChkbx.UseVisualStyleBackColor = false;
            // 
            // topChkbx
            // 
            this.topChkbx.AutoSize = true;
            this.topChkbx.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.topChkbx.Location = new System.Drawing.Point(600, 42);
            this.topChkbx.Name = "topChkbx";
            this.topChkbx.Size = new System.Drawing.Size(54, 20);
            this.topChkbx.TabIndex = 5;
            this.topChkbx.Text = "Top";
            this.topChkbx.UseVisualStyleBackColor = false;
            // 
            // rightChkbx
            // 
            this.rightChkbx.AutoSize = true;
            this.rightChkbx.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rightChkbx.Location = new System.Drawing.Point(677, 94);
            this.rightChkbx.Name = "rightChkbx";
            this.rightChkbx.Size = new System.Drawing.Size(60, 20);
            this.rightChkbx.TabIndex = 6;
            this.rightChkbx.Text = "Right";
            this.rightChkbx.UseVisualStyleBackColor = false;
            // 
            // bottomChkbx
            // 
            this.bottomChkbx.AutoSize = true;
            this.bottomChkbx.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bottomChkbx.Location = new System.Drawing.Point(600, 147);
            this.bottomChkbx.Name = "bottomChkbx";
            this.bottomChkbx.Size = new System.Drawing.Size(71, 20);
            this.bottomChkbx.TabIndex = 7;
            this.bottomChkbx.Text = "Bottom";
            this.bottomChkbx.UseVisualStyleBackColor = false;
            // 
            // centerChkbx
            // 
            this.centerChkbx.AutoSize = true;
            this.centerChkbx.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.centerChkbx.Location = new System.Drawing.Point(600, 96);
            this.centerChkbx.Name = "centerChkbx";
            this.centerChkbx.Size = new System.Drawing.Size(68, 20);
            this.centerChkbx.TabIndex = 8;
            this.centerChkbx.Text = "Center";
            this.centerChkbx.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(14, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Input file path:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Splines to extract:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(14, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Output folder path:";
            // 
            // outputPathChangeBtn
            // 
            this.outputPathChangeBtn.Location = new System.Drawing.Point(420, 68);
            this.outputPathChangeBtn.Name = "outputPathChangeBtn";
            this.outputPathChangeBtn.Size = new System.Drawing.Size(75, 24);
            this.outputPathChangeBtn.TabIndex = 13;
            this.outputPathChangeBtn.Text = "Browse";
            this.outputPathChangeBtn.UseVisualStyleBackColor = true;
            this.outputPathChangeBtn.Click += new System.EventHandler(this.outputPathChangeBtn_Click);
            // 
            // outputPathTextbox
            // 
            this.outputPathTextbox.Location = new System.Drawing.Point(17, 70);
            this.outputPathTextbox.Name = "outputPathTextbox";
            this.outputPathTextbox.Size = new System.Drawing.Size(396, 22);
            this.outputPathTextbox.TabIndex = 12;
            this.outputPathTextbox.Text = "Select path...";
            this.outputPathTextbox.TextChanged += new System.EventHandler(this.outputPathTextbox_TextChanged);
            this.outputPathTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textField_KeyDown);
            // 
            // splitTypeSelector
            // 
            this.splitTypeSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.splitTypeSelector.FormattingEnabled = true;
            this.splitTypeSelector.Location = new System.Drawing.Point(5, 27);
            this.splitTypeSelector.Name = "splitTypeSelector";
            this.splitTypeSelector.Size = new System.Drawing.Size(153, 24);
            this.splitTypeSelector.TabIndex = 15;
            this.splitTypeSelector.SelectedIndexChanged += new System.EventHandler(this.splitTypeSelector_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(2, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Split Type;";
            // 
            // nodesPerSplitSelector
            // 
            this.nodesPerSplitSelector.Location = new System.Drawing.Point(38, 65);
            this.nodesPerSplitSelector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nodesPerSplitSelector.Name = "nodesPerSplitSelector";
            this.nodesPerSplitSelector.Size = new System.Drawing.Size(120, 22);
            this.nodesPerSplitSelector.TabIndex = 17;
            this.nodesPerSplitSelector.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nodesPerSplitSelector.ValueChanged += new System.EventHandler(this.nodesPerSplitSelector_ValueChanged);
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.xLabel.Location = new System.Drawing.Point(16, 68);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(16, 16);
            this.xLabel.TabIndex = 18;
            this.xLabel.Text = "x:";
            // 
            // piecesSelector
            // 
            this.piecesSelector.Location = new System.Drawing.Point(38, 65);
            this.piecesSelector.Name = "piecesSelector";
            this.piecesSelector.Size = new System.Drawing.Size(120, 22);
            this.piecesSelector.TabIndex = 19;
            this.piecesSelector.ValueChanged += new System.EventHandler(this.piecesSelector_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.splitTypeSelector);
            this.panel1.Controls.Add(this.xLabel);
            this.panel1.Controls.Add(this.nodesPerSplitSelector);
            this.panel1.Controls.Add(this.piecesSelector);
            this.panel1.Location = new System.Drawing.Point(107, 289);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(161, 101);
            this.panel1.TabIndex = 20;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.roundTripChkbx);
            this.panel2.Controls.Add(this.numSplinePointsLabel);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(12, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(487, 142);
            this.panel2.TabIndex = 21;
            // 
            // roundTripChkbx
            // 
            this.roundTripChkbx.AutoSize = true;
            this.roundTripChkbx.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.roundTripChkbx.Location = new System.Drawing.Point(262, 104);
            this.roundTripChkbx.Name = "roundTripChkbx";
            this.roundTripChkbx.Size = new System.Drawing.Size(146, 20);
            this.roundTripChkbx.TabIndex = 24;
            this.roundTripChkbx.Text = "Connect end to start";
            this.roundTripChkbx.UseVisualStyleBackColor = false;
            this.roundTripChkbx.CheckedChanged += new System.EventHandler(this.roundTripChkbx_CheckedChanged);
            // 
            // numSplinePointsLabel
            // 
            this.numSplinePointsLabel.AutoSize = true;
            this.numSplinePointsLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.numSplinePointsLabel.Location = new System.Drawing.Point(137, 105);
            this.numSplinePointsLabel.Name = "numSplinePointsLabel";
            this.numSplinePointsLabel.Size = new System.Drawing.Size(30, 16);
            this.numSplinePointsLabel.TabIndex = 18;
            this.numSplinePointsLabel.Text = "N/A";
            this.numSplinePointsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label7.Location = new System.Drawing.Point(12, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "Center spline points:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(505, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(247, 187);
            this.panel3.TabIndex = 22;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel4.Controls.Add(this.label19);
            this.panel4.Controls.Add(this.label18);
            this.panel4.Controls.Add(this.label17);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.bottomDistanceTextBox);
            this.panel4.Controls.Add(this.rightDistanceTextBox);
            this.panel4.Controls.Add(this.topDistanceTextBox);
            this.panel4.Controls.Add(this.leftDistanceTextBox);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(505, 198);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(247, 192);
            this.panel4.TabIndex = 23;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label19.Location = new System.Drawing.Point(172, 91);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(38, 16);
            this.label19.TabIndex = 34;
            this.label19.Text = "Right";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label18.Location = new System.Drawing.Point(94, 137);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(49, 16);
            this.label18.TabIndex = 33;
            this.label18.Text = "Bottom";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label17.Location = new System.Drawing.Point(12, 91);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(28, 16);
            this.label17.TabIndex = 32;
            this.label17.Text = "Left";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label16.Location = new System.Drawing.Point(92, 37);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(32, 16);
            this.label16.TabIndex = 31;
            this.label16.Text = "Top";
            // 
            // bottomDistanceTextBox
            // 
            this.bottomDistanceTextBox.Location = new System.Drawing.Point(94, 156);
            this.bottomDistanceTextBox.Name = "bottomDistanceTextBox";
            this.bottomDistanceTextBox.Size = new System.Drawing.Size(69, 22);
            this.bottomDistanceTextBox.TabIndex = 14;
            this.bottomDistanceTextBox.Text = "10";
            this.bottomDistanceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.bottomDistanceTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textField_KeyDown);
            this.bottomDistanceTextBox.LostFocus += new System.EventHandler(this.bottomDistanceTextBox_LostFocus);
            // 
            // rightDistanceTextBox
            // 
            this.rightDistanceTextBox.Location = new System.Drawing.Point(175, 110);
            this.rightDistanceTextBox.Name = "rightDistanceTextBox";
            this.rightDistanceTextBox.Size = new System.Drawing.Size(69, 22);
            this.rightDistanceTextBox.TabIndex = 13;
            this.rightDistanceTextBox.Text = "10";
            this.rightDistanceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.rightDistanceTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textField_KeyDown);
            this.rightDistanceTextBox.LostFocus += new System.EventHandler(this.rightDistanceTextBox_LostFocus);
            // 
            // topDistanceTextBox
            // 
            this.topDistanceTextBox.Location = new System.Drawing.Point(94, 56);
            this.topDistanceTextBox.Name = "topDistanceTextBox";
            this.topDistanceTextBox.Size = new System.Drawing.Size(69, 22);
            this.topDistanceTextBox.TabIndex = 12;
            this.topDistanceTextBox.Text = "10";
            this.topDistanceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.topDistanceTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textField_KeyDown);
            this.topDistanceTextBox.LostFocus += new System.EventHandler(this.topDistanceTextBox_LostFocus);
            // 
            // leftDistanceTextBox
            // 
            this.leftDistanceTextBox.Location = new System.Drawing.Point(15, 110);
            this.leftDistanceTextBox.Name = "leftDistanceTextBox";
            this.leftDistanceTextBox.Size = new System.Drawing.Size(69, 22);
            this.leftDistanceTextBox.TabIndex = 11;
            this.leftDistanceTextBox.Text = "10";
            this.leftDistanceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.leftDistanceTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textField_KeyDown);
            this.leftDistanceTextBox.LostFocus += new System.EventHandler(this.leftDistanceTextBox_LostFocus);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(3, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Distance to Center:";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel5.Controls.Add(this.label13);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.label14);
            this.panel5.Controls.Add(this.xRotationTextbox);
            this.panel5.Controls.Add(this.label15);
            this.panel5.Controls.Add(this.yRotationTextbox);
            this.panel5.Controls.Add(this.zRotationTextbox);
            this.panel5.Location = new System.Drawing.Point(203, 153);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(296, 130);
            this.panel5.TabIndex = 21;
            this.panel5.Click += new System.EventHandler(this.panel5_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label13.Location = new System.Drawing.Point(42, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(109, 16);
            this.label13.TabIndex = 30;
            this.label13.Text = "z Axis (NL2 Front)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label8.Location = new System.Drawing.Point(3, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "Rotation (around origin)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label14.Location = new System.Drawing.Point(42, 64);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(105, 16);
            this.label14.TabIndex = 29;
            this.label14.Text = "y Axis (NL2 Top)";
            // 
            // xRotationTextbox
            // 
            this.xRotationTextbox.Location = new System.Drawing.Point(173, 33);
            this.xRotationTextbox.Name = "xRotationTextbox";
            this.xRotationTextbox.Size = new System.Drawing.Size(69, 22);
            this.xRotationTextbox.TabIndex = 25;
            this.xRotationTextbox.Text = "90";
            this.xRotationTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.xRotationTextbox.Click += new System.EventHandler(this.panel5_Click);
            this.xRotationTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textField_KeyDown);
            this.xRotationTextbox.LostFocus += new System.EventHandler(this.xRotationTextbox_LostFocus);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label15.Location = new System.Drawing.Point(42, 36);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 16);
            this.label15.TabIndex = 28;
            this.label15.Text = "x Axis (NL2 Left)";
            // 
            // yRotationTextbox
            // 
            this.yRotationTextbox.Location = new System.Drawing.Point(173, 61);
            this.yRotationTextbox.Name = "yRotationTextbox";
            this.yRotationTextbox.Size = new System.Drawing.Size(69, 22);
            this.yRotationTextbox.TabIndex = 26;
            this.yRotationTextbox.Text = "0";
            this.yRotationTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.yRotationTextbox.Click += new System.EventHandler(this.panel5_Click);
            this.yRotationTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textField_KeyDown);
            this.yRotationTextbox.LostFocus += new System.EventHandler(this.yRotationTextbox_LostFocus);
            // 
            // zRotationTextbox
            // 
            this.zRotationTextbox.Location = new System.Drawing.Point(173, 89);
            this.zRotationTextbox.Name = "zRotationTextbox";
            this.zRotationTextbox.Size = new System.Drawing.Size(69, 22);
            this.zRotationTextbox.TabIndex = 27;
            this.zRotationTextbox.Text = "0";
            this.zRotationTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.zRotationTextbox.Click += new System.EventHandler(this.panel5_Click);
            this.zRotationTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textField_KeyDown);
            this.zRotationTextbox.LostFocus += new System.EventHandler(this.zRotationTextbox_LostFocus);
            // 
            // affectDistancesCheckbox
            // 
            this.affectDistancesCheckbox.AutoSize = true;
            this.affectDistancesCheckbox.Checked = true;
            this.affectDistancesCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.affectDistancesCheckbox.Location = new System.Drawing.Point(6, 44);
            this.affectDistancesCheckbox.Name = "affectDistancesCheckbox";
            this.affectDistancesCheckbox.Size = new System.Drawing.Size(176, 20);
            this.affectDistancesCheckbox.TabIndex = 18;
            this.affectDistancesCheckbox.Text = "affect distances to center";
            this.affectDistancesCheckbox.UseVisualStyleBackColor = true;
            this.affectDistancesCheckbox.CheckedChanged += new System.EventHandler(this.affectDistancesCheckbox_CheckedChanged);
            // 
            // scalingTextbox
            // 
            this.scalingTextbox.Location = new System.Drawing.Point(82, 16);
            this.scalingTextbox.Name = "scalingTextbox";
            this.scalingTextbox.Size = new System.Drawing.Size(57, 22);
            this.scalingTextbox.TabIndex = 15;
            this.scalingTextbox.Text = "1";
            this.scalingTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.scalingTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textField_KeyDown);
            this.scalingTextbox.LostFocus += new System.EventHandler(this.scalingTextbox_LostFocus);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(3, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Scale;";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel6.Controls.Add(this.affectOffsetCheckbox);
            this.panel6.Controls.Add(this.scalingTextbox);
            this.panel6.Controls.Add(this.affectDistancesCheckbox);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Location = new System.Drawing.Point(274, 289);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(225, 101);
            this.panel6.TabIndex = 22;
            // 
            // affectOffsetCheckbox
            // 
            this.affectOffsetCheckbox.AutoSize = true;
            this.affectOffsetCheckbox.Checked = true;
            this.affectOffsetCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.affectOffsetCheckbox.Location = new System.Drawing.Point(6, 67);
            this.affectOffsetCheckbox.Name = "affectOffsetCheckbox";
            this.affectOffsetCheckbox.Size = new System.Drawing.Size(96, 20);
            this.affectOffsetCheckbox.TabIndex = 19;
            this.affectOffsetCheckbox.Text = "affect offset";
            this.affectOffsetCheckbox.UseVisualStyleBackColor = true;
            this.affectOffsetCheckbox.CheckedChanged += new System.EventHandler(this.affectOffsetCheckbox_CheckedChanged);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel7.Controls.Add(this.label12);
            this.panel7.Controls.Add(this.label11);
            this.panel7.Controls.Add(this.label10);
            this.panel7.Controls.Add(this.zOffsetTextbox);
            this.panel7.Controls.Add(this.yOffsetTextbox);
            this.panel7.Controls.Add(this.xOffsetTextbox);
            this.panel7.Controls.Add(this.label9);
            this.panel7.Location = new System.Drawing.Point(12, 153);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(185, 130);
            this.panel7.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label12.Location = new System.Drawing.Point(25, 95);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 16);
            this.label12.TabIndex = 24;
            this.label12.Text = "z";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label11.Location = new System.Drawing.Point(25, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 16);
            this.label11.TabIndex = 23;
            this.label11.Text = "y";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label10.Location = new System.Drawing.Point(25, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 16);
            this.label10.TabIndex = 22;
            this.label10.Text = "x";
            // 
            // zOffsetTextbox
            // 
            this.zOffsetTextbox.Location = new System.Drawing.Point(44, 89);
            this.zOffsetTextbox.Name = "zOffsetTextbox";
            this.zOffsetTextbox.Size = new System.Drawing.Size(114, 22);
            this.zOffsetTextbox.TabIndex = 21;
            this.zOffsetTextbox.Text = "0";
            this.zOffsetTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.zOffsetTextbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel5_Click);
            this.zOffsetTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textField_KeyDown);
            this.zOffsetTextbox.LostFocus += new System.EventHandler(this.zOffsetTextbox_LostFocus);
            // 
            // yOffsetTextbox
            // 
            this.yOffsetTextbox.Location = new System.Drawing.Point(44, 61);
            this.yOffsetTextbox.Name = "yOffsetTextbox";
            this.yOffsetTextbox.Size = new System.Drawing.Size(114, 22);
            this.yOffsetTextbox.TabIndex = 20;
            this.yOffsetTextbox.Text = "0";
            this.yOffsetTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.yOffsetTextbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel5_Click);
            this.yOffsetTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textField_KeyDown);
            this.yOffsetTextbox.LostFocus += new System.EventHandler(this.yOffsetTextbox_LostFocus);
            // 
            // xOffsetTextbox
            // 
            this.xOffsetTextbox.Location = new System.Drawing.Point(44, 33);
            this.xOffsetTextbox.Name = "xOffsetTextbox";
            this.xOffsetTextbox.Size = new System.Drawing.Size(113, 22);
            this.xOffsetTextbox.TabIndex = 15;
            this.xOffsetTextbox.Text = "0";
            this.xOffsetTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.xOffsetTextbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel5_Click);
            this.xOffsetTextbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textField_KeyDown);
            this.xOffsetTextbox.LostFocus += new System.EventHandler(this.xOffsetTextbox_LostFocus);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.Location = new System.Drawing.Point(3, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(174, 16);
            this.label9.TabIndex = 19;
            this.label9.Text = "Offset (applied after rotation)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 397);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.outputPathChangeBtn);
            this.Controls.Add(this.outputPathTextbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.centerChkbx);
            this.Controls.Add(this.bottomChkbx);
            this.Controls.Add(this.rightChkbx);
            this.Controls.Add(this.topChkbx);
            this.Controls.Add(this.leftChkbx);
            this.Controls.Add(this.caluclateBtn);
            this.Controls.Add(this.inputPathChangeBtn);
            this.Controls.Add(this.inputPathTextBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "NL2SplineExtractor";
            ((System.ComponentModel.ISupportInitialize)(this.nodesPerSplitSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.piecesSelector)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputPathTextBox;
        private System.Windows.Forms.Button inputPathChangeBtn;
        private System.Windows.Forms.Button caluclateBtn;
        private System.Windows.Forms.CheckBox leftChkbx;
        private System.Windows.Forms.CheckBox topChkbx;
        private System.Windows.Forms.CheckBox rightChkbx;
        private System.Windows.Forms.CheckBox bottomChkbx;
        private System.Windows.Forms.CheckBox centerChkbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button outputPathChangeBtn;
        private System.Windows.Forms.TextBox outputPathTextbox;
        private System.Windows.Forms.ComboBox splitTypeSelector;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nodesPerSplitSelector;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.NumericUpDown piecesSelector;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox bottomDistanceTextBox;
        private System.Windows.Forms.TextBox rightDistanceTextBox;
        private System.Windows.Forms.TextBox topDistanceTextBox;
        private System.Windows.Forms.TextBox leftDistanceTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox affectDistancesCheckbox;
        private System.Windows.Forms.TextBox scalingTextbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label numSplinePointsLabel;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox xRotationTextbox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox yRotationTextbox;
        private System.Windows.Forms.TextBox zRotationTextbox;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox zOffsetTextbox;
        private System.Windows.Forms.TextBox yOffsetTextbox;
        private System.Windows.Forms.TextBox xOffsetTextbox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox affectOffsetCheckbox;
        private System.Windows.Forms.CheckBox roundTripChkbx;
    }
}

