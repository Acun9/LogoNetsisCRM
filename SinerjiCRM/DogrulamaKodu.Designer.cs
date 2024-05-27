namespace Sinerji
{
    partial class DogrulamaKodu
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
            txtDogrulamaKodu = new TextBox();
            btnDogrula = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtDogrulamaKodu
            // 
            txtDogrulamaKodu.Location = new Point(121, 41);
            txtDogrulamaKodu.Name = "txtDogrulamaKodu";
            txtDogrulamaKodu.Size = new Size(100, 23);
            txtDogrulamaKodu.TabIndex = 0;
            // 
            // btnDogrula
            // 
            btnDogrula.Location = new Point(133, 80);
            btnDogrula.Name = "btnDogrula";
            btnDogrula.Size = new Size(75, 23);
            btnDogrula.TabIndex = 1;
            btnDogrula.Text = "Doğrula";
            btnDogrula.UseVisualStyleBackColor = true;
            btnDogrula.Click += btnDogrula_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(12, 44);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 2;
            label1.Text = "Doğrulama Kodu:";
            // 
            // DogrulamaKodu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(326, 145);
            Controls.Add(label1);
            Controls.Add(btnDogrula);
            Controls.Add(txtDogrulamaKodu);
            Name = "DogrulamaKodu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dogrulama Kodu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDogrulamaKodu;
        private Button btnDogrula;
        private Label label1;
    }
}