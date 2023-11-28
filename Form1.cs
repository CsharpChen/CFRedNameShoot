using System;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        [DllImport("user32")]
        private static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        [DllImport("user32.dll")]
        private static extern int SetCursorPos(int x, int y);
        private string txt_mouse_x_point = "0";
        private string txt_mouse_y_point = "0";
        //移动鼠标 
        const int MOUSEEVENTF_MOVE = 0x0001;
        //模拟鼠标左键按下 
        const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        //模拟鼠标左键抬起 
        const int MOUSEEVENTF_LEFTUP = 0x0004;
        //模拟鼠标右键按下 
        const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        //模拟鼠标右键抬起 
        const int MOUSEEVENTF_RIGHTUP = 0x0010;
        //模拟鼠标中键按下 
        const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        //模拟鼠标中键抬起 
        const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        //标示是否采用绝对坐标 
        const int MOUSEEVENTF_ABSOLUTE = 0x8000;

        bool savedesktop = false;
        int xxx = 0;
        private KeyboardHookLib _keyboardHook = null;
        private Screen CurrentScreen = null;
        private int w = 0;
        private int h = 0;
        Rectangle rc = new Rectangle();
        string KJ = "开始获取屏幕";
        public Form1()
        {
            InitializeComponent();
            Init();
        }
        void Init()
        {
            Screen[] s = Screen.AllScreens;
            CurrentScreen = s[0];
            w = CurrentScreen.Bounds.Width;
            h = CurrentScreen.Bounds.Height;
            rc = new Rectangle(0, 0, w, h);
            button1.Text = KJ;
            this.Text = Guid.NewGuid().ToString();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            _keyboardHook = new KeyboardHookLib();
            _keyboardHook.InstallHook(this.OnKeyPress);
        }
        public void OnKeyPress(KeyboardHookLib.HookStruct hookStruct, out bool handle)
        {
            handle = false; //预设不拦截任何键
            xxx++;
            if (xxx % 2 == 0)
            {
                return;
            }
            Keys key = (Keys)hookStruct.vkCode;
            if (key == Keys.Q)
            {
                // 退出程序
                this.Close();
            }
            if (key == Keys.F1)
            {
                //F1   【开始/结束】获取屏幕q
                button1.PerformClick();
            }
            if (key == Keys.F2)
            {
                //F2   【开始/结束】判断红名
                if (label7.Text == "是") { BlackLabelText(label7); }
                else if (label7.Text == "否") { RedLabelText(label7); }
            }
            if (key == Keys.F3)
            {
                //F3   全部结束
                button1.Text = "开始获取屏幕";
                BlackLabelText(label6);
                BlackLabelText(label7);
            }
            if (key == Keys.F4)
            {
                //F4          保存一张当前图片
                if (button1.Text == "结束获取屏幕") { savedesktop = true; }
            }
            return;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(rc.Width, rc.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bitmap);
            if (button1.Text == "开始获取屏幕")
            {
                RedLabelText(label6);
                button1.Text = "结束获取屏幕";
                while (button1.Text == "结束获取屏幕")
                {
                    g.CopyFromScreen(rc.X, rc.Y, 0, 0, rc.Size, CopyPixelOperation.SourceCopy);

//                    var tpdz = @"F:\Code\VS\C#\WinForm\WinFormsApp1\bin\Debug\net8.0-windows\2023-11-28\1701116836.png";
//                    System.Drawing.Image originImage = System.Drawing.Image.FromFile(tpdz);
//                    Bitmap bitmap222 = new Bitmap(originImage);//new Bitmap(rc.Width, rc.Height, PixelFormat.Format32bppArgb);

//                    var img = bitmap222;

//#if !DEBUG
// var img = bitmap;
//#endif
                    var img = bitmap;
                    pictureBox1.Image = img;
                    this.Text = Guid.NewGuid().ToString();
                    if (label7.Text == "是") { RedName(img); }
                    if (savedesktop)
                    {
                        savedesktop = false;
                        var path = DateTime.Now.ToString("yyyy-MM-dd");
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                        img.Save(path + "//" + Convert.ToInt64(ts.TotalSeconds).ToString() + ".png", ImageFormat.Png);
                    }
                    Application.DoEvents();
                }
            }
            else if (button1.Text == "结束获取屏幕")
            {
                button1.Text = "开始获取屏幕";
                BlackLabelText(label6);
                BlackLabelText(label7);
                g.Dispose();
                bitmap.Dispose();
            }
        }

        /// <summary>
        /// 判断红名
        /// </summary>
        /// <param name="bitmap"></param>
        void RedName(Bitmap bitmap)
        {
            int Width = bitmap.Width / 2 - Convert.ToInt32(bitmap.Width * 0.04);
            int Height = bitmap.Height / 2 + Convert.ToInt32(bitmap.Width * 0.02);
            //创建矩形对象表示原图上裁剪的矩形区域，这里相当于划定原图上坐标为(150, 50)处，50x50大小的矩形区域为裁剪区域
            Rectangle cropRegion = new Rectangle(Width, Height, 150, 50);
            //创建空白画布，大小为裁剪区域大小
            Bitmap result = new Bitmap(cropRegion.Width, cropRegion.Height);
            //创建Graphics对象，并指定要在result（目标图片画布）上绘制图像
            Graphics graphics = Graphics.FromImage(result);
            //使用Graphics对象把原图指定区域图像裁剪下来并填充进刚刚创建的空白画布
            graphics.DrawImage(bitmap, new Rectangle(0, 0, cropRegion.Width, cropRegion.Height), cropRegion, GraphicsUnit.Pixel);

            Color pixelColor = result.GetPixel(75, 25);
            BlackLabelText(label13, pixelColor.ToString());
            pictureBox2.Image = result;

            Bitmap resultxx = new Bitmap(cropRegion.Width, cropRegion.Height);
            Graphics g1 = Graphics.FromImage(resultxx); 
            SolidBrush pixelBrush = new SolidBrush(pixelColor);
            g1.FillRectangle(pixelBrush, 0, 0, 100, 100);
            pictureBox3.Image = resultxx;
            Application.DoEvents();
            if (pixelColor.R >= 110 && pixelColor.G <= 80 && pixelColor.B <= 80)
            {
                // 需要开枪
                RedLabelText(label12);
                mouse_event(MOUSEEVENTF_LEFTDOWN , Convert.ToInt32(txt_mouse_x_point), Convert.ToInt32(txt_mouse_y_point), 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, Convert.ToInt32(txt_mouse_x_point), Convert.ToInt32(txt_mouse_y_point), 0, 0);
            }
            else
            {
                // 不需要开枪
                BlackLabelText(label12);
            }
            graphics.Dispose();
            result.Dispose();
        }


        void RedLabelText(Label label, string text = "是")
        {
            label.Text = text;
            label.ForeColor = Color.Red;
        }
        void BlackLabelText(Label label, string text = "否")
        {
            label.Text = text;
            label.ForeColor = Color.Black;
        }
    }
}
