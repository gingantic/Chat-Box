namespace Chat_Box
{
    partial class Daftar
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
            this.btndaftar = new System.Windows.Forms.Button();
            this.txtpass2 = new System.Windows.Forms.TextBox();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btndaftar
            // 
            this.btndaftar.Location = new System.Drawing.Point(80, 131);
            this.btndaftar.Name = "btndaftar";
            this.btndaftar.Size = new System.Drawing.Size(75, 23);
            this.btndaftar.TabIndex = 13;
            this.btndaftar.Text = "Daftar";
            this.btndaftar.UseVisualStyleBackColor = true;
            this.btndaftar.Click += new System.EventHandler(this.btndaftar_Click);
            // 
            // txtpass2
            // 
            this.txtpass2.Location = new System.Drawing.Point(119, 81);
            this.txtpass2.Name = "txtpass2";
            this.txtpass2.Size = new System.Drawing.Size(100, 23);
            this.txtpass2.TabIndex = 12;
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(119, 47);
            this.txtpass.Name = "txtpass";
            this.txtpass.Size = new System.Drawing.Size(100, 23);
            this.txtpass.TabIndex = 11;
            // 
            // txtuser
            // 
            this.txtuser.Location = new System.Drawing.Point(119, 14);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(100, 23);
            this.txtuser.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Ulangi Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Username";
            // 
            // Daftar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 168);
            this.Controls.Add(this.btndaftar);
            this.Controls.Add(this.txtpass2);
            this.Controls.Add(this.txtpass);
            this.Controls.Add(this.txtuser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Daftar";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Daftar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btndaftar;
        private TextBox txtpass2;
        private TextBox txtpass;
        private TextBox txtuser;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}