using System.Drawing;

namespace ScreenLightService.Interfaces
{
    public interface IImageManipulate
    {
        Rectangle Rectangle { get; set; }
        Bitmap Image { get; set; }
        Image ImageResize();
    }
}
