﻿using CSharp_Events.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_Events
{
    public partial class Form1 : Form
    {
        private List<BaseObject> objects = new List<BaseObject>();
        private Player player;
        private Marker marker;
        private int score = 0;
        public Form1()
        {
            InitializeComponent();

            // Создаём объекты
            objects.Add(new Circle(100, 100, 0));
            objects.Add(new Circle(200, 200, 0));

            // Создаём игрока в центре
            player = new Player(pbMain.Width / 2, pbMain.Height / 2, 0);
            player.OnOverlap += (p, obj) =>
            {
                Log($"Игрок пересекся с {obj}");
            };
            player.OnMarkerOverlap += (m) =>
            {
                objects.Remove(m);
                marker = null;
            };
            player.OnCircleOverlap += (circle) =>
            {
                score++;
                ScoreLabel.Text = $"Счёт: {score}";
                circle.Respawn(pbMain);
            };
            objects.Add(player);
        }

        private void Log(string text)
        {
            txtLog.Text = $"[{DateTime.Now:HH:mm:ss:ff}] {text}\n" + txtLog.Text;
        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics; // Вытащили объект графики из события
            graphics.Clear(Color.White); // Заливка формы

            updatePlayer(); // Перемещение игрока
            
            // Проверяем пересечения
            foreach(var obj in objects.ToList())
            {
                if (obj != player && obj.Overlaps(player, graphics))
                {
                    player.Overlap(obj);
                    obj.Overlap(player);
                }
            }
            
            // Рендерим объекты
            foreach (var obj in objects.ToList())
            {
                graphics.Transform = obj.GetTransform();
                obj.Render(graphics);
            }
        }
        private void updatePlayer()
        {
            if (marker != null)
            {
                // Вектор между игроком и маркером
                float dx = marker.X - player.X;
                float dy = marker.Y - player.Y;

                // Расстояние
                float length = (float)Math.Sqrt(dx * dx + dy * dy);

                // Нормализуем координаты (вектор ускорения, притяжения)
                dx /= length;
                dy /= length;


                // Пересчитываем координаты игрока
                player.vX = dx * 2f;
                player.vY = dy * 2f;

                // расчитываем угол поворота игрока 
                player.Angle = (float)(90 - Math.Atan2(player.vX, player.vY) * 180 / Math.PI);
            }

            // Тормозящий момент,
            // Нужен чтобы, когда игрок достигнет маркера произошло постепенное замедление
            player.vX += -player.vX * 0.1f;
            player.vY += -player.vY * 0.1f;

            // Пересчет позиция игрока с помощью вектора скорости
            player.X += player.vX;
            player.Y += player.vY;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // Запрашиваем обновление pbMain (Вызов Paint)
            pbMain.Invalidate();
        }

        private void pbMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (marker == null)
            {
                marker = new Marker(0, 0, 0);
                objects.Add(marker);
            }

            marker.X = e.X;
            marker.Y = e.Y;
        }
    }
}