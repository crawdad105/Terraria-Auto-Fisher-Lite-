using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace fishingtest4.CustomClasses
{
    public class CustomTest : ComboBox
    {
        private string DrawedText = "";

        public PictureBox pictureBox;

        public CustomTest() 
        {
            pictureBox = new PictureBox();
            pictureBox.Size = Bounds.Size;
            pictureBox.Paint += new PaintEventHandler(Paint);
            pictureBox.Location = new Point(0, 0);
        }
        public void Paint(object s, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.Red, 10), ClientRectangle);
        }
        protected override void WndProc(ref Message m)
        {
                        base.WndProc(ref m);

            if (m.Msg == 0xF)
            {
                using (var g = Graphics.FromHwnd(Handle))
                {
                    // Uncomment this if you don't want the "highlight border".
                    /*
                    using (var p = new Pen(this.BorderColor, 1))
                    {
                        g.DrawRectangle(p, 0, 0, Width - 1, Height - 1);
                    }*/
                    if (DrawedText != Text)
                    g.DrawString(Text, Font, new SolidBrush(Color.Lime), new PointF(ClientRectangle.Left, ClientRectangle.Top));
                    
                    g.DrawRectangle(new Pen(Color.FromArgb(64, 64, 64), 10), ClientRectangle);
                    
                    g.DrawString(Text, Font, new SolidBrush(Color.Lime), new PointF(ClientRectangle.Left, ClientRectangle.Top));

                }
            }
            else if (m.Msg == 0x0014/*WM_ERASEBKGND*/)
            {
                using (var g = Graphics.FromHdcInternal(m.WParam))
                {
                    g.DrawString(Text, Font, new SolidBrush(Color.Lime), new PointF(ClientRectangle.Left, ClientRectangle.Top));

                    g.DrawRectangle(new Pen(Color.FromArgb(64, 64, 64), 10), ClientRectangle);

                    g.DrawString(Text, Font, new SolidBrush(Color.Lime), new PointF(ClientRectangle.Left, ClientRectangle.Top));
                }
                m.Result = (IntPtr)1;
            }

        }
    }
}
