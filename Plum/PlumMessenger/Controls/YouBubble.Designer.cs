namespace PlumMesseger
{
    partial class YouBubble
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
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.label1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.MaximumSize = new System.Drawing.Size(140, 0);
            this.label1.MinimumSize = new System.Drawing.Size(70, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3);
            this.label1.Size = new System.Drawing.Size(139, 150);
            this.label1.TabIndex = 3;
            this.label1.Text = " This is a sample text message. This is a sample text message. This is a sample t" +
    "ext message. \r\n\r\nThis is a sample text message. ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // YouBubble
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label1);
            this.Name = "YouBubble";
            this.Padding = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.Size = new System.Drawing.Size(320, 169);
            this.Load += new System.EventHandler(this.YouBubble_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
    }
}
