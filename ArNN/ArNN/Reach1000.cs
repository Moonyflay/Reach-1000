using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ArNN
{
    public partial class Reach1000 : Form
    {
        public static Random sluchai = new Random();
        public static int chance = 3;
        public static int goal = 1000; 
        public static int network_version = 0; 
        public static int total_action_number = 0;
        public static int action_number;
        public static int best_result;
        static bool pause = false;
        public  bool Pause
        { get { return pause; }
            set 
            {
                pause = value;
                PauseButton_Click(this, new EventArgs());
                return;
            }
        }
        Neuroweb Arny;

        public Reach1000()
        {
            InitializeComponent();

            StartButton.Click += StartButton_Click;
            StopButton.Click += StopButton_Click;
            PauseButton.Click += PauseButton_Click;
            ClearButton.Click += ClearButton_Click;
            RandomnessTrackBar.Scroll += RandomnessTrackBar_Scroll;

        }
        void StartButton_Click(Object sender, EventArgs e)
        {StopButton.Enabled = true;
            PauseButton.Enabled = true;
            StartButton.Enabled = false;
            Arny = new Neuroweb(this); // Не делать кнопку старта доступной, пока не заработает кнопка остановки!
            
        }
        void StopButton_Click(Object sender, EventArgs e)
        { 
            Arny = null;
            StopButton.Enabled = false;
            PauseButton.Enabled = false;
            StartButton.Enabled = true;
        }
        void PauseButton_Click(Object sender, EventArgs e)
        {
            if (pause == true) PauseButton.Text = "Continue"; else PauseButton.Text = "Pause";
            
            while (pause == true) { Thread.Sleep(100); }
            if (pause == true) PauseButton.Text = "Continue"; else PauseButton.Text = "Pause";
        }
        void ClearButton_Click(Object sender, EventArgs e) 
        {
            ProcessTextBox.ResetText();
        }
        void RandomnessTrackBar_Scroll(Object sender, EventArgs e)
        {
            chance = RandomnessTrackBar.Value;
            RandomnessLabel.Text = String.Format("Шанс мутации = {0} %", RandomnessTrackBar.Value);
        }
        public void Process_text(Neuroweb sender, string action, int previous)
        {
            ProcessTextBox.Text += network_version + '.' + action_number + ' ';
            switch (action)
            {
                case "Add": { ProcessTextBox.Text += "\n" + Convert.ToString(previous) + " + " + Convert.ToString(sender.random_param) + " = " + Convert.ToString(sender.reached_number); break; }
                case "Multiply": { ProcessTextBox.Text += "\n" + Convert.ToString(previous) + " * " + Convert.ToString(sender.random_param) + " = " + Convert.ToString(sender.reached_number); break; }
                default: { throw new Exception("В Process_text очепятка: " + action); }
            }
        }
        public void Show_network_version()
        { NetworkVersionLable.Text = String.Format("Номер нейросети: {0}", network_version ); }
        public void Show_action_number()
        { ActionNumberLable.Text = String.Format("Номер действия: {0}", total_action_number); }
        public void Show_best_result()
        { BestResultLable.Text = String.Format("Лучший результат: {0}", best_result); }
    }
}
