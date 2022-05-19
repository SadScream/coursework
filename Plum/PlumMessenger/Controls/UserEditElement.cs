using PlumMessenger.Connection.Requests;
using PlumMessenger.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlumMessenger.Controls
{
    public partial class UserEditElement : UserControl
    {
        public event EventHandler SaveClickedEvent;
        public event EventHandler CloseClickedEvent;

        User modifiedUser = new User();

        public UserEditElement()
        {
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            CloseClickedEvent?.Invoke(this, e);
        }

        private async void saveBtn_Click(object sender, EventArgs e)
        {
            SaveClickedEvent?.Invoke(this, e);
            UserRequest ur = new UserRequest();

            try
            {
                SetModifiedUserFields();

                if (await ur.EditUser(modifiedUser))
                {
                    await ur.GetUser();

                    MessageBox.Show("Информация обновлена", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } else
                {
                    MessageBox.Show("Не было внесено изменений", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetModifiedUserFields()
        {
            modifiedUser.Login = loginTextBox.Text;
            modifiedUser.Username = userNameTextBox.Text;

            if (phoneTextBox.MaskCompleted)
                modifiedUser.PhoneNumber = phoneTextBox.Text;

            modifiedUser.PhonePublicy = phoneVisibilityCheckBox.Checked;
            modifiedUser.password = passwordTextBox.Text;
            modifiedUser.Status = statusTextBox.Text;
        }

        private void SetFields()
        {
            loginTextBox.Text = UserRequest.CurrentUser.Login;
            userNameTextBox.Text = UserRequest.CurrentUser.Username;
            phoneTextBox.Text = UserRequest.CurrentUser.PhoneNumber;
            phoneVisibilityCheckBox.Checked = UserRequest.CurrentUser.PhonePublicy;
            passwordTextBox.Text = string.Empty;
            statusTextBox.Text = UserRequest.CurrentUser.Status;
        }

        private void UserEditElement_Load(object sender, EventArgs e)
        {
            User.UpdateFromUser(modifiedUser, UserRequest.CurrentUser);
            UserRequest.CurrentUser.EditEvent += CurrentUserEdited;
            SetFields();
        }

        private void CurrentUserEdited(object sender, EventArgs e)
        {
            SetFields();
        }
    }
}
