using System;
using System.Windows.Forms;

namespace PlumMessenger.Controls
{
    public partial class LoginElement : UserControl
    {
        public event EventHandler LoginClicked;
        public event EventHandler RegistrationClicked;

        public LoginElement()
        {
            InitializeComponent();
        }

        public string GetLogin()
        {
            return loginText.Text;
        }

        public string GetPassword()
        {
            return passwordText.Text;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            LoginClicked.Invoke(this, EventArgs.Empty);
        }

        private void goToRegistration_Click(object sender, EventArgs e)
        {
            RegistrationClicked.Invoke(this, EventArgs.Empty);
        }
    }
}
