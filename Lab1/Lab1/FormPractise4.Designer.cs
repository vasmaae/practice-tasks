namespace Lab1
{
    partial class FormPractise4
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
            dataGridView1 = new DataGridView();
            ColumnYear = new DataGridViewTextBoxColumn();
            ColumnFirst = new DataGridViewTextBoxColumn();
            ColumnSecond = new DataGridViewTextBoxColumn();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = SystemColors.Window;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ColumnYear, ColumnFirst, ColumnSecond });
            dataGridView1.Dock = DockStyle.Right;
            dataGridView1.Location = new Point(314, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(486, 450);
            dataGridView1.TabIndex = 0;
            // 
            // ColumnYear
            // 
            ColumnYear.HeaderText = "Год";
            ColumnYear.Name = "ColumnYear";
            ColumnYear.ReadOnly = true;
            // 
            // ColumnFirst
            // 
            ColumnFirst.HeaderText = "Первый вклад";
            ColumnFirst.Name = "ColumnFirst";
            ColumnFirst.ReadOnly = true;
            // 
            // ColumnSecond
            // 
            ColumnSecond.HeaderText = "Второй вклад";
            ColumnSecond.Name = "ColumnSecond";
            ColumnSecond.ReadOnly = true;
            // 
            // button1
            // 
            button1.Location = new Point(124, 213);
            button1.Name = "button1";
            button1.Size = new Size(114, 41);
            button1.TabIndex = 1;
            button1.Text = "Рассчитать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FormPractise4
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Name = "FormPractise4";
            Text = "FormPractise4";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ColumnYear;
        private DataGridViewTextBoxColumn ColumnFirst;
        private DataGridViewTextBoxColumn ColumnSecond;
        private Button button1;
    }
}