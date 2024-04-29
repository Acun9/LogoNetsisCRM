namespace C_Forms
{
    partial class AnaSayfa
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
            txtKullaniciAdi = new TextBox();
            txtSifre = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnGiris = new Button();
            btnCikis = new Button();
            cbSifre = new CheckBox();
            SuspendLayout();
            // 
            // txtKullaniciAdi
            // 
            txtKullaniciAdi.Font = new Font("Segoe UI", 9F);
            txtKullaniciAdi.Location = new Point(133, 58);
            txtKullaniciAdi.Name = "txtKullaniciAdi";
            txtKullaniciAdi.Size = new Size(258, 23);
            txtKullaniciAdi.TabIndex = 36;
            // 
            // txtSifre
            // 
            txtSifre.Font = new Font("Segoe UI", 9F);
            txtSifre.Location = new Point(133, 98);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(258, 23);
            txtSifre.TabIndex = 37;
            txtSifre.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(50, 61);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 38;
            label1.Text = "Kullanıcı Adı:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(90, 106);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 39;
            label2.Text = "Şifre:";
            // 
            // btnGiris
            // 
            btnGiris.Location = new Point(216, 162);
            btnGiris.Name = "btnGiris";
            btnGiris.Size = new Size(75, 23);
            btnGiris.TabIndex = 63;
            btnGiris.Text = "Giriş";
            btnGiris.UseVisualStyleBackColor = true;
            btnGiris.Click += btnGiris_Click;
            // 
            // btnCikis
            // 
            btnCikis.Location = new Point(216, 202);
            btnCikis.Name = "btnCikis";
            btnCikis.Size = new Size(75, 23);
            btnCikis.TabIndex = 64;
            btnCikis.Text = "Çıkış";
            btnCikis.UseVisualStyleBackColor = true;
            btnCikis.Click += btnCikis_Click;
            // 
            // cbSifre
            // 
            cbSifre.AutoSize = true;
            cbSifre.Location = new Point(297, 127);
            cbSifre.Name = "cbSifre";
            cbSifre.Size = new Size(94, 19);
            cbSifre.TabIndex = 65;
            cbSifre.Text = "Şifreyi göster";
            cbSifre.UseVisualStyleBackColor = true;
            cbSifre.CheckStateChanged += cbSifre_CheckStateChanged;
            // 
            // AnaSayfa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(512, 266);
            Controls.Add(cbSifre);
            Controls.Add(btnCikis);
            Controls.Add(btnGiris);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtSifre);
            Controls.Add(txtKullaniciAdi);
            Name = "AnaSayfa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sinerji - Satış Paneli";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtKullaniciAdi;
        private TextBox txtSifre;
        private Label label1;
        private Label label2;
        private Button btnGiris;
        private Button btnCikis;
        private CheckBox cbSifre;
    }
}