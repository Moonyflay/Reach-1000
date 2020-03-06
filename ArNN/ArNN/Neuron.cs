using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ArNN
{
    public delegate void Neuron_Action(ref int x, int a = 0);
    class Neuron
    {
        Neuron_Action action;
        Neuron Next; // Нейрон, которому передадут сигнал
        public Neuron(Neuron_Action _action, Neuron next)
        {
            
            Change_action("Add", _action);// Внесение первых действий в список выполняемых  действий
            if(next != null) Next = next; 
                
            action(ref Neuroweb.reached_number, Neuroweb.random_param);
            
        }
        public void Act() // Выполнение нейроном заданных действий
        { 
            action(ref Neuroweb.reached_number, Neuroweb.random_param);
            if (Neuroweb.reached_number < Reach1000.goal) Pass();
            else { Neuroweb.Evolve(); }
        }
        private void Pass() // Передача сигнала
        {
                Next.Act();          
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
