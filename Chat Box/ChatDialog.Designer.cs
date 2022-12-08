namespace Chat_Box
{
    partial class ChatDialog
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
            this.gpuser = new System.Windows.Forms.GroupBox();
            this.lblwaktu = new System.Windows.Forms.Label();
            this.lblpesan = new System.Windows.Forms.Label();
            this.gpuser.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpuser
            // 
            this.gpuser.Controls.Add(this.lblwaktu);
            this.gpuser.Controls.Add(this.lblpesan);
            this.gpuser.Location = new System.Drawing.Point(12, 12);
            this.gpuser.Name = "gpuser";
            this.gpuser.Size = new System.Drawing.Size(384, 137);
            this.gpuser.TabIndex = 0;
            this.gpuser.TabStop = false;
            this.gpuser.Text = "Username";
            this.gpuser.Enter += new System.EventHandler(this.gpuser_Enter);
            // 
            // lblwaktu
            // 
            this.lblwaktu.AutoSize = true;
            this.lblwaktu.BackColor = System.Drawing.Color.Transparent;
            this.lblwaktu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblwaktu.ForeColor = System.Drawing.Color.Black;
            this.lblwaktu.Location = new System.Drawing.Point(330, 119);
            this.lblwaktu.Name = "lblwaktu";
            this.lblwaktu.Size = new System.Drawing.Size(48, 15);
            this.lblwaktu.TabIndex = 1;
            this.lblwaktu.Text = "Tanggal";
            // 
            // lblpesan
            // 
            this.lblpesan.AutoSize = true;
            this.lblpesan.ForeColor = System.Drawing.Color.Black;
            this.lblpesan.Location = new System.Drawing.Point(3, 19);
            this.lblpesan.Name = "lblpesan";
            this.lblpesan.Size = new System.Drawing.Size(52, 15);
            this.lblpesan.TabIndex = 0;
            this.lblpesan.Text = "Isi Pesan";
            // 
            // ChatDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 161);
            this.Controls.Add(this.gpuser);
            this.Name = "ChatDialog";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gpuser.ResumeLayout(false);
            this.gpuser.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox gpuser;
        private Label lblpesan;
        private Label lblwaktu;
    }
}