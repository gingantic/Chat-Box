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
    public partial class ChatDialog : Form
    {
        public ChatDialog()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void gpuser_Enter(object sender, EventArgs e)
        {

        }

        private async void lblhapus_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Apakah Ingin Menghapus Pesan ?", "Yakin Dek ?", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                HttpHelper client = new();
                PassQuery passQuery = new();

                passQuery.query = "DELETE FROM chat_log WHERE id_pesan = '"+ gpuser.Name +"'";
                await client.PostData(passQuery);
            }
        }
    }
}
