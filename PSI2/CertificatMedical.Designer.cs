namespace PSI2  
{
    partial class CertificatMedical
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
            panel1 = new Panel();
            richTextBox1 = new RichTextBox();
            label28 = new Label();
            label26 = new Label();
            groupBox1 = new GroupBox();
            rbtF = new RadioButton();
            rbtM = new RadioButton();
            label17 = new Label();
            txtNr = new TextBox();
            txtNrPacient = new TextBox();
            txtEliberare = new TextBox();
            txtSeriePacient = new TextBox();
            txtAdresaPacient = new TextBox();
            txtVarsta = new TextBox();
            txtCNP = new TextBox();
            txtNumePacient = new TextBox();
            txtSpecializare = new TextBox();
            txtNumeDoctor = new TextBox();
            txtAdresa = new TextBox();
            txtUnitateSanitara = new TextBox();
            label6 = new Label();
            label15 = new Label();
            label14 = new Label();
            label22 = new Label();
            label29 = new Label();
            label27 = new Label();
            label21 = new Label();
            label16 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label3 = new Label();
            label2 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label1 = new Label();
            btnSalveaza = new Button();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnSalveaza);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(richTextBox1);
            panel1.Controls.Add(label28);
            panel1.Controls.Add(label26);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(label17);
            panel1.Controls.Add(txtNr);
            panel1.Controls.Add(txtNrPacient);
            panel1.Controls.Add(txtEliberare);
            panel1.Controls.Add(txtSeriePacient);
            panel1.Controls.Add(txtAdresaPacient);
            panel1.Controls.Add(txtVarsta);
            panel1.Controls.Add(txtCNP);
            panel1.Controls.Add(txtNumePacient);
            panel1.Controls.Add(txtSpecializare);
            panel1.Controls.Add(txtNumeDoctor);
            panel1.Controls.Add(txtAdresa);
            panel1.Controls.Add(txtUnitateSanitara);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(label22);
            panel1.Controls.Add(label29);
            panel1.Controls.Add(label27);
            panel1.Controls.Add(label21);
            panel1.Controls.Add(label16);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(12, 13);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 793);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(20, 578);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(738, 96);
            richTextBox1.TabIndex = 79;
            richTextBox1.Text = "";
            // 
            // label28
            // 
            label28.BackColor = Color.Black;
            label28.BorderStyle = BorderStyle.Fixed3D;
            label28.Location = new Point(11, 726);
            label28.Name = "label28";
            label28.Size = new Size(760, 3);
            label28.TabIndex = 78;
            // 
            // label26
            // 
            label26.BackColor = Color.Black;
            label26.BorderStyle = BorderStyle.Fixed3D;
            label26.Location = new Point(11, 539);
            label26.Name = "label26";
            label26.Size = new Size(760, 3);
            label26.TabIndex = 78;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbtF);
            groupBox1.Controls.Add(rbtM);
            groupBox1.Location = new Point(428, 425);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(188, 33);
            groupBox1.TabIndex = 77;
            groupBox1.TabStop = false;
            groupBox1.Text = "Sex";
            // 
            // rbtF
            // 
            rbtF.AutoSize = true;
            rbtF.Location = new Point(116, 11);
            rbtF.Name = "rbtF";
            rbtF.Size = new Size(31, 19);
            rbtF.TabIndex = 0;
            rbtF.TabStop = true;
            rbtF.Text = "F";
            rbtF.UseVisualStyleBackColor = true;
            // 
            // rbtM
            // 
            rbtM.AutoSize = true;
            rbtM.Location = new Point(59, 11);
            rbtM.Name = "rbtM";
            rbtM.Size = new Size(36, 19);
            rbtM.TabIndex = 0;
            rbtM.TabStop = true;
            rbtM.Text = "M";
            rbtM.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 238);
            label17.Location = new Point(410, 331);
            label17.Name = "label17";
            label17.Size = new Size(94, 12);
            label17.TabIndex = 76;
            label17.Text = "(numele si prenumele)";
            // 
            // txtNr
            // 
            txtNr.Enabled = false;
            txtNr.Location = new Point(487, 198);
            txtNr.Name = "txtNr";
            txtNr.Size = new Size(100, 23);
            txtNr.TabIndex = 75;
            // 
            // txtNrPacient
            // 
            txtNrPacient.Location = new Point(318, 502);
            txtNrPacient.Name = "txtNrPacient";
            txtNrPacient.Size = new Size(298, 23);
            txtNrPacient.TabIndex = 75;
            // 
            // txtEliberare
            // 
            txtEliberare.Location = new Point(218, 694);
            txtEliberare.Name = "txtEliberare";
            txtEliberare.Size = new Size(540, 23);
            txtEliberare.TabIndex = 75;
            // 
            // txtSeriePacient
            // 
            txtSeriePacient.Location = new Point(92, 502);
            txtSeriePacient.Name = "txtSeriePacient";
            txtSeriePacient.Size = new Size(190, 23);
            txtSeriePacient.TabIndex = 75;
            // 
            // txtAdresaPacient
            // 
            txtAdresaPacient.Location = new Point(109, 466);
            txtAdresaPacient.Name = "txtAdresaPacient";
            txtAdresaPacient.Size = new Size(649, 23);
            txtAdresaPacient.TabIndex = 75;
            // 
            // txtVarsta
            // 
            txtVarsta.Location = new Point(364, 430);
            txtVarsta.Name = "txtVarsta";
            txtVarsta.Size = new Size(43, 23);
            txtVarsta.TabIndex = 75;
            // 
            // txtCNP
            // 
            txtCNP.Location = new Point(49, 430);
            txtCNP.Name = "txtCNP";
            txtCNP.Size = new Size(207, 23);
            txtCNP.TabIndex = 75;
            // 
            // txtNumePacient
            // 
            txtNumePacient.Location = new Point(136, 393);
            txtNumePacient.Name = "txtNumePacient";
            txtNumePacient.Size = new Size(622, 23);
            txtNumePacient.TabIndex = 75;
            // 
            // txtSpecializare
            // 
            txtSpecializare.Location = new Point(92, 354);
            txtSpecializare.Name = "txtSpecializare";
            txtSpecializare.Size = new Size(666, 23);
            txtSpecializare.TabIndex = 75;
            // 
            // txtNumeDoctor
            // 
            txtNumeDoctor.Location = new Point(156, 306);
            txtNumeDoctor.Name = "txtNumeDoctor";
            txtNumeDoctor.Size = new Size(602, 23);
            txtNumeDoctor.TabIndex = 75;
            // 
            // txtAdresa
            // 
            txtAdresa.Location = new Point(113, 39);
            txtAdresa.Name = "txtAdresa";
            txtAdresa.Size = new Size(143, 23);
            txtAdresa.TabIndex = 70;
            // 
            // txtUnitateSanitara
            // 
            txtUnitateSanitara.Location = new Point(113, 10);
            txtUnitateSanitara.Name = "txtUnitateSanitara";
            txtUnitateSanitara.Size = new Size(143, 23);
            txtUnitateSanitara.TabIndex = 71;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label6.Location = new Point(141, 191);
            label6.Name = "label6";
            label6.Size = new Size(333, 37);
            label6.TabIndex = 67;
            label6.Text = "CERTIFICAT MEDICAL Nr.";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(437, 434);
            label15.Name = "label15";
            label15.Size = new Size(0, 15);
            label15.TabIndex = 67;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(276, 434);
            label14.Name = "label14";
            label14.Size = new Size(67, 15);
            label14.TabIndex = 67;
            label14.Text = "in varsta de";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(288, 506);
            label22.Name = "label22";
            label22.Size = new Size(21, 15);
            label22.TabIndex = 67;
            label22.Text = "nr.";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Location = new Point(12, 698);
            label29.Name = "label29";
            label29.Size = new Size(202, 15);
            label29.TabIndex = 67;
            label29.Text = "S-a eliberat prezentul spre a-i servi la:";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(12, 554);
            label27.Name = "label27";
            label27.Size = new Size(93, 15);
            label27.TabIndex = 67;
            label27.Text = "Este suferind de:";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(12, 506);
            label21.Name = "label21";
            label21.Size = new Size(82, 15);
            label21.TabIndex = 67;
            label21.Text = "cu B.I/C.I seria";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(12, 469);
            label16.Name = "label16";
            label16.Size = new Size(91, 15);
            label16.TabIndex = 67;
            label16.Text = "Cu domiciliu in:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(12, 434);
            label13.Name = "label13";
            label13.Size = new Size(31, 15);
            label13.TabIndex = 67;
            label13.Text = "CNP";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(12, 397);
            label12.Name = "label12";
            label12.Size = new Size(118, 15);
            label12.TabIndex = 67;
            label12.Text = "Se certifica de noi ca:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(12, 358);
            label11.Name = "label11";
            label11.Size = new Size(74, 15);
            label11.TabIndex = 67;
            label11.Text = "in calitate de";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(12, 310);
            label10.Name = "label10";
            label10.Size = new Size(119, 15);
            label10.TabIndex = 67;
            label10.Text = "In baza referatului Dr.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 43);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 67;
            label3.Text = "Adresa";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 14);
            label2.Name = "label2";
            label2.Size = new Size(95, 15);
            label2.TabIndex = 68;
            label2.Text = "Unitatea sanitara";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(211, 243);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(376, 23);
            dateTimePicker1.TabIndex = 80;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(152, 247);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 81;
            label1.Text = "Data";
            // 
            // btnSalveaza
            // 
            btnSalveaza.Location = new Point(332, 748);
            btnSalveaza.Name = "btnSalveaza";
            btnSalveaza.Size = new Size(75, 23);
            btnSalveaza.TabIndex = 1;
            btnSalveaza.Text = "Salveaza si inchide";
            btnSalveaza.UseVisualStyleBackColor = true;
            // 
            // CertificatMedical
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(817, 630);
            Controls.Add(panel1);
            Name = "CertificatMedical";
            Text = "CertificatMedical";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox txtAdresa;
        private TextBox txtUnitateSanitara;
        private Label label6;
        private Label label3;
        private Label label2;
        private TextBox txtNumeDoctor;
        private Label label10;
        private Label label17;
        private TextBox txtNumePacient;
        private TextBox txtSpecializare;
        private Label label12;
        private Label label11;
        private TextBox txtCNP;
        private Label label15;
        private Label label14;
        private Label label13;
        private GroupBox groupBox1;
        private RadioButton rbtF;
        private RadioButton rbtM;
        private TextBox txtNrPacient;
        private TextBox txtSeriePacient;
        private TextBox txtAdresaPacient;
        private Label label22;
        private Label label21;
        private Label label16;
        private RichTextBox richTextBox1;
        private Label label28;
        private Label label26;
        private TextBox txtEliberare;
        private Label label29;
        private Label label27;
        private TextBox txtNr;
        private TextBox txtVarsta;
        private Label label1;
        private DateTimePicker dateTimePicker1;
        private Button btnSalveaza;
    }
}