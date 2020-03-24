using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ArNN
{
    public delegate void Neuron_Action(ref int x, int a = 0);
    public class Neuron
    {
        Neuron_Action action;
        public Neuron Next; // Нейрон, которому передадут сигнал
        public Neuron(Neuron_Action _action)
        {
            Change_action("Add", _action);// Внесение первых действий в список выполняемых  действий
        }
        public void Act(Neuroweb sender) // Выполнение нейроном заданных действий
        { 
            action(ref sender.reached_number, sender.random_param);
            if (sender.reached_number < Reach1000.goal) Pass(sender);
            else {
                if (sender.Delta >= 0) sender.Evolve();
                else { sender = (Neuroweb)sender.previous.Clone(); sender.Evolve(); }
            }
        }
        private void Pass(Neuroweb sender) // Передача сигнала
        {
           /* Neuroweb.Mother.Pause = true;*/ Next.Act(sender);          
        }
        public void Change_action(string op_name, Neuron_Action _action) 
        {
            
                switch (op_name)
            {
                case "Add":
                    { action += _action; break; }
                case "Delete":
                    { action -= _action; break; }
                default: 
                    { throw new Exception("В Change_action опечатка: " + op_name); }
            }
        }
        

    }
}
