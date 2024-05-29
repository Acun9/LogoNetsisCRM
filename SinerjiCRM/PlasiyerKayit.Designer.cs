using System.Windows.Forms;

namespace SinerjiCRM
{
    partial class PlasiyerKayit
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
            txtPlasiyerKodu = new TextBox();
            txtMeslek = new TextBox();
            label2 = new Label();
            txtAdSoyad = new TextBox();
            label4 = new Label();
            label3 = new Label();
            txtMail = new TextBox();
            label8 = new Label();
            txtYonetici = new TextBox();
            label7 = new Label();
            txtDepartman = new TextBox();
            label6 = new Label();
            txtGorev = new TextBox();
            label5 = new Label();
            label12 = new Label();
            label11 = new Label();
            txtAdres = new TextBox();
            label10 = new Label();
            txtTelefon = new TextBox();
            label9 = new Label();
            label13 = new Label();
            cmbIller = new ComboBox();
            cmbIlceler = new ComboBox();
            cmbUlkeler = new ComboBox();
            btnKaydet = new Button();
            btnCikis = new Button();
            pcrResim = new PictureBox();
            btnResimEkle = new Button();
            label15 = new Label();
            txtResimYolu = new TextBox();
            dataGridView1 = new DataGridView();
            openFileDialog1 = new OpenFileDialog();
            txtCvYolu = new TextBox();
            label16 = new Label();
            btnCvEkle = new Button();
            rbErkek = new RadioButton();
            rbKadin = new RadioButton();
            btnSil = new Button();
            comboBox1 = new ComboBox();
            label14 = new Label();
            ((System.ComponentModel.ISupportInitialize)pcrResim).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 0;
            label1.Text = "Kişi Kodu";
            // 
            // txtPlasiyerKodu
            // 
            txtPlasiyerKodu.Font = new Font("Segoe UI", 9F);
            txtPlasiyerKodu.Location = new Point(147, 12);
            txtPlasiyerKodu.Name = "txtPlasiyerKodu";
            txtPlasiyerKodu.Size = new Size(258, 23);
            txtPlasiyerKodu.TabIndex = 1;
            // 
            // txtMeslek
            // 
            txtMeslek.Font = new Font("Segoe UI", 9F);
            txtMeslek.Location = new Point(147, 98);
            txtMeslek.Name = "txtMeslek";
            txtMeslek.Size = new Size(258, 23);
            txtMeslek.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(12, 44);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 2;
            label2.Text = "Ad-Soyad:";
            // 
            // txtAdSoyad
            // 
            txtAdSoyad.Font = new Font("Segoe UI", 9F);
            txtAdSoyad.Location = new Point(147, 41);
            txtAdSoyad.Name = "txtAdSoyad";
            txtAdSoyad.Size = new Size(258, 23);
            txtAdSoyad.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(12, 101);
            label4.Name = "label4";
            label4.Size = new Size(50, 15);
            label4.TabIndex = 6;
            label4.Text = "Meslek:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(12, 73);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 4;
            label3.Text = "Cinsiyet:";
            // 
            // txtMail
            // 
            txtMail.Font = new Font("Segoe UI", 9F);
            txtMail.Location = new Point(147, 214);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(258, 23);
            txtMail.TabIndex = 9;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.Location = new Point(12, 217);
            label8.Name = "label8";
            label8.Size = new Size(44, 15);
            label8.TabIndex = 14;
            label8.Text = "E-mail:";
            // 
            // txtYonetici
            // 
            txtYonetici.Font = new Font("Segoe UI", 9F);
            txtYonetici.Location = new Point(147, 185);
            txtYonetici.Name = "txtYonetici";
            txtYonetici.Size = new Size(258, 23);
            txtYonetici.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.Location = new Point(12, 188);
            label7.Name = "label7";
            label7.Size = new Size(127, 15);
            label7.TabIndex = 12;
            label7.Text = "Bağlı Olduğu Yönetici:";
            // 
            // txtDepartman
            // 
            txtDepartman.Font = new Font("Segoe UI", 9F);
            txtDepartman.Location = new Point(147, 156);
            txtDepartman.Name = "txtDepartman";
            txtDepartman.Size = new Size(258, 23);
            txtDepartman.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(12, 159);
            label6.Name = "label6";
            label6.Size = new Size(73, 15);
            label6.TabIndex = 10;
            label6.Text = "Departman:";
            // 
            // txtGorev
            // 
            txtGorev.Font = new Font("Segoe UI", 9F);
            txtGorev.Location = new Point(147, 127);
            txtGorev.Name = "txtGorev";
            txtGorev.Size = new Size(258, 23);
            txtGorev.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(12, 130);
            label5.Name = "label5";
            label5.Size = new Size(45, 15);
            label5.TabIndex = 8;
            label5.Text = "Görev:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label12.Location = new Point(12, 333);
            label12.Name = "label12";
            label12.Size = new Size(30, 15);
            label12.TabIndex = 22;
            label12.Text = "İlçe:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label11.Location = new Point(12, 304);
            label11.Name = "label11";
            label11.Size = new Size(17, 15);
            label11.TabIndex = 20;
            label11.Text = "İl:";
            // 
            // txtAdres
            // 
            txtAdres.Font = new Font("Segoe UI", 9F);
            txtAdres.Location = new Point(147, 272);
            txtAdres.Name = "txtAdres";
            txtAdres.Size = new Size(258, 23);
            txtAdres.TabIndex = 11;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label10.Location = new Point(12, 275);
            label10.Name = "label10";
            label10.Size = new Size(42, 15);
            label10.TabIndex = 18;
            label10.Text = "Adres:";
            // 
            // txtTelefon
            // 
            txtTelefon.Font = new Font("Segoe UI", 9F);
            txtTelefon.Location = new Point(147, 243);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(258, 23);
            txtTelefon.TabIndex = 10;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label9.Location = new Point(12, 246);
            label9.Name = "label9";
            label9.Size = new Size(52, 15);
            label9.TabIndex = 16;
            label9.Text = "Telefon:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label13.Location = new Point(12, 362);
            label13.Name = "label13";
            label13.Size = new Size(36, 15);
            label13.TabIndex = 24;
            label13.Text = "Ülke:";
            // 
            // cmbIller
            // 
            cmbIller.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIller.Font = new Font("Segoe UI", 9F);
            cmbIller.FormattingEnabled = true;
            cmbIller.Location = new Point(147, 301);
            cmbIller.Name = "cmbIller";
            cmbIller.Size = new Size(258, 23);
            cmbIller.TabIndex = 12;
            cmbIller.SelectedIndexChanged += cmbIller_SelectedIndexChanged;
            // 
            // cmbIlceler
            // 
            cmbIlceler.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIlceler.Font = new Font("Segoe UI", 9F);
            cmbIlceler.FormattingEnabled = true;
            cmbIlceler.Location = new Point(147, 330);
            cmbIlceler.Name = "cmbIlceler";
            cmbIlceler.Size = new Size(258, 23);
            cmbIlceler.TabIndex = 13;
            // 
            // cmbUlkeler
            // 
            cmbUlkeler.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUlkeler.Font = new Font("Segoe UI", 9F);
            cmbUlkeler.FormattingEnabled = true;
            cmbUlkeler.Location = new Point(147, 359);
            cmbUlkeler.Name = "cmbUlkeler";
            cmbUlkeler.Size = new Size(258, 23);
            cmbUlkeler.TabIndex = 14;
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(439, 325);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(75, 23);
            btnKaydet.TabIndex = 19;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // btnCikis
            // 
            btnCikis.Location = new Point(541, 354);
            btnCikis.Name = "btnCikis";
            btnCikis.Size = new Size(75, 23);
            btnCikis.TabIndex = 21;
            btnCikis.Text = "Çıkış";
            btnCikis.UseVisualStyleBackColor = true;
            btnCikis.Click += btnCikis_Click;
            // 
            // pcrResim
            // 
            pcrResim.Location = new Point(489, 15);
            pcrResim.Name = "pcrResim";
            pcrResim.Size = new Size(97, 106);
            pcrResim.SizeMode = PictureBoxSizeMode.StretchImage;
            pcrResim.TabIndex = 34;
            pcrResim.TabStop = false;
            // 
            // btnResimEkle
            // 
            btnResimEkle.Location = new Point(592, 130);
            btnResimEkle.Name = "btnResimEkle";
            btnResimEkle.Size = new Size(24, 23);
            btnResimEkle.TabIndex = 16;
            btnResimEkle.Text = "...";
            btnResimEkle.UseVisualStyleBackColor = true;
            btnResimEkle.Click += btnResimEkle_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label15.Location = new Point(439, 135);
            label15.Name = "label15";
            label15.Size = new Size(44, 15);
            label15.TabIndex = 36;
            label15.Text = "Resim:";
            // 
            // txtResimYolu
            // 
            txtResimYolu.Font = new Font("Segoe UI", 9F);
            txtResimYolu.Location = new Point(489, 130);
            txtResimYolu.Name = "txtResimYolu";
            txtResimYolu.Size = new Size(97, 23);
            txtResimYolu.TabIndex = 15;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 430);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(604, 314);
            dataGridView1.TabIndex = 22;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtCvYolu
            // 
            txtCvYolu.Font = new Font("Segoe UI", 9F);
            txtCvYolu.Location = new Point(489, 238);
            txtCvYolu.Name = "txtCvYolu";
            txtCvYolu.Size = new Size(97, 23);
            txtCvYolu.TabIndex = 17;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label16.Location = new Point(459, 243);
            label16.Name = "label16";
            label16.Size = new Size(24, 15);
            label16.TabIndex = 41;
            label16.Text = "Cv:";
            // 
            // btnCvEkle
            // 
            btnCvEkle.Location = new Point(592, 238);
            btnCvEkle.Name = "btnCvEkle";
            btnCvEkle.Size = new Size(24, 23);
            btnCvEkle.TabIndex = 18;
            btnCvEkle.Text = "...";
            btnCvEkle.UseVisualStyleBackColor = true;
            btnCvEkle.Click += btnCvEkle_Click;
            // 
            // rbErkek
            // 
            rbErkek.AutoSize = true;
            rbErkek.CheckAlign = ContentAlignment.MiddleRight;
            rbErkek.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            rbErkek.Location = new Point(147, 69);
            rbErkek.Name = "rbErkek";
            rbErkek.Size = new Size(53, 19);
            rbErkek.TabIndex = 3;
            rbErkek.TabStop = true;
            rbErkek.Text = "Erkek";
            rbErkek.UseVisualStyleBackColor = true;
            // 
            // rbKadin
            // 
            rbKadin.AutoSize = true;
            rbKadin.CheckAlign = ContentAlignment.MiddleRight;
            rbKadin.Location = new Point(206, 69);
            rbKadin.Name = "rbKadin";
            rbKadin.Size = new Size(69, 19);
            rbKadin.TabIndex = 4;
            rbKadin.TabStop = true;
            rbKadin.Text = "/   Kadın";
            rbKadin.UseVisualStyleBackColor = true;
            // 
            // btnSil
            // 
            btnSil.Location = new Point(439, 354);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(75, 23);
            btnSil.TabIndex = 20;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Segoe UI", 9F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(147, 388);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(258, 23);
            comboBox1.TabIndex = 42;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label14.Location = new Point(12, 391);
            label14.Name = "label14";
            label14.Size = new Size(36, 15);
            label14.TabIndex = 43;
            label14.Text = "Ülke:";
            // 
            // PlasiyerKayit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1411, 746);
            Controls.Add(comboBox1);
            Controls.Add(label14);
            Controls.Add(btnSil);
            Controls.Add(rbKadin);
            Controls.Add(rbErkek);
            Controls.Add(txtCvYolu);
            Controls.Add(label16);
            Controls.Add(btnCvEkle);
            Controls.Add(dataGridView1);
            Controls.Add(txtResimYolu);
            Controls.Add(label15);
            Controls.Add(btnResimEkle);
            Controls.Add(pcrResim);
            Controls.Add(btnCikis);
            Controls.Add(btnKaydet);
            Controls.Add(cmbUlkeler);
            Controls.Add(cmbIlceler);
            Controls.Add(cmbIller);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(txtAdres);
            Controls.Add(label10);
            Controls.Add(txtTelefon);
            Controls.Add(label9);
            Controls.Add(txtMail);
            Controls.Add(label8);
            Controls.Add(txtYonetici);
            Controls.Add(label7);
            Controls.Add(txtDepartman);
            Controls.Add(label6);
            Controls.Add(txtGorev);
            Controls.Add(label5);
            Controls.Add(txtAdSoyad);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtMeslek);
            Controls.Add(label2);
            Controls.Add(txtPlasiyerKodu);
            Controls.Add(label1);
            Name = "PlasiyerKayit";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kişi Kaydet";
            FormClosed += PlasiyerKayit_FormClosed;
            Load += PlasiyerKayit_Load;
            ((System.ComponentModel.ISupportInitialize)pcrResim).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtPlasiyerKodu;
        private TextBox txtMeslek;
        private Label label2;
        private TextBox txtAdSoyad;
        private Label label4;
        private Label label3;
        private TextBox txtMail;
        private Label label8;
        private TextBox txtYonetici;
        private Label label7;
        private TextBox txtDepartman;
        private Label label6;
        private TextBox txtGorev;
        private Label label5;
        private Label label12;
        private Label label11;
        private TextBox txtAdres;
        private Label label10;
        private TextBox txtTelefon;
        private Label label9;
        private Label label13;
        private ComboBox cmbIller;
        private ComboBox cmbIlceler;
        private ComboBox cmbUlkeler;
        private Button btnKaydet;
        private Button btnCikis;
        private PictureBox pcrResim;
        private Button btnResimEkle;
        private Label label15;
        private TextBox txtResimYolu;
        private DataGridView dataGridView1;
        private OpenFileDialog openFileDialog1;
        private AxAcroPDFLib.AxAcroPDF axAcropdf1;
        private TextBox txtCvYolu;
        private Label label16;
        private Button btnCvEkle;
        private RadioButton rbErkek;
        private RadioButton rbKadin;
        private Button btnSil;
        private ComboBox comboBox1;
        private Label label14;
    }
}