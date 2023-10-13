using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace fishingtest4.CustomClasses
{
    public class CustomNumaricUpDown : NumericUpDown
    {

        private bool Has = false;

        private int borderSize;
        private Color borderColor;
        private int borderRadius;
        private Color backgroundColor;
        private Color textColor;
        private int arrowSize;
        private Color arrowColor;
        private Color highlightColor;
        private HighlightType highlightType;

        public int _BorderSize
        {
            get { return borderSize; }
            set { borderSize = value; 
                Invalidate(); }
        }
        public Color _BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; 
                Invalidate(); }
        }
        private int _BorderRadius
        {
            get { return borderRadius; }
            set { borderRadius = value; 
                Invalidate(); }
        }
        public Color _BackgroundColor
        {
            get { return backgroundColor; }
            set { backgroundColor = value; BackColor = value;
                Invalidate(); }
        }
        public Color _TextColor
        {
            get { return textColor; }
            set { textColor = value; ForeColor = value;
                Invalidate(); }
        }
        public int _ArrowSize
        {
            get { return arrowSize; }
            set { arrowSize = value; 
                Invalidate(); }
        }
        public Color _ArrowColor
        {
            get { return arrowColor; }
            set { arrowColor = value; 
                Invalidate(); }
        }
        public Color _HighlightColor
        {
            get { return highlightColor; }
            set { highlightColor = value;  
                Invalidate(); }
        }
        public HighlightType _HighlightType
        {
            get { return highlightType; }
            set
            {
                highlightType = value;
                Invalidate();
            }
        }
        public enum HighlightType
        {
            Box,
            BeveledBox,
            ArrowFill,
            ArrowLine,
        }

        public CustomNumaricUpDown()
        {
            this.Font = new Font("Trebuchet MS", 9, FontStyle.Bold, GraphicsUnit.Point, 1, false);
            
            this.BorderStyle = BorderStyle.FixedSingle;

            this._BorderRadius = 0;
            this._BorderSize = 3;
            this._BorderColor = Color.FromArgb(0, 192, 0);
            this._BackgroundColor = Color.FromArgb(64, 64, 64);
            this._TextColor = Color.Lime;

            this._ArrowColor = Color.Black;
            this._HighlightColor = Color.Green;

            this._ArrowSize = 2;
            
            this.Resize += new EventHandler(Button_Resize);
            
            void Button_Resize(object sender, EventArgs e)
            {
                if (_BorderRadius > this.Height)
                    _BorderRadius = this.Height;
            }

            var renderer = new UpDownButtonRenderer(Controls[0]);
        }

        //Methods
        private GraphicsPath GetFigurePath(Rectangle rect, float radius)
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
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
            int smoothSize = 2;
            if (borderSize > 0)
                smoothSize = borderSize;

            if (borderRadius > 0) //Rounded button
            {
                GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius);
                GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius);

                pevent.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                //Button surface
                this.Region = new Region(pathSurface);
                //Draw surface border for HD result
                //pevent.Graphics.DrawPath(new Pen(_BackgroundColor, smoothSize), pathSurface);

                //Button border                    
                if (borderSize >= 1)
                    //Draw control border
                    pevent.Graphics.DrawPath(new Pen(_BorderColor, borderSize + 1), pathBorder);
                else
                    pevent.Graphics.DrawPath(new Pen(_BackgroundColor, borderSize), pathBorder);


            }
            else //Normal button
            {
                if (borderSize >= 1)
                    pevent.Graphics.DrawRectangle(new Pen(_BorderColor, borderSize + 1), rectSurface);
                else
                    pevent.Graphics.DrawRectangle(new Pen(_BackgroundColor, 2), rectSurface);
            }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
            void Container_BackColorChanged(object sender, EventArgs e)
            {
                this.Invalidate();
            }
        }

        private class UpDownButtonRenderer : NativeWindow
        {

            [DllImport("user32.dll", ExactSpelling = true, EntryPoint = "BeginPaint", CharSet = CharSet.Auto)]
            private static extern IntPtr IntBeginPaint(IntPtr hWnd, [In, Out] ref PAINTSTRUCT lpPaint);
            [StructLayout(LayoutKind.Sequential)]
            public struct PAINTSTRUCT
            {
                public IntPtr hdc;
                public bool fErase;
                public int rcPaint_left;
                public int rcPaint_top;
                public int rcPaint_right;
                public int rcPaint_bottom;
                public bool fRestore;
                public bool fIncUpdate;
                public int reserved1;
                public int reserved2;
                public int reserved3;
                public int reserved4;
                public int reserved5;
                public int reserved6;
                public int reserved7;
                public int reserved8;
            }
            [DllImport("user32.dll", ExactSpelling = true, EntryPoint = "EndPaint", CharSet = CharSet.Auto)]
            private static extern bool IntEndPaint(IntPtr hWnd, ref PAINTSTRUCT lpPaint);

            Control updown;
            public UpDownButtonRenderer(Control c)
            {
                this.updown = c;
                if (updown.IsHandleCreated)
                    this.AssignHandle(updown.Handle);
                else
                    updown.HandleCreated += (s, e) => this.AssignHandle(updown.Handle);
            }
            private Point[] GetDownArrow(Rectangle r)
            {
                var middle = new Point(r.Left + r.Width / 2, r.Top + r.Height / 2);
                int ArrowSize = ((CustomNumaricUpDown)updown.Parent)._ArrowSize;
                return new Point[]
                {
                    new Point(middle.X - (ArrowSize * 2) + 1, middle.Y - (ArrowSize)),
                    new Point(middle.X + (ArrowSize * 2), middle.Y - (ArrowSize)),
                    new Point(middle.X, middle.Y + (int)MathF.Ceiling((float)(ArrowSize * 1.5)) - 1)
                };
            }
            private Point[] GetUpArrow(Rectangle r)
            {
                var middle = new Point(r.Left + r.Width / 2, r.Top + r.Height / 2);
                int ArrowSize = ((CustomNumaricUpDown)updown.Parent)._ArrowSize;
                return new Point[]
                {
                    new Point(middle.X - (ArrowSize * 2), middle.Y + (ArrowSize) + 1),
                    new Point(middle.X + (ArrowSize * 2), middle.Y + (ArrowSize) + 1),
                    new Point(middle.X, middle.Y - (int)MathF.Ceiling((float)(ArrowSize * 1.5)) + 1)
                };
            }
            protected override void WndProc(ref Message m)
            {
                void PaintStuff(ref Graphics g)
                {
                    var get = ((CustomNumaricUpDown)updown.Parent);
                    bool enabled = updown.Enabled;

                    Point MousePos = updown.PointToClient(MousePosition);

                    Rectangle UpArrowRect = new Rectangle(0, 0, updown.Width, updown.Height / 2);
                    Rectangle DownArrowRect = new Rectangle(0, updown.Height / 2, updown.Width, updown.Height / 2 + 1);

                    Rectangle NewUpArrowRect = new Rectangle(UpArrowRect.X + 2, UpArrowRect.Y + 1, UpArrowRect.Width - 4, UpArrowRect.Height - 2);
                    Rectangle NewDownArrowRect = new Rectangle(DownArrowRect.X + 2, DownArrowRect.Y + 1, DownArrowRect.Width - 4, DownArrowRect.Height - 3);

                    Point[] UpArrowPoints = GetUpArrow(UpArrowRect);
                    Point[] DownArrowPoints = GetDownArrow(DownArrowRect);

                    Pen BackPaint = new Pen(enabled ? get._BorderColor : SystemColors.Control, 1);
                    Rectangle BackRect = new Rectangle(new Point(updown.ClientRectangle.Location.X + 1 + updown.ClientRectangle.Location.Y), new Size(updown.ClientRectangle.Width - 2, updown.ClientRectangle.Height - 1));

                    Bitmap image = new Bitmap(updown.ClientRectangle.Width, updown.ClientRectangle.Height);

                    Graphics g2 = Graphics.FromImage(image);

                    g2.FillPolygon(new SolidBrush(get._ArrowColor), UpArrowPoints);
                    g2.FillPolygon(new SolidBrush(get._ArrowColor), DownArrowPoints);
                    //Draw Back
                    g2.FillRectangle(new SolidBrush(enabled ? get._BackgroundColor : SystemColors.Control), updown.ClientRectangle);
                    //Draw Outline
                    g2.DrawRectangle(BackPaint, BackRect);
                    //Draw Arrows
                    g2.FillPolygon(new SolidBrush(get._ArrowColor), UpArrowPoints);
                    g2.FillPolygon(new SolidBrush(get._ArrowColor), DownArrowPoints);

                    if (NewUpArrowRect.Contains(MousePos))
                    {
                        if (get._HighlightType == HighlightType.Box)
                            g2.DrawRectangle(new Pen(get._HighlightColor), NewUpArrowRect);
                        if (get._HighlightType == HighlightType.BeveledBox)
                            g2.DrawPath(new Pen(get._HighlightColor), get.GetFigurePath(NewUpArrowRect, 2));
                        if (get._HighlightType == HighlightType.ArrowLine)
                            g2.DrawPolygon(new Pen(get._HighlightColor), UpArrowPoints);
                        if (get._HighlightType == HighlightType.ArrowFill)
                            g2.FillPolygon(new SolidBrush(get._HighlightColor), UpArrowPoints);
                    }
                    else
                    {
                        if (get._HighlightType == HighlightType.Box)
                            g2.DrawRectangle(new Pen(get._BackgroundColor), NewUpArrowRect);
                        if (get._HighlightType == HighlightType.BeveledBox)
                            g2.DrawPath(new Pen(get._BackgroundColor), get.GetFigurePath(NewUpArrowRect, 2));
                        if (get._HighlightType == HighlightType.ArrowLine)
                            g2.DrawPolygon(new Pen(get._ArrowColor), UpArrowPoints);
                        if (get._HighlightType == HighlightType.ArrowFill)
                            g2.FillPolygon(new SolidBrush(get._ArrowColor), UpArrowPoints);
                    }
                    if (NewDownArrowRect.Contains(MousePos))
                    {
                        if (get._HighlightType == HighlightType.Box)
                            g2.DrawRectangle(new Pen(get._HighlightColor), NewDownArrowRect);
                        if (get._HighlightType == HighlightType.BeveledBox)
                            g2.DrawPath(new Pen(get._HighlightColor), get.GetFigurePath(NewDownArrowRect, 2));
                        if (get._HighlightType == HighlightType.ArrowLine)
                            g2.DrawPolygon(new Pen(get._HighlightColor), DownArrowPoints);
                        if (get._HighlightType == HighlightType.ArrowFill)
                            g2.FillPolygon(new SolidBrush(get._HighlightColor), DownArrowPoints);
                    }
                    else
                    {
                        if (get._HighlightType == HighlightType.Box)
                            g2.DrawRectangle(new Pen(get._BackgroundColor), NewDownArrowRect);
                        if (get._HighlightType == HighlightType.BeveledBox)
                            g2.DrawPath(new Pen(get._BackgroundColor), get.GetFigurePath(NewDownArrowRect, 2));
                        if (get._HighlightType == HighlightType.ArrowLine)
                            g2.DrawPolygon(new Pen(get._ArrowColor), DownArrowPoints);
                        if (get._HighlightType == HighlightType.ArrowFill)
                            g2.FillPolygon(new SolidBrush(get._ArrowColor), DownArrowPoints);
                    }
                    g.DrawImage(image, 0, 0);
                }

                if (m.Msg == 0xF /*WM_PAINT*/ && ((CustomNumaricUpDown)updown.Parent).BorderStyle == BorderStyle.FixedSingle)
                {
                    var s = new PAINTSTRUCT();
                    IntBeginPaint(updown.Handle, ref s);

                    Graphics g = Graphics.FromHdc(s.hdc);
                    PaintStuff(ref g);

                    m.Result = (IntPtr)1;
                    base.WndProc(ref m);
                    IntEndPaint(updown.Handle, ref s);
                }
                else if (m.Msg == 0x0014/*WM_ERASEBKGND*/)
                {
                    Graphics g = Graphics.FromHdcInternal(m.WParam);
                    PaintStuff(ref g);

                    m.Result = (IntPtr)1;
                }
                else
                {
                    base.WndProc(ref m);
                }
            }

        }
    }
}
