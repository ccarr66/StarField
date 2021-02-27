using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarField
{
    public partial class StarField : Form
    {
        const int NumStars = 600;
        PointF CameraVelocityVec;
        PointF CameraAccelerationVec;
        Random CameraAdjRnd;
        Point GlobCenter;

        private bool mouseDown;
        private Point lastLocation;

        private List<Star> Stars;

        private Bitmap Background;

        private bool playMode;
        private System.Windows.Forms.Timer checkTimer;
        
        public StarField()
        {
            InitializeComponent();

            checkTimer = new System.Windows.Forms.Timer();
            checkTimer.Tick += new EventHandler(continueGame);

            Stars = new List<Star>((int)NumStars);
            GlobCenter = new Point((int)(pctBx_Display.Size.Width / 2), (int)(pctBx_Display.Size.Height / 2));

            Star.Center = new Point((int)(pctBx_Display.Size.Width / 2), (int)(pctBx_Display.Size.Height / 2));
            Star.ScreenSize = pctBx_Display.Size;

            //CameraAdjRnd = new Random();
            //CameraVelocityVec = new PointF((float)(5 * (CameraAdjRnd.NextDouble() - 0.5)), (float)(5 * (CameraAdjRnd.NextDouble() - 0.5)));
            //CameraAccelerationVec = new PointF((float)(2 * (CameraAdjRnd.NextDouble() - 0.5)), (float)(2 * (CameraAdjRnd.NextDouble() - 0.5)));
            newStars();
        }
        private void generateBackgroundImage()
        {
            Background = new Bitmap(pctBx_Display.Size.Width, pctBx_Display.Size.Height);
            for (int x = 0; x < Background.Width; x++)
                for (int y = 0; y < Background.Height; y++)
                    Background.SetPixel(x, y, Star.SkyColor);
        }
        private void updateDisplay()
        {
            int imgWidth = pctBx_Display.Width, imgHeight = pctBx_Display.Height;

            if (pctBx_Display.Image != null)
                pctBx_Display.Image.Dispose();

            /*if(CameraAdjRnd.NextDouble() > 0.8)
                CameraAccelerationVec = new PointF((float)(1 * (CameraAdjRnd.NextDouble() - 0.5)), (float)(1 * (CameraAdjRnd.NextDouble() - 0.5)));

            if (CameraAdjRnd.NextDouble() > 0.8)
                CameraVelocityVec = new PointF((float)(1 * (CameraAdjRnd.NextDouble() - 0.5)), (float)(1 * (CameraAdjRnd.NextDouble() - 0.5)));

            CameraVelocityVec.X += CameraAccelerationVec.X;
            CameraVelocityVec.Y += CameraAccelerationVec.Y;

            if (Math.Pow(Star.Center.X + (int)CameraVelocityVec.X - GlobCenter.X, 2) + Math.Pow(Star.Center.Y + (int)CameraVelocityVec.Y - GlobCenter.Y, 2) < 4000)
            {
                Star.Center.X += (int)CameraVelocityVec.X;
                Star.Center.Y += (int)CameraVelocityVec.Y;
            }*/

            Bitmap Frame = new Bitmap(Background);
            foreach (var star in Stars)
            {
                star.Move();

                star.DrawStar(ref Frame);
            }

            pctBx_Display.Image = Frame;
            pctBx_Display.Refresh();
        }

        //Event Handlers
        protected override void WndProc(ref Message m)
        {
            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg)
            {
                case 0x0084/*NCHITTEST*/ :
                    base.WndProc(ref m);

                    if ((int)m.Result == 0x01/*HTCLIENT*/)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                        {
                            /*if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)13;//HTTOPLEFT
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)12;//HTTOP
                            else
                                m.Result = (IntPtr)14;//HTTOPRIGHT*/
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10/*HTLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2/*HTCAPTION*/ ;
                            else
                                m.Result = (IntPtr)11/*HTRIGHT*/ ;
                        }
                        else
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)15/*HTBOTTOM*/ ;
                            else
                                m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
                        }
                    }
                    return;
            }
            base.WndProc(ref m);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // <--- use 0x20000
                return cp;
            }
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_DragRegion_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }
        private void btn_DragRegion_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }
        private void btn_DragRegion_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        private void StarField_ResizeEnd(object sender, EventArgs e)
        {
            resizeForm();
        }
        private void resizeForm()
        {
            this.btn_Close.Location = new Point(this.Size.Width - 20, 0);
            this.pctBx_Display.Size = new Size(this.Size.Width - pctBx_Display.Location.X - 12, this.Size.Height - pctBx_Display.Location.Y - 34);
            this.btn_DragRegion.Size = new Size(this.Size.Width - 40, 20);
            this.btn_Maximize.Location = new Point(this.Size.Width - 40, 0);

            this.btn_Play.Location = new Point(12, this.Size.Height - 27);

            this.btn_ResetImage.Location = new Point(this.Size.Width - 32, this.Size.Height - 28);

            GlobCenter = new Point((int)(pctBx_Display.Size.Width / 2), (int)(pctBx_Display.Size.Height / 2));

            Star.Center = new Point((int)(pctBx_Display.Size.Width / 2), (int)(pctBx_Display.Size.Height / 2));
            Star.ScreenSize = pctBx_Display.Size;

            newStars();
        }
        private void btn_maximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;

            StarField_ResizeEnd(sender, e);
        }
        private void btn_Play_Click(object sender, EventArgs e)
        {
            if (!playMode)
            {
                playMode = true;
                //this.btn_Play.BackgroundImage = global::StarField.Properties.Resources.Pause;
                setNextAlert();
            }
            else
            {
                playMode = false;
                //this.btn_Play.BackgroundImage = global::StarField.Properties.Resources.Play_Button;
            }
        }
        private void setNextAlert()
        {
            updateDisplay();

            checkTimer.Interval = 1;
            checkTimer.Start();
        }
        private void continueGame(object source, EventArgs e)
        {
            checkTimer.Stop();

            if (playMode)
            {
                setNextAlert();
            }

        }
        private void btn_ResetImage_Click(object sender, EventArgs e)
        {
            newStars();
        }

        private void newStars()
        {
            generateBackgroundImage();

            Stars.RemoveRange(0, Stars.Count);
            for (int st = 0; st < NumStars; st++)
                Stars.Add(new Star());

            updateDisplay();
        }
    }

    public class Star
    {
        //private static Color[] Colors = { Color.LightBlue, Color.AliceBlue, Color.Blue, Color.BlueViolet, Color.CadetBlue, Color.CornflowerBlue, Color.DarkBlue, Color.DarkSlateBlue, Color.DeepSkyBlue, Color.DodgerBlue, Color.LightSkyBlue, Color.LightSteelBlue, Color.MediumBlue, Color.MediumSlateBlue, Color.MidnightBlue, Color.PowderBlue, Color.RoyalBlue, Color.SkyBlue, Color.SlateBlue, Color.SteelBlue };
        private static Color[] Colors = { Color.LightBlue, Color.AntiqueWhite, Color.NavajoWhite, Color.GhostWhite, Color.WhiteSmoke, Color.LightYellow, Color.LightGoldenrodYellow, Color.LightCyan };
        private static Random RandStar = new Random();
        public static Size ScreenSize = new Size();
        public static Point Center = new Point();
        public static int MaxSpawnRadius = -1;
        public static int MinSpawnRadius = -1;
        public static float RadialMotion = 0.0f;
        public static float DirectionRotation = 0.0f;
        public static Color SkyColor = Color.Black;
        public static bool RandomStarColor = false;

        public Point Location;
        public int StarSize;
        public Color StarColor;

        public PointF Direction;
        public float Length;

        public float Velocity;
        public float Acceleration;
        public float Jerk;

        public Star()
        {
            Reset();

            this.Acceleration = 0.001f;
            this.Jerk = 0.0001f;
        }
        public void Move()
        {
            this.Jerk *= 1.05f;

            if (this.Acceleration < 0.1f)
                this.Acceleration += this.Jerk;

            if (this.Length <= 200)
                this.Length *= 1 + 5 * this.Acceleration;
            this.Velocity *= 1 + this.Acceleration;

            this.Location = new Point(this.Location.X + (int)(this.Velocity * Direction.X), this.Location.Y + (int)(this.Velocity * Direction.Y));

            if (RadialMotion != 0)
                this.Location = new Point((int)(Math.Cos(RadialMotion) * this.Location.X - Math.Sin(RadialMotion) * this.Location.Y), (int)(Math.Sin(RadialMotion) * this.Location.X + Math.Cos(RadialMotion) * this.Location.Y));

            if (DirectionRotation != 0)
                this.Direction = new PointF((float)(Math.Cos(DirectionRotation) * this.Direction.X - Math.Sin(DirectionRotation) * this.Direction.Y), (float)(Math.Sin(DirectionRotation) * this.Direction.X + Math.Cos(DirectionRotation) * this.Direction.Y));
        }
        public void DrawStar(ref Bitmap img)
        {
            this.StarBoundsCheck();

            var CurrLoc = this.Location;
            if (RadialMotion != 0)
                CurrLoc = new Point(CurrLoc.X + Center.X, CurrLoc.Y + Center.Y);

            var LineEnd = new Point(CurrLoc.X + (int)(this.Direction.X * this.Length), CurrLoc.Y + (int)(this.Direction.Y * this.Length));

            //Brush starPen = new Brush(); (this.StarColor this.StarSize);

            if (this.Length > 2 && LineEnd != this.Location)
            {
                var linGrBrush = new LinearGradientBrush(
                   CurrLoc,
                   LineEnd,
                   SkyColor,   
                   this.StarColor
                );  //*/

                var pen = new Pen(linGrBrush, this.StarSize);

                //e.Graphics.DrawLine(pen, 0, 10, 200, 10);
                using (var g = Graphics.FromImage(img))
                    g.DrawLine(pen, CurrLoc.X, CurrLoc.Y, LineEnd.X, LineEnd.Y);
            }
            else
                img.SetPixel(CurrLoc.X, CurrLoc.Y, this.StarColor);
        }
        public void Reset()
        {
            if (MaxSpawnRadius < 0 || MinSpawnRadius < 0)
                this.Location = new Point(RandStar.Next(0, ScreenSize.Width - 1), RandStar.Next(0, ScreenSize.Height - 1));
            else
            {
                var angle = RandStar.NextDouble() * 2 * Math.PI;
                var radius = (MaxSpawnRadius - MinSpawnRadius) * RandStar.NextDouble() + MinSpawnRadius;
                this.Location = new Point((int)(radius * Math.Cos(angle)) + Center.X, (int)(radius * Math.Sin(angle)) + Center.Y);
            }

            if (RadialMotion != 0)
            {
                this.Location = new Point(this.Location.X - Center.X, this.Location.Y - Center.Y);
                this.Direction = new PointF(this.Location.X, this.Location.Y);
            }
            else
                this.Direction = new PointF(this.Location.X - Center.X, this.Location.Y - Center.Y);

            var mag = (float)Math.Sqrt(Math.Pow(this.Direction.X, 2) + Math.Pow(this.Direction.Y, 2));
            this.Direction = new PointF(this.Direction.X / mag, this.Direction.Y / mag);

            this.StarSize = RandStar.Next(0, 4);
            if (RandomStarColor)
                this.StarColor = Color.FromArgb(RandStar.Next(0, 255), RandStar.Next(0, 255), RandStar.Next(0, 255));
            else
                this.StarColor = Colors[RandStar.Next(0, Colors.Length - 1)];

            this.Length = 1.0f;
            this.Velocity = RandStar.Next(10, 10);
        }

        private void StarBoundsCheck()
        {
            bool success = false;

            while (!success)
            {
                if (RadialMotion == 0 && (this.Location.X < 0 || this.Location.X >= ScreenSize.Width || this.Location.Y < 0 || this.Location.Y >= ScreenSize.Height))
                    this.Reset();
                else if (RadialMotion != 0)
                {
                    var CurrLoc = new Point(this.Location.X + Center.X, this.Location.Y + Center.Y);
                    if (CurrLoc.X < 0 || CurrLoc.X >= ScreenSize.Width || CurrLoc.Y < 0 || CurrLoc.Y >= ScreenSize.Height)
                        this.Reset();
                    else
                        success = true;
                }
                else
                    success = true;
            }

        }
    }
}
