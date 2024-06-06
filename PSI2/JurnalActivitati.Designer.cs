namespace PSI2
{
    partial class JurnalActivitati
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
            ID = new DataGridViewTextBoxColumn();
            Data = new DataGridViewTextBoxColumn();
            Ora = new DataGridViewTextBoxColumn();
            Utilizator = new DataGridViewTextBoxColumn();
            Actiune = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ID, Data, Ora, Utilizator, Actiune });
            dataGridView1.Location = new Point(2, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(794, 445);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            // 
            // Data
            // 
            Data.HeaderText = "Data";
            Data.Name = "Data";
            Data.Width = 80;
            // 
            // Ora
            // 
            Ora.HeaderText = "Ora";
            Ora.Name = "Ora";
            Ora.Width = 50;
            // 
            // Utilizator
            // 
            Utilizator.HeaderText = "Utilizator";
            Utilizator.Name = "Utilizator";
            // 
            // Actiune
            // 
            Actiune.HeaderText = "Actiune";
            Actiune.Name = "Actiune";
            Actiune.Width = 500;
            // 
            // JurnalActivitati
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Name = "JurnalActivitati";
            Text = "JurnalActivitati";
            Load += JurnalActivitati_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Data;
        private DataGridViewTextBoxColumn Ora;
        private DataGridViewTextBoxColumn Utilizator;
        private DataGridViewTextBoxColumn Actiune;
    }
}