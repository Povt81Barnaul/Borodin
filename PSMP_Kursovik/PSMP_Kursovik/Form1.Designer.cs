namespace PSMP_Kursovik
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonStart = new System.Windows.Forms.Button();
            this.numericTrainCount = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericStationCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.dataGridViewTrain = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.checkBoxRend = new System.Windows.Forms.CheckBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericTrainCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStationCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrain)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(829, 116);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(83, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // numericTrainCount
            // 
            this.numericTrainCount.Location = new System.Drawing.Point(922, 7);
            this.numericTrainCount.Name = "numericTrainCount";
            this.numericTrainCount.Size = new System.Drawing.Size(36, 20);
            this.numericTrainCount.TabIndex = 1;
            this.numericTrainCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericTrainCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(827, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Кол-во поездов";
            // 
            // numericStationCount
            // 
            this.numericStationCount.Location = new System.Drawing.Point(922, 33);
            this.numericStationCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericStationCount.Name = "numericStationCount";
            this.numericStationCount.Size = new System.Drawing.Size(36, 20);
            this.numericStationCount.TabIndex = 3;
            this.numericStationCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericStationCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(827, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Кол-во станций";
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(800, 500);
            this.pictureBox.TabIndex = 5;
            this.pictureBox.TabStop = false;
            // 
            // dataGridViewTrain
            // 
            this.dataGridViewTrain.AllowDrop = true;
            this.dataGridViewTrain.AllowUserToAddRows = false;
            this.dataGridViewTrain.AllowUserToDeleteRows = false;
            this.dataGridViewTrain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTrain.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridViewTrain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTrain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridViewTrain.Location = new System.Drawing.Point(808, 206);
            this.dataGridViewTrain.Name = "dataGridViewTrain";
            this.dataGridViewTrain.RowHeadersVisible = false;
            this.dataGridViewTrain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewTrain.Size = new System.Drawing.Size(240, 145);
            this.dataGridViewTrain.TabIndex = 6;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.Frozen = true;
            this.Column1.HeaderText = " № ";
            this.Column1.Name = "Column1";
            this.Column1.Width = 46;
            // 
            // Column2
            // 
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "Начальная";
            this.Column2.Name = "Column2";
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column2.Width = 95;
            // 
            // Column3
            // 
            this.Column3.Frozen = true;
            this.Column3.HeaderText = "Конечная";
            this.Column3.Name = "Column3";
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column3.Width = 94;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(807, 358);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(241, 105);
            this.textBox1.TabIndex = 7;
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(829, 145);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(83, 23);
            this.buttonStop.TabIndex = 8;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // checkBoxRend
            // 
            this.checkBoxRend.AutoSize = true;
            this.checkBoxRend.Checked = true;
            this.checkBoxRend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRend.Location = new System.Drawing.Point(808, 174);
            this.checkBoxRend.Name = "checkBoxRend";
            this.checkBoxRend.Size = new System.Drawing.Size(110, 17);
            this.checkBoxRend.TabIndex = 9;
            this.checkBoxRend.Text = "Рандомный путь";
            this.checkBoxRend.UseVisualStyleBackColor = true;
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(829, 87);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(83, 23);
            this.buttonCreate.TabIndex = 10;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.Create_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 500);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.checkBoxRend);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridViewTrain);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericStationCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericTrainCount);
            this.Controls.Add(this.buttonStart);
            this.Name = "Form1";
            this.Text = "Форма";
            ((System.ComponentModel.ISupportInitialize)(this.numericTrainCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStationCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.NumericUpDown numericTrainCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericStationCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewTrain;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column2;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column3;
        public System.Windows.Forms.PictureBox pictureBox;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.CheckBox checkBoxRend;
        private System.Windows.Forms.Button buttonCreate;
    }
}

