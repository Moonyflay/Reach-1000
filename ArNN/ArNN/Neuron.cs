using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ArNN
{
    public delegate void Neuron_Action(ref int x, int a);
    public class Neuron : ICloneable
    {
        Neuron_Action action;
        public Neuron Next; // Нейрон, которому передадут сигнал
        public int next_index;
        public int param = 0; // Он прибавляется к х/ На него умножается х
        public double coeff = 1; // Коэффициент, на который умножается изначальная вероятность. Чем лучше этот нейрон по сравнению с остальными, тем меньше вероятность мутации
        public double param_coeff = 1;
        public double addmult_coeff = 1; // Может принимать значения от 0 до двух. Коэффициент больше 1 - больше шанс выбора сложения, меньше 1 - умножения  
        public int sum_of_delta; // Разница между значениями х после и до алгебраических действий 
        public int num_of_calls; // Показывает, сколько раз этот нейрон выполнял свои действия
        public int num_of_add; // Количество операций сложения в action
        public int num_of_mult; // Количество операций умножения
        public bool param_changed = false;
        public double uspeshnost 
        {
            get
            {
                if (num_of_calls != 0) return sum_of_delta / num_of_calls;
                else return -1;
            }
        }
       
        public Neuron(Neuron_Action _action)
        {
            Change_action("Add", _action);// Внесение первых действий в список выполняемых  действий
        }
        public void Act(ref Neuroweb sender) // Выполнение нейроном заданных действий
        {
            num_of_calls ++;
            int b4 = sender.reached_number;
            action(ref sender.reached_number, param);
            sum_of_delta += sender.reached_number - b4;
            if (Reach1000.action_number < Reach1000.action_limit && sender.reached_number < Reach1000.goal) Pass(ref sender);
            else {
                Neuroweb.Mother.Show_best_result(sender.Best_result);
                if (sender.Delta <= 0 || sender.previous == null) sender.Evolve();
                else { sender = (Neuroweb)sender.previous.Clone(); sender.Evolve(); }
            }
        }
        private void Pass(ref Neuroweb sender) // Передача сигнала
        {
            Next.Act(ref sender);          
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
        public object Clone()
        {
            Neuron old = new Neuron(this.action)
            {
                next_index = this.next_index,
                coeff = this.coeff,
                param = this.param,
                param_coeff = this.param_coeff,
                addmult_coeff = this.addmult_coeff, 
                sum_of_delta  = this.sum_of_delta, 
                num_of_calls = this.num_of_calls, 
                num_of_add = this.num_of_add, 
                num_of_mult = this.num_of_mult 
            };
            return old;
        }



    }
}
