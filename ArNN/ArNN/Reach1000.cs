using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArNN
{
    public partial class Reach1000 : Form
    {
        public static Random sluchai = new Random();
        public static int chance = 3;
        public static int goal = 1000; //
        public static int network_version = 0; // после написания кода спавна нейростети надо слить в один параметр
        public static int action_number = 0;
        public static int best_result;

        public Reach1000()
        {
            InitializeComponent();

            StartButton.Click += StartButton_Click;
            StopButton.Click += StopButton_Click;
            ClearButton.Click += ClearButton_Click;
            RandomnessTrackBar.Scroll += RandomnessTrackBar_Scroll;

        }
        void StartButton_Click(Object sender, EventArgs e)
        {
            Neuroweb Arny = new Neuroweb(this); // Не делать кнопку старта доступной, пока не заработает кнопка остановки!
        }
        void StopButton_Click(Object sender, EventArgs e)
        { }
        void ClearButton_Click(Object sender, EventArgs e) 
        {
            ProcessTextBox.ResetText();
        }
        void RandomnessTrackBar_Scroll(Object sender, EventArgs e)
        {
            chance = RandomnessTrackBar.Value;
            RandomnessLabel.Text = String.Format("Шанс мутации = {0} %", RandomnessTrackBar.Value);
        }
        public void Show_network_version()
        { NetworkVersionLable.Text = String.Format("Номер нейросети: {0}", network_version ); }
        public void Show_action_number()
        { ActionNumberLable.Text = String.Format("Номер действия: {0}", action_number); }
        public void Show_best_result()
        { BestResultLable.Text = String.Format("Лучший результат: {0}", best_result); }
    }
}
