using ScreenLightService.Interfaces;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System;

namespace ScreenLightService.Classes
{
    public class ImageManipulator : IImageManipulate
    {
        public Rectangle Rectangle { get; set; }
        public Bitmap Image { get; set; }

        public Image ImageResize()
        {
            throw new NotImplementedException();
        }

        public Image ResizeImage(Image image, int width, int height)
        {
            Rectangle = new Rectangle(0, 0, width, height);
            Image = new Bitmap(width, height);

            Image.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(Image))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighSpeed;
                graphics.InterpolationMode = InterpolationMode.Default;
                graphics.SmoothingMode = SmoothingMode.HighSpeed;
                graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, Rectangle, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return Image;
        }
    }
}
