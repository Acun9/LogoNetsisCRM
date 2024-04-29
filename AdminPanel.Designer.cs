namespace C_Forms
{
    partial class AdminPanel
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
            btnPlasiyer = new Button();
            btnMusteri = new Button();
            btnCikis = new Button();
            SuspendLayout();
            // 
            // btnPlasiyer
            // 
            btnPlasiyer.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnPlasiyer.Location = new Point(36, 56);
            btnPlasiyer.Name = "btnPlasiyer";
            btnPlasiyer.Size = new Size(113, 23);
            btnPlasiyer.TabIndex = 0;
            btnPlasiyer.Text = "Plasiyer İşlemleri";
            btnPlasiyer.UseVisualStyleBackColor = true;
            btnPlasiyer.Click += btnPlasiyer_Click;
            // 
            // btnMusteri
            // 
            btnMusteri.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnMusteri.Location = new Point(155, 56);
            btnMusteri.Name = "btnMusteri";
            btnMusteri.Size = new Size(113, 23);
            btnMusteri.TabIndex = 1;
            btnMusteri.Text = "Müşteri İşlemleri";
            btnMusteri.UseVisualStyleBackColor = true;
            btnMusteri.Click += btnMusteri_Click;
            // 
            // btnCikis
            // 
            btnCikis.Location = new Point(117, 97);
            btnCikis.Name = "btnCikis";
            btnCikis.Size = new Size(75, 23);
            btnCikis.TabIndex = 2;
            btnCikis.Text = "Çıkış";
            btnCikis.UseVisualStyleBackColor = true;
            btnCikis.Click += btnCikis_Click;
            // 
            // AdminPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(316, 143);
            Controls.Add(btnCikis);
            Controls.Add(btnMusteri);
            Controls.Add(btnPlasiyer);
            Name = "AdminPanel";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin Paneli";
            FormClosed += AdminPanelForm_FormClosed;
            ResumeLayout(false);
        }

        #endregion

        private Button btnPlasiyer;
        private Button btnMusteri;
        private Button btnCikis;
    }
}