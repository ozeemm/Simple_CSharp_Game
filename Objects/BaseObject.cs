using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Events.Objects
{
    internal class BaseObject
    {
        public float X;
        public float Y;
        public float Angle;
        protected Color fillColor;
        protected Color currentColor;

        public Action<BaseObject, BaseObject> OnOverlap; // Делегат, к которому будет привязать реакцию на события
        public BaseObject(float x, float y, float angle)
        {
            X = x;
            Y = y;
            Angle = angle;
        }
        
        public Matrix GetTransform() // Матрица преобразования
        {
            var matrix = new Matrix();
            matrix.Translate(X, Y);
            matrix.Rotate(Angle);

            return matrix;
        }
        
        public virtual GraphicsPath GetGraphicsPath() // Описать форму объекта в двумерном пространстве в виде набора примитивов
        {
            // пока возвращаем пустую форму
            return new GraphicsPath();
        }

        public virtual bool Overlaps(BaseObject obj, Graphics graphics)
        {
            // Информация о форме
            var path1 = this.GetGraphicsPath();
            var path2 = obj.GetGraphicsPath();

            // Применяем к объектам матрицы трансформации
            path1.Transform(this.GetTransform());
            path2.Transform(obj.GetTransform());

            // используем класс Region, который позволяет определить 
            // пересечение объектов в данном графическом контексте
            var region = new Region(path1);
            region.Intersect(path2); // Пересекаем
            return !region.IsEmpty(graphics); // Если полученная форма не пуста то значит было пересечение
        }

        public virtual void Overlap(BaseObject obj)
        {
            if(this.OnOverlap != null) // Если есть привязанные функции
            {
                this.OnOverlap(this, obj); // Вызываем их
            }
        }

        public void Discolor() { currentColor = Color.White; }
        public void NormalColor() { currentColor = fillColor; }

        public virtual void Render(Graphics graphics) { }
    }
}
