using PlumMessenger.Models;
using PlumMessenger.Connection.Requests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;
using PlumMessenger.Connection;
using PlumMesseger;
using PlumMessenger.Controls;

namespace PlumMessenger
{
    public partial class MainF : Form
    {
        ContactElement lastContactElement;
        Contact currentContact;
        public static ContactsRequest contacts;

        Puller puller;

        // когда мы отправили сообщение или добавили в контакты пользователя из поиска
        // нам нужно ждать, когда сервер обработает запрос и добавит его в контакты, чтобы затем
        // во-первых, убрать контакт с ним из панели поиска(послать запрос поиска еще раз),
        // а во-вторых как только к нам придет новый список контактов, где он уже есть, активировать диалог с ним
        int WaitingUserId = -1;

        public MainF()
        {
            InitializeComponent();
        }

        private void MainF_Load(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();

            SetEditButtonHoveredListeners();
            SetMinInfoHeaderClickedListeners();

            searchPanelWrapper.Visible = false;
            chatWrapper.Visible = false;

            puller = new Puller();
            puller.AddContact += AddContact;
            puller.DeleteContact += DeleteContact;
            puller.DeleteContact += searchTextBox_TextChanged; // обновляем панель поиска при удалении контакта

            UserRequest.CurrentUser.EditEvent += CurrentUserEdited;
            UpdateCurrentUserInfoLabels();

            puller.StartPulling();
        }

        private void MainF_Shown(object sender, EventArgs e)
        {
            this.label1.Focus();
        }

        private void SetEditButtonHoveredListeners()
        {
            foreach (Control c in GetNestedControls<Control>(editUserInfoPanel))
            {
                c.MouseEnter += editUserInfoPanel_MouseEnter;
                c.MouseLeave += editUserInfoPanel_MouseLeave;
            }
        }

        private void SetMinInfoHeaderClickedListeners()
        {
            foreach (Control c in GetNestedControls<Control>(contactMinInfoPanel))
            {
                c.Click += contactMinInfoPanel_Click;
            }
        }

        private void CurrentUserEdited(object sender, EventArgs e)
        {
            UpdateCurrentUserInfoLabels();
        }

        private void UpdateCurrentUserInfoLabels()
        {
            userNameLabel.Text = UserRequest.CurrentUser.Username;
            userLoginLabel.Text = "@"+UserRequest.CurrentUser.Login;
        }

        private void DeleteContact(object sender, EventArgs e)
        {
            NotifyCollectionChangedEventArgs args = (NotifyCollectionChangedEventArgs)e;

            this.Invoke(new MethodInvoker(() => {
                contactsPanel.Controls
                    .Remove(contactsPanel.Controls
                                .Cast<ContactElement>()
                                .First(x => x.contact == (Contact)sender));

                if (currentContact == (Contact)sender)
                {
                    chatWrapper.Visible = false;
                    lastContactElement.Selected = false;
                    currentContact = null;
                    lastContactElement = null;
                }
            }));
        }

        private void AddContact(object sender, EventArgs e)
        {
            NotifyCollectionChangedEventArgs args = (NotifyCollectionChangedEventArgs)e;

            this.Invoke(new MethodInvoker(() => {
                if (args.Action == NotifyCollectionChangedAction.Add)
                {
                    Contact contact = (Contact)sender;

                    ContactElement element = new ContactElement(contact);
                    element.Dock = DockStyle.Top;

                    contactsPanel.RowCount = contactsPanel.RowCount + 1;
                    contactsPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    contactsPanel.Controls.Add(element);

                    element.Clicked += ContactClicked;
                    element.RightClicked += element.OpenContextMenuDefault;
                    element.ContextMenuAction = (x =>
                    {
                        Console.WriteLine($"{lastContactElement} {element}");

                        return Puller.contactRequest.DeleteContact(x);
                    });

                    if (contact.Id == WaitingUserId)
                    {
                        ContactClicked(element, EventArgs.Empty); // костыль
                        searchTextBox_TextChanged(null, EventArgs.Empty); // костыль
                        WaitingUserId = -1;
                    }
                }
            }));
        }

