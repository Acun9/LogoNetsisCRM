namespace SinerjiCRM
{
    partial class KayitOl
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtKullaniciAdi = new TextBox();
            txtMail = new TextBox();
            txtSifre = new TextBox();
            txtSifreTekrar = new TextBox();
            btnKayitOl = new Button();
            btnGeri = new Button();
            cbSifre = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(86, 46);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 0;
            label1.Text = "Kullanıcı Adı";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(86, 75);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 1;
            label2.Text = "E-Posta";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(86, 104);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 2;
            label3.Text = "Şifre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(86, 133);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 3;
            label4.Text = "Şifre Tekrar";
            // 
            // txtKullaniciAdi
            // 
            txtKullaniciAdi.Location = new Point(165, 43);
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Size = new Size(196, 23);
            txtKullaniciAdi.TabIndex = 4;
            // 
            // txtMail
            // 
            txtMail.Location = new Point(165, 72);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(196, 23);
            txtMail.TabIndex = 5;
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(165, 101);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(196, 23);
            txtSifre.TabIndex = 6;
            txtSifre.UseSystemPasswordChar = true;
            // 
            // txtSifreTekrar
            // 
            txtSifreTekrar.Location = new Point(165, 130);
            txtSifreTekrar.Name = "txtSifreTekrar";
            txtSifreTekrar.Size = new Size(196, 23);
            txtSifreTekrar.TabIndex = 7;
            txtSifreTekrar.UseSystemPasswordChar = true;
            // 
            // btnKayitOl
            // 
            btnKayitOl.Location = new Point(205, 193);
            btnKayitOl.Name = "btnKayitOl";
            btnKayitOl.Size = new Size(75, 23);
            btnKayitOl.TabIndex = 8;
            btnKayitOl.Text = "Kayıt Ol";
            btnKayitOl.UseVisualStyleBackColor = true;
            btnKayitOl.Click += btnKayitOl_Click;
            // 
            // btnGeri
            // 
            btnGeri.Location = new Point(286, 193);
            btnGeri.Name = "btnGeri";
            btnGeri.Size = new Size(75, 23);
            btnGeri.TabIndex = 9;
            btnGeri.Text = "Geri";
            btnGeri.UseVisualStyleBackColor = true;
            btnGeri.Click += btnGeri_Click;
            // 
            // cbSifre
            // 
            cbSifre.AutoSize = true;
            cbSifre.Location = new Point(267, 159);
            cbSifre.Name = "cbSifre";
            cbSifre.Size = new Size(94, 19);
            cbSifre.TabIndex = 10;
            cbSifre.Text = "Şifreyi göster";
            cbSifre.UseVisualStyleBackColor = true;
            cbSifre.CheckedChanged += cbSifre_CheckStateChanged;
            // 
            // KayitOl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(504, 261);
            Controls.Add(cbSifre);
            Controls.Add(btnGeri);
            Controls.Add(btnKayitOl);
            Controls.Add(txtSifreTekrar);
            Controls.Add(txtSifre);
            Controls.Add(txtMail);
            Controls.Add(txtKullaniciAdi);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "KayitOl";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kayıt Ol";
            FormClosed += KayitOl_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtKullaniciAdi;
        private TextBox txtMail;
        private TextBox txtSifre;
        private TextBox txtSifreTekrar;
        private Button btnKayitOl;
        private Button btnGeri;
        private CheckBox cbSifre;
    }
}