using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Events.Objects
{
    internal class DarkArea : BaseObject
    {
        public Action<BaseObject> OnOver;
        public DarkArea(float x, float y, float angle) : base(x, y, angle) 
        {
            fillColor = Color.Black;
            currentColor = fillColor;
        }

        public int width = 150;
        public float speed = 4f;

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

        public virtual void Over(BaseObject obj)
        {
            if (this.OnOver != null) // Если есть привязанные функции
            {
                this.OnOver(obj); // Вызываем их
            }
        }
    }
}
