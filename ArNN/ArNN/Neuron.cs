using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ArNN
{
    
    class Neuron
    {
        public delegate void Action(ref int x, int a);
        Action action;
        Queue<Neuron> Next = new Queue<Neuron>();
        public Neuron(Action _action, Queue<Neuron> next = null )
        {
            
            Change_action("Add", _action);// Внесение первых действий в список выполняемых  действий
            if(next != null) Change_PassList("Add", next) ;// Внесение нейронов в список для передачи сигнала
                
            action(ref Neuroweb.reached_number, Neuroweb.random_param);
            
        }
        public void Act() // Выполнение нейроном заданных действий
        { 
            action(ref Neuroweb.reached_number, Neuroweb.random_param);
            Pass();
        }
        private void Pass() // Передача сигнала
        {
            foreach (Neuron i in Next)                                                                                                                   // Провеить работу и заменить на for, eсли необходимо
            {
                Next.Dequeue().Act();
            }
        }
        public void Change_action(string op_name, Action _action) 
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
        public void Change_PassList(string op_name, Queue<Neuron> next)
        {

            switch (op_name)
            {
                case "Add":
                    {
                        foreach (Neuron i in next)                                                                                                        // Проверить, удаляется ли из next объекты
                        { 
                            Next.Enqueue(i); 
                        }
                        break;
                    }
                case "Delete":
                    {MessageBox.Show("Change_PassList, Delete в процессе написанния"); break; }
                default:
                    { throw new Exception("В Change_PassList опечатка: " + op_name); }
            }
        }

    }
}