        private void ContactClicked(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(() => {
                ContactElement clickedContactElement = (ContactElement)sender;
                Contact contact = clickedContactElement.contact;

                if (currentContact == null)
                    SetChatVisibility(true);

                if (lastContactElement != null)
                {
                    // если был выбран тот же чат, то выходим из функции
                    if (lastContactElement == clickedContactElement)
                        return;

                    // снимаем выбор с предыдущего контакта
                    lastContactElement.Selected = false;
                }

                lastContactElement = clickedContactElement;
                clickedContactElement.Selected = true; // делаем текущий контакт выбранным

                // временно останавливаем "прослушку" сообщений, пока не подготовим чат панель
                Puller.ObservingUserId = -1;

                chatPanel.Controls.Clear();
                chatPanel.RowStyles.Clear();
                chatPanel.ColumnStyles.Clear();

                if (currentContact != null)
                {
                    EditCurrentContactListeners(false);
                }

                currentContact = contact;

                EditCurrentContactListeners(true);
                ChatHeaderToCurrentContact();

                LoadMessages();
                Puller.ObservingUserId = contact.Id;
            }));
        }

        private void EditCurrentContactListeners(bool add)
        {
            if (add)
            {
                currentContact.MessageAddedEvent += AddMessage;
                currentContact.EditEvent += СurrentContactEdited;
            } else
            {
                currentContact.EditEvent -= СurrentContactEdited;
                currentContact.MessageAddedEvent -= AddMessage;
            }
        }

        /// <summary>
        /// Устанавливаем видимость панели чата
        /// </summary>
        /// <param name="state"></param>
        private void SetChatVisibility(bool state)
        {
            chatWrapper.Visible = state;
        }

        /// <summary>
        /// Вызывается при изменении какого-либо свойства поля currentUser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void СurrentContactEdited(object sender, EventArgs e)
        {
            ChatHeaderToCurrentContact();
        }

        private void ChatHeaderToCurrentContact()
        {
            nameLabel.Text = currentContact.Username;
            onlineLabel.Text = currentContact.IsOnline() ? "Online" : "Offline";
        }

        /// <summary>
        /// Загружаем имеющиеся у контакта сообщения
        /// </summary>
        private void LoadMessages()
        {
            foreach (Models.Message message in currentContact.GetMessages())
            {
                AddMessageBubble(message);
            }
        }

