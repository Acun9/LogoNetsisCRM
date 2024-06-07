namespace SinerjiCRM
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
            btnKisiKaydet = new Button();
            btnSatisTeklif = new Button();
            btnCikis = new Button();
            btnCariKaydet = new Button();
            SuspendLayout();
            // 
            // btnKisiKaydet
            // 
            btnKisiKaydet.Anchor = AnchorStyles.Top;
            btnKisiKaydet.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnKisiKaydet.Location = new Point(95, 12);
            btnKisiKaydet.Name = "btnKisiKaydet";
            btnKisiKaydet.Size = new Size(80, 60);
            btnKisiKaydet.TabIndex = 0;
            btnKisiKaydet.Text = "Kişi Kaydet";
            btnKisiKaydet.UseVisualStyleBackColor = true;
            btnKisiKaydet.Click += btnKisi_Click;
            // 
            // btnSatisTeklif
            // 
            btnSatisTeklif.Anchor = AnchorStyles.Top;
            btnSatisTeklif.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnSatisTeklif.Location = new Point(181, 12);
            btnSatisTeklif.Name = "btnSatisTeklif";
            btnSatisTeklif.Size = new Size(80, 60);
            btnSatisTeklif.TabIndex = 1;
            btnSatisTeklif.Text = "Satış Teklif";
            btnSatisTeklif.UseVisualStyleBackColor = true;
            btnSatisTeklif.Click += btnSatisTeklif_Click;
            // 
            // btnCikis
            // 
            btnCikis.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCikis.Location = new Point(185, 94);
            btnCikis.Name = "btnCikis";
            btnCikis.Size = new Size(75, 23);
            btnCikis.TabIndex = 2;
            btnCikis.Text = "Çıkış";
            btnCikis.UseVisualStyleBackColor = true;
            btnCikis.Click += btnCikis_Click;
            // 
            // btnCariKaydet
            // 
            btnCariKaydet.Anchor = AnchorStyles.Top;
            btnCariKaydet.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnCariKaydet.Location = new Point(9, 12);
            btnCariKaydet.Name = "btnCariKaydet";
            btnCariKaydet.Size = new Size(80, 60);
            btnCariKaydet.TabIndex = 3;
            btnCariKaydet.Text = "Cari Kaydet";
            btnCariKaydet.UseVisualStyleBackColor = true;
            btnCariKaydet.Click += btnCari_Click;
            // 
            // AnaSayfa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(272, 129);
            Controls.Add(btnCariKaydet);
            Controls.Add(btnCikis);
            Controls.Add(btnSatisTeklif);
            Controls.Add(btnKisiKaydet);
            MaximizeBox = false;
            Name = "AnaSayfa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sinerji CRM";
            FormClosed += SinerjiCRM_FormClosed;
            ResumeLayout(false);
        }

        #endregion

        private Button btnKisiKaydet;
        private Button btnSatisTeklif;
        private Button btnCikis;
        private Button btnCariKaydet;
    }
}