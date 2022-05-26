using System;
using System.Windows.Forms;

namespace PlumMessenger.Controls
{
    public partial class RegistrationElement : UserControl
    {
        public event EventHandler RegistrationClicked;
        public event EventHandler LoginClicked;

        public RegistrationElement()
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

        private void registrationBtn_Click(object sender, EventArgs e)
        {
            RegistrationClicked.Invoke(this, EventArgs.Empty);
        }

        private void goToLoginBtn_Click(object sender, EventArgs e)
        {
            LoginClicked.Invoke(this, EventArgs.Empty);
        }
    }
}