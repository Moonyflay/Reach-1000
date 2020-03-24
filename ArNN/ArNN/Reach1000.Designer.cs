namespace ArNN
{
    partial class Reach1000
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
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.RandomnessTrackBar = new System.Windows.Forms.TrackBar();
            this.RandomnessLabel = new System.Windows.Forms.Label();
            this.ProcessTextBox = new System.Windows.Forms.TextBox();
            this.TimeLable = new System.Windows.Forms.Label();
            this.ActionNumberLable = new System.Windows.Forms.Label();
            this.NetworkVersionLable = new System.Windows.Forms.Label();
            this.BestResultLable = new System.Windows.Forms.Label();
            this.PauseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RandomnessTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(692, 380);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 32);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(596, 380);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 32);
            this.StopButton.TabIndex = 1;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(322, 418);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(106, 46);
            this.ClearButton.TabIndex = 2;
            this.ClearButton.Text = "Clear TextBox";
            this.ClearButton.UseVisualStyleBackColor = true;
            // 
            // RandomnessTrackBar
            // 
            this.RandomnessTrackBar.Location = new System.Drawing.Point(532, 240);
            this.RandomnessTrackBar.Maximum = 100;
            this.RandomnessTrackBar.Minimum = 1;
            this.RandomnessTrackBar.Name = "RandomnessTrackBar";
            this.RandomnessTrackBar.Size = new System.Drawing.Size(235, 56);
            this.RandomnessTrackBar.TabIndex = 3;
            this.RandomnessTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.RandomnessTrackBar.Value = 3;
            // 
            // RandomnessLabel
            // 
            this.RandomnessLabel.AutoSize = true;
            this.RandomnessLabel.Location = new System.Drawing.Point(539, 201);
            this.RandomnessLabel.Name = "RandomnessLabel";
            this.RandomnessLabel.Size = new System.Drawing.Size(129, 17);
            this.RandomnessLabel.TabIndex = 7;
            this.RandomnessLabel.Text = "Шанс мутации: 3%";
            // 
            // ProcessTextBox
            // 
            this.ProcessTextBox.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.ProcessTextBox.AllowDrop = true;
            this.ProcessTextBox.Location = new System.Drawing.Point(12, 12);
            this.ProcessTextBox.Multiline = true;
            this.ProcessTextBox.Name = "ProcessTextBox";
            this.ProcessTextBox.ReadOnly = true;
            this.ProcessTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ProcessTextBox.Size = new System.Drawing.Size(416, 400);
            this.ProcessTextBox.TabIndex = 8;
            // 
            // TimeLable
            // 
            this.TimeLable.AutoSize = true;
            this.TimeLable.Location = new System.Drawing.Point(539, 37);
            this.TimeLable.Name = "TimeLable";
            this.TimeLable.Size = new System.Drawing.Size(208, 17);
            this.TimeLable.TabIndex = 9;
            this.TimeLable.Text = "Время действия программы: 0";
            // 
            // ActionNumberLable
            // 
            this.ActionNumberLable.AutoSize = true;
            this.ActionNumberLable.Location = new System.Drawing.Point(539, 114);
            this.ActionNumberLable.Name = "ActionNumberLable";
            this.ActionNumberLable.Size = new System.Drawing.Size(132, 17);
            this.ActionNumberLable.TabIndex = 10;
            this.ActionNumberLable.Text = "Номер действия: 0";
            // 
            // NetworkVersionLable
            // 
            this.NetworkVersionLable.AutoSize = true;
            this.NetworkVersionLable.Location = new System.Drawing.Point(539, 76);
            this.NetworkVersionLable.Name = "NetworkVersionLable";
            this.NetworkVersionLable.Size = new System.Drawing.Size(141, 17);
            this.NetworkVersionLable.TabIndex = 11;
            this.NetworkVersionLable.Text = "Номер нейросети: 0";
            // 
            // BestResultLable
            // 
            this.BestResultLable.AutoSize = true;
            this.BestResultLable.Location = new System.Drawing.Point(539, 148);
            this.BestResultLable.Name = "BestResultLable";
            this.BestResultLable.Size = new System.Drawing.Size(135, 17);
            this.BestResultLable.TabIndex = 12;
            this.BestResultLable.Text = "Лучший результат:";
            // 
            // PauseButton
            // 
            this.PauseButton.Location = new System.Drawing.Point(490, 380);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(75, 32);
            this.PauseButton.TabIndex = 13;
            this.PauseButton.Text = "Pause";
            this.PauseButton.UseVisualStyleBackColor = true;
            // 
            // Reach1000
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 468);
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.BestResultLable);
            this.Controls.Add(this.NetworkVersionLable);
            this.Controls.Add(this.ActionNumberLable);
            this.Controls.Add(this.TimeLable);
            this.Controls.Add(this.ProcessTextBox);
            this.Controls.Add(this.RandomnessLabel);
            this.Controls.Add(this.RandomnessTrackBar);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartButton);
            this.Name = "Reach1000";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.RandomnessTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.TrackBar RandomnessTrackBar;
        private System.Windows.Forms.Label RandomnessLabel;
        private System.Windows.Forms.TextBox ProcessTextBox;
        private System.Windows.Forms.Label TimeLable;
        private System.Windows.Forms.Label ActionNumberLable;
        private System.Windows.Forms.Label NetworkVersionLable;
        private System.Windows.Forms.Label BestResultLable;
        private System.Windows.Forms.Button PauseButton;
    }
}

