using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace fishingtest4.CustomClasses
{
    public partial class CustomTabs : TabControl
    {
        public int _BorderRadius
        {
            get;
            set;
        }






        public int TagToInt(object inObject) => Convert.ToInt32((inObject as Control).Tag);
        public Color Background { get; set; } = Color.FromArgb(0, 0, 0);

        public Color BackgroundTab { get; set; } = Color.FromArgb(0, 0, 0);

        public Color Border { get; set; } = Color.FromArgb(0, 122, 204);

        public bool BorderEdges { get; set; } = true;

        private int _BorderSize = 1;
        public int BorderSize
        {
            get => _BorderSize;
            set => _BorderSize = value; //Two is the largest it can be.  Anymore won't be seen.
        }

        public Color ActiveTab { get; set; } = Color.FromArgb(0, 122, 204);

        public Color AlternativeTab { get; set; } = Color.OrangeRed;

        public Color InActiveTab { get; set; } = Color.FromArgb(0, 0, 0);

        public Color ActiveIndicator { get; set; } = Color.FromArgb(0, 122, 204);
        public Color InActiveIndicator { get; set; } = Color.FromArgb(0, 122, 204);
        public int IndicatorSize { get; set; } = 6; //Might become obsolete

        public Color Divider { get; set; } = Color.FromArgb(0, 122, 204);

        private int _DividerSize = 2;
        public int DividerSize
        {
            get => _DividerSize;
            set => _DividerSize = value;
        }

        public Color ActiveText { get; set; } = Color.FromArgb(255, 255, 255);
        public Color InActiveText { get; set; } = Color.FromArgb(255, 255, 255);

        public CustomTabs()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.CacheText, true);
        }
        private GraphicsPath GetFigurePath(Rectangle rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            try
            {
                path.StartFigure();
                path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
                path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
                path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
                path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
                path.CloseFigure();
            }
            catch (Exception)
            {

            }

            return path;
        }
        protected override void OnMouseUp(MouseEventArgs e) { Invalidate(); }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle container = new Rectangle(0, 0, Width - (BorderSize % 2), Height - (BorderSize % 2));

            e.Graphics.Clear(Background); //Background

            //Draw Devider
            e.Graphics.FillRectangle(new SolidBrush(BackgroundTab), DisplayRectangle);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            //SolidBrush brushAlternative = new SolidBrush(AlternativeTab);
            //SolidBrush brushActiveIndicator = new SolidBrush(ControlPaint.Light(ActiveIndicator, .75f));
            //SolidBrush brushInActiveIndicator = new SolidBrush(InActiveIndicator);

            Rectangle containerHead = new Rectangle();

            //Draw devider
            e.Graphics.DrawLine(new Pen(Divider, 4), -5, TabPages[SelectedIndex].Top - DividerSize - 2, Width - BorderSize + 15, TabPages[SelectedIndex].Top - DividerSize - 2);

            for (int i = 0; i < TabCount; i++)
            {
                containerHead = GetTabRect(i);

                if (SelectedIndex == i)
                    e.Graphics.FillPath(new SolidBrush(ActiveTab), GetFigurePath(new Rectangle(containerHead.Location, new Size(containerHead.Width, containerHead.Height + 4)), 4));
                else
                    e.Graphics.FillPath(new SolidBrush(InActiveTab), GetFigurePath(new Rectangle(new Point(containerHead.Location.X, containerHead.Location.Y + 2), new Size(containerHead.Width, containerHead.Height + 4)), 4));


                //Indicator
                Rectangle rectDivider = default(Rectangle);

                rectDivider = new Rectangle(containerHead.X, containerHead.Y + containerHead.Height, containerHead.Width, DividerSize);

                //Draw Higjhlite
                e.Graphics.DrawLine(i == SelectedIndex ? new Pen(ActiveText, 4) : new Pen(InActiveText, 4), new Point(rectDivider.Left, rectDivider.Top - 2), new Point(rectDivider.Right, rectDivider.Top - 2));


                e.Graphics.TranslateTransform(containerHead.X + (containerHead.Width / 2), containerHead.Y + IndicatorSize + ((containerHead.Height - IndicatorSize) / 2));

                Size textSize = e.Graphics.MeasureString(TabPages[i].Text, Font).ToSize();
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawString(TabPages[i].Text, Font, ((SelectedIndex == i) ? new SolidBrush(ActiveText) : new SolidBrush(InActiveText)), new PointF((-textSize.Width / 2f), (-textSize.Height / 2f) - 4));

                e.Graphics.ResetTransform();
            }
        }
    }
}
