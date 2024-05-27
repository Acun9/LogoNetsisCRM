namespace Sinerji
{
    partial class CariKayit
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
            txtCariKod = new TextBox();
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
            btnEkle = new Button();
            btnGuncelle = new Button();
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
            label13 = new Label();
            txtVergiNo = new TextBox();
            label14 = new Label();
            txtTelefon = new TextBox();
            label15 = new Label();
            txtFaks = new TextBox();
            label16 = new Label();
            txtMail = new TextBox();
            label17 = new Label();
            txtWeb = new TextBox();
            btnAktar = new Button();
            txtTC = new TextBox();
            label7 = new Label();
            txtCariIsim = new TextBox();
            txtAdres = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 0;
            label1.Text = "Cari Kod:";
            // 
            // txtCariKod
            // 
            txtCariKod.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCariKod.Location = new Point(120, 6);
            txtCariKod.MaxLength = 15;
            txtCariKod.Name = "txtCariKod";
            txtCariKod.Size = new Size(258, 23);
            txtCariKod.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(12, 38);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 2;
            label2.Text = "Cari İsim:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(12, 90);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 7;
            label3.Text = "Adres:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label4.Location = new Point(12, 142);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 8;
            label4.Text = "Ülke:";
            // 
            // cmbUlke
            // 
            cmbUlke.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbUlke.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUlke.Font = new Font("Segoe UI", 9F);
            cmbUlke.FormattingEnabled = true;
            cmbUlke.Location = new Point(120, 139);
            cmbUlke.Name = "cmbUlke";
            cmbUlke.Size = new Size(258, 23);
            cmbUlke.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label5.Location = new Point(12, 171);
            label5.Name = "label5";
            label5.RightToLeft = RightToLeft.No;
            label5.Size = new Size(17, 15);
            label5.TabIndex = 62;
            label5.Text = "İl:";
            // 
            // cmbIl
            // 
            cmbIl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbIl.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIl.Font = new Font("Segoe UI", 9F);
            cmbIl.FormattingEnabled = true;
            cmbIl.Location = new Point(120, 168);
            cmbIl.Name = "cmbIl";
            cmbIl.Size = new Size(258, 23);
            cmbIl.TabIndex = 5;
            cmbIl.SelectedIndexChanged += cmbIl_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label6.Location = new Point(12, 200);
            label6.Name = "label6";
            label6.RightToLeft = RightToLeft.No;
            label6.Size = new Size(30, 15);
            label6.TabIndex = 64;
            label6.Text = "İlçe:";
            // 
            // cmbIlce
            // 
            cmbIlce.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbIlce.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIlce.Font = new Font("Segoe UI", 9F);
            cmbIlce.FormattingEnabled = true;
            cmbIlce.Location = new Point(120, 197);
            cmbIlce.Name = "cmbIlce";
            cmbIlce.Size = new Size(258, 23);
            cmbIlce.TabIndex = 6;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label8.Location = new Point(12, 229);
            label8.Name = "label8";
            label8.RightToLeft = RightToLeft.No;
            label8.Size = new Size(72, 15);
            label8.TabIndex = 67;
            label8.Text = "Posta Kodu:";
            // 
            // cmbPostaKodu
            // 
            cmbPostaKodu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbPostaKodu.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPostaKodu.Font = new Font("Segoe UI", 9F);
            cmbPostaKodu.FormattingEnabled = true;
            cmbPostaKodu.Location = new Point(120, 226);
            cmbPostaKodu.Name = "cmbPostaKodu";
            cmbPostaKodu.Size = new Size(258, 23);
            cmbPostaKodu.TabIndex = 7;
            // 
            // btnEkle
            // 
            btnEkle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEkle.Location = new Point(141, 545);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(75, 23);
            btnEkle.TabIndex = 18;
            btnEkle.Text = "Ekle";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // btnGuncelle
            // 
            btnGuncelle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGuncelle.Location = new Point(222, 545);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(75, 23);
            btnGuncelle.TabIndex = 19;
            btnGuncelle.Text = "Güncelle";
            btnGuncelle.UseVisualStyleBackColor = true;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // btnSil
            // 
            btnSil.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSil.Location = new Point(303, 545);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(75, 23);
            btnSil.TabIndex = 20;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // btnGeri
            // 
            btnGeri.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGeri.Location = new Point(303, 574);
            btnGeri.Name = "btnGeri";
            btnGeri.Size = new Size(75, 23);
            btnGeri.TabIndex = 22;
            btnGeri.Text = "Geri";
            btnGeri.UseVisualStyleBackColor = true;
            btnGeri.Click += btnGeri_Click;
            // 
            // cmbRaporKodu2
            // 
            cmbRaporKodu2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbRaporKodu2.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRaporKodu2.Font = new Font("Segoe UI", 9F);
            cmbRaporKodu2.FormattingEnabled = true;
            cmbRaporKodu2.Location = new Point(120, 516);
            cmbRaporKodu2.Name = "cmbRaporKodu2";
            cmbRaporKodu2.Size = new Size(258, 23);
            cmbRaporKodu2.TabIndex = 17;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label9.Location = new Point(12, 519);
            label9.Name = "label9";
            label9.RightToLeft = RightToLeft.No;
            label9.Size = new Size(85, 15);
            label9.TabIndex = 77;
            label9.Text = "Rapor Kodu 2:";
            // 
            // cmbRaporKodu1
            // 
            cmbRaporKodu1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbRaporKodu1.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRaporKodu1.Font = new Font("Segoe UI", 9F);
            cmbRaporKodu1.FormattingEnabled = true;
            cmbRaporKodu1.Location = new Point(120, 487);
            cmbRaporKodu1.Name = "cmbRaporKodu1";
            cmbRaporKodu1.Size = new Size(258, 23);
            cmbRaporKodu1.TabIndex = 16;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label10.Location = new Point(12, 490);
            label10.Name = "label10";
            label10.RightToLeft = RightToLeft.No;
            label10.Size = new Size(85, 15);
            label10.TabIndex = 75;
            label10.Text = "Rapor Kodu 1:";
            // 
            // cmbGrupKodu
            // 
            cmbGrupKodu.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbGrupKodu.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbGrupKodu.Font = new Font("Segoe UI", 9F);
            cmbGrupKodu.FormattingEnabled = true;
            cmbGrupKodu.Location = new Point(120, 458);
            cmbGrupKodu.Name = "cmbGrupKodu";
            cmbGrupKodu.Size = new Size(258, 23);
            cmbGrupKodu.TabIndex = 15;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label11.Location = new Point(12, 461);
            label11.Name = "label11";
            label11.Size = new Size(70, 15);
            label11.TabIndex = 73;
            label11.Text = "Grup Kodu:";
            // 
            // cmbVergiDairesi
            // 
            cmbVergiDairesi.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbVergiDairesi.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbVergiDairesi.Font = new Font("Segoe UI", 9F);
            cmbVergiDairesi.FormattingEnabled = true;
            cmbVergiDairesi.Location = new Point(120, 371);
            cmbVergiDairesi.Name = "cmbVergiDairesi";
            cmbVergiDairesi.Size = new Size(258, 23);
            cmbVergiDairesi.TabIndex = 12;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label12.Location = new Point(12, 374);
            label12.Name = "label12";
            label12.Size = new Size(80, 15);
            label12.TabIndex = 79;
            label12.Text = "Vergi Dairesi:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label13.Location = new Point(12, 403);
            label13.Name = "label13";
            label13.RightToLeft = RightToLeft.No;
            label13.Size = new Size(58, 15);
            label13.TabIndex = 81;
            label13.Text = "Vergi No:";
            // 
            // txtVergiNo
            // 
            txtVergiNo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtVergiNo.Location = new Point(120, 400);
            txtVergiNo.MaxLength = 15;
            txtVergiNo.Name = "txtVergiNo";
            txtVergiNo.Size = new Size(258, 23);
            txtVergiNo.TabIndex = 13;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label14.Location = new Point(12, 258);
            label14.Name = "label14";
            label14.RightToLeft = RightToLeft.No;
            label14.Size = new Size(52, 15);
            label14.TabIndex = 83;
            label14.Text = "Telefon:";
            // 
            // txtTelefon
            // 
            txtTelefon.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTelefon.Location = new Point(120, 255);
            txtTelefon.MaxLength = 20;
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(258, 23);
            txtTelefon.TabIndex = 8;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label15.Location = new Point(12, 287);
            label15.Name = "label15";
            label15.RightToLeft = RightToLeft.No;
            label15.Size = new Size(34, 15);
            label15.TabIndex = 85;
            label15.Text = "Faks:";
            // 
            // txtFaks
            // 
            txtFaks.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtFaks.Location = new Point(120, 284);
            txtFaks.MaxLength = 20;
            txtFaks.Name = "txtFaks";
            txtFaks.Size = new Size(258, 23);
            txtFaks.TabIndex = 9;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label16.Location = new Point(12, 316);
            label16.Name = "label16";
            label16.RightToLeft = RightToLeft.No;
            label16.Size = new Size(51, 15);
            label16.TabIndex = 87;
            label16.Text = "E-Posta:";
            // 
            // txtMail
            // 
            txtMail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMail.Location = new Point(120, 313);
            txtMail.MaxLength = 255;
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(258, 23);
            txtMail.TabIndex = 10;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label17.Location = new Point(12, 345);
            label17.Name = "label17";
            label17.RightToLeft = RightToLeft.No;
            label17.Size = new Size(74, 15);
            label17.TabIndex = 89;
            label17.Text = "Web Adresi:";
            // 
            // txtWeb
            // 
            txtWeb.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtWeb.Location = new Point(120, 342);
            txtWeb.MaxLength = 60;
            txtWeb.Name = "txtWeb";
            txtWeb.Size = new Size(258, 23);
            txtWeb.TabIndex = 11;
            // 
            // btnAktar
            // 
            btnAktar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAktar.Location = new Point(141, 574);
            btnAktar.Name = "btnAktar";
            btnAktar.Size = new Size(156, 23);
            btnAktar.TabIndex = 21;
            btnAktar.Text = "Tabloyu NETSIS'e aktar";
            btnAktar.UseVisualStyleBackColor = true;
            btnAktar.Click += btnAktar_Click;
            // 
            // txtTC
            // 
            txtTC.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTC.Location = new Point(120, 429);
            txtTC.MaxLength = 11;
            txtTC.Name = "txtTC";
            txtTC.Size = new Size(258, 23);
            txtTC.TabIndex = 14;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label7.Location = new Point(12, 432);
            label7.Name = "label7";
            label7.RightToLeft = RightToLeft.No;
            label7.Size = new Size(86, 15);
            label7.TabIndex = 66;
            label7.Text = "T.C. Kimlik No:";
            // 
            // txtCariIsim
            // 
            txtCariIsim.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCariIsim.Location = new Point(120, 35);
            txtCariIsim.MaxLength = 100;
            txtCariIsim.Multiline = true;
            txtCariIsim.Name = "txtCariIsim";
            txtCariIsim.Size = new Size(258, 46);
            txtCariIsim.TabIndex = 2;
            // 
            // txtAdres
            // 
            txtAdres.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAdres.Location = new Point(120, 87);
            txtAdres.MaxLength = 255;
            txtAdres.Multiline = true;
            txtAdres.Name = "txtAdres";
            txtAdres.Size = new Size(258, 46);
            txtAdres.TabIndex = 3;
            // 
            // CariKayit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(396, 608);
            Controls.Add(txtAdres);
            Controls.Add(txtCariIsim);
            Controls.Add(btnAktar);
            Controls.Add(label17);
            Controls.Add(txtWeb);
            Controls.Add(label16);
            Controls.Add(txtMail);
            Controls.Add(label15);
            Controls.Add(txtFaks);
            Controls.Add(label14);
            Controls.Add(txtTelefon);
            Controls.Add(label13);
            Controls.Add(txtVergiNo);
            Controls.Add(cmbVergiDairesi);
            Controls.Add(label12);
            Controls.Add(cmbRaporKodu2);
            Controls.Add(label9);
            Controls.Add(cmbRaporKodu1);
            Controls.Add(label10);
            Controls.Add(cmbGrupKodu);
            Controls.Add(label11);
            Controls.Add(btnGeri);
            Controls.Add(btnSil);
            Controls.Add(btnGuncelle);
            Controls.Add(btnEkle);
            Controls.Add(cmbPostaKodu);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(cmbIlce);
            Controls.Add(label6);
            Controls.Add(cmbIl);
            Controls.Add(label5);
            Controls.Add(cmbUlke);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtTC);
            Controls.Add(label2);
            Controls.Add(txtCariKod);
            Controls.Add(label1);
            Name = "CariKayit";
            Text = "Cari Kayıt";
            Load += CariKayit_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtCariKod;
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
        private Button btnEkle;
        private Button btnGuncelle;
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
        private Label label13;
        private TextBox txtVergiNo;
        private Label label14;
        private TextBox txtTelefon;
        private Label label15;
        private TextBox txtFaks;
        private Label label16;
        private TextBox txtMail;
        private Label label17;
        private TextBox txtWeb;
        private Button btnAktar;
        private TextBox txtTC;
        private Label label7;
        private TextBox txtCariIsim;
        private TextBox txtAdres;
    }
}