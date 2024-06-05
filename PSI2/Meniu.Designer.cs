namespace PSI2
{
    partial class Meniu
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
            btnAdaugaPacient = new Button();
            listBox1 = new ListBox();
            txtCautare = new TextBox();
            label2 = new Label();
            btnAdaugaAdeverinta = new Button();
            btnAdaugaBilet = new Button();
            listBox2 = new ListBox();
            btnVizualizareDocument = new Button();
            SuspendLayout();
            // 
            // btnAdaugaPacient
            // 
            btnAdaugaPacient.Location = new Point(652, 10);
            btnAdaugaPacient.Name = "btnAdaugaPacient";
            btnAdaugaPacient.Size = new Size(137, 23);
            btnAdaugaPacient.TabIndex = 1;
            btnAdaugaPacient.Text = "Adauga pacient";
            btnAdaugaPacient.UseVisualStyleBackColor = true;
            btnAdaugaPacient.Click += btnAdaugaPacient_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(9, 66);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(230, 244);
            listBox1.TabIndex = 7;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // txtCautare
            // 
            txtCautare.Location = new Point(9, 39);
            txtCautare.Name = "txtCautare";
            txtCautare.Size = new Size(230, 23);
            txtCautare.TabIndex = 8;
            txtCautare.TextChanged += txtCautare_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 14);
            label2.Name = "label2";
            label2.Size = new Size(203, 15);
            label2.TabIndex = 9;
            label2.Text = "Cauta pacient dupa numele complet:";
            // 
            // btnAdaugaAdeverinta
            // 
            btnAdaugaAdeverinta.Location = new Point(652, 49);
            btnAdaugaAdeverinta.Name = "btnAdaugaAdeverinta";
            btnAdaugaAdeverinta.Size = new Size(137, 23);
            btnAdaugaAdeverinta.TabIndex = 10;
            btnAdaugaAdeverinta.Text = "Adauga adeverinta";
            btnAdaugaAdeverinta.UseVisualStyleBackColor = true;
            btnAdaugaAdeverinta.Click += btnAdaugaAdeverinta_Click;
            // 
            // btnAdaugaBilet
            // 
            btnAdaugaBilet.Location = new Point(652, 89);
            btnAdaugaBilet.Name = "btnAdaugaBilet";
            btnAdaugaBilet.Size = new Size(137, 23);
            btnAdaugaBilet.TabIndex = 10;
            btnAdaugaBilet.Text = "Adauga bilet trimitere";
            btnAdaugaBilet.UseVisualStyleBackColor = true;
            btnAdaugaBilet.Click += btnAdaugaBilet_Click;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(245, 66);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(133, 244);
            listBox2.TabIndex = 7;
            listBox2.SelectedIndexChanged += listBox2_SelectedIndexChanged;
            // 
            // btnVizualizareDocument
            // 
            btnVizualizareDocument.Location = new Point(509, 10);
            btnVizualizareDocument.Name = "btnVizualizareDocument";
            btnVizualizareDocument.Size = new Size(137, 23);
            btnVizualizareDocument.TabIndex = 1;
            btnVizualizareDocument.Text = "Vizualizare document";
            btnVizualizareDocument.UseVisualStyleBackColor = true;
            btnVizualizareDocument.Click += btnVizualizareDocument_Click;
            // 
            // Meniu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAdaugaBilet);
            Controls.Add(btnAdaugaAdeverinta);
            Controls.Add(label2);
            Controls.Add(txtCautare);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Controls.Add(btnVizualizareDocument);
            Controls.Add(btnAdaugaPacient);
            Name = "Meniu";
            Text = "Meniu";
            Load += Meniu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnAdaugaPacient;
        private ListBox listBox1;
        private TextBox txtCautare;
        private Label label2;
        private Button btnAdaugaAdeverinta;
        private Button btnAdaugaBilet;
        private ListBox listBox2;
        private Button btnVizualizareDocument;
    }
}