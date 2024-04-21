using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Events.Objects
{
    internal class Player : BaseObject
    {
        public float Speed = 2.5f;
        public float vX, vY;

        public Action<Marker> OnMarkerOverlap;
        public Action<Circle> OnCircleOverlap;

        // Вызов конструктора родительского класса
        public Player(float x, float y, float angle) : base(x, y, angle)
        {
            fillColor = Color.DeepSkyBlue;
            currentColor = fillColor;
        }

        public override void Render(Graphics graphics)
        {
            // Круг с фоном
            graphics.FillEllipse(new SolidBrush(currentColor), -15, -15, 30, 30);
            graphics.DrawEllipse(new Pen(Color.Black, 2), -15, -15, 30, 30);

            // Палочка, указывающая направление
            graphics.DrawLine(new Pen(Color.Black, 2), 0, 0, 25, 0);
        }

        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-15, -15, 30, 30); // Добавляем круг, совпадающий размерами с нашим
            return path;
        }

        public override void Overlap(BaseObject obj)
        {
            base.Overlap(obj);
            if(obj is Marker) { OnMarkerOverlap(obj as Marker); }
            if(obj is Circle) { OnCircleOverlap(obj as Circle); }
        }
    }
}
