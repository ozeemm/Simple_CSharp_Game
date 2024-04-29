using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Remoting;

namespace CSharp_Events.Objects
{
    internal class DarkArea : BaseObject
    {
        public List<BaseObject> touchingObjects = new List<BaseObject>();
        public DarkArea(float x, float y, float angle) : base(x, y, angle) 
        {
            fillColor = Color.Black;
            currentColor = fillColor;
        }

        public int width = 150;
        public float Speed = 4f;

        public override void Render(Graphics graphics)
        {
            // Круг с фоном
            graphics.FillRectangle(new SolidBrush(Color.Black), 0, 0, width, 420);
        }
        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddRectangle(new Rectangle(0, 0, width, 420));
            return path;
        }

        public void RecolorObjects(List<BaseObject> objects)
        {
            // Обесцвечиваем всё, что касается
            foreach (var obj in objects)
            {
                obj.Discolor();
            }
            if (touchingObjects != null)
            {
                // Возвращаем цвет тем, кто уже не касается
                foreach (var obj in touchingObjects)
                {
                    if (!objects.Contains(obj))
                    {
                        obj.NormalColor();
                    }
                }
            }
            touchingObjects = objects;
        }
    }
}
