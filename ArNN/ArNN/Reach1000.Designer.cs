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
            this.StartLabel = new System.Windows.Forms.Label();
            this.StopLable = new System.Windows.Forms.Label();
            this.ClearLabel = new System.Windows.Forms.Label();
            this.RandomnessLabel = new System.Windows.Forms.Label();
            this.ProcessTextBox = new System.Windows.Forms.TextBox();
            this.TimeLable = new System.Windows.Forms.Label();
            this.ActionNumberLable = new System.Windows.Forms.Label();
            this.NetworkVersionLable = new System.Windows.Forms.Label();
            this.BestLable = new System.Windows.Forms.Label();
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
            this.StopButton.Location = new System.Drawing.Point(571, 380);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 32);
            this.StopButton.TabIndex = 1;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(459, 380);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 32);
            this.ClearButton.TabIndex = 2;
            this.ClearButton.Text = "Clear";
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
            // StartLabel
            // 
            this.StartLabel.AutoSize = true;
            this.StartLabel.Location = new System.Drawing.Point(689, 344);
            this.StartLabel.Name = "StartLabel";
            this.StartLabel.Size = new System.Drawing.Size(46, 17);
            this.StartLabel.TabIndex = 4;
            this.StartLabel.Text = "label1";
            // 
            // StopLable
            // 
            this.StopLable.AutoSize = true;
            this.StopLable.Location = new System.Drawing.Point(568, 344);
            this.StopLable.Name = "StopLable";
            this.StopLable.Size = new System.Drawing.Size(46, 17);
            this.StopLable.TabIndex = 5;
            this.StopLable.Text = "label2";
            // 
            // ClearLabel
            // 
            this.ClearLabel.AutoSize = true;
            this.ClearLabel.Location = new System.Drawing.Point(456, 344);
            this.ClearLabel.Name = "ClearLabel";
            this.ClearLabel.Size = new System.Drawing.Size(75, 17);
            this.ClearLabel.TabIndex = 6;
            this.ClearLabel.Text = "Очистить ";
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
            // BestLable
            // 
            this.BestLable.AutoSize = true;
            this.BestLable.Location = new System.Drawing.Point(539, 148);
            this.BestLable.Name = "BestLable";
            this.BestLable.Size = new System.Drawing.Size(135, 17);
            this.BestLable.TabIndex = 12;
            this.BestLable.Text = "Лучший результат:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 468);
            this.Controls.Add(this.BestLable);
            this.Controls.Add(this.NetworkVersionLable);
            this.Controls.Add(this.ActionNumberLable);
            this.Controls.Add(this.TimeLable);
            this.Controls.Add(this.ProcessTextBox);
            this.Controls.Add(this.RandomnessLabel);
            this.Controls.Add(this.ClearLabel);
            this.Controls.Add(this.StopLable);
            this.Controls.Add(this.StartLabel);
            this.Controls.Add(this.RandomnessTrackBar);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartButton);
            this.Name = "Form1";
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
        private System.Windows.Forms.Label StartLabel;
        private System.Windows.Forms.Label StopLable;
        private System.Windows.Forms.Label ClearLabel;
        private System.Windows.Forms.Label RandomnessLabel;
        private System.Windows.Forms.TextBox ProcessTextBox;
        private System.Windows.Forms.Label TimeLable;
        private System.Windows.Forms.Label ActionNumberLable;
        private System.Windows.Forms.Label NetworkVersionLable;
        private System.Windows.Forms.Label BestLable;
    }
}

