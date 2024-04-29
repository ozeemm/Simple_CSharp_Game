using CSharp_Events.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CSharp_Events
{
    public partial class Form1 : Form
    {
        private List<BaseObject> objects = new List<BaseObject>();
        private Player player;
        private Marker marker;
        private DarkArea darkArea;
        private int score = 0;
        private int circles = 0;

        private const int messagesToClear = 100; // Порог для автоочистки
        private int logMessages = 0;
        public Form1()
        {
            InitializeComponent();

            // Создаём тёмную область
            darkArea = new DarkArea(-100, 0, 0);
            darkArea.OnOverlap += (d, obj) =>
            {
                obj.Discolor();
            };
            objects.Add(darkArea);

            int middleX = pbMain.Width / 2;
            int middleY = pbMain.Height / 2;

            // Создаём кружочки (2)
            ChangeCirclesCount();

            // Создаём игрока в центре
            player = new Player(middleX, middleY, 0);
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
                Application.OpenForms[0].Text = $"MyGame | Счёт: {score}";
                circle.Respawn(pbMain);
            };
            objects.Add(player);
        }

        private void Log(string text)
        {
            txtLog.Text = $"[{DateTime.Now:HH:mm:ss:ff}] {text}\n" + txtLog.Text;
            
            // Счётчик
            logMessages++;
            LogCounter.Text = logMessages.ToString();
            
            // Автоочистка
            if (logMessages > messagesToClear && AutoClearLog.Checked)
                ClearLog();
        }
        private void ClearLog()
        {
            txtLog.Text = "";
            logMessages = 0;
            Log("Логи очищены!");
        }

        private void pbMain_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics; // Вытащили объект графики из события
            graphics.Clear(Color.White); // Заливка формы

            updateDarkArea(); // Перемещение чёрной области
            updatePlayer(); // Перемещение игрока       

            // Проверяем пересечения
            List<BaseObject> touchingWithDarkArea = new List<BaseObject>();
            foreach (var obj in objects.ToList())
            {
                if (obj != player && obj.Overlaps(player, graphics))
                {
                    player.Overlap(obj);
                    obj.Overlap(player);
                }
                if(obj != darkArea && obj.Overlaps(darkArea, graphics))
                {
                    touchingWithDarkArea.Add(obj);
                }
            }
            darkArea.RecolorObjects(touchingWithDarkArea);

            // Рендерим объекты
            foreach (var obj in objects.ToList())
            {
                graphics.Transform = obj.GetTransform();
                obj.Render(graphics);
            }
        } // Отрисовка
       
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
                player.vX = dx * player.Speed;
                player.vY = dy * player.Speed;

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
        } // Движение игрока
        private void updateDarkArea()
        {
            darkArea.X += darkArea.Speed;

            if (darkArea.X > pbMain.Width) // Сброс позиции
                darkArea.X = -darkArea.width;
        } // Движение тёмной области

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
        } // Маркер

        private void ClearLogButton_Click(object sender, EventArgs e)
        {
            ClearLog();
        } // Кнопка очистки логов
        private void SpeedTrack_Scroll(object sender, EventArgs e)
        {
            float speed = SpeedTrack.Value / 10.0f;
            SpeedLabel.Text = $"Скорость игрока: {speed}";
            player.Speed = speed;
        }  // Изменение скорости игрока
        private void AreaSpeedTrack_Scroll(object sender, EventArgs e)
        {
            float speed = AreaSpeedTrack.Value / 10.0f;
            AreaSpeedLabel.Text = $"Скорость тёмной зоны: {speed}";
            darkArea.Speed = speed;
        } // Изменение скорости тёмной зоны
        private void AreaWidthTrack_Scroll(object sender, EventArgs e)
        {
            int width = AreaWidthTrack.Value;
            AreaWidthLabel.Text = $"Ширина тёмной зоны: {width}"; ;
            darkArea.width = width;
        } // Изменение ширины тёмной зоны
        private void CirclesTrack_Scroll(object sender, EventArgs e)
        {
            ChangeCirclesCount(); 
        } 
        private void ChangeCirclesCount() 
        {
            int newCircles = CirclesTrack.Value;
            CirclesLabel.Text = $"Количество кружков: {newCircles}";

            if (newCircles > circles)
            {
                for (int i = 0; i < newCircles - circles; i++)
                {
                    var circle = new Circle(0, 0, 0);
                    circle.Respawn(pbMain);
                    objects.Add(circle);
                }
            }
            else if (newCircles < circles)
            {
                int k = 0;
                foreach (var obj in objects.ToList())
                {
                    if (obj is Circle)
                    {
                        k++;
                        if (k > newCircles)
                        {
                            objects.Remove(obj);
                        }
                    }
                }
            }
            circles = newCircles;
        } // Изменение количества кружков
    }
}