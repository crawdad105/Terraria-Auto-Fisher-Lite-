using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fishingtest4.CustomClasses
{
    [DefaultEvent("OnSelectedIndexChanged")]
    class RJComboBox : UserControl
    {

        //Fields
        private Color backColor = Color.WhiteSmoke;
        private Color iconColor = Color.MediumSlateBlue;
        private Color listBackColor = Color.FromArgb(230, 228, 245);
        private Color listTextColor = Color.DimGray;
        private Color borderColor = Color.MediumSlateBlue;
        private Padding lblPadding = new Padding();

        private int afterSelectIndex = 0;
        //Items
        private ComboBox cmbList;
        private Label lblText;
        private Button btnIcon;
        //Events
        public event EventHandler OnSelectedIndexChanged;//Default event
        public event EventHandler OnIndexChange;//Default event

        //Constructor
        public RJComboBox()
        {
            cmbList = new ComboBox();
            lblText = new Label();
            btnIcon = new Button();
            this.SuspendLayout();
            //ComboBox: Dropdown list
            cmbList.BackColor = listBackColor;
            cmbList.Font = new Font(Font.FontFamily, 7, FontStyle.Bold);
            cmbList.DropDownWidth = Size.Width - 10;
            cmbList.Location = new Point(0, -2);
            cmbList.ForeColor = listTextColor;
            cmbList.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);//Default event
            cmbList.TextChanged += new EventHandler(ComboBox_TextChanged);
            cmbList.DrawItem += new DrawItemEventHandler(PaintDropDpown);

            cmbList.DrawMode = DrawMode.OwnerDrawVariable;

            cmbList.MaxDropDownItems = 15;

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
                                                               //Label: Text
            lblText.Dock = DockStyle.Fill;
            lblText.AutoSize = false;
            lblText.BackColor = backColor;
            lblText.TextAlign = ContentAlignment.TopLeft;
            lblText.Padding = lblPadding;
            lblText.Font = new Font(Font.FontFamily, 7, FontStyle.Bold);
            //->Attach label events to user control event
            lblText.Click += new EventHandler(Surface_Click);//Select combo box
            lblText.MouseEnter += new EventHandler((s, e) => OnMouseEnter(e));
            lblText.MouseLeave += new EventHandler((s, e) => OnMouseLeave(e));
            //User Control
            this.Controls.Add(lblText);//2
            this.Controls.Add(btnIcon);//1
            this.Controls.Add(cmbList);//0
            this.ForeColor = Color.DimGray;
            base.BackColor = borderColor; //Border Color
            this.ResumeLayout();
            AdjustComboBoxDimensions();
        }

        //Private methods
        private void AdjustComboBoxDimensions()
        {
            cmbList.Width = lblText.Width;
            //cmbList.Location = new Point()
            //{
            //    X = this.Width - this.Padding.Right - cmbList.Width,
            //    Y = lblText.Bottom - cmbList.Height
            //};
        }

        //Event methods
        //-> Default event
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            AfterSelectIndex = cmbList.SelectedIndex;

            if (OnSelectedIndexChanged != null)
                OnSelectedIndexChanged.Invoke(sender, e);
            //Refresh text
            lblText.Text = cmbList.Text;

        }
        //-> Items actions
        private void Icon_Click(object sender, EventArgs e)
        {
            //Open dropdown list
            cmbList.Select();
            cmbList.DroppedDown = true;
        }
        private void Surface_Click(object sender, EventArgs e)
        {
            //Attach label click to user control click
            this.OnClick(e);
            //Select combo box
            cmbList.Select();
            if (cmbList.DropDownStyle == ComboBoxStyle.DropDownList)
                cmbList.DroppedDown = true;//Open dropdown list
        }
        private void PaintDropDpown(object o, DrawItemEventArgs e)
        {

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

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(combo.BackColor), new Rectangle(e.Bounds.Location.X, e.Bounds.Location.Y, e.Bounds.Width, e.Bounds.Height + 1));
                e.Graphics.DrawPath(new Pen(Color.Lime), GetFigurePath(new Rectangle(e.Bounds.Location.X, e.Bounds.Location.Y, e.Bounds.Width - 1, e.Bounds.Height - 1), 4));

                Font f = new Font(lblText.Font.Name, lblText.Font.Size, FontStyle.Bold, lblText.Font.Unit);
                e.Graphics.DrawString(combo.Items[e.Index].ToString(), f, new SolidBrush(Color.Lime), new Point(e.Bounds.X + 2, e.Bounds.Y + 2));
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(combo.BackColor), new Rectangle(e.Bounds.Location.X - 1, e.Bounds.Location.Y - 1, e.Bounds.Width, e.Bounds.Height + 2));

                Font f = new Font(lblText.Font.Name, lblText.Font.Size, FontStyle.Regular, lblText.Font.Unit);
                e.Graphics.DrawString(combo.Items[e.Index].ToString(), f, new SolidBrush(combo.ForeColor), new Point(e.Bounds.X, e.Bounds.Y + 2));
            }
        }
        private void ComboBox_TextChanged(object sender, EventArgs e)
        {
            //Refresh text
            lblText.Text = cmbList.Text;
            if (OnIndexChange != null)
                OnIndexChange.Invoke(sender, e);
        }

        //-> Draw icon
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

            graph.FillPolygon(new SolidBrush(btnIcon.ClientRectangle.Contains(btnIcon.PointToClient(MousePosition)) && !cmbList.DroppedDown ? Color.Green : Color.Black), GetDownArrow(new Rectangle(rectIcon.X, rectIcon.Y + 1, rectIcon.Width, rectIcon.Height)));
        }

        //Properties
        //-> Appearance
        [Category("- Appearance")]
        public new Padding LblPadding
        {
            get { return lblPadding; }
            set
            {
                lblPadding = value;
                lblText.Padding = lblPadding;
            }
        }
        [Category("- Appearance")]
        public new Color BackColor
        {
            get { return backColor; }
            set
            {
                backColor = value;
                lblText.BackColor = backColor;
                btnIcon.BackColor = backColor;
            }
        }
        [Category("- Appearance")]
        public Color IconColor
        {
            get { return iconColor; }
            set
            {
                iconColor = value;
                btnIcon.Invalidate();//Redraw icon
            }
        }
        [Category("- Appearance")]
        public Color ListBackColor
        {
            get { return listBackColor; }
            set
            {
                listBackColor = value;
                cmbList.BackColor = listBackColor;
            }
        }
        [Category("- Appearance")]
        public Color ListTextColor
        {
            get { return listTextColor; }
            set
            {
                listTextColor = value;
                cmbList.ForeColor = listTextColor;
            }
        }
        [Category("- Appearance")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                base.BackColor = borderColor; //Border Color
            }
        }
        [Category("- Appearance")]
        public string Texts
        {
            get { return lblText.Text; }
            set { lblText.Text = value; }
        }
        [Category("- Appearance")]
        public ComboBoxStyle DropDownStyle
        {
            get { return cmbList.DropDownStyle; }
            set
            {
                if (cmbList.DropDownStyle != ComboBoxStyle.Simple)
                    cmbList.DropDownStyle = value;
            }
        }

        //Properties
        //-> Data
        [Category("- Data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Localizable(true)]
        [MergableProperty(false)]
        public ComboBox.ObjectCollection Items
        {
            get { return cmbList.Items; }
        }
        [Category("- Data")]
        [Bindable(true)]
        [Browsable(false)]
        public object SelectedItem
        {
            get { return cmbList.SelectedItem; }
            set { cmbList.SelectedItem = value; }
        }
        [Category("- Data")]
        [Browsable(false)]
        public int SelectedIndex
        {
            get { return cmbList.SelectedIndex; }
            set { cmbList.SelectedIndex = value; }
        }
        [Category("- Data")]
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
        public string DisplayMember
        {
            get { return cmbList.DisplayMember; }
            set { cmbList.DisplayMember = value; }
        }
        [Category("- Data")]
        [DefaultValue("")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        public string ValueMember
        {
            get { return cmbList.ValueMember; }
            set { cmbList.ValueMember = value; }
        }
        [Category("- Appearance")]
        public int AfterSelectIndex
        {
            get { return afterSelectIndex; }
            set
            {
                afterSelectIndex = value;
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AdjustComboBoxDimensions();
        }
    }
}
