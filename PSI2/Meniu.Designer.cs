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
            listBox1 = new ListBox();
            btnAdaugaPacient = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(31, 45);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(293, 124);
            listBox1.TabIndex = 0;
            // 
            // btnAdaugaPacient
            // 
            btnAdaugaPacient.Location = new Point(362, 45);
            btnAdaugaPacient.Name = "btnAdaugaPacient";
            btnAdaugaPacient.Size = new Size(114, 23);
            btnAdaugaPacient.TabIndex = 1;
            btnAdaugaPacient.Text = "Adauga pacient";
            btnAdaugaPacient.UseVisualStyleBackColor = true;
            btnAdaugaPacient.Click += btnAdaugaPacient_Click;
            // 
            // Meniu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAdaugaPacient);
            Controls.Add(listBox1);
            Name = "Meniu";
            Text = "Meniu";
            Load += Meniu_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox1;
        private Button btnAdaugaPacient;
    }
}