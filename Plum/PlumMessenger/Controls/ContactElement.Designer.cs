
namespace PlumMessenger
{
    partial class ContactElement
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.usernameLabel = new System.Windows.Forms.Label();
            this.newMessagesCountLabel = new System.Windows.Forms.Label();
            this.dataPanel = new System.Windows.Forms.Panel();
            this.loginLabel = new System.Windows.Forms.Label();
            this.dataPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // usernameLabel
            // 
            this.usernameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.usernameLabel.Location = new System.Drawing.Point(0, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(161, 34);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "username";
            this.usernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // newMessagesCountLabel
            // 
            this.newMessagesCountLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.newMessagesCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newMessagesCountLabel.Location = new System.Drawing.Point(161, 0);
            this.newMessagesCountLabel.Name = "newMessagesCountLabel";
            this.newMessagesCountLabel.Size = new System.Drawing.Size(42, 56);
            this.newMessagesCountLabel.TabIndex = 1;
            this.newMessagesCountLabel.Text = "0";
            this.newMessagesCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataPanel
            // 
            this.dataPanel.Controls.Add(this.loginLabel);
            this.dataPanel.Controls.Add(this.usernameLabel);
            this.dataPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataPanel.Location = new System.Drawing.Point(0, 0);
            this.dataPanel.Name = "dataPanel";
            this.dataPanel.Size = new System.Drawing.Size(161, 56);
            this.dataPanel.TabIndex = 2;
            // 
            // loginLabel
            // 
            this.loginLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.loginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.loginLabel.Location = new System.Drawing.Point(0, 34);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(161, 22);
            this.loginLabel.TabIndex = 1;
            this.loginLabel.Text = "@login";
            this.loginLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ContactElement
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Thistle;
            this.Controls.Add(this.dataPanel);
            this.Controls.Add(this.newMessagesCountLabel);
            this.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.Name = "ContactElement";
            this.Size = new System.Drawing.Size(203, 56);
            this.dataPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label newMessagesCountLabel;
        private System.Windows.Forms.Panel dataPanel;
        private System.Windows.Forms.Label loginLabel;
    }
}
