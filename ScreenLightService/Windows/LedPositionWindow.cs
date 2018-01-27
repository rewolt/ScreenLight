using ScreenLightService.Models;
using ScreenLightService.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenLightService.Windows
{
    public partial class LedPositionWindow : Form
    {
        private Image frame;
        private ImageManipulator im;
        private const int windowSizePercent = 90;
        private const int imageSizePercent = 90;

        public LedPositionWindow()
        {
            InitializeComponent();

            im = new ImageManipulator();
            frame = ScreenCapturer.GetSingleFrame();
            this.Width = (int)(frame.Width * windowSizePercent / 100);
            this.Height = (int)(frame.Height * windowSizePercent / 100);
            pb_main.Image = im.ResizeImage(frame, pb_main.Width, pb_main.Height);
        }

        private void bt_reset_Click(object sender, EventArgs e)
        {
            LedEngine.RemoveAll();
        }

        private void LedPositionConfig_ResizeEnd(object sender, EventArgs e)
        {
            frame = ScreenCapturer.GetSingleFrame();
            pb_main.Image = im.ResizeImage(frame, pb_main.Width, pb_main.Height);
        }

        private void LedPositionConfig_Resize(object sender, EventArgs e)
        {
            pb_main.Height = this.Height - 150;
        }

        private void ledMarkerControl1_Load(object sender, EventArgs e)
        {

        }

        private void pb_main_Click(object sender, EventArgs e)
        {
            
        }

        private void pb_main_MouseDown(object sender, MouseEventArgs e)
        {
            var ledMarkerControl = new LEDMarkerControl.LEDMarkerControl();
            ledMarkerControl.BackColor = System.Drawing.Color.Transparent;
            ledMarkerControl.Location = new System.Drawing.Point(e.Y, e.X);
            ledMarkerControl.Name = "ledMarkerControl1";
            ledMarkerControl.Size = new System.Drawing.Size(12, 12);
            ledMarkerControl.TabIndex = 5;
            this.Controls.Add(ledMarkerControl);
        }
    }
}
