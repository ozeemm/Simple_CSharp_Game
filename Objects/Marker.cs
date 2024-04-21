using System.Drawing;
using System.Drawing.Drawing2D;

namespace CSharp_Events.Objects
{
    internal class Marker : BaseObject
    {
        // Вызов конструктора родительского класса
        public Marker(float x, float y, float angle) : base(x, y, angle) 
        {
            fillColor = Color.Red;
            currentColor = fillColor;
        }

        public override void Render(Graphics graphics)
        {
            graphics.FillEllipse(new SolidBrush(currentColor), -3, -3, 6, 6);
            graphics.DrawEllipse(new Pen(currentColor, 2), -6, -6, 12, 12);
            graphics.DrawEllipse(new Pen(currentColor, 2), -10, -10, 20, 20);
        }

        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-3, -3, 6, 6); // Добавляем самый маленький круг
            return path;
        }
    }
}
