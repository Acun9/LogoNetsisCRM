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
            btnKisi = new Button();
            btnMusteri = new Button();
            btnCikis = new Button();
            btnCari = new Button();
            SuspendLayout();
            // 
            // btnKisi
            // 
            btnKisi.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnKisi.Location = new Point(12, 12);
            btnKisi.Name = "btnKisi";
            btnKisi.Size = new Size(80, 60);
            btnKisi.TabIndex = 0;
            btnKisi.Text = "Kişi İşlemleri";
            btnKisi.UseVisualStyleBackColor = true;
            btnKisi.Click += btnKisi_Click;
            // 
            // btnMusteri
            // 
            btnMusteri.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnMusteri.Location = new Point(98, 12);
            btnMusteri.Name = "btnMusteri";
            btnMusteri.Size = new Size(80, 60);
            btnMusteri.TabIndex = 1;
            btnMusteri.Text = "Müşteri İşlemleri";
            btnMusteri.UseVisualStyleBackColor = true;
            btnMusteri.Click += btnMusteri_Click;
            // 
            // btnCikis
            // 
            btnCikis.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCikis.Location = new Point(216, 189);
            btnCikis.Name = "btnCikis";
            btnCikis.Size = new Size(75, 23);
            btnCikis.TabIndex = 2;
            btnCikis.Text = "Çıkış";
            btnCikis.UseVisualStyleBackColor = true;
            btnCikis.Click += btnCikis_Click;
            // 
            // btnCari
            // 
            btnCari.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnCari.Location = new Point(184, 12);
            btnCari.Name = "btnCari";
            btnCari.Size = new Size(80, 60);
            btnCari.TabIndex = 3;
            btnCari.Text = "Cari İşlemleri";
            btnCari.UseVisualStyleBackColor = true;
            btnCari.Click += btnCari_Click;
            // 
            // SinerjiCRM
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(303, 224);
            Controls.Add(btnCari);
            Controls.Add(btnCikis);
            Controls.Add(btnMusteri);
            Controls.Add(btnKisi);
            Name = "SinerjiCRM";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sinerji CRM";
            FormClosed += SinerjiCRM_FormClosed;
            ResumeLayout(false);
        }

        #endregion

        private Button btnKisi;
        private Button btnMusteri;
        private Button btnCikis;
        private Button btnCari;
    }
}