namespace SinerjiCRM
{
    partial class SatinAlmaTalep
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
            label1 = new Label();
            txtKod = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            cmbUlke = new ComboBox();
            label5 = new Label();
            cmbIl = new ComboBox();
            label6 = new Label();
            cmbIlce = new ComboBox();
            label8 = new Label();
            cmbPostaKodu = new ComboBox();
            btnSil = new Button();
            btnGeri = new Button();
            cmbRaporKodu2 = new ComboBox();
            label9 = new Label();
            cmbRaporKodu1 = new ComboBox();
            label10 = new Label();
            cmbGrupKodu = new ComboBox();
            label11 = new Label();
            cmbVergiDairesi = new ComboBox();
            label12 = new Label();
            txtVergiTCNo = new TextBox();
            label14 = new Label();
            txtTelefon = new TextBox();
            label15 = new Label();
            txtFaks = new TextBox();
            label16 = new Label();
            txtMail = new TextBox();
            label17 = new Label();
            txtWeb = new TextBox();
            btnAktar = new Button();
            txtIsim = new TextBox();
            txtAdres = new TextBox();
            rbVergi = new RadioButton();
            rbTC = new RadioButton();
            cmbRaporKodu3 = new ComboBox();
            label7 = new Label();
            btnEkleGuncelle = new Button();
            panel1 = new Panel();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(5, 6);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 0;
            label1.Text = "Cari Kod";
            // 
            // txtKod
            // 
            txtKod.Anchor = AnchorStyles.Top;
            txtKod.Location = new Point(64, 3);
            txtKod.MaxLength = 15;
            txtKod.Name = "txtKod";
            txtKod.Size = new Size(236, 23);
            txtKod.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(4, 35);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 2;
            label2.Text = "Cari İsim";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(19, 87);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 7;
            label3.Text = "Adres";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label4.Location = new Point(717, 6);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 8;
            label4.Text = "Ülke";
            // 
            // cmbUlke
            // 
            cmbUlke.Anchor = AnchorStyles.Top;
            cmbUlke.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUlke.Font = new Font("Segoe UI", 9F);
            cmbUlke.FormattingEnabled = true;
            cmbUlke.Location = new Point(756, 3);
            cmbUlke.Name = "cmbUlke";
            cmbUlke.Size = new Size(236, 23);
            cmbUlke.TabIndex = 4;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label5.Location = new Point(736, 35);
            label5.Name = "label5";
            label5.RightToLeft = RightToLeft.No;
            label5.Size = new Size(14, 15);
            label5.TabIndex = 62;
            label5.Text = "İl";
            // 
            // cmbIl
            // 
            cmbIl.Anchor = AnchorStyles.Top;
            cmbIl.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIl.Font = new Font("Segoe UI", 9F);
            cmbIl.FormattingEnabled = true;
            cmbIl.Location = new Point(756, 32);
            cmbIl.Name = "cmbIl";
            cmbIl.Size = new Size(236, 23);
            cmbIl.TabIndex = 5;
            cmbIl.SelectedIndexChanged += cmbIl_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label6.Location = new Point(723, 64);
            label6.Name = "label6";
            label6.RightToLeft = RightToLeft.No;
            label6.Size = new Size(27, 15);
            label6.TabIndex = 64;
            label6.Text = "İlçe";
            // 
            // cmbIlce
            // 
            cmbIlce.Anchor = AnchorStyles.Top;
            cmbIlce.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIlce.Font = new Font("Segoe UI", 9F);
            cmbIlce.FormattingEnabled = true;
            cmbIlce.Location = new Point(756, 61);
            cmbIlce.Name = "cmbIlce";
            cmbIlce.Size = new Size(236, 23);
            cmbIlce.TabIndex = 6;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label8.Location = new Point(681, 93);
            label8.Name = "label8";
            label8.RightToLeft = RightToLeft.No;
            label8.Size = new Size(69, 15);
            label8.TabIndex = 67;
            label8.Text = "Posta Kodu";
            // 
            // cmbPostaKodu
            // 
            cmbPostaKodu.Anchor = AnchorStyles.Top;
            cmbPostaKodu.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPostaKodu.Font = new Font("Segoe UI", 9F);
            cmbPostaKodu.FormattingEnabled = true;
            cmbPostaKodu.Location = new Point(756, 90);
            cmbPostaKodu.Name = "cmbPostaKodu";
            cmbPostaKodu.Size = new Size(236, 23);
            cmbPostaKodu.TabIndex = 7;
            // 
            // btnSil
            // 
            btnSil.Anchor = AnchorStyles.Top;
            btnSil.Location = new Point(1262, 122);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(75, 23);
            btnSil.TabIndex = 20;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // btnGeri
            // 
            btnGeri.Anchor = AnchorStyles.Top;
            btnGeri.Location = new Point(1262, 151);
            btnGeri.Name = "btnGeri";
            btnGeri.Size = new Size(75, 23);
            btnGeri.TabIndex = 22;
            btnGeri.Text = "Geri";
            btnGeri.UseVisualStyleBackColor = true;
            btnGeri.Click += btnGeri_Click;
            // 
            // cmbRaporKodu2
            // 
            cmbRaporKodu2.Anchor = AnchorStyles.Top;
            cmbRaporKodu2.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRaporKodu2.Font = new Font("Segoe UI", 9F);
            cmbRaporKodu2.FormattingEnabled = true;
            cmbRaporKodu2.Location = new Point(1100, 61);
            cmbRaporKodu2.Name = "cmbRaporKodu2";
            cmbRaporKodu2.Size = new Size(236, 23);
            cmbRaporKodu2.TabIndex = 17;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label9.Location = new Point(1012, 64);
            label9.Name = "label9";
            label9.RightToLeft = RightToLeft.No;
            label9.Size = new Size(82, 15);
            label9.TabIndex = 77;
            label9.Text = "Rapor Kodu 2";
            // 
            // cmbRaporKodu1
            // 
            cmbRaporKodu1.Anchor = AnchorStyles.Top;
            cmbRaporKodu1.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRaporKodu1.Font = new Font("Segoe UI", 9F);
            cmbRaporKodu1.FormattingEnabled = true;
            cmbRaporKodu1.Location = new Point(1100, 32);
            cmbRaporKodu1.Name = "cmbRaporKodu1";
            cmbRaporKodu1.Size = new Size(236, 23);
            cmbRaporKodu1.TabIndex = 16;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label10.Location = new Point(1012, 35);
            label10.Name = "label10";
            label10.RightToLeft = RightToLeft.No;
            label10.Size = new Size(82, 15);
            label10.TabIndex = 75;
            label10.Text = "Rapor Kodu 1";
            // 
            // cmbGrupKodu
            // 
            cmbGrupKodu.Anchor = AnchorStyles.Top;
            cmbGrupKodu.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGrupKodu.Font = new Font("Segoe UI", 9F);
            cmbGrupKodu.FormattingEnabled = true;
            cmbGrupKodu.Location = new Point(1100, 3);
            cmbGrupKodu.Name = "cmbGrupKodu";
            cmbGrupKodu.Size = new Size(236, 23);
            cmbGrupKodu.TabIndex = 15;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top;
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label11.Location = new Point(1027, 6);
            label11.Name = "label11";
            label11.Size = new Size(67, 15);
            label11.TabIndex = 73;
            label11.Text = "Grup Kodu";
            // 
            // cmbVergiDairesi
            // 
            cmbVergiDairesi.Anchor = AnchorStyles.Top;
            cmbVergiDairesi.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVergiDairesi.Font = new Font("Segoe UI", 9F);
            cmbVergiDairesi.FormattingEnabled = true;
            cmbVergiDairesi.Location = new Point(756, 119);
            cmbVergiDairesi.Name = "cmbVergiDairesi";
            cmbVergiDairesi.Size = new Size(236, 23);
            cmbVergiDairesi.TabIndex = 12;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top;
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label12.Location = new Point(673, 122);
            label12.Name = "label12";
            label12.Size = new Size(77, 15);
            label12.TabIndex = 79;
            label12.Text = "Vergi Dairesi";
            // 
            // txtVergiTCNo
            // 
            txtVergiTCNo.Anchor = AnchorStyles.Top;
            txtVergiTCNo.Location = new Point(505, 119);
            txtVergiTCNo.MaxLength = 15;
            txtVergiTCNo.Name = "txtVergiTCNo";
            txtVergiTCNo.Size = new Size(147, 23);
            txtVergiTCNo.TabIndex = 13;
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Top;
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label14.Location = new Point(361, 6);
            label14.Name = "label14";
            label14.RightToLeft = RightToLeft.No;
            label14.Size = new Size(49, 15);
            label14.TabIndex = 83;
            label14.Text = "Telefon";
            // 
            // txtTelefon
            // 
            txtTelefon.Anchor = AnchorStyles.Top;
            txtTelefon.Location = new Point(416, 3);
            txtTelefon.MaxLength = 20;
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(236, 23);
            txtTelefon.TabIndex = 8;
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.Top;
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label15.Location = new Point(379, 35);
            label15.Name = "label15";
            label15.RightToLeft = RightToLeft.No;
            label15.Size = new Size(31, 15);
            label15.TabIndex = 85;
            label15.Text = "Faks";
            // 
            // txtFaks
            // 
            txtFaks.Anchor = AnchorStyles.Top;
            txtFaks.Location = new Point(416, 32);
            txtFaks.MaxLength = 20;
            txtFaks.Name = "txtFaks";
            txtFaks.Size = new Size(236, 23);
            txtFaks.TabIndex = 9;
            // 
            // label16
            // 
            label16.Anchor = AnchorStyles.Top;
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label16.Location = new Point(362, 64);
            label16.Name = "label16";
            label16.RightToLeft = RightToLeft.No;
            label16.Size = new Size(48, 15);
            label16.TabIndex = 87;
            label16.Text = "E-Posta";
            // 
            // txtMail
            // 
            txtMail.Anchor = AnchorStyles.Top;
            txtMail.Location = new Point(416, 61);
            txtMail.MaxLength = 255;
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(236, 23);
            txtMail.TabIndex = 10;
            // 
            // label17
            // 
            label17.Anchor = AnchorStyles.Top;
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label17.Location = new Point(339, 93);
            label17.Name = "label17";
            label17.RightToLeft = RightToLeft.No;
            label17.Size = new Size(71, 15);
            label17.TabIndex = 89;
            label17.Text = "Web Adresi";
            // 
            // txtWeb
            // 
            txtWeb.Anchor = AnchorStyles.Top;
            txtWeb.Location = new Point(416, 90);
            txtWeb.MaxLength = 60;
            txtWeb.Name = "txtWeb";
            txtWeb.Size = new Size(236, 23);
            txtWeb.TabIndex = 11;
            // 
            // btnAktar
            // 
            btnAktar.Anchor = AnchorStyles.Top;
            btnAktar.Location = new Point(1100, 151);
            btnAktar.Name = "btnAktar";
            btnAktar.Size = new Size(156, 23);
            btnAktar.TabIndex = 21;
            btnAktar.Text = "Tabloyu NETSIS'e aktar";
            btnAktar.UseVisualStyleBackColor = true;
            btnAktar.Click += btnAktar_Click;
            // 
            // txtIsim
            // 
            txtIsim.Anchor = AnchorStyles.Top;
            txtIsim.Location = new Point(64, 32);
            txtIsim.MaxLength = 100;
            txtIsim.Multiline = true;
            txtIsim.Name = "txtIsim";
            txtIsim.Size = new Size(236, 46);
            txtIsim.TabIndex = 2;
            // 
            // txtAdres
            // 
            txtAdres.Anchor = AnchorStyles.Top;
            txtAdres.Location = new Point(64, 84);
            txtAdres.MaxLength = 255;
            txtAdres.Multiline = true;
            txtAdres.Name = "txtAdres";
            txtAdres.Size = new Size(236, 46);
            txtAdres.TabIndex = 3;
            // 
            // rbVergi
            // 
            rbVergi.Anchor = AnchorStyles.Top;
            rbVergi.AutoSize = true;
            rbVergi.CheckAlign = ContentAlignment.MiddleRight;
            rbVergi.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            rbVergi.Location = new Point(337, 120);
            rbVergi.Name = "rbVergi";
            rbVergi.Size = new Size(73, 19);
            rbVergi.TabIndex = 90;
            rbVergi.TabStop = true;
            rbVergi.Text = "Vergi No";
            rbVergi.UseVisualStyleBackColor = true;
            // 
            // rbTC
            // 
            rbTC.Anchor = AnchorStyles.Top;
            rbTC.AutoSize = true;
            rbTC.CheckAlign = ContentAlignment.MiddleRight;
            rbTC.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            rbTC.Location = new Point(419, 120);
            rbTC.Name = "rbTC";
            rbTC.Size = new Size(80, 19);
            rbTC.TabIndex = 91;
            rbTC.TabStop = true;
            rbTC.Text = "/    T.C. No";
            rbTC.UseVisualStyleBackColor = true;
            // 
            // cmbRaporKodu3
            // 
            cmbRaporKodu3.Anchor = AnchorStyles.Top;
            cmbRaporKodu3.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRaporKodu3.Font = new Font("Segoe UI", 9F);
            cmbRaporKodu3.FormattingEnabled = true;
            cmbRaporKodu3.Location = new Point(1100, 90);
            cmbRaporKodu3.Name = "cmbRaporKodu3";
            cmbRaporKodu3.Size = new Size(236, 23);
            cmbRaporKodu3.TabIndex = 92;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label7.Location = new Point(1012, 93);
            label7.Name = "label7";
            label7.RightToLeft = RightToLeft.No;
            label7.Size = new Size(82, 15);
            label7.TabIndex = 93;
            label7.Text = "Rapor Kodu 3";
            // 
            // btnEkleGuncelle
            // 
            btnEkleGuncelle.Anchor = AnchorStyles.Top;
            btnEkleGuncelle.Location = new Point(1100, 122);
            btnEkleGuncelle.Name = "btnEkleGuncelle";
            btnEkleGuncelle.Size = new Size(156, 23);
            btnEkleGuncelle.TabIndex = 94;
            btnEkleGuncelle.Text = "Ekle / Güncelle";
            btnEkleGuncelle.UseVisualStyleBackColor = true;
            btnEkleGuncelle.Click += btnEkleGuncelle_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtKod);
            panel1.Controls.Add(btnEkleGuncelle);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(cmbRaporKodu3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(rbTC);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(rbVergi);
            panel1.Controls.Add(cmbUlke);
            panel1.Controls.Add(txtAdres);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtIsim);
            panel1.Controls.Add(cmbIl);
            panel1.Controls.Add(btnAktar);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label17);
            panel1.Controls.Add(cmbIlce);
            panel1.Controls.Add(txtWeb);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label16);
            panel1.Controls.Add(cmbPostaKodu);
            panel1.Controls.Add(txtMail);
            panel1.Controls.Add(btnSil);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(btnGeri);
            panel1.Controls.Add(txtFaks);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(cmbGrupKodu);
            panel1.Controls.Add(txtTelefon);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(txtVergiTCNo);
            panel1.Controls.Add(cmbRaporKodu1);
            panel1.Controls.Add(cmbVergiDairesi);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(cmbRaporKodu2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1343, 178);
            panel1.TabIndex = 95;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 178);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1343, 447);
            dataGridView1.TabIndex = 96;
            // 
            // SatinAlmaTalep
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1343, 625);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Name = "SatinAlmaTalep";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Satın Alma Talep";
            FormClosed += SatinAlmaTalep_FormClosed;
            Load += SatinAlmaTalep_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private TextBox txtKod;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox cmbUlke;
        private Label label5;
        private ComboBox cmbIl;
        private Label label6;
        private ComboBox cmbIlce;
        private Label label8;
        private ComboBox cmbPostaKodu;
        private Button btnSil;
        private Button btnGeri;
        private ComboBox cmbRaporKodu2;
        private Label label9;
        private ComboBox cmbRaporKodu1;
        private Label label10;
        private ComboBox cmbGrupKodu;
        private Label label11;
        private ComboBox cmbVergiDairesi;
        private Label label12;
        private TextBox txtVergiTCNo;
        private Label label14;
        private TextBox txtTelefon;
        private Label label15;
        private TextBox txtFaks;
        private Label label16;
        private TextBox txtMail;
        private Label label17;
        private TextBox txtWeb;
        private Button btnAktar;
        private TextBox txtIsim;
        private TextBox txtAdres;
        private RadioButton rbVergi;
        private RadioButton rbTC;
        private ComboBox cmbRaporKodu3;
        private Label label7;
        private Button btnEkleGuncelle;
        private Panel panel1;
        private DataGridView dataGridView1;
    }
}