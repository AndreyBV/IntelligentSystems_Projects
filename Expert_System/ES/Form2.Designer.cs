namespace ES
{
    partial class Form2
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
            this.nUDStep = new System.Windows.Forms.NumericUpDown();
            this.cbOnOffGipercube = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonOp = new System.Windows.Forms.Button();
            this.buttonSv = new System.Windows.Forms.Button();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvMatrixB = new System.Windows.Forms.DataGridView();
            this.lbConcept = new System.Windows.Forms.ListBox();
            this.lbClass = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label6 = new System.Windows.Forms.Label();
            this.btnLearn = new System.Windows.Forms.Button();
            this.combClass = new System.Windows.Forms.ComboBox();
            this.btnSvConcept = new System.Windows.Forms.Button();
            this.btnResetLearn = new System.Windows.Forms.Button();
            this.btnAddClass = new System.Windows.Forms.Button();
            this.txbNameClass = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLearn = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkboxEl = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnResetExpert = new System.Windows.Forms.Button();
            this.txbRes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnQustion = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvExp = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkbox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.nUDStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatrixB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLearn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExp)).BeginInit();
            this.SuspendLayout();
            // 
            // nUDStep
            // 
            this.nUDStep.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nUDStep.Location = new System.Drawing.Point(126, 665);
            this.nUDStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDStep.Name = "nUDStep";
            this.nUDStep.Size = new System.Drawing.Size(120, 22);
            this.nUDStep.TabIndex = 15;
            this.nUDStep.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbOnOffGipercube
            // 
            this.cbOnOffGipercube.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbOnOffGipercube.AutoSize = true;
            this.cbOnOffGipercube.Checked = true;
            this.cbOnOffGipercube.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOnOffGipercube.Location = new System.Drawing.Point(275, 665);
            this.cbOnOffGipercube.Name = "cbOnOffGipercube";
            this.cbOnOffGipercube.Size = new System.Drawing.Size(216, 21);
            this.cbOnOffGipercube.TabIndex = 14;
            this.cbOnOffGipercube.Text = "Возврат на грани гиперкуба";
            this.cbOnOffGipercube.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 665);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Шаг:";
            // 
            // buttonOp
            // 
            this.buttonOp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOp.Location = new System.Drawing.Point(732, 654);
            this.buttonOp.Name = "buttonOp";
            this.buttonOp.Size = new System.Drawing.Size(129, 41);
            this.buttonOp.TabIndex = 12;
            this.buttonOp.Text = "Открыть";
            this.buttonOp.UseVisualStyleBackColor = true;
            // 
            // buttonSv
            // 
            this.buttonSv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSv.Location = new System.Drawing.Point(597, 654);
            this.buttonSv.Name = "buttonSv";
            this.buttonSv.Size = new System.Drawing.Size(129, 41);
            this.buttonSv.TabIndex = 11;
            this.buttonSv.Text = "Сохранить";
            this.buttonSv.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer3.Location = new System.Drawing.Point(867, 50);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.lbClass);
            this.splitContainer3.Size = new System.Drawing.Size(259, 650);
            this.splitContainer3.SplitterDistance = 393;
            this.splitContainer3.TabIndex = 10;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(0, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvMatrixB);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel2.Controls.Add(this.lbConcept);
            this.splitContainer2.Size = new System.Drawing.Size(256, 332);
            this.splitContainer2.SplitterDistance = 161;
            this.splitContainer2.TabIndex = 1;
            // 
            // dgvMatrixB
            // 
            this.dgvMatrixB.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMatrixB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatrixB.Location = new System.Drawing.Point(14, 10);
            this.dgvMatrixB.Name = "dgvMatrixB";
            this.dgvMatrixB.RowTemplate.Height = 24;
            this.dgvMatrixB.Size = new System.Drawing.Size(218, 178);
            this.dgvMatrixB.TabIndex = 0;
            // 
            // lbConcept
            // 
            this.lbConcept.FormattingEnabled = true;
            this.lbConcept.ItemHeight = 16;
            this.lbConcept.Location = new System.Drawing.Point(14, 17);
            this.lbConcept.Name = "lbConcept";
            this.lbConcept.Size = new System.Drawing.Size(218, 164);
            this.lbConcept.TabIndex = 0;
            // 
            // lbClass
            // 
            this.lbClass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbClass.FormattingEnabled = true;
            this.lbClass.ItemHeight = 16;
            this.lbClass.Location = new System.Drawing.Point(14, 18);
            this.lbClass.Name = "lbClass";
            this.lbClass.Size = new System.Drawing.Size(218, 116);
            this.lbClass.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(60, 50);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.btnLearn);
            this.splitContainer1.Panel1.Controls.Add(this.combClass);
            this.splitContainer1.Panel1.Controls.Add(this.btnSvConcept);
            this.splitContainer1.Panel1.Controls.Add(this.btnResetLearn);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddClass);
            this.splitContainer1.Panel1.Controls.Add(this.txbNameClass);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.dgvLearn);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.btnResetExpert);
            this.splitContainer1.Panel2.Controls.Add(this.txbRes);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.btnQustion);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.dgvExp);
            this.splitContainer1.Size = new System.Drawing.Size(801, 593);
            this.splitContainer1.SplitterDistance = 416;
            this.splitContainer1.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 461);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Доступные классы:";
            // 
            // btnLearn
            // 
            this.btnLearn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLearn.Location = new System.Drawing.Point(326, 461);
            this.btnLearn.Name = "btnLearn";
            this.btnLearn.Size = new System.Drawing.Size(145, 50);
            this.btnLearn.TabIndex = 13;
            this.btnLearn.Text = "Обучить";
            this.btnLearn.UseVisualStyleBackColor = true;
            // 
            // combClass
            // 
            this.combClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.combClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combClass.Location = new System.Drawing.Point(12, 486);
            this.combClass.Name = "combClass";
            this.combClass.Size = new System.Drawing.Size(156, 24);
            this.combClass.TabIndex = 12;
            // 
            // btnSvConcept
            // 
            this.btnSvConcept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSvConcept.Location = new System.Drawing.Point(177, 408);
            this.btnSvConcept.Name = "btnSvConcept";
            this.btnSvConcept.Size = new System.Drawing.Size(143, 50);
            this.btnSvConcept.TabIndex = 11;
            this.btnSvConcept.Text = "Сохр. признаки";
            this.btnSvConcept.UseVisualStyleBackColor = true;
            // 
            // btnResetLearn
            // 
            this.btnResetLearn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnResetLearn.Location = new System.Drawing.Point(177, 461);
            this.btnResetLearn.Name = "btnResetLearn";
            this.btnResetLearn.Size = new System.Drawing.Size(143, 50);
            this.btnResetLearn.TabIndex = 10;
            this.btnResetLearn.Text = "Сбросить выбор";
            this.btnResetLearn.UseVisualStyleBackColor = true;
            // 
            // btnAddClass
            // 
            this.btnAddClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddClass.Location = new System.Drawing.Point(326, 408);
            this.btnAddClass.Name = "btnAddClass";
            this.btnAddClass.Size = new System.Drawing.Size(145, 50);
            this.btnAddClass.TabIndex = 9;
            this.btnAddClass.Text = "Добавить";
            this.btnAddClass.UseVisualStyleBackColor = true;
            // 
            // txbNameClass
            // 
            this.txbNameClass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txbNameClass.Location = new System.Drawing.Point(12, 433);
            this.txbNameClass.Name = "txbNameClass";
            this.txbNameClass.Size = new System.Drawing.Size(156, 22);
            this.txbNameClass.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 408);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Наименование класса:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(173, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "ОБУЧЕНИЕ";
            // 
            // dgvLearn
            // 
            this.dgvLearn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLearn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLearn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLearn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.checkboxEl});
            this.dgvLearn.Location = new System.Drawing.Point(12, 44);
            this.dgvLearn.Name = "dgvLearn";
            this.dgvLearn.RowTemplate.Height = 24;
            this.dgvLearn.Size = new System.Drawing.Size(310, 347);
            this.dgvLearn.TabIndex = 2;
            // 
            // name
            // 
            this.name.HeaderText = "Наименование";
            this.name.Name = "name";
            // 
            // checkboxEl
            // 
            this.checkboxEl.HeaderText = "Выбор";
            this.checkboxEl.Name = "checkboxEl";
            // 
            // btnResetExpert
            // 
            this.btnResetExpert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnResetExpert.Location = new System.Drawing.Point(16, 408);
            this.btnResetExpert.Name = "btnResetExpert";
            this.btnResetExpert.Size = new System.Drawing.Size(133, 50);
            this.btnResetExpert.TabIndex = 12;
            this.btnResetExpert.Text = "Сбросить выбор";
            this.btnResetExpert.UseVisualStyleBackColor = true;
            // 
            // txbRes
            // 
            this.txbRes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txbRes.Location = new System.Drawing.Point(72, 488);
            this.txbRes.Name = "txbRes";
            this.txbRes.ReadOnly = true;
            this.txbRes.Size = new System.Drawing.Size(221, 22);
            this.txbRes.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 488);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ответ:";
            // 
            // btnQustion
            // 
            this.btnQustion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnQustion.Location = new System.Drawing.Point(160, 408);
            this.btnQustion.Name = "btnQustion";
            this.btnQustion.Size = new System.Drawing.Size(133, 50);
            this.btnQustion.TabIndex = 9;
            this.btnQustion.Text = "Спросить";
            this.btnQustion.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(88, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "ЭКСПЕРТИЗА";
            // 
            // dgvExp
            // 
            this.dgvExp.AllowUserToAddRows = false;
            this.dgvExp.AllowUserToDeleteRows = false;
            this.dgvExp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvExp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.checkbox});
            this.dgvExp.Location = new System.Drawing.Point(17, 44);
            this.dgvExp.Name = "dgvExp";
            this.dgvExp.RowTemplate.Height = 24;
            this.dgvExp.Size = new System.Drawing.Size(292, 347);
            this.dgvExp.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Наименование";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // checkbox
            // 
            this.checkbox.HeaderText = "Выбор";
            this.checkbox.Name = "checkbox";
            this.checkbox.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.checkbox.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 751);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.nUDStep);
            this.Controls.Add(this.cbOnOffGipercube);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonOp);
            this.Controls.Add(this.buttonSv);
            this.Controls.Add(this.splitContainer3);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.nUDStep)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatrixB)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLearn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nUDStep;
        private System.Windows.Forms.CheckBox cbOnOffGipercube;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonOp;
        private System.Windows.Forms.Button buttonSv;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgvMatrixB;
        private System.Windows.Forms.ListBox lbConcept;
        private System.Windows.Forms.ListBox lbClass;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnLearn;
        private System.Windows.Forms.ComboBox combClass;
        private System.Windows.Forms.Button btnSvConcept;
        private System.Windows.Forms.Button btnResetLearn;
        private System.Windows.Forms.Button btnAddClass;
        private System.Windows.Forms.TextBox txbNameClass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvLearn;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkboxEl;
        private System.Windows.Forms.Button btnResetExpert;
        private System.Windows.Forms.TextBox txbRes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnQustion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvExp;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkbox;
    }
}