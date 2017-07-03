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
    public partial class LedPositionConfig : Form
    {
        private LEDList ledList;

        public LedPositionConfig()
        {
            InitializeComponent();
            ledList = new LEDList();

            ImageManipulator im = new ImageManipulator();
            pb_main.Image = im.ResizeImage(ScreenCapturer.GetSingleFrame(), pb_main.Width, pb_main.Height);
        }

        private void bt_reset_Click(object sender, EventArgs e)
        {
            ledList = null;
        }
    }
}
