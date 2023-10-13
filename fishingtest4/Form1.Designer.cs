namespace fishingtest4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            FindBobber = new CustomClasses.ButtonBetter();
            BobberXNum = new CustomClasses.CustomNumaricUpDown();
            BobberXLable = new Label();
            BobberYNum = new CustomClasses.CustomNumaricUpDown();
            BobberYLable = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            timer2 = new System.Windows.Forms.Timer(components);
            buttonBetter3 = new CustomClasses.ButtonBetter();
            BobberDropDown = new CustomClasses.RJComboBox();
            EnableFisher = new CustomClasses.CustomCheckBox();
            buttonBetter1 = new CustomClasses.ButtonBetter();
            Console = new RichTextBox();
            ClearLogBtn = new CustomClasses.ButtonBetter();
            buttonBetter2 = new CustomClasses.ButtonBetter();
            buttonBetter4 = new CustomClasses.ButtonBetter();
            buttonBetter5 = new CustomClasses.ButtonBetter();
            buttonBetter6 = new CustomClasses.ButtonBetter();
            buttonBetter7 = new CustomClasses.ButtonBetter();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)BobberXNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BobberYNum).BeginInit();
            SuspendLayout();
            // 
            // FindBobber
            // 
            FindBobber._BackgroundColor = Color.FromArgb(64, 64, 64);
            FindBobber._BorderColor = Color.FromArgb(0, 192, 0);
            FindBobber._BorderRadius = 4;
            FindBobber._BorderSize = 1;
            FindBobber._TextColor = Color.Lime;
            FindBobber.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            FindBobber.BackColor = Color.FromArgb(64, 64, 64);
            FindBobber.Cursor = Cursors.Hand;
            FindBobber.FlatAppearance.BorderSize = 0;
            FindBobber.FlatStyle = FlatStyle.Flat;
            FindBobber.Font = new Font("Trebuchet MS", 6F, FontStyle.Bold, GraphicsUnit.Point);
            FindBobber.ForeColor = Color.Lime;
            FindBobber.Location = new Point(87, 101);
            FindBobber.Margin = new Padding(0);
            FindBobber.Name = "FindBobber";
            FindBobber.Size = new Size(114, 34);
            FindBobber.TabIndex = 0;
            FindBobber.Text = "Auto Locate Bobber\r\n(this could take a while)";
            FindBobber.UseVisualStyleBackColor = false;
            FindBobber.Click += FindBobber_Click;
            // 
            // BobberXNum
            // 
            BobberXNum._ArrowColor = Color.Black;
            BobberXNum._ArrowSize = 2;
            BobberXNum._BackgroundColor = Color.FromArgb(64, 64, 64);
            BobberXNum._BorderColor = Color.Green;
            BobberXNum._BorderSize = 0;
            BobberXNum._HighlightColor = Color.FromArgb(0, 192, 0);
            BobberXNum._HighlightType = CustomClasses.CustomNumaricUpDown.HighlightType.ArrowFill;
            BobberXNum._TextColor = Color.Lime;
            BobberXNum.BackColor = Color.FromArgb(64, 64, 64);
            BobberXNum.BorderStyle = BorderStyle.FixedSingle;
            BobberXNum.Cursor = Cursors.Hand;
            BobberXNum.Font = new Font("Trebuchet MS", 8F, FontStyle.Bold, GraphicsUnit.Point);
            BobberXNum.ForeColor = Color.FromArgb(0, 192, 0);
            BobberXNum.Increment = new decimal(new int[] { 2, 0, 0, 0 });
            BobberXNum.Location = new Point(66, 10);
            BobberXNum.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            BobberXNum.Minimum = new decimal(new int[] { 9999, 0, 0, int.MinValue });
            BobberXNum.Name = "BobberXNum";
            BobberXNum.Size = new Size(53, 20);
            BobberXNum.TabIndex = 4;
            BobberXNum.ValueChanged += BobberXNum_ValueChanged;
            // 
            // BobberXLable
            // 
            BobberXLable.AutoSize = true;
            BobberXLable.BackColor = Color.FromArgb(64, 64, 64);
            BobberXLable.Font = new Font("Trebuchet MS", 8F, FontStyle.Bold, GraphicsUnit.Point);
            BobberXLable.ForeColor = Color.Lime;
            BobberXLable.Location = new Point(9, 12);
            BobberXLable.Name = "BobberXLable";
            BobberXLable.Size = new Size(62, 16);
            BobberXLable.TabIndex = 6;
            BobberXLable.Text = "Bobber X:";
            // 
            // BobberYNum
            // 
            BobberYNum._ArrowColor = Color.Black;
            BobberYNum._ArrowSize = 2;
            BobberYNum._BackgroundColor = Color.FromArgb(64, 64, 64);
            BobberYNum._BorderColor = Color.Green;
            BobberYNum._BorderSize = 0;
            BobberYNum._HighlightColor = Color.FromArgb(0, 192, 0);
            BobberYNum._HighlightType = CustomClasses.CustomNumaricUpDown.HighlightType.ArrowFill;
            BobberYNum._TextColor = Color.Lime;
            BobberYNum.BackColor = Color.FromArgb(64, 64, 64);
            BobberYNum.BorderStyle = BorderStyle.FixedSingle;
            BobberYNum.Cursor = Cursors.Hand;
            BobberYNum.Font = new Font("Trebuchet MS", 8F, FontStyle.Bold, GraphicsUnit.Point);
            BobberYNum.ForeColor = Color.FromArgb(0, 192, 0);
            BobberYNum.Increment = new decimal(new int[] { 2, 0, 0, 0 });
            BobberYNum.Location = new Point(66, 33);
            BobberYNum.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            BobberYNum.Minimum = new decimal(new int[] { 9999, 0, 0, int.MinValue });
            BobberYNum.Name = "BobberYNum";
            BobberYNum.Size = new Size(53, 20);
            BobberYNum.TabIndex = 7;
            BobberYNum.ValueChanged += BobberXNum_ValueChanged;
            // 
            // BobberYLable
            // 
            BobberYLable.AutoSize = true;
            BobberYLable.BackColor = Color.FromArgb(64, 64, 64);
            BobberYLable.Font = new Font("Trebuchet MS", 8F, FontStyle.Bold, GraphicsUnit.Point);
            BobberYLable.ForeColor = Color.Lime;
            BobberYLable.Location = new Point(10, 35);
            BobberYLable.Name = "BobberYLable";
            BobberYLable.Size = new Size(61, 16);
            BobberYLable.TabIndex = 9;
            BobberYLable.Text = "Bobber Y:";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 250;
            timer1.Tick += timer1_Tick;
            // 
            // timer2
            // 
            timer2.Enabled = true;
            timer2.Interval = 5;
            timer2.Tick += timer2_Tick;
            // 
            // buttonBetter3
            // 
            buttonBetter3._BackgroundColor = Color.FromArgb(20, 20, 20);
            buttonBetter3._BorderColor = Color.FromArgb(0, 192, 0);
            buttonBetter3._BorderRadius = 12;
            buttonBetter3._BorderSize = 5;
            buttonBetter3._TextColor = Color.Transparent;
            buttonBetter3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonBetter3.BackColor = Color.FromArgb(20, 20, 20);
            buttonBetter3.Enabled = false;
            buttonBetter3.FlatAppearance.BorderSize = 0;
            buttonBetter3.FlatStyle = FlatStyle.Flat;
            buttonBetter3.Font = new Font("Trebuchet MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonBetter3.ForeColor = Color.Transparent;
            buttonBetter3.Location = new Point(-2, -2);
            buttonBetter3.Name = "buttonBetter3";
            buttonBetter3.Size = new Size(597, 146);
            buttonBetter3.TabIndex = 22;
            buttonBetter3.UseVisualStyleBackColor = false;
            // 
            // BobberDropDown
            // 
            BobberDropDown.AfterSelectIndex = 0;
            BobberDropDown.BackColor = Color.FromArgb(64, 64, 64);
            BobberDropDown.BorderColor = Color.FromArgb(0, 192, 0);
            BobberDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            BobberDropDown.Font = new Font("Trebuchet MS", 6F, FontStyle.Bold, GraphicsUnit.Point);
            BobberDropDown.ForeColor = Color.Lime;
            BobberDropDown.IconColor = Color.Black;
            BobberDropDown.Items.AddRange(new object[] { "Wood Fishing Pole", "Reinforced Fishing Pole*", "Fisher of Souls", "Fleshcatcher", "Chum Caster", "Scarab Fishing Rod", "Fiberglass Fishing Pole*", "Mechanic's Rod*", "Sitting Duck's Fishing Pole", "Hotline Fishing Hook", "Golden Fishing Rod" });
            BobberDropDown.LblPadding = new Padding(0, 2, 0, 0);
            BobberDropDown.ListBackColor = Color.FromArgb(64, 64, 64);
            BobberDropDown.ListTextColor = Color.FromArgb(0, 192, 0);
            BobberDropDown.Location = new Point(125, 34);
            BobberDropDown.Name = "BobberDropDown";
            BobberDropDown.SelectedIndex = -1;
            BobberDropDown.SelectedItem = null;
            BobberDropDown.Size = new Size(145, 18);
            BobberDropDown.TabIndex = 45;
            BobberDropDown.Texts = "Select a Fishing Pole";
            BobberDropDown.OnSelectedIndexChanged += BobberSelect_SelectedIndexChanged;
            // 
            // EnableFisher
            // 
            EnableFisher._CheckBoxRect = new Rectangle(0, 2, 12, 12);
            EnableFisher.AutoSize = true;
            EnableFisher.BackColor = Color.FromArgb(64, 64, 64);
            EnableFisher.Depth = 0;
            EnableFisher.Font = new Font("Trebuchet MS", 8F, FontStyle.Bold, GraphicsUnit.Point);
            EnableFisher.ForeColor = Color.FromArgb(64, 64, 64);
            EnableFisher.Location = new Point(127, 10);
            EnableFisher.MouseLocation = new Point(-1, -1);
            EnableFisher.Name = "EnableFisher";
            EnableFisher.Size = new Size(126, 20);
            EnableFisher.TabIndex = 64;
            EnableFisher.Text = "Enable Auto Fisher";
            EnableFisher.UseVisualStyleBackColor = false;
            // 
            // buttonBetter1
            // 
            buttonBetter1._BackgroundColor = Color.FromArgb(35, 35, 35);
            buttonBetter1._BorderColor = Color.FromArgb(0, 192, 0);
            buttonBetter1._BorderRadius = 6;
            buttonBetter1._BorderSize = 4;
            buttonBetter1._TextColor = Color.Lime;
            buttonBetter1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            buttonBetter1.BackColor = Color.FromArgb(35, 35, 35);
            buttonBetter1.Enabled = false;
            buttonBetter1.FlatAppearance.BorderSize = 0;
            buttonBetter1.FlatStyle = FlatStyle.Flat;
            buttonBetter1.Font = new Font("Trebuchet MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonBetter1.ForeColor = Color.Lime;
            buttonBetter1.Location = new Point(274, 7);
            buttonBetter1.Name = "buttonBetter1";
            buttonBetter1.Size = new Size(313, 129);
            buttonBetter1.TabIndex = 67;
            buttonBetter1.Text = "buttonBetter1";
            buttonBetter1.UseVisualStyleBackColor = false;
            // 
            // Console
            // 
            Console.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Console.BackColor = Color.FromArgb(35, 35, 35);
            Console.BorderStyle = BorderStyle.None;
            Console.Cursor = Cursors.Cross;
            Console.Font = new Font("Consolas", 8F, FontStyle.Bold, GraphicsUnit.Point);
            Console.ForeColor = Color.FromArgb(0, 192, 0);
            Console.Location = new Point(281, 14);
            Console.Name = "Console";
            Console.ReadOnly = true;
            Console.Size = new Size(300, 116);
            Console.TabIndex = 11;
            Console.Tag = "";
            Console.Text = "Console";
            Console.WordWrap = false;
            // 
            // ClearLogBtn
            // 
            ClearLogBtn._BackgroundColor = Color.FromArgb(64, 64, 64);
            ClearLogBtn._BorderColor = Color.FromArgb(0, 192, 0);
            ClearLogBtn._BorderRadius = 4;
            ClearLogBtn._BorderSize = 1;
            ClearLogBtn._TextColor = Color.Lime;
            ClearLogBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            ClearLogBtn.BackColor = Color.FromArgb(64, 64, 64);
            ClearLogBtn.FlatAppearance.BorderSize = 0;
            ClearLogBtn.FlatStyle = FlatStyle.Flat;
            ClearLogBtn.Font = new Font("Trebuchet MS", 7F, FontStyle.Bold, GraphicsUnit.Point);
            ClearLogBtn.ForeColor = Color.Lime;
            ClearLogBtn.Location = new Point(280, 107);
            ClearLogBtn.Name = "ClearLogBtn";
            ClearLogBtn.Size = new Size(62, 22);
            ClearLogBtn.TabIndex = 13;
            ClearLogBtn.Text = "Clear Log";
            ClearLogBtn.UseVisualStyleBackColor = false;
            ClearLogBtn.Click += ClearLogBtn_Click;
            // 
            // buttonBetter2
            // 
            buttonBetter2._BackgroundColor = Color.FromArgb(64, 64, 64);
            buttonBetter2._BorderColor = Color.FromArgb(0, 192, 0);
            buttonBetter2._BorderRadius = 4;
            buttonBetter2._BorderSize = 1;
            buttonBetter2._TextColor = Color.Lime;
            buttonBetter2.BackColor = Color.FromArgb(64, 64, 64);
            buttonBetter2.FlatAppearance.BorderSize = 0;
            buttonBetter2.FlatStyle = FlatStyle.Flat;
            buttonBetter2.Font = new Font("Trebuchet MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonBetter2.ForeColor = Color.Lime;
            buttonBetter2.Location = new Point(7, 8);
            buttonBetter2.Name = "buttonBetter2";
            buttonBetter2.Size = new Size(114, 23);
            buttonBetter2.TabIndex = 68;
            buttonBetter2.Text = "buttonBetter2";
            buttonBetter2.UseVisualStyleBackColor = false;
            // 
            // buttonBetter4
            // 
            buttonBetter4._BackgroundColor = Color.FromArgb(64, 64, 64);
            buttonBetter4._BorderColor = Color.FromArgb(0, 192, 0);
            buttonBetter4._BorderRadius = 4;
            buttonBetter4._BorderSize = 1;
            buttonBetter4._TextColor = Color.Lime;
            buttonBetter4.BackColor = Color.FromArgb(64, 64, 64);
            buttonBetter4.FlatAppearance.BorderSize = 0;
            buttonBetter4.FlatStyle = FlatStyle.Flat;
            buttonBetter4.Font = new Font("Trebuchet MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonBetter4.ForeColor = Color.Lime;
            buttonBetter4.Location = new Point(7, 31);
            buttonBetter4.Name = "buttonBetter4";
            buttonBetter4.Size = new Size(114, 23);
            buttonBetter4.TabIndex = 69;
            buttonBetter4.Text = "buttonBetter4";
            buttonBetter4.UseVisualStyleBackColor = false;
            // 
            // buttonBetter5
            // 
            buttonBetter5._BackgroundColor = Color.FromArgb(64, 64, 64);
            buttonBetter5._BorderColor = Color.FromArgb(0, 192, 0);
            buttonBetter5._BorderRadius = 4;
            buttonBetter5._BorderSize = 1;
            buttonBetter5._TextColor = Color.Lime;
            buttonBetter5.BackColor = Color.FromArgb(64, 64, 64);
            buttonBetter5.FlatAppearance.BorderSize = 0;
            buttonBetter5.FlatStyle = FlatStyle.Flat;
            buttonBetter5.Font = new Font("Trebuchet MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonBetter5.ForeColor = Color.Lime;
            buttonBetter5.Location = new Point(121, 31);
            buttonBetter5.Name = "buttonBetter5";
            buttonBetter5.Size = new Size(151, 23);
            buttonBetter5.TabIndex = 70;
            buttonBetter5.Text = "buttonBetter5";
            buttonBetter5.UseVisualStyleBackColor = false;
            // 
            // buttonBetter6
            // 
            buttonBetter6._BackgroundColor = Color.FromArgb(64, 64, 64);
            buttonBetter6._BorderColor = Color.FromArgb(0, 192, 0);
            buttonBetter6._BorderRadius = 4;
            buttonBetter6._BorderSize = 1;
            buttonBetter6._TextColor = Color.Lime;
            buttonBetter6.BackColor = Color.FromArgb(64, 64, 64);
            buttonBetter6.FlatAppearance.BorderSize = 0;
            buttonBetter6.FlatStyle = FlatStyle.Flat;
            buttonBetter6.Font = new Font("Trebuchet MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            buttonBetter6.ForeColor = Color.Lime;
            buttonBetter6.Location = new Point(121, 8);
            buttonBetter6.Name = "buttonBetter6";
            buttonBetter6.Size = new Size(151, 23);
            buttonBetter6.TabIndex = 71;
            buttonBetter6.Text = "buttonBetter6";
            buttonBetter6.UseVisualStyleBackColor = false;
            // 
            // buttonBetter7
            // 
            buttonBetter7._BackgroundColor = Color.FromArgb(64, 64, 64);
            buttonBetter7._BorderColor = Color.FromArgb(0, 192, 0);
            buttonBetter7._BorderRadius = 4;
            buttonBetter7._BorderSize = 2;
            buttonBetter7._TextColor = Color.Lime;
            buttonBetter7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonBetter7.BackColor = Color.FromArgb(64, 64, 64);
            buttonBetter7.Cursor = Cursors.Hand;
            buttonBetter7.FlatAppearance.BorderSize = 0;
            buttonBetter7.FlatStyle = FlatStyle.Flat;
            buttonBetter7.Font = new Font("Trebuchet MS", 6F, FontStyle.Bold, GraphicsUnit.Point);
            buttonBetter7.ForeColor = Color.Lime;
            buttonBetter7.Location = new Point(7, 55);
            buttonBetter7.Margin = new Padding(0);
            buttonBetter7.Name = "buttonBetter7";
            buttonBetter7.Size = new Size(80, 80);
            buttonBetter7.TabIndex = 72;
            buttonBetter7.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(20, 20, 20);
            label1.Font = new Font("Trebuchet MS", 6F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(0, 64, 0);
            label1.Location = new Point(10, 60);
            label1.Name = "label1";
            label1.Size = new Size(69, 26);
            label1.TabIndex = 73;
            label1.Text = "Version: 1.0 Lite\r\n\r\n";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(594, 143);
            Controls.Add(buttonBetter7);
            Controls.Add(EnableFisher);
            Controls.Add(buttonBetter6);
            Controls.Add(BobberDropDown);
            Controls.Add(buttonBetter5);
            Controls.Add(ClearLogBtn);
            Controls.Add(Console);
            Controls.Add(FindBobber);
            Controls.Add(BobberYNum);
            Controls.Add(BobberYLable);
            Controls.Add(BobberXNum);
            Controls.Add(BobberXLable);
            Controls.Add(buttonBetter1);
            Controls.Add(buttonBetter2);
            Controls.Add(buttonBetter4);
            Controls.Add(label1);
            Controls.Add(buttonBetter3);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(296, 182);
            Name = "Form1";
            Text = "Auto Fisher (Lite)";
            TopMost = true;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)BobberXNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)BobberYNum).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomClasses.ButtonBetter FindBobber;
        private CustomClasses.CustomNumaricUpDown BobberXNum;
        private Label BobberXLable;
        private CustomClasses.CustomNumaricUpDown BobberYNum;
        private Label BobberYLable;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private CustomClasses.ButtonBetter buttonBetter3;
        private CustomClasses.RJComboBox BobberDropDown;
        private CustomClasses.CustomCheckBox EnableFisher;
        private CustomClasses.ButtonBetter buttonBetter1;
        private RichTextBox Console;
        private CustomClasses.ButtonBetter ClearLogBtn;
        private CustomClasses.ButtonBetter buttonBetter2;
        private CustomClasses.ButtonBetter buttonBetter4;
        private CustomClasses.ButtonBetter buttonBetter5;
        private CustomClasses.ButtonBetter buttonBetter6;
        private CustomClasses.ButtonBetter buttonBetter7;
        private Label label1;
    }
}