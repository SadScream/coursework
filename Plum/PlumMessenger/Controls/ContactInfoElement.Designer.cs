
namespace PlumMessenger.Controls
{
    partial class ContactInfoElement
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
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.phoneNumberPanel = new System.Windows.Forms.Panel();
            this.phoneNumberLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.loginLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel9.SuspendLayout();
            this.phoneNumberPanel.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(264, 25);
            this.label4.TabIndex = 14;
            this.label4.Text = "Информация о пользователе";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(264, 25);
            this.panel5.TabIndex = 3;
            // 
            // statusLabel
            // 
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.statusLabel.Location = new System.Drawing.Point(0, 24);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(261, 65);
            this.statusLabel.TabIndex = 10;
            this.statusLabel.Text = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
    "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(136)))), ((int)(((byte)(193)))));
            this.closeBtn.FlatAppearance.BorderSize = 0;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.closeBtn.Location = new System.Drawing.Point(83, 0);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(100, 25);
            this.closeBtn.TabIndex = 0;
            this.closeBtn.Text = "Закрыть";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.closeBtn);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 191);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(264, 25);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(10, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(264, 217);
            this.panel4.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel9);
            this.panel2.Controls.Add(this.phoneNumberPanel);
            this.panel2.Controls.Add(this.panel7);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(264, 166);
            this.panel2.TabIndex = 1;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.statusLabel);
            this.panel9.Controls.Add(this.label5);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 75);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(264, 90);
            this.panel9.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Статус";
            // 
            // phoneNumberPanel
            // 
            this.phoneNumberPanel.Controls.Add(this.phoneNumberLabel);
            this.phoneNumberPanel.Controls.Add(this.label3);
            this.phoneNumberPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.phoneNumberPanel.Location = new System.Drawing.Point(0, 50);
            this.phoneNumberPanel.Name = "phoneNumberPanel";
            this.phoneNumberPanel.Size = new System.Drawing.Size(264, 25);
            this.phoneNumberPanel.TabIndex = 13;
            // 
            // phoneNumberLabel
            // 
            this.phoneNumberLabel.AutoSize = true;
            this.phoneNumberLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.phoneNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.phoneNumberLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.phoneNumberLabel.Location = new System.Drawing.Point(145, 0);
            this.phoneNumberLabel.Name = "phoneNumberLabel";
            this.phoneNumberLabel.Size = new System.Drawing.Size(119, 15);
            this.phoneNumberLabel.TabIndex = 5;
            this.phoneNumberLabel.Text = "aaaaaaaaaaaaaaaa";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Номер телефона";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.userNameLabel);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 25);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(264, 25);
            this.panel7.TabIndex = 12;
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.userNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userNameLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.userNameLabel.Location = new System.Drawing.Point(145, 0);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(119, 15);
            this.userNameLabel.TabIndex = 2;
            this.userNameLabel.Text = "aaaaaaaaaaaaaaaa";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "Имя пользователя";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.loginLabel);
            this.panel6.Controls.Add(this.label1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(264, 25);
            this.panel6.TabIndex = 11;
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.loginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.loginLabel.Location = new System.Drawing.Point(145, 0);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(119, 15);
            this.loginLabel.TabIndex = 3;
            this.loginLabel.Text = "aaaaaaaaaaaaaaaa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Логин";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Location = new System.Drawing.Point(12, 16);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(284, 237);
            this.panel1.TabIndex = 1;
            // 
            // ContactInfoElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.Controls.Add(this.panel1);
            this.Name = "ContactInfoElement";
            this.Size = new System.Drawing.Size(309, 268);
            this.Load += new System.EventHandler(this.ContactInfoElement_Load);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.phoneNumberPanel.ResumeLayout(false);
            this.phoneNumberPanel.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel phoneNumberPanel;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label phoneNumberLabel;
        private System.Windows.Forms.Label loginLabel;
    }
}
