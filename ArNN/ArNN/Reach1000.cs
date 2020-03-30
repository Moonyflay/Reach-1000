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
        public static int chance;
        public static int action_limit;
        public static int goal = 1000; 
        public static int network_version = 0;  // Версия нейросети
        public static int total_action_number = 0; // Суммарное количество действий всех нейросетей
        public static int action_number; // Номер действия в текущеей нейросети 
        public static int best_result;
        static bool pause = false;
        public  bool Pause
        { get { return pause; }
            set 
            {
                pause = value;
                InnerPause();
                return;
            }
        }
        Neuroweb Arny;

        public Reach1000()
        {
            InitializeComponent();
            chance = RandomnessTrackBar.Value;
            action_limit = LimitTrackBar.Value;
            StartButton.Click += StartButton_Click;
            StopButton.Click += StopButton_Click;
            PauseButton.Click += PauseButton_Click;
            ClearButton.Click += ClearButton_Click;
            RandomnessTrackBar.Scroll += RandomnessTrackBar_Scroll;
            LimitTrackBar.Scroll += LimitTrackBar_Scroll;

        }
        void StartButton_Click(Object sender, EventArgs e)
        {
            if (Arny == null)
            {
                StopButton.Enabled = true;
                //PauseButton.Enabled = true;
                //StartButton.Enabled = false;
                Arny = new Neuroweb(this); // Не делать кнопку старта доступной, пока не заработает кнопка остановки!
            }
            Arny.Start(ref Arny);
        }
        void StopButton_Click(Object sender, EventArgs e)
        { 
            Arny = null;
            StopButton.Enabled = false;
            //PauseButton.Enabled = false;
            //StartButton.Enabled = true;
        }
        void PauseButton_Click(Object sender, EventArgs e)
        {
            Pause = !Pause;
            InnerPause();
        }
        void InnerPause() 
        {
            if (pause == true) PauseButton.Text = "Continue"; else PauseButton.Text = "Pause";
            while (pause == true) { Thread.Sleep(100); }
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
        void LimitTrackBar_Scroll(Object sender, EventArgs e)
        {
            action_limit = LimitTrackBar.Value;
            LimitLabel.Text = String.Format("Предельное количество действий, совершаемых нейросетью: {0}", LimitTrackBar.Value);
        }
        public void Process_text(int result, int param, string action )
        {
            ProcessTextBox.Text += Convert.ToString(network_version) + "." + Convert.ToString(action_number) + ") ";
            Show_network_version();
            Show_action_number();
            Show_best_result(); 
            switch (action)
            {
                case "Add": { ProcessTextBox.AppendText(String.Format("{0} + {1} = {2}{3}", result - param, param, result, Environment.NewLine)); break; }
                case "Multiply": { ProcessTextBox.AppendText(String.Format("{0} * {1} = {2}{3}", param == 0 ? 0 : result / param, param , result, Environment.NewLine)); break; }
                default: { throw new Exception("В Process_text очепятка: " + action); }
            }
        }
        public void Show_network_version()
        { NetworkVersionLable.Text = String.Format("Номер нейросети: {0}", network_version ); }
        public void Show_action_number()
        { ActionNumberLable.Text = String.Format("Номер действия: {0}", total_action_number); }
        public void Show_best_result()
        { BestResultLable.Text = String.Format("Лучший результат: {0}", best_result); }

        private void Reach1000_Load(object sender, EventArgs e)
        {

        }
    }
}
