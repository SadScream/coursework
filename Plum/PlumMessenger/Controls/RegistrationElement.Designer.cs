
namespace PlumMessenger.Controls
{
    partial class RegistrationElement
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
            this.registrationBtn = new System.Windows.Forms.Button();
            this.goToLoginBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label.Location = new System.Drawing.Point(24, 9);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(128, 25);
            this.label.TabIndex = 8;
            this.label.Text = "Регистрация";
            // 
            // login_label
            // 
            this.login_label.AutoSize = true;
            this.login_label.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.login_label.Location = new System.Drawing.Point(3, 0);
            this.login_label.Name = "login_label";
            this.login_label.Size = new System.Drawing.Size(41, 15);
            this.login_label.TabIndex = 6;
            this.login_label.Text = "Логин";
            // 
            // loginText
            // 
            this.loginText.Location = new System.Drawing.Point(0, 16);
            this.loginText.Name = "loginText";
            this.loginText.Size = new System.Drawing.Size(176, 20);
            this.loginText.TabIndex = 3;
            // 
            // passwordText
            // 
            this.passwordText.Location = new System.Drawing.Point(0, 55);
            this.passwordText.Name = "passwordText";
            this.passwordText.Size = new System.Drawing.Size(176, 20);
            this.passwordText.TabIndex = 5;
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Location = new System.Drawing.Point(0, 39);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(45, 13);
            this.password_label.TabIndex = 4;
            this.password_label.Text = "Пароль";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.registrationBtn);
            this.panel1.Controls.Add(this.login_label);
            this.panel1.Controls.Add(this.loginText);
            this.panel1.Controls.Add(this.passwordText);
            this.panel1.Controls.Add(this.password_label);
            this.panel1.Location = new System.Drawing.Point(3, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(176, 134);
            this.panel1.TabIndex = 9;
            // 
            // registrationBtn
            // 
            this.registrationBtn.Location = new System.Drawing.Point(26, 112);
            this.registrationBtn.Name = "registrationBtn";
            this.registrationBtn.Size = new System.Drawing.Size(123, 22);
            this.registrationBtn.TabIndex = 7;
            this.registrationBtn.Text = "Зарегистрироваться";
            this.registrationBtn.UseVisualStyleBackColor = true;
            this.registrationBtn.Click += new System.EventHandler(this.registrationBtn_Click);
            // 
            // goToLoginBtn
            // 
            this.goToLoginBtn.Location = new System.Drawing.Point(60, 177);
            this.goToLoginBtn.Name = "goToLoginBtn";
            this.goToLoginBtn.Size = new System.Drawing.Size(64, 23);
            this.goToLoginBtn.TabIndex = 8;
            this.goToLoginBtn.Text = "Назад";
            this.goToLoginBtn.UseVisualStyleBackColor = true;
            this.goToLoginBtn.Click += new System.EventHandler(this.goToLoginBtn_Click);
            // 
            // RegistrationElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.goToLoginBtn);
            this.Controls.Add(this.label);
            this.Controls.Add(this.panel1);
            this.Name = "RegistrationElement";
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
        private System.Windows.Forms.Button registrationBtn;
        private System.Windows.Forms.Button goToLoginBtn;
    }
}
