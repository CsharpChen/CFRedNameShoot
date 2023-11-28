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
        //�ƶ���� 
        const int MOUSEEVENTF_MOVE = 0x0001;
        //ģ������������ 
        const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        //ģ��������̧�� 
        const int MOUSEEVENTF_LEFTUP = 0x0004;
        //ģ������Ҽ����� 
        const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
        //ģ������Ҽ�̧�� 
        const int MOUSEEVENTF_RIGHTUP = 0x0010;
        //ģ������м����� 
        const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        //ģ������м�̧�� 
        const int MOUSEEVENTF_MIDDLEUP = 0x0040;
        //��ʾ�Ƿ���þ������� 
        const int MOUSEEVENTF_ABSOLUTE = 0x8000;

        bool savedesktop = false;
        int xxx = 0;
        private KeyboardHookLib _keyboardHook = null;
        private Screen CurrentScreen = null;
        private int w = 0;
        private int h = 0;
        Rectangle rc = new Rectangle();
        string KJ = "��ʼ��ȡ��Ļ";
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
            handle = false; //Ԥ�費�����κμ�
            xxx++;
            if (xxx % 2 == 0)
            {
                return;
            }
            Keys key = (Keys)hookStruct.vkCode;
            if (key == Keys.Q)
            {
                // �˳�����
                this.Close();
            }
            if (key == Keys.F1)
            {
                //F1   ����ʼ/��������ȡ��Ļq
                button1.PerformClick();
            }
            if (key == Keys.F2)
            {
                //F2   ����ʼ/�������жϺ���
                if (label7.Text == "��") { BlackLabelText(label7); }
                else if (label7.Text == "��") { RedLabelText(label7); }
            }
            if (key == Keys.F3)
            {
                //F3   ȫ������
                button1.Text = "��ʼ��ȡ��Ļ";
                BlackLabelText(label6);
                BlackLabelText(label7);
            }
            if (key == Keys.F4)
            {
                //F4          ����һ�ŵ�ǰͼƬ
                if (button1.Text == "������ȡ��Ļ") { savedesktop = true; }
            }
            return;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(rc.Width, rc.Height, PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bitmap);
            if (button1.Text == "��ʼ��ȡ��Ļ")
            {
                RedLabelText(label6);
                button1.Text = "������ȡ��Ļ";
                while (button1.Text == "������ȡ��Ļ")
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
                    if (label7.Text == "��") { RedName(img); }
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
            else if (button1.Text == "������ȡ��Ļ")
            {
                button1.Text = "��ʼ��ȡ��Ļ";
                BlackLabelText(label6);
                BlackLabelText(label7);
                g.Dispose();
                bitmap.Dispose();
            }
        }

        /// <summary>
        /// �жϺ���
        /// </summary>
        /// <param name="bitmap"></param>
        void RedName(Bitmap bitmap)
        {
            int Width = bitmap.Width / 2 - Convert.ToInt32(bitmap.Width * 0.04);
            int Height = bitmap.Height / 2 + Convert.ToInt32(bitmap.Width * 0.02);
            //�������ζ����ʾԭͼ�ϲü��ľ������������൱�ڻ���ԭͼ������Ϊ(150, 50)����50x50��С�ľ�������Ϊ�ü�����
            Rectangle cropRegion = new Rectangle(Width, Height, 150, 50);
            //�����հ׻�������СΪ�ü������С
            Bitmap result = new Bitmap(cropRegion.Width, cropRegion.Height);
            //����Graphics���󣬲�ָ��Ҫ��result��Ŀ��ͼƬ�������ϻ���ͼ��
            Graphics graphics = Graphics.FromImage(result);
            //ʹ��Graphics�����ԭͼָ������ͼ��ü������������ոմ����Ŀհ׻���
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
                // ��Ҫ��ǹ
                RedLabelText(label12);
                mouse_event(MOUSEEVENTF_LEFTDOWN , Convert.ToInt32(txt_mouse_x_point), Convert.ToInt32(txt_mouse_y_point), 0, 0);
                mouse_event(MOUSEEVENTF_LEFTUP, Convert.ToInt32(txt_mouse_x_point), Convert.ToInt32(txt_mouse_y_point), 0, 0);
            }
            else
            {
                // ����Ҫ��ǹ
                BlackLabelText(label12);
            }
            graphics.Dispose();
            result.Dispose();
        }


        void RedLabelText(Label label, string text = "��")
        {
            label.Text = text;
            label.ForeColor = Color.Red;
        }
        void BlackLabelText(Label label, string text = "��")
        {
            label.Text = text;
            label.ForeColor = Color.Black;
        }
    }
}
