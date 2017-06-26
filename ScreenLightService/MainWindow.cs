using System;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace ScreenLightService
{
    public partial class MainWindow : Form
    {
        ScreenCapturer _screenCapturer;

        public MainWindow()
        {
            InitializeComponent();
            _screenCapturer = new ScreenCapturer();
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Minimized)
            {
                notifyIcon.Visible = true;
                this.Hide();
            }
            else if(WindowState == FormWindowState.Normal 
                || WindowState == FormWindowState.Maximized)
            {
                notifyIcon.Visible = false;
            }
        }


        private static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Image = ResizeImage(_screenCapturer.GetFrame(), pictureBox1.Width, pictureBox1.Height);
        }
    }
}
