using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
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
        private async Task LoopUpdateChatLog(CancellationTokenSource stopToken)
        {
            try
            {
                while (!stopToken.IsCancellationRequested)
                {
                    await UpdateChatLog(currentChatid,true);
                    await Task.Delay(750);
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
            sqlquery.query = "SELECT * FROM chat_log WHERE id_chat=\"" + id_chat + "\"";
            var updatechat = await client.PostData(sqlquery);
            if (!updatechat.Contains("Error"))
            {
                var toJson = JObject.Parse(updatechat);
                if (toJson["result"].Any())
                {
                    if (!loop)
                        flppesan.Controls.Clear();
                    foreach (var putChat in toJson["result"])
                    {
                        string formatText = putChat["username"].ToString() + " : " + putChat["pesan"].ToString();
                        string lblid = putChat["id_pesan"].ToString();
                        Control[] chk = flppesan.Controls.Find(lblid, true);
                        if (chk.Length == 0)
                            flppesan.Controls.Add(new Label() { Name = lblid, Text = formatText, Size = new Size(flppesan.Width - 30, 20) });
                    }
                }
            }
            else
            {
                MessageBox.Show("Error " + updatechat);
            }
        }

        private void Chat_Load(object sender, EventArgs e)
        {

        }

        private void lbluser_Click(object sender, EventArgs e)
        {

        }

        private async void btnmasuk_Click(object sender, EventArgs e)
        {
            PassQuery sqlquery = new();
            stopToken.Cancel();
            stopToken = new();
            if (txtchatid.Text != "")
            {
                sqlquery.query = "SELECT * FROM chat_log WHERE id_chat=\"" + txtchatid.Text + "\"";
                var checkchatid = await client.PostData(sqlquery);
                if (!checkchatid.Contains("Error"))
                {
                    flppesan.Controls.Clear();
                    var toJson = JObject.Parse(checkchatid);
                    if (toJson["result"].Count() != 0)
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
                else
                {
                    MessageBox.Show("Error " + checkchatid);
                }
                await LoopUpdateChatLog(stopToken);
            }
        }

        private async void btnkirim_Click(object sender, EventArgs e)
        {
            PassQuery sqlquery = new();
            if (currentChatid == null)
            {
                MessageBox.Show("Masuk dulu ke Chat Room");
            }
            else
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
    }
}
