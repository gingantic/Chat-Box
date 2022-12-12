using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Chat_Box.HttpHelper;

namespace Chat_Box
{
    public partial class Daftar : Form
    {
        public Daftar()
        {
            InitializeComponent();
        }

        private async void btndaftar_Click(object sender, EventArgs e)
        {
            HttpHelper client = new();
            PassQuery passQuery = new();
            if (txtuser.Text != "" && txtpass.Text != "" && txtpass2.Text != "")
            {
                if (txtpass.Text == txtpass2.Text)
                {
                    passQuery.query = "select * from users where username='" + txtuser.Text + "'";
                    try
                    {
                        var chkdata = await client.PostData(passQuery);
                        var toJson = JObject.Parse(chkdata);
                        if (toJson["result"].Count() == 0)
                        {
                            passQuery.query = "insert into users values('"+ txtuser.Text + "','"+ txtpass.Text + "')";
                            var inputdata = await client.PostData(passQuery);
                            if (inputdata.Contains("Erorr"))
                            {
                                MessageBox.Show("Error " + inputdata);
                            }
                            else
                            {
                                MessageBox.Show("User sudah Teregister");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Username sudah di pakai");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error " + ex);
                    }
                }
                else
                {
                    MessageBox.Show("Password Tidak Sama !!!");
                }
            }
            else
            {
                MessageBox.Show("Isi Semua !!!");
            }
        }

        private void Daftar_Load(object sender, EventArgs e)
        {

        }
    }
}
