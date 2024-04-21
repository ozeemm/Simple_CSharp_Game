using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CSharp_Events.Objects
{
    internal class Circle : BaseObject
    {
        private static Random rand = new Random();
        public Circle(float x, float y, float angle) : base(x, y, angle) 
        {
            fillColor = Color.GreenYellow;
            currentColor = fillColor;
        }

        public override void Render(Graphics graphics)
        {
            // Круг с фоном
            graphics.FillEllipse(new SolidBrush(currentColor), -15, -15, 30, 30);
        }
        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-15, -15, 30, 30);
            return path;
        }
        public void Respawn(PictureBox pb)
        {
            X = rand.Next(pb.Width - 60) + 30;
            Y = rand.Next(pb.Height - 60) + 30;
        }
    }
}
