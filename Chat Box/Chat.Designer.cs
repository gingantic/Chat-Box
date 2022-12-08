namespace Chat_Box
{
    partial class Chat
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
            this.flppesan = new System.Windows.Forms.FlowLayoutPanel();
            this.btnkirim = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbluser = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblchatid = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtpesan = new System.Windows.Forms.TextBox();
            this.btnmasuk = new System.Windows.Forms.Button();
            this.txtchatid = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flppesan
            // 
            this.flppesan.AutoScroll = true;
            this.flppesan.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flppesan.Location = new System.Drawing.Point(6, 51);
            this.flppesan.Name = "flppesan";
            this.flppesan.Size = new System.Drawing.Size(417, 294);
            this.flppesan.TabIndex = 0;
            this.flppesan.WrapContents = false;
            // 
            // btnkirim
            // 
            this.btnkirim.Location = new System.Drawing.Point(305, 351);
            this.btnkirim.Name = "btnkirim";
            this.btnkirim.Size = new System.Drawing.Size(75, 23);
            this.btnkirim.TabIndex = 1;
            this.btnkirim.Text = "Kirim";
            this.btnkirim.UseVisualStyleBackColor = true;
            this.btnkirim.Click += new System.EventHandler(this.btnkirim_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Login Sebagai : ";
            // 
            // lbluser
            // 
            this.lbluser.AutoSize = true;
            this.lbluser.Location = new System.Drawing.Point(95, 9);
            this.lbluser.Name = "lbluser";
            this.lbluser.Size = new System.Drawing.Size(60, 15);
            this.lbluser.TabIndex = 3;
            this.lbluser.Text = "Username";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblchatid);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtpesan);
            this.groupBox1.Controls.Add(this.btnmasuk);
            this.groupBox1.Controls.Add(this.txtchatid);
            this.groupBox1.Controls.Add(this.btnkirim);
            this.groupBox1.Controls.Add(this.flppesan);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 396);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chat Box";
            // 
            // lblchatid
            // 
            this.lblchatid.AutoSize = true;
            this.lblchatid.Location = new System.Drawing.Point(319, 26);
            this.lblchatid.Name = "lblchatid";
            this.lblchatid.Size = new System.Drawing.Size(77, 15);
            this.lblchatid.TabIndex = 4;
            this.lblchatid.Text = "Chat ID Place";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(271, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Chat ID :";
            // 
            // txtpesan
            // 
            this.txtpesan.Location = new System.Drawing.Point(6, 351);
            this.txtpesan.MaxLength = 255;
            this.txtpesan.Name = "txtpesan";
            this.txtpesan.Size = new System.Drawing.Size(293, 23);
            this.txtpesan.TabIndex = 2;
            this.txtpesan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpesan_KeyDown);
            // 
            // btnmasuk
            // 
            this.btnmasuk.Location = new System.Drawing.Point(175, 22);
            this.btnmasuk.Name = "btnmasuk";
            this.btnmasuk.Size = new System.Drawing.Size(75, 23);
            this.btnmasuk.TabIndex = 1;
            this.btnmasuk.Text = "Masuk";
            this.btnmasuk.UseVisualStyleBackColor = true;
            this.btnmasuk.Click += new System.EventHandler(this.btnmasuk_Click);
            // 
            // txtchatid
            // 
            this.txtchatid.Location = new System.Drawing.Point(6, 22);
            this.txtchatid.MaxLength = 25;
            this.txtchatid.Name = "txtchatid";
            this.txtchatid.Size = new System.Drawing.Size(163, 23);
            this.txtchatid.TabIndex = 0;
            this.txtchatid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtchatid_KeyDown);
            // 
            // Chat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbluser);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Chat";
            this.Text = "Chat";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FlowLayoutPanel flppesan;
        private Button btnkirim;
        private Label label1;
        private Label lbluser;
        private GroupBox groupBox1;
        private TextBox txtpesan;
        private Button btnmasuk;
        private TextBox txtchatid;
        private Label lblchatid;
        private Label label2;
    }
}