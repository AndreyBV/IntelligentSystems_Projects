namespace ID3
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
            this.dgvBase = new System.Windows.Forms.DataGridView();
            this.dgvSign = new System.Windows.Forms.DataGridView();
            this.Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGiveValKey = new System.Windows.Forms.Button();
            this.txtbKeyWordChipher = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSeeKeyWord = new System.Windows.Forms.Button();
            this.btnDelKeyWord = new System.Windows.Forms.Button();
            this.btnClearKeyValue = new System.Windows.Forms.Button();
            this.btnSolve = new System.Windows.Forms.Button();
            this.dgvBaseInt = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSign)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaseInt)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBase
            // 
            this.dgvBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvBase.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBase.Location = new System.Drawing.Point(12, 40);
            this.dgvBase.Name = "dgvBase";
            this.dgvBase.RowHeadersVisible = false;
            this.dgvBase.RowTemplate.Height = 24;
            this.dgvBase.Size = new System.Drawing.Size(509, 328);
            this.dgvBase.TabIndex = 0;
            // 
            // dgvSign
            // 
            this.dgvSign.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSign.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSign.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Key,
            this.Value});
            this.dgvSign.Location = new System.Drawing.Point(527, 40);
            this.dgvSign.Name = "dgvSign";
            this.dgvSign.RowHeadersVisible = false;
            this.dgvSign.RowTemplate.Height = 24;
            this.dgvSign.Size = new System.Drawing.Size(237, 327);
            this.dgvSign.TabIndex = 4;
            // 
            // Key
            // 
            this.Key.HeaderText = "Key";
            this.Key.Name = "Key";
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            // 
            // btnGiveValKey
            // 
            this.btnGiveValKey.Location = new System.Drawing.Point(530, 501);
            this.btnGiveValKey.Name = "btnGiveValKey";
            this.btnGiveValKey.Size = new System.Drawing.Size(234, 42);
            this.btnGiveValKey.TabIndex = 5;
            this.btnGiveValKey.Text = "Задать соответствие";
            this.btnGiveValKey.UseVisualStyleBackColor = true;
            this.btnGiveValKey.Click += new System.EventHandler(this.btnGiveValKey_Click);
            // 
            // txtbKeyWordChipher
            // 
            this.txtbKeyWordChipher.BackColor = System.Drawing.Color.White;
            this.txtbKeyWordChipher.Location = new System.Drawing.Point(653, 373);
            this.txtbKeyWordChipher.Name = "txtbKeyWordChipher";
            this.txtbKeyWordChipher.Size = new System.Drawing.Size(111, 22);
            this.txtbKeyWordChipher.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(527, 373);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ключевое слово:";
            // 
            // btnSeeKeyWord
            // 
            this.btnSeeKeyWord.Location = new System.Drawing.Point(647, 405);
            this.btnSeeKeyWord.Name = "btnSeeKeyWord";
            this.btnSeeKeyWord.Size = new System.Drawing.Size(117, 42);
            this.btnSeeKeyWord.TabIndex = 8;
            this.btnSeeKeyWord.Text = "Посмотреть";
            this.btnSeeKeyWord.UseVisualStyleBackColor = true;
            this.btnSeeKeyWord.Click += new System.EventHandler(this.btnSeeKeyWord_Click);
            // 
            // btnDelKeyWord
            // 
            this.btnDelKeyWord.Location = new System.Drawing.Point(530, 405);
            this.btnDelKeyWord.Name = "btnDelKeyWord";
            this.btnDelKeyWord.Size = new System.Drawing.Size(111, 42);
            this.btnDelKeyWord.TabIndex = 9;
            this.btnDelKeyWord.Text = "Удалить";
            this.btnDelKeyWord.UseVisualStyleBackColor = true;
            this.btnDelKeyWord.Click += new System.EventHandler(this.btnDelKeyWord_Click);
            // 
            // btnClearKeyValue
            // 
            this.btnClearKeyValue.Location = new System.Drawing.Point(530, 453);
            this.btnClearKeyValue.Name = "btnClearKeyValue";
            this.btnClearKeyValue.Size = new System.Drawing.Size(234, 42);
            this.btnClearKeyValue.TabIndex = 10;
            this.btnClearKeyValue.Text = "Стереть";
            this.btnClearKeyValue.UseVisualStyleBackColor = true;
            this.btnClearKeyValue.Click += new System.EventHandler(this.btnClearKeyValue_Click);
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(530, 549);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(234, 42);
            this.btnSolve.TabIndex = 11;
            this.btnSolve.Text = "Решить";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // dgvBaseInt
            // 
            this.dgvBaseInt.AllowUserToAddRows = false;
            this.dgvBaseInt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvBaseInt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBaseInt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBaseInt.Location = new System.Drawing.Point(12, 405);
            this.dgvBaseInt.Name = "dgvBaseInt";
            this.dgvBaseInt.RowHeadersVisible = false;
            this.dgvBaseInt.RowTemplate.Height = 24;
            this.dgvBaseInt.Size = new System.Drawing.Size(509, 325);
            this.dgvBaseInt.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(530, 640);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(234, 42);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpen.Location = new System.Drawing.Point(530, 688);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(234, 42);
            this.btnOpen.TabIndex = 14;
            this.btnOpen.Text = "Открыть";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "Исходные данные:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 377);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(258, 25);
            this.label3.TabIndex = 16;
            this.label3.Text = "Закодированые данные:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(525, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 25);
            this.label4.TabIndex = 17;
            this.label4.Text = "Ключ-значение:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1483, 743);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvBaseInt);
            this.Controls.Add(this.btnSolve);
            this.Controls.Add(this.btnClearKeyValue);
            this.Controls.Add(this.btnDelKeyWord);
            this.Controls.Add(this.btnSeeKeyWord);
            this.Controls.Add(this.txtbKeyWordChipher);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGiveValKey);
            this.Controls.Add(this.dgvSign);
            this.Controls.Add(this.dgvBase);
            this.Name = "Form1";
            this.Text = "ID3";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSign)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBaseInt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBase;
        private System.Windows.Forms.DataGridView dgvSign;
        private System.Windows.Forms.Button btnGiveValKey;
        private System.Windows.Forms.TextBox txtbKeyWordChipher;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSeeKeyWord;
        private System.Windows.Forms.Button btnDelKeyWord;
        private System.Windows.Forms.DataGridViewTextBoxColumn Key;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.Button btnClearKeyValue;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.DataGridView dgvBaseInt;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

