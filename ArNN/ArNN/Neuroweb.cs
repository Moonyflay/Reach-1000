using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArNN
{
    public class Neuroweb : ICloneable
    {
        public static Reach1000 Mother;
        private static int Сhance
        { get { return Reach1000.chance; } }
        public int reached_number = 0;
        public int random_param = 0;
        private int initial_amount = Reach1000.sluchai.Next(1, 6);  // Исходное количество действий для нейрона
        private int multiply_amount = Reach1000.sluchai.Next(0, 6);// Исходное количество действий умножения в нейроне
        public Neuron[] web = new Neuron[5];                       // Разница initial_amount и multiply_amount дает исходное количество действий сложения в нейроне
        Neuron_Action[] initial_action = new Neuron_Action[5];
        public Neuroweb previous;
        private int total_action_numer_of_this_nw = 0; // Суммарное количество действий данной нейросети
        public int Delta 
        {
            get{ return this.total_action_numer_of_this_nw - previous.total_action_numer_of_this_nw; }
           
        }
        public Neuroweb(Reach1000 mother, bool dospawn = true)
        {
            Mother = mother;
            if (Reach1000.network_version == 0 && dospawn == true) Spawn();
           
        }

        void Spawn() 
        {
            int next_neuron_index;
            Reach1000.network_version++;
            Mother.Show_network_version();
            for (int i = 0; i < 5; i++)
            { 
                Initial_action_creation(ref initial_action[i]);
                web[i] = new Neuron(initial_action[i]);
            }
            for (int i = 0; i < 5; i++)
            { 
                do { next_neuron_index = Reach1000.sluchai.Next(0, 5); } while (next_neuron_index == i);
                web[i].Next = web[next_neuron_index];
            }
            previous = (Neuroweb)this.Clone();
                
        }
        public void Start(ref Neuroweb sender)
        { 
            web[0].Act(ref sender);
        }
        public void Evolve() 
        {
                Reach1000.network_version++;
                Reach1000.action_number = 0;
                previous = (Neuroweb)this.Clone();
            reached_number = 0;
            Mother.Show_network_version();
            for (int i = 0; i < web.Length; i++)
            {
                if (Reach1000.sluchai.Next(0, 101) <= Reach1000.chance)
                {
                    string op_name;
                    Neuron_Action act;
                    if (Reach1000.sluchai.Next(0, 101) < 50) op_name = "Add"; else op_name = "Delete";
                    if (Reach1000.sluchai.Next(0, 101) < 50) act = Add; else act = Multiply;
                    web[i].Change_action(op_name, act);
                }
                if (Reach1000.sluchai.Next(0, 101) <= Reach1000.chance)
                {
                    int j;
                    do 
                    { 
                        j = Reach1000.sluchai.Next(0, web.Length); 
                        web[i].Next = web[j]; 
                    }
                    while (i == j);
                }
                if (Reach1000.sluchai.Next(0, 101) <= Reach1000.chance)
                {
                    random_param += Reach1000.sluchai.Next(0, 5);
                }
            }
            //Mother.Pause = true;
            //web[0].Act(this);
        }
        void Initial_action_creation(ref Neuron_Action action)
        {
            int i = 0;
            int j = 0;
            int who = 0; 
            // who отвечает за создание случайного порядка действий
            // Когда один из типов действий будет полностью внесен в коллекцию, 
            // who примет постоянное значение, соответствующее оставшемуся типу
            for (int k = 0; k < initial_amount; k++)
            {
                if (i < multiply_amount && j < initial_amount - multiply_amount) who = Reach1000.sluchai.Next(0, 1); 
                else if (i < multiply_amount) who = 0;
                else who = 1;
                if( who == 0 && i < multiply_amount )
                { 
                    action += Multiply; 
                    i++;
                }
                if( who == 1 && j < initial_amount - multiply_amount)
                {
                    action += Add; 
                    j++;
                }
            } 
        }
        public object Clone() 
        {
            Neuroweb old = new Neuroweb(Mother, false)
            {
                reached_number = this.reached_number,
                random_param = this.random_param,
                initial_amount = this.initial_amount, 
                multiply_amount = this.multiply_amount
            };
            for (int i = 0; i < web.Length; i++)
            { old.web[i] = this.web[i]; }
            for (int i = 0; i < initial_action.Length; i++)
            { old.initial_action[i] = this.initial_action[i]; }
            return old;
        }
        public void Add(ref int x, int a)
        {
            if (a == 0) x += x; else x += a;
            Reach1000.action_number++;
            Reach1000.total_action_number++;
            total_action_numer_of_this_nw++;
            Mother.Show_action_number();
            Mother.Process_text(x, a, "Add");
        }
        public void Multiply(ref int x, int a)                                                                                                                              
        {
            if (a == 0) x *= x; else x *= a;
            Reach1000.action_number++;
            Reach1000.total_action_number++;
            total_action_numer_of_this_nw++;
            Mother.Show_action_number();
            Mother.Process_text(x, a, "Multiply");
        }
        
    }
    
}