        private void AddMessage(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(() => {
                NotifyCollectionChangedEventArgs messageEvent = (NotifyCollectionChangedEventArgs)e;

                foreach (Models.Message message in messageEvent.NewItems)
                {
                    AddMessageBubble(message);
                }
            }));
        }

        private void AddMessageBubble(Models.Message message)
        {
            UserControl bubble;
            string dateFormat = "{0:HH:mm}";

            // если с момента отправки прошло больше одного дня, то вместе с временем отправки
            // показываем число и месяц отправки
            if ((DateTime.UtcNow - message.Date).TotalDays >= 1.0)
            {
                dateFormat = "{0:dd.MM HH:mm}";
            }

            if (message.OwnerId == UserRequest.CurrentUserId)
            {
                bubble = new MeBubble();
                ((MeBubble)bubble).Body = message.Text;
                ((MeBubble)bubble).Time = String.Format(dateFormat, message.Date);
            }
            else
            {
                bubble = new YouBubble();
                ((YouBubble)bubble).Body = message.Text;
                ((YouBubble)bubble).Time = String.Format(dateFormat, message.Date);
            }

            bubble.AutoSize = false;
            bubble.Dock = DockStyle.Fill;
            bubble.TabIndex = 0;

            chatPanel.RowCount = chatPanel.RowCount + 1;
            chatPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            chatPanel.Controls.Add(bubble);
        }

        private void MainF_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (puller != null)
                puller.Looping = false;
        }

        private async void sendBtn_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(messageTextBox.Text))
            {
                if (!Puller.AvailableContacts.Contains(currentContact))
                {
                    WaitingUserId = currentContact.Id;
                }

                try
                {
                    var res = await Puller.messagesRequest
                        .SendMessage(currentContact.Id, messageTextBox.Text.Trim(' '));

                    if (res)
                        messageTextBox.Clear();
                    else
                        MessageBox.Show("Не доставлено", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void chatPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            chatPanelWrapperL2.ScrollControlIntoView(e.Control);
        }

        private void editUserInfo_Click(object sender, EventArgs e)
        {
            UserEditElement userEditElement = new UserEditElement();
            userEditElement.CloseClickedEvent += PopUpControlCloseClicked;
            this.Controls.Add(userEditElement);
            userEditElement.Dock = DockStyle.Fill;
            userEditElement.BringToFront();
            leftPanelWrapper.Enabled = false;
        }

        private void PopUpControlCloseClicked(object sender, EventArgs e)
        {
            this.Controls.Remove((Control)sender);
            ((Control)sender).Dispose();
            leftPanelWrapper.Enabled = true;
        }

        private void editUserInfoPanel_MouseEnter(object sender, EventArgs e)
        {
            editUserInfoPanel.BackColor = Color.FromArgb(32, 43, 54);
        }

        private void editUserInfoPanel_MouseLeave(object sender, EventArgs e)
        {
            editUserInfoPanel.BackColor = Color.FromArgb(23, 33, 43);
        }

        private IEnumerable<ControlType> GetNestedControls<ControlType>(Control control)
        {
            if (control.Controls == null || control.Controls.Count == 0)
                return Enumerable.Empty<ControlType>();

            return control.Controls
                .OfType<ControlType>()
                .Concat(control.Controls
                    .Cast<Control>()
                    .SelectMany(x => GetNestedControls<ControlType>(x)));
        }

        private void contactMinInfoPanel_Click(object sender, EventArgs e)
        {
            if (currentContact == null)
                return;

            ContactInfoElement contactInfo = new ContactInfoElement(currentContact);
            contactInfo.CloseClickedEvent += PopUpControlCloseClicked;
            this.Controls.Add(contactInfo);
            contactInfo.Dock = DockStyle.Fill;
            contactInfo.BringToFront();
            leftPanelWrapper.Enabled = false;
        }

        private async void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (searchTextBox.Text.Length == 0)
            {
                searchPanelWrapper.Visible = false;
                searchPanel.Controls.Clear();
                searchPanel.RowStyles.Clear();
                searchPanel.ColumnStyles.Clear();
                return;
            } else
            {
                searchPanelWrapper.Visible = true;
                string searchString = searchTextBox.Text;
                List<Contact> searchedUsers = await SearchUsers(searchString);
                searchPanel.Controls.Clear();
                searchPanel.RowStyles.Clear();
                searchPanel.ColumnStyles.Clear();
                FillSearchPanel(searchedUsers);
            }
        }

        private void FillSearchPanel(List<Contact> searchedUsers)
        {
            foreach (Contact contact in searchedUsers)
            {
                this.Invoke(new MethodInvoker(() => {
                    ContactElement element = new ContactElement(contact);
                    element.Dock = DockStyle.Top;

                    searchPanel.RowCount = searchPanel.RowCount + 1;
                    searchPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    searchPanel.Controls.Add(element);

                    element.Clicked += ContactClicked;
                    element.RightClicked += element.OpenContextMenuFromSearch;
                    element.ContextMenuAction = ((x) =>
                    {
                        WaitingUserId = contact.Id;
                        return Puller.contactRequest.AddContact(x);
                    });
                }));
            }
        }

        private async Task<List<Contact>> SearchUsers(string searchString)
        {
            return await Puller.userRequest.SearchUsers(searchString);
        }
    }
}
