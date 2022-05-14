
namespace PlumMessenger
{
    partial class MainF
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.leftPanelWrapper = new System.Windows.Forms.Panel();
            this.contactsPanelWrapper = new System.Windows.Forms.Panel();
            this.contactsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.leftPanelHeader = new System.Windows.Forms.Panel();
            this.contentPanelWrapper = new System.Windows.Forms.Panel();
            this.contactMinInfoPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.sendBtn = new System.Windows.Forms.Button();
            this.sendButtonPanel = new System.Windows.Forms.Panel();
            this.messagePanel = new System.Windows.Forms.Panel();
            this.leftPanelWrapper.SuspendLayout();
            this.contactsPanelWrapper.SuspendLayout();
            this.contentPanelWrapper.SuspendLayout();
            this.panel2.SuspendLayout();
            this.sendButtonPanel.SuspendLayout();
            this.messagePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftPanelWrapper
            // 
            this.leftPanelWrapper.Controls.Add(this.contactsPanelWrapper);
            this.leftPanelWrapper.Controls.Add(this.leftPanelHeader);
            this.leftPanelWrapper.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanelWrapper.Location = new System.Drawing.Point(0, 0);
            this.leftPanelWrapper.Name = "leftPanelWrapper";
            this.leftPanelWrapper.Size = new System.Drawing.Size(279, 514);
            this.leftPanelWrapper.TabIndex = 0;
            // 
            // contactsPanelWrapper
            // 
            this.contactsPanelWrapper.AutoScroll = true;
            this.contactsPanelWrapper.Controls.Add(this.contactsPanel);
            this.contactsPanelWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contactsPanelWrapper.Location = new System.Drawing.Point(0, 45);
            this.contactsPanelWrapper.Name = "contactsPanelWrapper";
            this.contactsPanelWrapper.Size = new System.Drawing.Size(279, 469);
            this.contactsPanelWrapper.TabIndex = 1;
            // 
            // contactsPanel
            // 
            this.contactsPanel.AutoSize = true;
            this.contactsPanel.ColumnCount = 1;
            this.contactsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.contactsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.contactsPanel.Location = new System.Drawing.Point(0, 0);
            this.contactsPanel.Name = "contactsPanel";
            this.contactsPanel.RowCount = 5;
            this.contactsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contactsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contactsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contactsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contactsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.contactsPanel.Size = new System.Drawing.Size(279, 0);
            this.contactsPanel.TabIndex = 2;
            // 
            // leftPanelHeader
            // 
            this.leftPanelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.leftPanelHeader.Location = new System.Drawing.Point(0, 0);
            this.leftPanelHeader.Name = "leftPanelHeader";
            this.leftPanelHeader.Size = new System.Drawing.Size(279, 45);
            this.leftPanelHeader.TabIndex = 1;
            // 
            // contentPanelWrapper
            // 
            this.contentPanelWrapper.Controls.Add(this.panel1);
            this.contentPanelWrapper.Controls.Add(this.panel2);
            this.contentPanelWrapper.Controls.Add(this.contactMinInfoPanel);
            this.contentPanelWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanelWrapper.Location = new System.Drawing.Point(279, 0);
            this.contentPanelWrapper.Name = "contentPanelWrapper";
            this.contentPanelWrapper.Size = new System.Drawing.Size(454, 514);
            this.contentPanelWrapper.TabIndex = 1;
            // 
            // contactMinInfoPanel
            // 
            this.contactMinInfoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.contactMinInfoPanel.Location = new System.Drawing.Point(0, 0);
            this.contactMinInfoPanel.Name = "contactMinInfoPanel";
            this.contactMinInfoPanel.Size = new System.Drawing.Size(454, 45);
            this.contactMinInfoPanel.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(454, 444);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.messagePanel);
            this.panel2.Controls.Add(this.sendButtonPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 489);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(454, 25);
            this.panel2.TabIndex = 3;
            // 
            // messageTextBox
            // 
            this.messageTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.messageTextBox.Location = new System.Drawing.Point(0, 0);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(318, 24);
            this.messageTextBox.TabIndex = 0;
            this.messageTextBox.Text = "awd";
            // 
            // sendBtn
            // 
            this.sendBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendBtn.Location = new System.Drawing.Point(0, 0);
            this.sendBtn.MaximumSize = new System.Drawing.Size(133, 25);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(133, 25);
            this.sendBtn.TabIndex = 1;
            this.sendBtn.Text = "Отправить";
            this.sendBtn.UseVisualStyleBackColor = true;
            // 
            // sendButtonPanel
            // 
            this.sendButtonPanel.AutoSize = true;
            this.sendButtonPanel.Controls.Add(this.sendBtn);
            this.sendButtonPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.sendButtonPanel.Location = new System.Drawing.Point(318, 0);
            this.sendButtonPanel.Name = "sendButtonPanel";
            this.sendButtonPanel.Size = new System.Drawing.Size(136, 25);
            this.sendButtonPanel.TabIndex = 4;
            // 
            // messagePanel
            // 
            this.messagePanel.Controls.Add(this.messageTextBox);
            this.messagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messagePanel.Location = new System.Drawing.Point(0, 0);
            this.messagePanel.Name = "messagePanel";
            this.messagePanel.Size = new System.Drawing.Size(318, 25);
            this.messagePanel.TabIndex = 5;
            // 
            // MainF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 514);
            this.Controls.Add(this.contentPanelWrapper);
            this.Controls.Add(this.leftPanelWrapper);
            this.Name = "MainF";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainF_FormClosing);
            this.Load += new System.EventHandler(this.MainF_Load);
            this.leftPanelWrapper.ResumeLayout(false);
            this.contactsPanelWrapper.ResumeLayout(false);
            this.contactsPanelWrapper.PerformLayout();
            this.contentPanelWrapper.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.sendButtonPanel.ResumeLayout(false);
            this.messagePanel.ResumeLayout(false);
            this.messagePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel leftPanelWrapper;
        private System.Windows.Forms.Panel leftPanelHeader;
        private System.Windows.Forms.Panel contactsPanelWrapper;
        private System.Windows.Forms.TableLayoutPanel contactsPanel;
        private System.Windows.Forms.Panel contentPanelWrapper;
        private System.Windows.Forms.Panel contactMinInfoPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button sendBtn;
        private System.Windows.Forms.TextBox messageTextBox;
        private System.Windows.Forms.Panel sendButtonPanel;
        private System.Windows.Forms.Panel messagePanel;
    }
}

