using ScreenLightService.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using System.Drawing;

namespace ScreenLightServiceTests
{
    [TestClass]
    public class ScreenCapturerTests
    {
        [TestMethod]
        public void GetSingleFrame_GetsFrameFromScreen_Screenshot()
        {
            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            var frame = ScreenCapturer.GetSingleFrame();

            Assert.AreEqual(true, frame != null);
            Assert.AreEqual(resolution.Height, frame.Height);
            Assert.AreEqual(resolution.Width, frame.Width);
        }
    }
}
