namespace CSharp_Events
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbMain = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.ClearLogButton = new System.Windows.Forms.Button();
            this.SpeedTrack = new System.Windows.Forms.TrackBar();
            this.SpeedLabel = new System.Windows.Forms.Label();
            this.AreaSpeedLabel = new System.Windows.Forms.Label();
            this.AreaSpeedTrack = new System.Windows.Forms.TrackBar();
            this.LogCounter = new System.Windows.Forms.Label();
            this.CirclesLabel = new System.Windows.Forms.Label();
            this.CirclesTrack = new System.Windows.Forms.TrackBar();
            this.AreaWidthLabel = new System.Windows.Forms.Label();
            this.AreaWidthTrack = new System.Windows.Forms.TrackBar();
            this.AutoClearLog = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AreaSpeedTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CirclesTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AreaWidthTrack)).BeginInit();
            this.SuspendLayout();
            // 
            // pbMain
            // 
            this.pbMain.Location = new System.Drawing.Point(12, 12);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(640, 517);
            this.pbMain.TabIndex = 0;
            this.pbMain.TabStop = false;
            this.pbMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pbMain_Paint);
            this.pbMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbMain_MouseClick);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 30;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(658, 12);
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new System.Drawing.Size(279, 517);
            this.txtLog.TabIndex = 1;
            this.txtLog.Text = "";
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Location = new System.Drawing.Point(588, 25);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(52, 16);
            this.ScoreLabel.TabIndex = 2;
            this.ScoreLabel.Text = "Счёт: 0";
            // 
            // ClearLogButton
            // 
            this.ClearLogButton.Location = new System.Drawing.Point(734, 537);
            this.ClearLogButton.Name = "ClearLogButton";
            this.ClearLogButton.Size = new System.Drawing.Size(125, 32);
            this.ClearLogButton.TabIndex = 3;
            this.ClearLogButton.Text = "Очистить логи";
            this.ClearLogButton.UseVisualStyleBackColor = true;
            this.ClearLogButton.Click += new System.EventHandler(this.ClearLogButton_Click);
            // 
            // SpeedTrack
            // 
            this.SpeedTrack.Location = new System.Drawing.Point(12, 536);
            this.SpeedTrack.Maximum = 50;
            this.SpeedTrack.Minimum = 10;
            this.SpeedTrack.Name = "SpeedTrack";
            this.SpeedTrack.Size = new System.Drawing.Size(175, 56);
            this.SpeedTrack.TabIndex = 4;
            this.SpeedTrack.TickFrequency = 5;
            this.SpeedTrack.Value = 25;
            this.SpeedTrack.Scroll += new System.EventHandler(this.SpeedTrack_Scroll);
            // 
            // SpeedLabel
            // 
            this.SpeedLabel.AutoSize = true;
            this.SpeedLabel.Location = new System.Drawing.Point(14, 577);
            this.SpeedLabel.Name = "SpeedLabel";
            this.SpeedLabel.Size = new System.Drawing.Size(139, 16);
            this.SpeedLabel.TabIndex = 5;
            this.SpeedLabel.Text = "Скорость игрока: 2,5";
            this.SpeedLabel.Click += new System.EventHandler(this.SpeedLabel_Click);
            // 
            // AreaSpeedLabel
            // 
            this.AreaSpeedLabel.AutoSize = true;
            this.AreaSpeedLabel.Location = new System.Drawing.Point(196, 576);
            this.AreaSpeedLabel.Name = "AreaSpeedLabel";
            this.AreaSpeedLabel.Size = new System.Drawing.Size(168, 16);
            this.AreaSpeedLabel.TabIndex = 7;
            this.AreaSpeedLabel.Text = "Скорость тёмной зоны: 4";
            this.AreaSpeedLabel.Click += new System.EventHandler(this.AreaSpeedLabel_Click);
            // 
            // AreaSpeedTrack
            // 
            this.AreaSpeedTrack.Location = new System.Drawing.Point(189, 536);
            this.AreaSpeedTrack.Maximum = 100;
            this.AreaSpeedTrack.Minimum = 10;
            this.AreaSpeedTrack.Name = "AreaSpeedTrack";
            this.AreaSpeedTrack.Size = new System.Drawing.Size(175, 56);
            this.AreaSpeedTrack.TabIndex = 6;
            this.AreaSpeedTrack.TickFrequency = 5;
            this.AreaSpeedTrack.Value = 40;
            this.AreaSpeedTrack.Scroll += new System.EventHandler(this.AreaSpeedTrack_Scroll);
            // 
            // LogCounter
            // 
            this.LogCounter.Location = new System.Drawing.Point(872, 536);
            this.LogCounter.Name = "LogCounter";
            this.LogCounter.Size = new System.Drawing.Size(65, 20);
            this.LogCounter.TabIndex = 8;
            this.LogCounter.Text = "0";
            this.LogCounter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CirclesLabel
            // 
            this.CirclesLabel.AutoSize = true;
            this.CirclesLabel.Location = new System.Drawing.Point(550, 577);
            this.CirclesLabel.Name = "CirclesLabel";
            this.CirclesLabel.Size = new System.Drawing.Size(156, 16);
            this.CirclesLabel.TabIndex = 10;
            this.CirclesLabel.Text = "Количество кружков: 2";
            this.CirclesLabel.Click += new System.EventHandler(this.CirclesLabel_Click);
            // 
            // CirclesTrack
            // 
            this.CirclesTrack.Location = new System.Drawing.Point(553, 537);
            this.CirclesTrack.Minimum = 1;
            this.CirclesTrack.Name = "CirclesTrack";
            this.CirclesTrack.Size = new System.Drawing.Size(175, 56);
            this.CirclesTrack.TabIndex = 9;
            this.CirclesTrack.Value = 2;
            this.CirclesTrack.Scroll += new System.EventHandler(this.CirclesTrack_Scroll);
            // 
            // AreaWidthLabel
            // 
            this.AreaWidthLabel.AutoSize = true;
            this.AreaWidthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AreaWidthLabel.Location = new System.Drawing.Point(385, 577);
            this.AreaWidthLabel.Name = "AreaWidthLabel";
            this.AreaWidthLabel.Size = new System.Drawing.Size(159, 15);
            this.AreaWidthLabel.TabIndex = 12;
            this.AreaWidthLabel.Text = "Ширина тёмной зоны: 150";
            this.AreaWidthLabel.Click += new System.EventHandler(this.AreaWidthLabel_Click);
            // 
            // AreaWidthTrack
            // 
            this.AreaWidthTrack.Location = new System.Drawing.Point(372, 537);
            this.AreaWidthTrack.Maximum = 300;
            this.AreaWidthTrack.Minimum = 10;
            this.AreaWidthTrack.Name = "AreaWidthTrack";
            this.AreaWidthTrack.Size = new System.Drawing.Size(175, 56);
            this.AreaWidthTrack.SmallChange = 10;
            this.AreaWidthTrack.TabIndex = 11;
            this.AreaWidthTrack.TickFrequency = 50;
            this.AreaWidthTrack.Value = 150;
            this.AreaWidthTrack.Scroll += new System.EventHandler(this.AreaWidthTrack_Scroll);
            // 
            // AutoClearLog
            // 
            this.AutoClearLog.AutoSize = true;
            this.AutoClearLog.Checked = true;
            this.AutoClearLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoClearLog.Location = new System.Drawing.Point(823, 575);
            this.AutoClearLog.Name = "AutoClearLog";
            this.AutoClearLog.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.AutoClearLog.Size = new System.Drawing.Size(114, 20);
            this.AutoClearLog.TabIndex = 13;
            this.AutoClearLog.Text = "Автоочистка";
            this.AutoClearLog.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 601);
            this.Controls.Add(this.AutoClearLog);
            this.Controls.Add(this.AreaWidthLabel);
            this.Controls.Add(this.AreaWidthTrack);
            this.Controls.Add(this.CirclesLabel);
            this.Controls.Add(this.CirclesTrack);
            this.Controls.Add(this.LogCounter);
            this.Controls.Add(this.AreaSpeedLabel);
            this.Controls.Add(this.AreaSpeedTrack);
            this.Controls.Add(this.SpeedLabel);
            this.Controls.Add(this.SpeedTrack);
            this.Controls.Add(this.ClearLogButton);
            this.Controls.Add(this.ScoreLabel);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.pbMain);
            this.Name = "Form1";
            this.Text = "MyGame";
            ((System.ComponentModel.ISupportInitialize)(this.pbMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AreaSpeedTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CirclesTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AreaWidthTrack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMain;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.Button ClearLogButton;
        private System.Windows.Forms.TrackBar SpeedTrack;
        private System.Windows.Forms.Label SpeedLabel;
        private System.Windows.Forms.Label AreaSpeedLabel;
        private System.Windows.Forms.TrackBar AreaSpeedTrack;
        private System.Windows.Forms.Label LogCounter;
        private System.Windows.Forms.Label CirclesLabel;
        private System.Windows.Forms.TrackBar CirclesTrack;
        private System.Windows.Forms.Label AreaWidthLabel;
        private System.Windows.Forms.TrackBar AreaWidthTrack;
        private System.Windows.Forms.CheckBox AutoClearLog;
    }
}

