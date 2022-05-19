
namespace PlumMessenger.Controls
{
    partial class LoginElement
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
            this.label = new System.Windows.Forms.Label();
            this.login_label = new System.Windows.Forms.Label();
            this.loginText = new System.Windows.Forms.TextBox();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.password_label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.loginBtn = new System.Windows.Forms.Button();
            this.goToRegistration = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label.ForeColor = System.Drawing.SystemColors.Control;
            this.label.Location = new System.Drawing.Point(51, 9);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(69, 25);
            this.label.TabIndex = 10;
            this.label.Text = "Войти";
            // 
            // login_label
            // 
            this.login_label.AutoSize = true;
            this.login_label.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.login_label.ForeColor = System.Drawing.SystemColors.Control;
            this.login_label.Location = new System.Drawing.Point(3, 0);
            this.login_label.Name = "login_label";
            this.login_label.Size = new System.Drawing.Size(41, 15);
            this.login_label.TabIndex = 6;
            this.login_label.Text = "Логин";
            // 
            // loginText
            // 
            this.loginText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(48)))), ((int)(((byte)(62)))));
            this.loginText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loginText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginText.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.loginText.Location = new System.Drawing.Point(0, 16);
            this.loginText.MaxLength = 16;
            this.loginText.Name = "loginText";
            this.loginText.Size = new System.Drawing.Size(176, 21);
            this.loginText.TabIndex = 3;
            // 
            // passwordText
            // 
            this.passwordText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(48)))), ((int)(((byte)(62)))));
            this.passwordText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passwordText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordText.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.passwordText.Location = new System.Drawing.Point(0, 55);
            this.passwordText.MaxLength = 32;
            this.passwordText.Name = "passwordText";
            this.passwordText.PasswordChar = '*';
            this.passwordText.Size = new System.Drawing.Size(176, 21);
            this.passwordText.TabIndex = 5;
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.ForeColor = System.Drawing.SystemColors.Control;
            this.password_label.Location = new System.Drawing.Point(0, 39);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(45, 13);
            this.password_label.TabIndex = 4;
            this.password_label.Text = "Пароль";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.loginBtn);
            this.panel1.Controls.Add(this.login_label);
            this.panel1.Controls.Add(this.loginText);
            this.panel1.Controls.Add(this.passwordText);
            this.panel1.Controls.Add(this.password_label);
            this.panel1.Location = new System.Drawing.Point(3, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(176, 134);
            this.panel1.TabIndex = 12;
            // 
            // loginBtn
            // 
            this.loginBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(136)))), ((int)(((byte)(193)))));
            this.loginBtn.FlatAppearance.BorderSize = 0;
            this.loginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.loginBtn.Location = new System.Drawing.Point(53, 113);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(64, 22);
            this.loginBtn.TabIndex = 7;
            this.loginBtn.Text = "Войти";
            this.loginBtn.UseVisualStyleBackColor = false;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // goToRegistration
            // 
            this.goToRegistration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(136)))), ((int)(((byte)(193)))));
            this.goToRegistration.FlatAppearance.BorderSize = 0;
            this.goToRegistration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.goToRegistration.ForeColor = System.Drawing.SystemColors.Control;
            this.goToRegistration.Location = new System.Drawing.Point(41, 177);
            this.goToRegistration.Name = "goToRegistration";
            this.goToRegistration.Size = new System.Drawing.Size(95, 23);
            this.goToRegistration.TabIndex = 11;
            this.goToRegistration.Text = "Регистрация";
            this.goToRegistration.UseVisualStyleBackColor = false;
            this.goToRegistration.Click += new System.EventHandler(this.goToRegistration_Click);
            // 
            // LoginElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.Controls.Add(this.label);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.goToRegistration);
            this.Name = "LoginElement";
            this.Size = new System.Drawing.Size(182, 207);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label login_label;
        private System.Windows.Forms.TextBox loginText;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Button goToRegistration;
    }
}
