using Newtonsoft.Json.Linq;
using static Chat_Box.HttpHelper;

namespace Chat_Box
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void btnlogin_Click(object sender, EventArgs e)
        {
            btnlogin.Enabled = false;
            btnlogin.Text = "Loading..!!!";
            HttpHelper httpHelp = new();
            PassQuery passQuery = new()
            {
                query = "SELECT * from users WHERE username = '" + txtuser.Text + "' AND password = '" + txtpass.Text + "'"
            };

            var getData = await httpHelp.PostData(passQuery);

            if (!getData.Contains("Error") && txtuser.Text != "" && txtpass.Text != "")
            {
                var toJson = JObject.Parse(getData);
                if (toJson["result"].Count() != 0)
                {
                    string username = toJson["result"][0]["username"].ToString();
                    string password = toJson["result"][0]["password"].ToString();

                    if (username == txtuser.Text && password == txtpass.Text)
                    {
                        Chat chatform = new(username);
                        this.Hide();
                        chatform.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("username atau password salah");
                    }
                }
                else
                {
                    MessageBox.Show("username tidak ada, Yah kasihan");
                }
            }
            else
            {
                MessageBox.Show(getData);
            }
            btnlogin.Enabled = true;
            btnlogin.Text = "Login";
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void txtuser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnlogin_Click(sender, e);
            }
        }

        private void txtpass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnlogin_Click(sender, e);
            }
        }
    }
}