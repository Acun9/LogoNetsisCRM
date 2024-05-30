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
            openFileDialog1 = new OpenFileDialog();
            txtCvYolu = new TextBox();
            label16 = new Label();
            btnCvEkle = new Button();
            rbErkek = new RadioButton();
            rbKadin = new RadioButton();
            btnSil = new Button();
            comboBox1 = new ComboBox();
            label14 = new Label();
            panel1 = new Panel();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pcrResim).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(3, 9);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 0;
            label1.Text = "Kişi Kodu";
            // 
            // txtPlasiyerKodu
            // 
            txtPlasiyerKodu.Anchor = AnchorStyles.Top;
            txtPlasiyerKodu.Font = new Font("Segoe UI", 9F);
            txtPlasiyerKodu.Location = new Point(138, 6);
            txtPlasiyerKodu.Name = "txtPlasiyerKodu";
            txtPlasiyerKodu.Size = new Size(258, 23);
            txtPlasiyerKodu.TabIndex = 1;
            // 
            // txtMeslek
            // 
            txtMeslek.Anchor = AnchorStyles.Top;
            txtMeslek.Font = new Font("Segoe UI", 9F);
            txtMeslek.Location = new Point(138, 92);
            txtMeslek.Name = "txtMeslek";
            txtMeslek.Size = new Size(258, 23);
            txtMeslek.TabIndex = 5;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(3, 38);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 2;
            label2.Text = "Ad-Soyad";
            // 
            // txtAdSoyad
            // 
            txtAdSoyad.Anchor = AnchorStyles.Top;
            txtAdSoyad.Font = new Font("Segoe UI", 9F);
            txtAdSoyad.Location = new Point(138, 35);
            txtAdSoyad.Name = "txtAdSoyad";
            txtAdSoyad.Size = new Size(258, 23);
            txtAdSoyad.TabIndex = 2;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(3, 95);
            label4.Name = "label4";
            label4.Size = new Size(47, 15);
            label4.TabIndex = 6;
            label4.Text = "Meslek";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(3, 67);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 4;
            label3.Text = "Cinsiyet";
            // 
            // txtMail
            // 
            txtMail.Anchor = AnchorStyles.Top;
            txtMail.Font = new Font("Segoe UI", 9F);
            txtMail.Location = new Point(672, 6);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(258, 23);
            txtMail.TabIndex = 9;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.Location = new Point(625, 9);
            label8.Name = "label8";
            label8.Size = new Size(41, 15);
            label8.TabIndex = 14;
            label8.Text = "E-mail";
            // 
            // txtYonetici
            // 
            txtYonetici.Anchor = AnchorStyles.Top;
            txtYonetici.Font = new Font("Segoe UI", 9F);
            txtYonetici.Location = new Point(138, 179);
            txtYonetici.Name = "txtYonetici";
            txtYonetici.Size = new Size(258, 23);
            txtYonetici.TabIndex = 8;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.Location = new Point(3, 182);
            label7.Name = "label7";
            label7.Size = new Size(124, 15);
            label7.TabIndex = 12;
            label7.Text = "Bağlı Olduğu Yönetici";
            // 
            // txtDepartman
            // 
            txtDepartman.Anchor = AnchorStyles.Top;
            txtDepartman.Font = new Font("Segoe UI", 9F);
            txtDepartman.Location = new Point(138, 150);
            txtDepartman.Name = "txtDepartman";
            txtDepartman.Size = new Size(258, 23);
            txtDepartman.TabIndex = 7;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(3, 153);
            label6.Name = "label6";
            label6.Size = new Size(70, 15);
            label6.TabIndex = 10;
            label6.Text = "Departman";
            // 
            // txtGorev
            // 
            txtGorev.Anchor = AnchorStyles.Top;
            txtGorev.Font = new Font("Segoe UI", 9F);
            txtGorev.Location = new Point(138, 121);
            txtGorev.Name = "txtGorev";
            txtGorev.Size = new Size(258, 23);
            txtGorev.TabIndex = 6;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(3, 124);
            label5.Name = "label5";
            label5.Size = new Size(42, 15);
            label5.TabIndex = 8;
            label5.Text = "Görev";
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top;
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label12.Location = new Point(639, 124);
            label12.Name = "label12";
            label12.Size = new Size(27, 15);
            label12.TabIndex = 22;
            label12.Text = "İlçe";
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top;
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label11.Location = new Point(652, 100);
            label11.Name = "label11";
            label11.Size = new Size(14, 15);
            label11.TabIndex = 20;
            label11.Text = "İl";
            // 
            // txtAdres
            // 
            txtAdres.Anchor = AnchorStyles.Top;
            txtAdres.Font = new Font("Segoe UI", 9F);
            txtAdres.Location = new Point(672, 64);
            txtAdres.Name = "txtAdres";
            txtAdres.Size = new Size(258, 23);
            txtAdres.TabIndex = 11;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label10.Location = new Point(627, 67);
            label10.Name = "label10";
            label10.Size = new Size(39, 15);
            label10.TabIndex = 18;
            label10.Text = "Adres";
            // 
            // txtTelefon
            // 
            txtTelefon.Anchor = AnchorStyles.Top;
            txtTelefon.Font = new Font("Segoe UI", 9F);
            txtTelefon.Location = new Point(672, 35);
            txtTelefon.Name = "txtTelefon";
            txtTelefon.Size = new Size(258, 23);
            txtTelefon.TabIndex = 10;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top;
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label9.Location = new Point(617, 38);
            label9.Name = "label9";
            label9.Size = new Size(49, 15);
            label9.TabIndex = 16;
            label9.Text = "Telefon";
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Top;
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label13.Location = new Point(633, 154);
            label13.Name = "label13";
            label13.Size = new Size(33, 15);
            label13.TabIndex = 24;
            label13.Text = "Ülke";
            // 
            // cmbIller
            // 
            cmbIller.Anchor = AnchorStyles.Top;
            cmbIller.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIller.Font = new Font("Segoe UI", 9F);
            cmbIller.FormattingEnabled = true;
            cmbIller.Location = new Point(672, 93);
            cmbIller.Name = "cmbIller";
            cmbIller.Size = new Size(258, 23);
            cmbIller.TabIndex = 12;
            cmbIller.SelectedIndexChanged += cmbIller_SelectedIndexChanged;
            // 
            // cmbIlceler
            // 
            cmbIlceler.Anchor = AnchorStyles.Top;
            cmbIlceler.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIlceler.Font = new Font("Segoe UI", 9F);
            cmbIlceler.FormattingEnabled = true;
            cmbIlceler.Location = new Point(672, 122);
            cmbIlceler.Name = "cmbIlceler";
            cmbIlceler.Size = new Size(258, 23);
            cmbIlceler.TabIndex = 13;
            // 
            // cmbUlkeler
            // 
            cmbUlkeler.Anchor = AnchorStyles.Top;
            cmbUlkeler.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUlkeler.Font = new Font("Segoe UI", 9F);
            cmbUlkeler.FormattingEnabled = true;
            cmbUlkeler.Location = new Point(672, 151);
            cmbUlkeler.Name = "cmbUlkeler";
            cmbUlkeler.Size = new Size(258, 23);
            cmbUlkeler.TabIndex = 14;
            // 
            // btnKaydet
            // 
            btnKaydet.Anchor = AnchorStyles.Top;
            btnKaydet.Location = new Point(415, 180);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(63, 23);
            btnKaydet.TabIndex = 19;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // btnCikis
            // 
            btnCikis.Anchor = AnchorStyles.Top;
            btnCikis.Location = new Point(553, 180);
            btnCikis.Name = "btnCikis";
            btnCikis.Size = new Size(63, 23);
            btnCikis.TabIndex = 21;
            btnCikis.Text = "Çıkış";
            btnCikis.UseVisualStyleBackColor = true;
            btnCikis.Click += btnCikis_Click;
            // 
            // pcrResim
            // 
            pcrResim.Anchor = AnchorStyles.Top;
            pcrResim.Location = new Point(462, 6);
            pcrResim.Name = "pcrResim";
            pcrResim.Size = new Size(97, 106);
            pcrResim.SizeMode = PictureBoxSizeMode.StretchImage;
            pcrResim.TabIndex = 34;
            pcrResim.TabStop = false;
            // 
            // btnResimEkle
            // 
            btnResimEkle.Anchor = AnchorStyles.Top;
            btnResimEkle.Location = new Point(565, 119);
            btnResimEkle.Name = "btnResimEkle";
            btnResimEkle.Size = new Size(24, 23);
            btnResimEkle.TabIndex = 16;
            btnResimEkle.Text = "...";
            btnResimEkle.UseVisualStyleBackColor = true;
            btnResimEkle.Click += btnResimEkle_Click;
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.Top;
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label15.Location = new Point(415, 125);
            label15.Name = "label15";
            label15.Size = new Size(41, 15);
            label15.TabIndex = 36;
            label15.Text = "Resim";
            // 
            // txtResimYolu
            // 
            txtResimYolu.Anchor = AnchorStyles.Top;
            txtResimYolu.Font = new Font("Segoe UI", 9F);
            txtResimYolu.Location = new Point(462, 120);
            txtResimYolu.Name = "txtResimYolu";
            txtResimYolu.Size = new Size(97, 23);
            txtResimYolu.TabIndex = 15;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtCvYolu
            // 
            txtCvYolu.Anchor = AnchorStyles.Top;
            txtCvYolu.Font = new Font("Segoe UI", 9F);
            txtCvYolu.Location = new Point(462, 150);
            txtCvYolu.Name = "txtCvYolu";
            txtCvYolu.Size = new Size(97, 23);
            txtCvYolu.TabIndex = 17;
            // 
            // label16
            // 
            label16.Anchor = AnchorStyles.Top;
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label16.Location = new Point(435, 155);
            label16.Name = "label16";
            label16.Size = new Size(21, 15);
            label16.TabIndex = 41;
            label16.Text = "Cv";
            // 
            // btnCvEkle
            // 
            btnCvEkle.Anchor = AnchorStyles.Top;
            btnCvEkle.Location = new Point(565, 150);
            btnCvEkle.Name = "btnCvEkle";
            btnCvEkle.Size = new Size(24, 23);
            btnCvEkle.TabIndex = 18;
            btnCvEkle.Text = "...";
            btnCvEkle.UseVisualStyleBackColor = true;
            btnCvEkle.Click += btnCvEkle_Click;
            // 
            // rbErkek
            // 
            rbErkek.Anchor = AnchorStyles.Top;
            rbErkek.AutoSize = true;
            rbErkek.CheckAlign = ContentAlignment.MiddleRight;
            rbErkek.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 162);
            rbErkek.Location = new Point(138, 63);
            rbErkek.Name = "rbErkek";
            rbErkek.Size = new Size(53, 19);
            rbErkek.TabIndex = 3;
            rbErkek.TabStop = true;
            rbErkek.Text = "Erkek";
            rbErkek.UseVisualStyleBackColor = true;
            // 
            // rbKadin
            // 
            rbKadin.Anchor = AnchorStyles.Top;
            rbKadin.AutoSize = true;
            rbKadin.CheckAlign = ContentAlignment.MiddleRight;
            rbKadin.Location = new Point(197, 63);
            rbKadin.Name = "rbKadin";
            rbKadin.Size = new Size(69, 19);
            rbKadin.TabIndex = 4;
            rbKadin.TabStop = true;
            rbKadin.Text = "/   Kadın";
            rbKadin.UseVisualStyleBackColor = true;
            // 
            // btnSil
            // 
            btnSil.Anchor = AnchorStyles.Top;
            btnSil.Location = new Point(484, 180);
            btnSil.Name = "btnSil";
            btnSil.Size = new Size(63, 23);
            btnSil.TabIndex = 20;
            btnSil.Text = "Sil";
            btnSil.UseVisualStyleBackColor = true;
            btnSil.Click += btnSil_Click;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Segoe UI", 9F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(672, 180);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(258, 23);
            comboBox1.TabIndex = 42;
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Top;
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label14.Location = new Point(633, 183);
            label14.Name = "label14";
            label14.Size = new Size(33, 15);
            label14.TabIndex = 43;
            label14.Text = "Ülke";
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(txtPlasiyerKodu);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnSil);
            panel1.Controls.Add(txtMeslek);
            panel1.Controls.Add(rbKadin);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(rbErkek);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtCvYolu);
            panel1.Controls.Add(txtAdSoyad);
            panel1.Controls.Add(label16);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(btnCvEkle);
            panel1.Controls.Add(txtGorev);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(txtResimYolu);
            panel1.Controls.Add(txtDepartman);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(btnResimEkle);
            panel1.Controls.Add(txtYonetici);
            panel1.Controls.Add(pcrResim);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(btnCikis);
            panel1.Controls.Add(txtMail);
            panel1.Controls.Add(btnKaydet);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(cmbUlkeler);
            panel1.Controls.Add(txtTelefon);
            panel1.Controls.Add(cmbIlceler);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(cmbIller);
            panel1.Controls.Add(txtAdres);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label12);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(935, 212);
            panel1.TabIndex = 44;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 212);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(935, 263);
            dataGridView1.TabIndex = 22;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // PlasiyerKayit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(935, 475);
            Controls.Add(dataGridView1);
            Controls.Add(panel1);
            Name = "PlasiyerKayit";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kişi Kaydet";
            FormClosed += PlasiyerKayit_FormClosed;
            Load += PlasiyerKayit_Load;
            ((System.ComponentModel.ISupportInitialize)pcrResim).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
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
        private Panel panel1;
        private DataGridView dataGridView1;
    }
}