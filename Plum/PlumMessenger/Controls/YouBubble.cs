using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Design;

namespace PlumMesseger
{
    public partial class YouBubble : UserControl
    {
        public YouBubble()
        {
            InitializeComponent();
        }

        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public string Body
        {
            get
            {
                return label1.Text.Replace(Environment.NewLine,"\n");
            }
            set
            {
                label1.Text = value.Replace("\n", Environment.NewLine);
            }
        }

        public Cursor ChatTextCursor
        {
            get
            {
                return label1.Cursor;
            }
            set
            {
                label1.Cursor = value;
            }
        }

        public Color MsgColor
        {
            get
            {
                return label1.BackColor;
            }
            set
            {
                label1.BackColor = value;
            }
        }

        public Color MsgTextColor
        {
            get
            {
                return label1.ForeColor;
            }
            set
            {
                label1.ForeColor = value;
            }
        }

        public Color TimeColor
        {
            get
            {
                return time.ForeColor;
            }
            set
            {
                time.ForeColor = value;
            }
        }

        public string Time
        {
            get
            {
                return time.Text;

            }
            set
            {
                time.Text = value;
                SetTimeWidth();
            }
        }
        private void SetTimeWidth()
        {
            time.Width = TextRenderer.MeasureText(time.Text, time.Font).Width;
        }


        Panel messageBottom = new Panel();
        Label time = new Label();
        bool isAdded = false;

        private void YouBubble_Load(object sender, EventArgs e)
        {

        }
        protected override void OnPaint(PaintEventArgs e)
        {
            label1.MaximumSize = new Size((this.Width - 21)/2, 0);
            label1.Width = this.Width - 21;

            //if (label1.Height < panel2.Height + 1)
            //{
            //    this.MinimumSize = new Size(0, panel2.Height + 11);
            //    this.Height = panel2.Height + 11;
            //}
            //else
            //{
            //    this.MinimumSize = new Size(0, label1.Height + 20);
            //    this.Height = label1.Height + 20;
            //}
            if (label1.Height < 1)
            {
                this.MinimumSize = new Size(0, 11 + 15);
                this.Height = 11 + 15;
            }
            else
            {
                this.MinimumSize = new Size(0, label1.Height + 10 + 15);
                this.Height = label1.Height + 10 + 15;
            }

            if (!isAdded)
            {
                messageBottom.Size = new Size(0, 15);
                messageBottom.Dock = DockStyle.Bottom;
                messageBottom.Padding = new Padding(10, 0, 0, 0);
                messageBottom.BackColor = Color.Transparent;
                messageBottom.ForeColor = Color.White;

                time.Dock = DockStyle.Left;
                SetTimeWidth();

                messageBottom.Controls.Add(time);

                this.Controls.Add(messageBottom);
                isAdded = true;
            }

            GraphicsPath path = RoundedRectangle.Create(label1.ClientRectangle, 5, RoundedRectangle.RectangleCorners.All);
            label1.Region = new Region(path);

            base.OnPaint(e);
        }

        public delegate void ChatImageClick(object sender, EventArgs e);
        public delegate void ChatTextClick(object sender, EventArgs e);

        public event ChatTextClick OnChatTextClick;

        private void label1_Click(object sender, EventArgs e)
        {
            if (OnChatTextClick != null)
            {
                OnChatTextClick.Invoke(sender, e);
            }
        }
    }

   
}
