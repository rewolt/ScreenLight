using System.Drawing;
using System.Windows.Forms;

namespace LEDMarkerControl
{
    public partial class LEDMarkerControl : UserControl
    {
        public LEDMarkerControl()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics graphics = pe.Graphics;

            using (Pen redPen = new Pen(Color.Red))
            using (Pen darkRedPen = new Pen(Color.DarkRed))
            {
                graphics.DrawEllipse(darkRedPen, 0, 0, 10, 10);
                graphics.FillEllipse(redPen.Brush, 0, 0, 10, 10);
            }
            
        }
    }
}
