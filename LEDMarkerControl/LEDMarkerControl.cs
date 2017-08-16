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
            using (Pen blackPen = new Pen(Color.Black))
            using (Pen whitePen = new Pen(Color.White))
            {
                graphics.DrawRectangle(blackPen, 0, 0, 12, 12);
                graphics.FillRectangle(whitePen.Brush, 0, 0, 12, 12);
                graphics.DrawEllipse(darkRedPen, 0, 0, 10, 10);
                graphics.FillEllipse(redPen.Brush, 0, 0, 10, 10);
            }
            
        }
    }
}
