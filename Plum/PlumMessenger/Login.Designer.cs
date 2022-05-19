
namespace PlumMessenger
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.loginElement = new PlumMessenger.Controls.LoginElement();
            this.registrationElement = new PlumMessenger.Controls.RegistrationElement();
            this.SuspendLayout();
            // 
            // loginElement
            // 
            this.loginElement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.loginElement.Location = new System.Drawing.Point(12, 12);
            this.loginElement.Name = "loginElement";
            this.loginElement.Size = new System.Drawing.Size(187, 207);
            this.loginElement.TabIndex = 0;
            // 
            // registrationElement
            // 
            this.registrationElement.Location = new System.Drawing.Point(12, 12);
            this.registrationElement.Name = "registrationElement";
            this.registrationElement.Size = new System.Drawing.Size(182, 207);
            this.registrationElement.TabIndex = 1;
            this.registrationElement.Visible = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(207, 220);
            this.Controls.Add(this.registrationElement);
            this.Controls.Add(this.loginElement);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Вход";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.LoginElement loginElement;
        private Controls.RegistrationElement registrationElement;
    }
}