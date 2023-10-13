using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fishingtest4.CustomClasses
{
    public class CustomCheckBox : CheckBox
    {



        public Rectangle CheckBoxRect = new Rectangle(0, 0, 0, 0);
        public Rectangle _CheckBoxRect 
        { 
            get { return CheckBoxRect; }
            set { CheckBoxRect = value; }
        }

        [Browsable(false)]
        public int Depth { get; set; }
        [Browsable(false)]
        public Point MouseLocation { get; set; }

        private const int CHECKBOX_SIZE = 18;
        private const int CHECKBOX_SIZE_HALF = CHECKBOX_SIZE / 2;
        private const int CHECKBOX_INNER_BOX_SIZE = CHECKBOX_SIZE - 4;

        public CustomCheckBox()
        {
            MouseLocation = new Point(-1, -1);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
        }

        private static readonly Point[] CheckmarkLine = { new Point(1, 7), new Point(5, 11), new Point(12, 4) };

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

        protected override void OnPaint(PaintEventArgs pevent)
        {
            var g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;

            g.Clear(BackColor);

            Point CheckBoxSenter = new Point(0, 0);

            GraphicsPath checkmarkPath = GetFigurePath(CheckBoxRect, 3);

            g.FillPath(new SolidBrush(Color.Green), checkmarkPath);
            g.DrawPath(new Pen(Color.FromArgb(0, 192, 0)), checkmarkPath);

            if (Checked)
            {
                GraphicsPath graphicsPath = new GraphicsPath();
                graphicsPath.AddLines(CheckmarkLine);
                g.DrawPath(new Pen(Color.Lime, 2), graphicsPath);
            }

            g.DrawString(Text, Font, new SolidBrush(Color.Lime), new Point(CheckBoxSenter.X + CheckBoxRect.Width + 2, CheckBoxSenter.Y + 2));

        }

        public override bool AutoSize
        {
            get { return base.AutoSize; }
            set
            {
                base.AutoSize = value;
                if (value)
                {
                    Size = new Size(10, 10);
                }
            }
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
        }

    }
}
