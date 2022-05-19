namespace PlumMesseger
{
    partial class MeBubble
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(64)))), ((int)(((byte)(75)))));
            this.label1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(176, 5);
            this.label1.MaximumSize = new System.Drawing.Size(140, 0);
            this.label1.MinimumSize = new System.Drawing.Size(70, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3);
            this.label1.Size = new System.Drawing.Size(139, 150);
            this.label1.TabIndex = 1;
            this.label1.Text = " This is a sample text message. This is a sample text message. This is a sample t" +
    "ext message. \r\n\r\nThis is a sample text message. \r\n";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // MeBubble
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(0, 41);
            this.Name = "MeBubble";
            this.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.Size = new System.Drawing.Size(320, 193);
            this.Load += new System.EventHandler(this.Bubble_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
    }
}
