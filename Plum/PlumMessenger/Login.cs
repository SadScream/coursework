using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;
using PlumMessenger.Connection.Requests;

namespace PlumMessenger
{
    public partial class Login : Form
    {
        Auth authApi;

        public Login()
        {
            InitializeComponent();
            authApi = new Auth();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Auth.LoggedIn)
            {
                Application.Exit();
            }
        }

        private async void login_Click(object sender, EventArgs e)
        {
            try
            {
                await authApi.SignInMethod(loginElement.GetLogin(), loginElement.GetPassword());

                Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void registration_Click(object sender, EventArgs e)
        {
            try
            {
                await authApi.SignUpMethod(registrationElement.GetLogin(), registrationElement.GetPassword());
                MessageBox.Show("Вы зарегистрировались!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}

        private void Login_Load(object sender, EventArgs e)
        {
            loginElement.RegistrationClicked += GoToRegistration;
            registrationElement.LoginClicked += GoToLogin;

            loginElement.LoginClicked += login_Click;
            registrationElement.RegistrationClicked += registration_Click;
        }

        private void GoToRegistration(object sender, EventArgs e)
        {
            loginElement.Visible = false;
            registrationElement.Visible = true;
        }

        private void GoToLogin(object sender, EventArgs e)
        {
            loginElement.Visible = true;
            registrationElement.Visible = false;
        }
    }
}
