using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static Chat_Box.HttpHelper;

namespace Chat_Box
{
    public partial class Chat : Form
    {
        CancellationTokenSource stopToken = new();
        HttpHelper client = new();
        private string username;

        private string? _currentChatid;
        public string? currentChatid
        {
            get { 
                return _currentChatid; }
            set { 
                _currentChatid = value; 
                lblchatid.Text = value;
            }
        }

        public Chat(string username)
        {
            InitializeComponent();
            lbluser.Text = username;
            this.username = username;
        }

        private Control DialogChat(string id, string username, string pesan, string waktu)
        {
            ChatDialog form = new();
            var gpuser = form.Controls.Find("gpuser", true)[0];
            var lblpesan = form.Controls.Find("lblpesan", true)[0];
            var lblwaktu = form.Controls.Find("lblwaktu", true)[0];

            if (this.username == username)
            {
                username = "Anda";
                gpuser.ForeColor = Color.Green;
            }

            DateTime date = DateTime.Parse(waktu);

            if (date.Date == DateTime.Today)
                waktu = date.TimeOfDay.ToString();

            gpuser.Name = id;
            gpuser.Text = username;
            lblpesan.Text = pesan;
            lblwaktu.Text = waktu;

            gpuser.Height = 200;
            gpuser.Width = flppesan.Width - 30;

            lblpesan.MaximumSize = new Size(gpuser.Width - 10, 0);
            gpuser.Height = lblpesan.Height + 43;

            lblwaktu.Location = new Point(gpuser.Right - (lblwaktu.Width + 13), gpuser.Bottom - (lblwaktu.Height + 16));

            return gpuser;
        }

        private async Task LoopUpdateChatLog(CancellationTokenSource stopToken)
        {
            try
            {
                while (!stopToken.IsCancellationRequested)
                {
                    await UpdateChatLog(currentChatid,true);
                    await Task.Delay(1000);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return;
            }
        }
        private async Task UpdateChatLog(string id_chat, bool loop = false)
        {
            PassQuery sqlquery = new();
            sqlquery.query = "SELECT * FROM chat_log WHERE id_chat='" + id_chat + "'";
            var updatechat = await client.PostData(sqlquery);
            try
            {
                var toJson = JObject.Parse(updatechat);
                if (toJson["result"].Any())
                {
                    if (!loop)
                        flppesan.Controls.Clear();
                    foreach (var putChat in toJson["result"])
                    {
                        string username = putChat["username"].ToString();
                        string pesan = putChat["pesan"].ToString();
                        string id = putChat["id_pesan"].ToString();
                        string waktu = putChat["waktu"].ToString();
                        Control[] chk = flppesan.Controls.Find(id, true);
                        if (chk.Length == 0)
                            flppesan.Controls.Add(DialogChat(id,username,pesan,waktu));
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Error " + updatechat);
            }
        }
        private async void btnmasuk_Click(object sender, EventArgs e)
        {
            PassQuery sqlquery = new();
            stopToken.Cancel();
            stopToken = new();
            if (txtchatid.Text != "")
            {
                sqlquery.query = "SELECT * FROM chat_log WHERE id_chat='" + txtchatid.Text + "'";
                var checkchatid = await client.PostData(sqlquery);
                try
                {
                    btnmasuk.Enabled = false;
                    btnmasuk.Text = "Loading";
                    flppesan.Controls.Clear();
                    var toJson = JObject.Parse(checkchatid);
                    if (toJson["result"].Any())
                    {
                        await UpdateChatLog(txtchatid.Text);
                    }
                    else
                    {
                        var result = MessageBox.Show("ID Chat Tidak Di temukan, Ingin Membuat baru ?", "hehe", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            sqlquery.query = "INSERT INTO chat_log (id_chat, username, pesan, waktu)\r\nVALUES ('" + txtchatid.Text + "','" + username+"', '"+username+" Telah Memulai Percakapan', NOW());";
                            var inputnewchatid = await client.PostData(sqlquery);
                            if (inputnewchatid.Contains("Error"))
                            {
                                MessageBox.Show("Error " + inputnewchatid);
                                return;
                            }
                            else
                            {
                                await UpdateChatLog(txtchatid.Text);
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    currentChatid = txtchatid.Text;
                }
                catch (Exception)
                {
                    MessageBox.Show("Error " + checkchatid);
                }
                btnmasuk.Enabled = true;
                btnmasuk.Text = "Masuk";
                await LoopUpdateChatLog(stopToken);
            }
            else
            {
                MessageBox.Show("Masukan Chat ID !");
            }
        }

        private async void btnkirim_Click(object sender, EventArgs e)
        {
            PassQuery sqlquery = new();
            if (currentChatid == null)
            {
                MessageBox.Show("Masuk dulu ke Chat Room");
            }
            else if(txtpesan.Text != "")
            {
                sqlquery.query = "INSERT INTO chat_log (id_chat, username, pesan, waktu)\r\nVALUES ('" + currentChatid + "','" + username + "', '" + txtpesan.Text + "', NOW());";
                var inputnewchatid = await client.PostData(sqlquery);
                if (inputnewchatid.Contains("Error"))
                {
                    MessageBox.Show("Error " + inputnewchatid);
                    return;
                }
                else
                {
                    await UpdateChatLog(txtchatid.Text,true);
                }
            }
            flppesan.VerticalScroll.Value = flppesan.VerticalScroll.Maximum;
            txtpesan.Clear();
        }
        private void txtchatid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnmasuk_Click(sender, e);
        }

        private void txtpesan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnkirim_Click(sender, e);
        }
    }
}
