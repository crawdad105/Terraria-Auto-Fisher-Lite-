using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace fishingtest4
{
    public partial class Form1 : Form
    {
        public class Bobber
        {
            public Bobber(int[][]? PixleChecks, Point[] ColorPoints)
            {
                this.PixleChecks = PixleChecks;
                this.ColorPoints = ColorPoints;
            }
            public int[][]? PixleChecks;
            public Point[] ColorPoints;
        }

        public static Bobber[] Bobbers = new Bobber[]
        {
            // Wood
            new Bobber(new int[][]{
                new int[8] { 0, 0, 0, 0, 0, 1, 1, 1},
                new int[8] { 0, 0, 0, 0, 1, 0, 2, 1},
                new int[8] { 0, 0, 0, 1, 0, 2, 0, 1},
                new int[8] { 0, 0, 0, 1, 3, 0, 1, 0},
                new int[8] { 0, 0, 4, 3, 1, 1, 0, 0},
                new int[8] { 0, 4, 5, 0, 5, 4, 0, 0},
            },new Point[]{ new Point(7, 0), new Point(6, 1), new Point(4, 3), new Point(2, 4), new Point(2, 5) }),
            // Iron
            new Bobber(new int[][]{
                new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                new int[9] { 0, 1, 1, 1, 1, 1, 1, 1, 0},
                new int[9] { 0, 1, 2, 3, 3, 3, 2, 1, 0},
            },new Point[]{ new Point(1, 2) , new Point(2, 2) , new Point(3, 2) }),
            // Coruption Fisher
            new Bobber(new int[][]{
                new int[9] { 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                new int[9] { 0, 0, 0, 1, 2, 1, 0, 0, 0 },
                new int[9] { 1, 1, 0, 1, 3, 1, 0, 1, 1 },
                new int[9] { 1, 2, 1, 3, 0, 3, 1, 2, 1 },
                new int[9] { 1, 3, 3, 2, 3, 2, 3, 3, 1 },
            }, new Point[]{ new Point(4, 0), new Point(4, 1), new Point(4, 2)}),
            // Crimzon
            new Bobber(new int[][]{
                new int[10] { 0, 0, 0, 0, 0, 1, 1, 0, 0, 0},
                new int[10] { 0, 0, 0, 0, 1, 2, 3, 1, 0, 0},
                new int[10] { 0, 0, 0, 1, 2, 1, 1, 3, 1, 0},
                new int[10] { 0, 1, 1, 1, 3, 1, 0, 1, 2, 1},
                new int[10] { 1, 2, 4, 1, 3, 1, 1, 1, 3, 1},
                new int[10] { 1, 3, 1, 1, 4, 1, 4, 1, 3, 1},
            },new Point[]{ new Point(0, 5),  new Point(1, 4) ,  new Point(1, 5)  ,  new Point(2, 4) }),
            //Chum
            new Bobber(new int[][]{
                new int[7] { 0, 0, 1, 1, 2, 0, 0},
                new int[7] { 0, 1, 3, 3, 0, 2, 0},
                new int[7] { 1, 3, 0, 0, 3, 1, 0},
            },new Point[]{ new Point(2, 0) , new Point(4, 0) , new Point(1, 2)}),
            // Desert
            new Bobber(new int[][]{
                new int[9] { 3, 0, 0, 1, 0, 1, 0, 0, 3},
                new int[9] { 0, 2, 1, 0, 1, 5, 1, 2, 0},
                new int[9] { 0, 1, 0, 4, 1, 4, 5, 1, 0},
            },new Point[]{ new Point(3, 0) , new Point(1, 1) , new Point(0, 0) , new Point(3, 2)  , new Point(5, 1) }),
            // Jungle
            new Bobber(new int[][]{
                new int[7] { 0, 0, 0, 0, 0, 0, 0},
                new int[7] { 0, 0, 1, 1, 1, 0, 0},
                new int[7] { 0, 1, 2, 3, 2, 1, 0},
                new int[7] { 1, 2, 3, 4, 4, 2, 1},
            },new Point[]{ new Point(2, 1) , new Point(2, 2) , new Point(3, 2) , new Point(3, 3)}),
            // Mecahntcs
            new Bobber(new int[][]{
                new int[7] { 0, 0, 0, 0, 0, 0, 0},
                new int[7] { 0, 0, 1, 1, 1, 0, 0},
                new int[7] { 0, 1, 2, 3, 2, 1, 0},
                new int[7] { 1, 4, 3, 2, 2, 4, 1},
            },new Point[]{ new Point(2, 1) , new Point(2, 2) , new Point(3, 2) , new Point(1, 3)}),
            // Duck
            new Bobber(new int[][]{// Duck Fisher
                new int[9] { 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                new int[9] { 0, 0, 0, 1, 0, 1, 0, 0, 0 },
                new int[9] { 0, 0, 0, 1, 2, 1, 0, 0, 0 },
                new int[9] { 1, 1, 0, 1, 0, 1, 0, 1, 1 },
                new int[9] { 1, 2, 1, 3, 0, 3, 1, 2, 1 },
            }, new Point[]{ new Point(4, 0), new Point(4, 2), new Point(5, 4)}),
            // fire
            new Bobber(new int[][]{
                new int[9] { 0, 0, 0, 0, 3, 0, 0, 0, 0},
                new int[9] { 0, 0, 0, 3, 2, 3, 0, 0, 0},
                new int[9] { 0, 0, 4, 2, 1, 2, 4, 0, 0},
                new int[9] { 0, 4, 2, 1, 1, 1, 2, 4, 0},
                new int[9] { 0, 3, 2, 1, 1, 1, 2, 3, 0},
                new int[9] { 0, 5, 1, 1, 1, 1, 1, 5, 0},
            },new Point[]{ new Point(4, 2), new Point(4, 1), new Point(4, 0), new Point(1, 3), new Point(1, 5)}),
            // Gold
            new Bobber(new int[][]{
                new int[7] { 0, 0, 0, 0, 0, 0, 0},
                new int[7] { 0, 0, 1, 1, 1, 0, 0},
                new int[7] { 0, 1, 2, 3, 4, 1, 0},
                new int[7] { 1, 2, 0, 4, 3, 3, 1},
            },new Point[]{ new Point(2, 1) , new Point(2, 2) , new Point(3, 2) , new Point(4, 2)}),
        };

        public Rectangle ViewPortRect { get { return new Rectangle((int)BobberXNum.Value, (int)BobberYNum.Value, 80, 80); } }

        public Bitmap ViewPortImage;
        public Bitmap ScreenImage;

        public bool FoundBobber;
        public bool ValidBobber;

        public bool ProgramRuning;
        public bool PauseAutoFisher;
        public bool UseBobberAccessories;

        public bool ShowDebug;
        public bool ClickAtBobber;

        public bool AutoFisherEnabled
        {
            get { return EnableFisher.Checked; }
            set { EnableFisher.Invoke(() => EnableFisher.Checked = value); }
        }
        /// 
        /// Bigger Functions
        ///

        public bool CheckImageForBobber(Bitmap image, int x, int y, Bobber bobber)
        {
            List<Color> colors = new List<Color>();
            for (int i = 0; i < bobber.ColorPoints.Length; i++)
            {
                colors.Add(image.GetPixel(x + bobber.ColorPoints[i].X, y + bobber.ColorPoints[i].Y));
                if (colors.Count > 1)
                    if (colors[i - 1] == colors[i])
                        return false;
            }
            if (colors.Count > 1)
                if (colors[0] == colors[colors.Count - 1])
                    return false;

            for (int y2 = 0; y2 < bobber.PixleChecks.Length; y2++)
            {
                for (int x2 = 0; x2 < bobber.PixleChecks[0].Length; x2++)
                {
                    Color Pixle = image.GetPixel(x + x2, y + y2);

                    if (bobber.PixleChecks[y2][x2] == 0)
                        for (int i = 0; i < colors.Count; i++)
                        {
                            if (Pixle == colors[i])
                                return false;
                        }

                    for (int i = 1; i < 4; i++)
                    {
                        if (bobber.PixleChecks[y2][x2] == (i + 1))
                            if (Pixle != colors[i])
                                return false;
                    }
                }
            }
            return true;
        }
        public void FindBobberInViewPort()
        {
            if (ValidBobber == false)
            {
                Log($"Invalid pole.", "Bobber Detection");
                AutoFisherEnabled = false;
                return;
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();

            Bobber? bobber = null;

            BobberDropDown.Invoke(() =>
            {
                bobber = Bobbers[BobberDropDown.AfterSelectIndex];
            });

            if (bobber == null || bobber.PixleChecks == null)
            {
                if (bobber != null)
                    if (bobber.PixleChecks == null)
                        AutoFisherEnabled = false;
                return;
            }

            Bitmap ScreenImage = new Bitmap(ViewPortRect.Width / 2, ViewPortRect.Height / 2);
            Graphics g = Graphics.FromImage(ScreenImage);
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.DrawImage(ViewPortImage, 0, 0, ScreenImage.Width, ScreenImage.Height);

            for (int y = 0; y < ScreenImage.Width - bobber.PixleChecks.Length; y++)
            {
                for (int x = 0; x < ScreenImage.Width - bobber.PixleChecks[0].Length; x++)
                {
                    if (CheckImageForBobber(ScreenImage, x, y, bobber))
                    {

                        stopwatch.Stop();
                        if (FoundBobber == false) Log($"Bobber Detected ({stopwatch.ElapsedMilliseconds}ms)", "Bobber Detection");
                        FoundBobber = true;
                        return;
                    }
                }
            }
            stopwatch.Stop();
            if (FoundBobber)
            {
                FoundBobber = false;
                Log($"Detected Movment ({stopwatch.ElapsedMilliseconds}ms)", "Bobber Detection");
                CatchFish();
            }
            else
                Log($"Bobber Not Detected ({stopwatch.ElapsedMilliseconds}ms)", "Bobber Detection");
        }
        public void FindBobberInScreen()
        {
            if (ValidBobber == false)
            {
                Log($"Invalid pole.", "screen search");
                AutoFisherEnabled = false;
                return;
            }

            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();

            Bobber? bobber = null;

            BobberDropDown.Invoke(() =>
            {
                bobber = Bobbers[BobberDropDown.AfterSelectIndex];
            });

            if (bobber == null || bobber.PixleChecks == null)
            {
                if (bobber != null)
                    if (bobber.PixleChecks == null)
                        AutoFisherEnabled = false;
                return;
            }

            GetScreenImage();
            Bitmap image = new Bitmap(ScreenImage.Width / 2, ScreenImage.Height / 2);
            Graphics g = Graphics.FromImage(image);
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.DrawImage(ScreenImage, 0, 0, image.Width, image.Height);

            for (int y = 0; y < image.Height - bobber.PixleChecks.Length; y++)
            {
                for (int x = 0; x < image.Width - bobber.PixleChecks[0].Length; x++)
                {
                    if (CheckImageForBobber(image, x, y, bobber))
                    {
                        stopwatch.Stop();
                        Log($"Bobber Was Found! ({stopwatch.ElapsedMilliseconds}ms)", "screen search");
                        BobberXNum.Value = (x * 2) - (ViewPortRect.Size.Width / 2) + 8;
                        BobberYNum.Value = (y * 2) - (ViewPortRect.Size.Height / 2) + 4;
                        return;
                    }
                }
            }
            stopwatch.Stop();
            Log($"Bobber Was Not Found. ({stopwatch.ElapsedMilliseconds}ms)", "screen search");
        }
        public void CatchFish()
        {
            PauseAutoFisher = true;

            Stopwatch sw = Stopwatch.StartNew();

            for (int i = 0; i < 2; i++)
            {
                mouse_event(MOUSE_LEFT_DOWN, 0, 0, 0, 0);
                Thread.Sleep(50);
                mouse_event(MOUSE_LEFT_UP, 0, 0, 0, 0);

                if (i == 0) Log($"Fishing Pole Realed (Mouse Clicked) ({sw.ElapsedMilliseconds}ms)", "Mouse Clicker");
                if (i == 1) Log($"Fishing Pole Casted (Mouse Clicked) ({sw.ElapsedMilliseconds}ms)", "Mouse Clicker");

                Thread.Sleep(250);
            }
            Thread.Sleep(500);

            PauseAutoFisher = false;
        }

        public void RenderViewPort()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();

            Bitmap DesplayPortImage = new Bitmap(ViewPortRect.Size.Width, ViewPortRect.Size.Height);
            Graphics.FromImage(DesplayPortImage).CopyFromScreen(new Point(SystemInformation.VirtualScreen.Left + ViewPortRect.Location.X, SystemInformation.VirtualScreen.Top + ViewPortRect.Location.Y), new Point(0, 0), DesplayPortImage.Size);
            try
            {
                buttonBetter7.Image = DesplayPortImage;
                ViewPortImage = DesplayPortImage;
            }
            catch (Exception e)
            {

            }

            stopwatch.Stop();
        }
        public Bitmap GetScreenImage()
        {
            Bitmap ScreenImage = new Bitmap(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height);
            Graphics g = Graphics.FromImage(ScreenImage);
            g.CopyFromScreen(SystemInformation.VirtualScreen.X, SystemInformation.VirtualScreen.Y, 0, 0, ScreenImage.Size);
            this.ScreenImage = ScreenImage;
            return ScreenImage;
        }

        public void Log(string _str = "", string _level = "", bool Clear = false)
        {
            Thread thread = new Thread(() =>
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                string time = $"[{DateTime.Now.TimeOfDay.Hours}:{DateTime.Now.TimeOfDay.Minutes}:{DateTime.Now.TimeOfDay.Seconds}.{DateTime.Now.TimeOfDay.Milliseconds}]";
                string space = "";
                for (int i = 0; i < 14 - time.Length; i++) space += " ";
                if (_level.Length > 0) _level = $"[{_level}] ";
                if (Clear)
                {
                    Console.Invoke(new Action(() =>
                    {
                        Console.Text = "";
                    }));
                    if (_str == "")
                        return;
                }
                Console.Invoke(new Action(() =>
                {
                    if (_level != "[test] ") Console.AppendText($"{time}{space} {_level}{_str}\n");
                    else Console.AppendText($"{time}{space} {_level}{_str} ({stopwatch.Elapsed.Milliseconds}ms)\n");
                    Console.ScrollToCaret();
                }));
            });

            thread.Start();
        }

        [DllImport("user32.dll")]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(int i);
        const int MOUSE_LEFT_DOWN = 0x02;
        const int MOUSE_LEFT_UP = 0x04;

        public Form1()
        {
            ProgramRuning = false;
            InitializeComponent();

            Log(Clear: true);

            this.ResizeRedraw = true;
            this.DoubleBuffered = true;

            BobberXNum.Value = SystemInformation.VirtualScreen.Width / 2;
            BobberYNum.Value = SystemInformation.VirtualScreen.Height / 2;

            ProgramRuning = true;

            SetWindowPos(this.Handle, new IntPtr(-1), 0, 0, 0, 0, 0x0002 | 0x0001);
        }
        private void Form1_Load(object sender, EventArgs e)
        { 
            Log("Program Started!");
            MessageBox.Show("Thank you for downloading this auto fisher!\nCurrintly this is only a lite version of what is yet to come.\nIf you come across any errors be sure to report them somewere.", "Auto Fisher", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        }

        private void FindBobber_Click(object sender, EventArgs e)
        { FindBobberInScreen(); }

        private void ClearLogBtn_Click(object sender, EventArgs e)
        { Log("Log Cleared", Clear: true); }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RenderViewPort();
            if (AutoFisherEnabled && !PauseAutoFisher)
                FindBobberInViewPort();
        }
        private void BobberSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidBobber = Bobbers[BobberDropDown.AfterSelectIndex].PixleChecks == null ? false : true;
            if (Bobbers[BobberDropDown.AfterSelectIndex].PixleChecks == null)
                AutoFisherEnabled = false;

            if (!ValidBobber)
                Log($"The selected fishing pole has not been implamented yet", "Invalid pole");
            else
            {
                Log($"Bobber swiched to " + BobberDropDown.SelectedItem.ToString().Replace("*", ""), "Bobber swich");
                if (BobberDropDown.SelectedItem.ToString().Contains("*"))
                {
                    Log($"* Detection this bobber is inacurit you might need to manualy set the location.", "Warning");
                    Log($"* This bobber will only work if the WAVES QUALITY in the game is OFF.", "Warning");
                }

            }
            FoundBobber = false;
            PauseAutoFisher = false;
        }

        private void BobberXNum_ValueChanged(object sender, EventArgs e)
        {
            if (ProgramRuning) RenderViewPort();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (GetAsyncKeyState((int)Keys.F5) == 32769)
                AutoFisherEnabled = !AutoFisherEnabled;
        }
    }
}