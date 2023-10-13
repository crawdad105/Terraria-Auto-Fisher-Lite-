using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static fishingtest4.CustomClasses.CustomNumaricUpDown;

namespace fishingtest4.CustomClasses
{
    [DefaultEvent("_Change_Index_")]
    public class CustomDropDown : ComboBox
    {

        #region variables
        //Fields
        private Color backColor = Color.WhiteSmoke;
        private Color iconColor = Color.MediumSlateBlue;
        private Color listBackColor = Color.FromArgb(230, 228, 245);
        private Color listTextColor = Color.DimGray;
        //Items
        //private ComboBox cmbList;
        private Button btnIcon;

        #endregion variables

        #region Geter Seters
        //Properties
        //-> Appearance
        public Color _IconColor
        {
            get { return iconColor; }
            set
            {
                iconColor = value;
                btnIcon.Invalidate();//Redraw icon
            }
        }
        public Color _ListBackColor
        {
            get { return listBackColor; }
            set
            {
                listBackColor = value;
                BackColor = listBackColor;
            }
        }

        #endregion Properties


        //Constructor
        public CustomDropDown()
        {
            //cmbList = new ComboBox();
            btnIcon = new Button();
            this.SuspendLayout();
            //ComboBox: Dropdown list
            BackColor = listBackColor;
            Font = new Font("Trebuchet MS", 8F, FontStyle.Bold, GraphicsUnit.Point);
            ForeColor = listTextColor;


            //Refresh text
            //Button: Icon
            btnIcon.Dock = DockStyle.Right;
            btnIcon.FlatStyle = FlatStyle.Flat;
            btnIcon.FlatAppearance.BorderSize = 0;
            btnIcon.BackColor = backColor;
            btnIcon.Size = new Size(15, 30);
            btnIcon.Cursor = Cursors.Hand;
            btnIcon.Click += new EventHandler(Icon_Click);//Open dropdown list
            btnIcon.Paint += new PaintEventHandler(Icon_Paint);//Draw icon

            //User Control
            this.Controls.Add(btnIcon);//1
            this.ForeColor = Color.DimGray;
            this.Font = new Font(this.Font.Name, 10F);
            this.ResumeLayout();

            DrawMode = System.Windows.Forms.DrawMode.Normal;
            DrawItem += new DrawItemEventHandler((o, e) => {
                
                if (e.Index < 0)
                    return;

                GraphicsPath GetFigurePath(Rectangle rect, float radius)
                {
                    GraphicsPath path = new GraphicsPath();
                    float curveSize = radius * 2F;

                    path.StartFigure();
                    path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
                    path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
                    path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
                    path.CloseFigure();
                    return path;
                }

                ComboBox combo = (ComboBox)o;

                

                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e.Graphics.FillRectangle(new SolidBrush(combo.BackColor), new Rectangle(e.Bounds.Location.X, e.Bounds.Location.Y, e.Bounds.Width, e.Bounds.Height + 1));
                    e.Graphics.DrawPath(new Pen(Color.Lime), GetFigurePath(new Rectangle(e.Bounds.Location.X, e.Bounds.Location.Y, e.Bounds.Width - 1, e.Bounds.Height), 4));

                    Font f = new Font(e.Font.FontFamily, e.Font.Size, e.Font.Style, e.Font.Unit);
                    e.Graphics.DrawString(combo.Items[e.Index].ToString(), f, new SolidBrush(Color.Lime), new Point(e.Bounds.X + 2, e.Bounds.Y));
                }
                else
                { 
                    e.Graphics.FillRectangle(new SolidBrush(combo.BackColor), new Rectangle(e.Bounds.Location.X, e.Bounds.Location.Y, e.Bounds.Width, e.Bounds.Height + 1));

                    Font f = new Font(e.Font.FontFamily, e.Font.Size, e.Font.Style, e.Font.Unit);
                    e.Graphics.DrawString(combo.Items[e.Index].ToString(), f, new SolidBrush(combo.ForeColor), new Point(e.Bounds.X, e.Bounds.Y));
                }

                //e.DrawFocusRectangle();
            });
        }
        private void Icon_Click(object sender, EventArgs e) { Select(); DroppedDown = true; }

        private void Icon_Paint(object sender, PaintEventArgs e)
        {

            //Fields
            int iconWidht = 14;
            int iconHeight = 6;
            var rectIcon = new Rectangle((btnIcon.Width - iconWidht) / 2, (btnIcon.Height - iconHeight) / 2, iconWidht, iconHeight);
            Graphics graph = e.Graphics;

            //Draw arrow down icon
            graph.DrawRectangle(new Pen(Color.Green), new Rectangle(
                new Point(btnIcon.ClientRectangle.Left, btnIcon.ClientRectangle.Top),
                new Size(btnIcon.ClientRectangle.Width - 1, btnIcon.ClientRectangle.Height - 1)));

            Point[] GetDownArrow(Rectangle r)
            {
                var middle = new Point(r.Left + r.Width / 2, r.Top + r.Height / 2);
                int ArrowSize = 2;
                return new Point[]
                {
                    new Point(middle.X - (ArrowSize * 2) + 1, middle.Y - (ArrowSize)),
                    new Point(middle.X + (ArrowSize * 2), middle.Y - (ArrowSize)),
                    new Point(middle.X, middle.Y + (int)MathF.Ceiling((float)(ArrowSize * 1.5)) - 1)
                };
            }

            graph.FillPolygon(new SolidBrush(btnIcon.ClientRectangle.Contains(btnIcon.PointToClient(MousePosition)) && !DroppedDown ? Color.Green : Color.Black), GetDownArrow(new Rectangle(rectIcon.X, rectIcon.Y + 1, rectIcon.Width, rectIcon.Height)));
            //graph.DrawString(_Index.ToString(), Font, new SolidBrush(btnIcon.ClientRectangle.Contains(btnIcon.PointToClient(MousePosition)) && !cmbList.DroppedDown ? Color.Green : Color.Black), new PointF());
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
                    g.DrawString(Text, Font, new SolidBrush(Color.Lime), new PointF(ClientRectangle.Left, ClientRectangle.Top));

                    g.FillRectangle(new SolidBrush(Color.FromArgb(64, 64, 64)), ClientRectangle);

                    g.DrawString(Text, Font, new SolidBrush(Color.Lime), new PointF(ClientRectangle.Left, ClientRectangle.Top));

                }
            }
            else if (m.Msg == 0x0014/*WM_ERASEBKGND*/)
            {
                using (var g = Graphics.FromHdcInternal(m.WParam))
                {
                    g.DrawString(Text, Font, new SolidBrush(Color.Lime), new PointF(ClientRectangle.Left, ClientRectangle.Top));

                    g.FillRectangle(new SolidBrush(Color.FromArgb(64, 64, 64)), ClientRectangle);

                    g.DrawString(Text, Font, new SolidBrush(Color.Lime), new PointF(ClientRectangle.Left, ClientRectangle.Top));
                }
                m.Result = (IntPtr)1;
            }

        }
        //protected override void OnResize(EventArgs e) { base.OnResize(e); AdjustComboBoxDimensions(); }
    }
}
