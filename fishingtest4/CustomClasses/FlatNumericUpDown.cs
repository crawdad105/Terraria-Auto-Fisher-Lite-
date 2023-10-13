using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace fishingtest4.CustomClasse
{
    public class FlatNumericUpDown : NumericUpDown
    {
        #region Properties (Geters, Seters)

        private int BorderSize;
        private Color BorderColor;
        private int BorderRadius;
        //private Color BackgroundColor;
        //private Color TextColor;
        private int ArrowSize;
        private Color ArrowColor;
        private Color HighlightColor;
        private HighliteType highliteType;

        public enum HighliteType
        {
            Box,
            BeveledBox,
            ArrowFill,
            ArrowLine,
        }
        //Properties
        [Category("Addons")] public int _BorderSize
        {
            get { return BorderSize; }
            set { BorderSize = value; Invalidate(); }
        }
        [Category("Addons")] public Color _BorderColor
        {
            get { return BorderColor; }
            set { BorderColor = value; Invalidate(); }
        }
        [Category("Addons")] public int _BorderRadius
        {
            get { return BorderRadius; }
            set { BorderRadius = value; Invalidate(); }
        }
        [Category("Addons")] public Color _BackgroundColor
        {
            get { return BackColor; }
            set { BackColor = value; Invalidate(); }
        }
        [Category("Addons")] public Color _TextColor
        {
            get { return ForeColor; }
            set { ForeColor = value; Invalidate(); }
        }
        [Category("Addons")] public int _ArrowSize
        {
            get { return ArrowSize; }
            set { ArrowSize = value; Invalidate(); }
        }
        [Category("Addons")] public Color _ArrowColor
        {
            get { return ArrowColor; }
            set { ArrowColor = value; Invalidate(); }
        }
        [Category("Addons")] public Color _HighlightColor
        {
            get { return _HighlightColor; }
            set { _HighlightColor = value; Invalidate(); }
        }
        [Category("Addons")] public HighliteType _HighliteType
        {
            get { return highliteType; }
            set { highliteType = value; Invalidate(); }
        }
        #endregion 
        public FlatNumericUpDown() : base()
        {
            this.Font = new Font("Trebuchet MS", 9, FontStyle.Bold, GraphicsUnit.Point, 1, false);

            this._BackgroundColor = Color.FromArgb(64, 64, 64);
            this.BorderStyle = BorderStyle.FixedSingle;
            this._TextColor = Color.Lime;

            var renderer = new UpDownButtonRenderer(Controls[0]);

            Invalidate();
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
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -_BorderSize, -_BorderSize);
            int smoothSize = 2;
            if (_BorderSize > 0)
                smoothSize = _BorderSize;

            if (_BorderRadius > 0) //Rounded button
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, _BorderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, _BorderRadius - _BorderSize))
                using (Pen penSurface = new Pen(this.Parent.BackColor, smoothSize))
                using (Pen penBorder = new Pen(_BorderColor, _BorderSize))
                {
                    pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    //Button surface
                    this.Region = new Region(pathSurface);
                    //Draw surface border for HD result
                    pevent.Graphics.DrawPath(penSurface, pathSurface);

                    //Button border                    
                    if (_BorderSize >= 1)
                        //Draw control border
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
            else //Normal button
            {
                pevent.Graphics.SmoothingMode = SmoothingMode.None;
                //Button surface
                this.Region = new Region(rectSurface);
                //Button border
                if (_BorderSize >= 1)
                {
                    using (Pen penBorder = new Pen(_BorderColor, _BorderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
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
                int ArrowSize = ((FlatNumericUpDown)updown.Parent)._ArrowSize;
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
                int ArrowSize = ((FlatNumericUpDown)updown.Parent)._ArrowSize;
                return new Point[]
                {
                    new Point(middle.X - (ArrowSize * 2), middle.Y + (ArrowSize)),
                    new Point(middle.X + (ArrowSize * 2), middle.Y + (ArrowSize)),
                    new Point(middle.X, middle.Y - (int)MathF.Ceiling((float)(ArrowSize * 1.5)))
                };
            }
            protected override void WndProc(ref Message m)
            {
                if (m.Msg == 0xF /*WM_PAINT*/ && ((FlatNumericUpDown)updown.Parent).BorderStyle == BorderStyle.FixedSingle)
                {
                    var s = new PAINTSTRUCT();
                    IntBeginPaint(updown.Handle, ref s);
                    using (var g = Graphics.FromHdc(s.hdc))
                    {
                        #region Calculations
                        var get = ((FlatNumericUpDown)updown.Parent);
                        bool enabled = updown.Enabled;

                        Point MousePos = updown.PointToClient(MousePosition);

                        Rectangle UpArrowRect = new Rectangle(0, 0, updown.Width, updown.Height / 2);
                        Rectangle DownArrowRect = new Rectangle(0, updown.Height / 2, updown.Width, updown.Height / 2 + 1);

                        Rectangle NewUpArrowRect = new Rectangle(UpArrowRect.X + 2, UpArrowRect.Y + 1, UpArrowRect.Width - 3, UpArrowRect.Height - 2);
                        Rectangle NewDownArrowRect = new Rectangle(DownArrowRect.X + 2, DownArrowRect.Y + 1, DownArrowRect.Width - 3, DownArrowRect.Height - 2);

                        Point[] UpArrowPoints = GetUpArrow(UpArrowRect);
                        Point[] DownArrowPoints = GetDownArrow(DownArrowRect);

                        Pen BackGroundPen = new Pen(enabled ? get._ArrowColor : SystemColors.Control, 1);
                        Rectangle BackRect = new Rectangle(new Point(updown.ClientRectangle.Location.X + 1 + updown.ClientRectangle.Location.Y), new Size(updown.ClientRectangle.Width - 2, updown.ClientRectangle.Height - 1));

                        SolidBrush OutlineBrush = new SolidBrush(enabled ? get._BackgroundColor : SystemColors.Control);
                        Rectangle OutlineRect = updown.ClientRectangle;

                        SolidBrush ArrowBrush = new SolidBrush(get._ArrowColor);
                        Pen ArrowPen = new Pen(get._ArrowColor);

                        #endregion 

                        //Draw Back
                        g.FillRectangle(OutlineBrush, OutlineRect);
                        //Draw Outline
                        g.DrawRectangle(BackGroundPen, BackRect);
                        //Draw Arrows
                        g.FillPolygon(ArrowBrush, UpArrowPoints);
                        g.FillPolygon(ArrowBrush, DownArrowPoints);

                        g.DrawRectangle(ArrowPen, NewUpArrowRect);
                        g.DrawRectangle(ArrowPen, NewDownArrowRect);

                        if (NewUpArrowRect.Contains(MousePos))
                        {
                            if (get._HighliteType == HighliteType.Box)
                                g.DrawRectangle(ArrowPen, NewUpArrowRect);
                            if (get._HighliteType == HighliteType.BeveledBox)
                                g.DrawPath(ArrowPen, get.GetFigurePath(NewUpArrowRect, 2));
                            if (get._HighliteType == HighliteType.ArrowLine)
                                g.DrawPolygon(ArrowPen, UpArrowPoints);
                            if (get._HighliteType == HighliteType.ArrowLine)
                                g.FillPolygon(ArrowBrush, UpArrowPoints);
                        }


                        if (NewDownArrowRect.Contains(MousePos))
                            g.DrawRectangle(new Pen(Color.Red), NewDownArrowRect);

                        if (enabled && updown.ClientRectangle.Contains(MousePos))
                        {
                            using (var pen = new Pen(((FlatNumericUpDown)updown.Parent)._BorderColor))
                            {
                                g.DrawLines(pen,
                                    new[] { new Point(0, 0), new Point(0, updown.Height),
                                        new Point(0, updown.Height / 2), new Point(updown.Width, updown.Height / 2)
                                    });
                            }
                        }

                    }
                    m.Result = (IntPtr)1;
                    base.WndProc(ref m);
                    IntEndPaint(updown.Handle, ref s);
                }
                else if (m.Msg == 0x0014/*WM_ERASEBKGND*/)
                {
                    using (var g = Graphics.FromHdcInternal(m.WParam))
                        g.FillRectangle(Brushes.White, updown.ClientRectangle);
                    m.Result = (IntPtr)1;
                }
                else
                    base.WndProc(ref m);
            }
                
        }
    }
    
}