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
        public static int chance = 3;
        public static int goal = 1000; //
        public static int network_version = 0; // после написания кода спавна нейростети надо слить в один параметр
        int action_number = 0;
        int best_result;

        public Reach1000()
        {
            InitializeComponent();
            
            StartButton.Click += StartButton_Click;
            StopButton.Click += StopButton_Click;
            RandomnessTrackBar.Scroll += RandomnessTrackBar_Scroll;
            
        }
        void StartButton_Click(Object sender,EventArgs e) 
        { }
        void StopButton_Click (Object sender, EventArgs e)
        { }
        void RandomnessTrackBar_Scroll(Object sender, EventArgs e)
        {
            chance = RandomnessTrackBar.Value;
            RandomnessLabel.Text = String.Format("Шанс мутации = {0} %", RandomnessTrackBar.Value); 
        }
    }
}
