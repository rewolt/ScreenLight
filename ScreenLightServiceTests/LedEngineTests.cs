using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace ScreenLightServiceTests
{
    [TestClass]
    public class LedEngineTests
    {
        [DataTestMethod]
        [DataRow(0, 0, 0)]
        [DataRow(100, 200, 255)]
        public void SetLedColor_SetColorOnParticularLed_LedColor(int ledX, int ledY, int colorValue)
        {
            var point = new ScreenLightService.Models.Point
            {
                X = ledX,
                Y = ledY
            };
            var color1 = Color.Red;
            var color2 = Color.FromArgb(colorValue, colorValue, colorValue, colorValue);

            ScreenLightService.Classes.LedEngine.AddOrUpdate(point, color1);
            ScreenLightService.Classes.LedEngine.AddOrUpdate(point, color2);

            Assert.AreNotEqual(Color.Blue, ScreenLightService.Classes.LedEngine.GetColor(point));
            Assert.AreEqual(Color.FromArgb(colorValue, colorValue, colorValue, colorValue), ScreenLightService.Classes.LedEngine.GetColor(point));
        }
    }
}
