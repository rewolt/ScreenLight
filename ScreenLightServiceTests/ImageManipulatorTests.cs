using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScreenLightService.Classes;
using System.Drawing;

namespace ScreenLightServiceTests
{
    [TestClass]
    public class ImageManipulatorTests
    {
        [TestMethod]
        public void ResizeImage_ResizeImage_SmallerImage()
        {
            var manipulator = new ImageManipulator();
            var image = new Bitmap(1000, 1000);
            
            var newImage = manipulator.ResizeImage(image, 500, 500);

            Assert.AreEqual(true, newImage != null);
            Assert.AreEqual(500, newImage.Width);
            Assert.AreEqual(500, newImage.Height);
        }
    }
}
