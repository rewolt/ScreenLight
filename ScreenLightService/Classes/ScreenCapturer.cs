using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;

namespace ScreenLightService.Classes
{
    class ScreenCapturer
    {
        private Image screen;
        private CancellationTokenSource cts;
        private Task frameRecorder;
        public Image GetActualFrame()
        {
            if (frameRecorder == null) return null;
            return screen;
        }

        public static Image GetSingleFrame()
        {
            var handle = User32.GetDesktopWindow();
            // get te hDC of the target window
            IntPtr hdcSrc = User32.GetWindowDC(handle);
            // get the size
            User32.RECT windowRect = new User32.RECT();
            User32.GetWindowRect(handle, ref windowRect);
            int width = windowRect.right - windowRect.left;
            int height = windowRect.bottom - windowRect.top;
            // create a device context we can copy to
            IntPtr hdcDest = GDI32.CreateCompatibleDC(hdcSrc);
            IntPtr hBitmap;
            IntPtr hOld;
            // create a bitmap we can copy it to,
            // using GetDeviceCaps to get the width/height
            hBitmap = GDI32.CreateCompatibleBitmap(hdcSrc, width, height);
            // select the bitmap object
            hOld = GDI32.SelectObject(hdcDest, hBitmap);
            // select the bitmap object
            hOld = GDI32.SelectObject(hdcDest, hBitmap);
            // bitblt over
            GDI32.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, GDI32.SRCCOPY);
            // restore selection
            GDI32.SelectObject(hdcDest, hOld);
            // get a .NET image object for it
            var screen = Image.FromHbitmap(hBitmap);
            // clean up 
            // free up the Bitmap object
            GDI32.DeleteObject(hBitmap);
            GDI32.DeleteDC(hdcDest);
            User32.ReleaseDC(handle, hdcSrc);
            GC.Collect();
            return screen;
        }

        public void Start()
        {
            cts = new CancellationTokenSource();
            frameRecorder = new Task(() => CaptureFrame(User32.GetDesktopWindow(), cts.Token));
            frameRecorder.Start();
        }

        public void Stop()
        {
            cts?.Cancel();
        }

        private void CaptureFrame(IntPtr handle, CancellationToken token)
        {
            // get te hDC of the target window
            IntPtr hdcSrc = User32.GetWindowDC(handle);
            // get the size
            User32.RECT windowRect = new User32.RECT();
            User32.GetWindowRect(handle, ref windowRect);
            int width = windowRect.right - windowRect.left;
            int height = windowRect.bottom - windowRect.top;
            // create a device context we can copy to
            IntPtr hdcDest = GDI32.CreateCompatibleDC(hdcSrc);
            IntPtr hBitmap;
            IntPtr hOld;
            // create a bitmap we can copy it to,
            // using GetDeviceCaps to get the width/height
            hBitmap = GDI32.CreateCompatibleBitmap(hdcSrc, width, height);
            // select the bitmap object
            hOld = GDI32.SelectObject(hdcDest, hBitmap);

            try
            {
                while (true)
                {
                    token.ThrowIfCancellationRequested();
                    // select the bitmap object
                    hOld = GDI32.SelectObject(hdcDest, hBitmap);
                    // bitblt over
                    GDI32.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, GDI32.SRCCOPY);
                    // restore selection
                    GDI32.SelectObject(hdcDest, hOld);
                    // get a .NET image object for it
                    screen = Image.FromHbitmap(hBitmap);
                    GC.Collect();
                }
            }
            catch (TaskCanceledException ex)
            {
                // clean up 
                // free up the Bitmap object
                GDI32.DeleteObject(hBitmap);
                GDI32.DeleteDC(hdcDest);
                User32.ReleaseDC(handle, hdcSrc);
                Logger.Log(ex);
            }
            
        }

        /// <summary>
        /// Helper class containing Gdi32 API functions
        /// </summary>
        private class GDI32
        {

            public const int SRCCOPY = 0x00CC0020; // BitBlt dwRop parameter

            [DllImport("gdi32.dll")]
            public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest,
                int nWidth, int nHeight, IntPtr hObjectSource,
                int nXSrc, int nYSrc, int dwRop);
            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth,
                int nHeight);
            [DllImport("gdi32.dll")]
            public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
            [DllImport("gdi32.dll")]
            public static extern bool DeleteDC(IntPtr hDC);
            [DllImport("gdi32.dll")]
            public static extern bool DeleteObject(IntPtr hObject);
            [DllImport("gdi32.dll")]
            public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
        }

        /// <summary>
        /// Helper class containing User32 API functions
        /// </summary>
        private class User32
        {
            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public int left;
                public int top;
                public int right;
                public int bottom;
            }

            [DllImport("user32.dll")]
            public static extern IntPtr GetDesktopWindow();
            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowDC(IntPtr hWnd);
            [DllImport("user32.dll")]
            public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);
            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowRect(IntPtr hWnd, ref RECT rect);

        }
    }
}
