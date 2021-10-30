namespace K_means
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txbNumClass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbStartCenter = new System.Windows.Forms.TextBox();
            this.btnSolve = new System.Windows.Forms.Button();
            this.btnAddCol = new System.Windows.Forms.Button();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnChart = new System.Windows.Forms.Button();
            this.rbKmeans = new System.Windows.Forms.RadioButton();
            this.rbCos = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvBase = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClean = new System.Windows.Forms.Button();
            this.btnWinRegression = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsRemoveRow = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRemoveCol = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBase)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txbNumClass
            // 
            this.txbNumClass.Location = new System.Drawing.Point(3, 28);
            this.txbNumClass.Name = "txbNumClass";
            this.txbNumClass.Size = new System.Drawing.Size(175, 22);
            this.txbNumClass.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Количество классов:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Начальный центр:";
            // 
            // txbStartCenter
            // 
            this.txbStartCenter.Location = new System.Drawing.Point(4, 73);
            this.txbStartCenter.Name = "txbStartCenter";
            this.txbStartCenter.ReadOnly = true;
            this.txbStartCenter.Size = new System.Drawing.Size(175, 22);
            this.txbStartCenter.TabIndex = 3;
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(200, 127);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(175, 38);
            this.btnSolve.TabIndex = 5;
            this.btnSolve.Text = "Решить";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // btnAddCol
            // 
            this.btnAddCol.Location = new System.Drawing.Point(3, 127);
            this.btnAddCol.Name = "btnAddCol";
            this.btnAddCol.Size = new System.Drawing.Size(175, 38);
            this.btnAddCol.TabIndex = 6;
            this.btnAddCol.Text = "Добавить столбец";
            this.btnAddCol.UseVisualStyleBackColor = true;
            this.btnAddCol.Click += new System.EventHandler(this.btnAddCol_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Location = new System.Drawing.Point(4, 171);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(175, 38);
            this.btnAddRow.TabIndex = 7;
            this.btnAddRow.Text = "Добавить строку";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(200, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(175, 38);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Сохранить ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(200, 56);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(175, 38);
            this.btnLoad.TabIndex = 9;
            this.btnLoad.Text = " Открыть";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnChart
            // 
            this.btnChart.Location = new System.Drawing.Point(200, 171);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(175, 38);
            this.btnChart.TabIndex = 11;
            this.btnChart.Text = "График";
            this.btnChart.UseVisualStyleBackColor = true;
            this.btnChart.Click += new System.EventHandler(this.btnChart_Click);
            // 
            // rbKmeans
            // 
            this.rbKmeans.AutoSize = true;
            this.rbKmeans.Location = new System.Drawing.Point(211, 100);
            this.rbKmeans.Name = "rbKmeans";
            this.rbKmeans.Size = new System.Drawing.Size(95, 21);
            this.rbKmeans.TabIndex = 12;
            this.rbKmeans.TabStop = true;
            this.rbKmeans.Text = "K-MEANS ";
            this.rbKmeans.UseVisualStyleBackColor = true;
            this.rbKmeans.CheckedChanged += new System.EventHandler(this.rbKmeans_CheckedChanged);
            // 
            // rbCos
            // 
            this.rbCos.AutoSize = true;
            this.rbCos.Location = new System.Drawing.Point(312, 100);
            this.rbCos.Name = "rbCos";
            this.rbCos.Size = new System.Drawing.Size(58, 21);
            this.rbCos.TabIndex = 13;
            this.rbCos.TabStop = true;
            this.rbCos.Text = "COS";
            this.rbCos.UseVisualStyleBackColor = true;
            this.rbCos.CheckedChanged += new System.EventHandler(this.rbKmeans_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(6, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(797, 710);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvBase);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(789, 681);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Исходные данные";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvBase
            // 
            this.dgvBase.AllowUserToAddRows = false;
            this.dgvBase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBase.BackgroundColor = System.Drawing.Color.White;
            this.dgvBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBase.ColumnHeadersVisible = false;
            this.dgvBase.Location = new System.Drawing.Point(3, 4);
            this.dgvBase.Name = "dgvBase";
            this.dgvBase.RowHeadersVisible = false;
            this.dgvBase.RowTemplate.Height = 24;
            this.dgvBase.Size = new System.Drawing.Size(780, 672);
            this.dgvBase.TabIndex = 1;
            this.dgvBase.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBase_CellValueChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvData);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(789, 681);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Результат";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.ColumnHeadersVisible = false;
            this.dgvData.Location = new System.Drawing.Point(3, 3);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowTemplate.Height = 24;
            this.dgvData.Size = new System.Drawing.Size(783, 675);
            this.dgvData.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnClean);
            this.panel1.Controls.Add(this.btnWinRegression);
            this.panel1.Controls.Add(this.txbStartCenter);
            this.panel1.Controls.Add(this.txbNumClass);
            this.panel1.Controls.Add(this.rbCos);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.rbKmeans);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnChart);
            this.panel1.Controls.Add(this.btnSolve);
            this.panel1.Controls.Add(this.btnLoad);
            this.panel1.Controls.Add(this.btnAddCol);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnAddRow);
            this.panel1.Location = new System.Drawing.Point(809, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 274);
            this.panel1.TabIndex = 15;
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(4, 215);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(371, 38);
            this.btnClean.TabIndex = 15;
            this.btnClean.Text = "Очистить";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // btnWinRegression
            // 
            this.btnWinRegression.Location = new System.Drawing.Point(200, 171);
            this.btnWinRegression.Name = "btnWinRegression";
            this.btnWinRegression.Size = new System.Drawing.Size(175, 38);
            this.btnWinRegression.TabIndex = 14;
            this.btnWinRegression.Text = "Регресс. анлиз";
            this.btnWinRegression.UseVisualStyleBackColor = true;
            this.btnWinRegression.Click += new System.EventHandler(this.btnWinRegression_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsRemoveRow,
            this.cmsRemoveCol});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(195, 52);
            // 
            // cmsRemoveRow
            // 
            this.cmsRemoveRow.Name = "cmsRemoveRow";
            this.cmsRemoveRow.Size = new System.Drawing.Size(194, 24);
            this.cmsRemoveRow.Text = "Удалить строку";
            this.cmsRemoveRow.Click += new System.EventHandler(this.cmsRemoveRow_Click);
            // 
            // cmsRemoveCol
            // 
            this.cmsRemoveCol.Name = "cmsRemoveCol";
            this.cmsRemoveCol.Size = new System.Drawing.Size(194, 24);
            this.cmsRemoveCol.Text = "Удалить столбец";
            this.cmsRemoveCol.Click += new System.EventHandler(this.cmsRemoveCol_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.pictureBox1);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(789, 681);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Руководство пользователя";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(549, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "     Данный раздел содержит краткое руководство по использованию программы.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(586, 250);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(107, 306);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(386, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Рисунок 1 - Пример представления данных для решения";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 335);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(589, 85);
            this.label5.TabIndex = 3;
            this.label5.Text = resources.GetString("label5.Text");
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 433);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(602, 136);
            this.label6.TabIndex = 4;
            this.label6.Text = resources.GetString("label6.Text");
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1193, 734);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "K-MEANS";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBase)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txbNumClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbStartCenter;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.Button btnAddCol;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnChart;
        private System.Windows.Forms.RadioButton rbKmeans;
        private System.Windows.Forms.RadioButton rbCos;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvBase;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnWinRegression;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cmsRemoveRow;
        private System.Windows.Forms.ToolStripMenuItem cmsRemoveCol;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

