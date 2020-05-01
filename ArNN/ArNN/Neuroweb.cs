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
        private int initial_amount = Reach1000.sluchai.Next(1, 6);  // Исходное количество действий для нейрона
        private int multiply_amount; // Исходное количество действий умножения в нейроне
        private bool initial_amount_was_defined = false;
        private int Multiply_amount 
        {
            get
            {
                if (initial_amount_was_defined == false)
                {
                    do { multiply_amount = Reach1000.sluchai.Next(0, 6); }
                    while (multiply_amount > initial_amount);
                    initial_amount_was_defined = true;
                }
                return multiply_amount; 
            }
            set { multiply_amount = value; }
        }
        public Neuron[] web = new Neuron[5];                       // Разница initial_amount и multiply_amount дает исходное количество действий сложения в нейроне
        Neuron_Action[] initial_action = new Neuron_Action[5];
        public Neuroweb previous;

        private int total_action_numer_of_this_nw = 0; // Суммарное количество действий данной версии нейросети
        private static int best_result = Reach1000.action_limit;
        public int Delta 
        {
            get
            {
                if (previous != null && previous.total_action_numer_of_this_nw != 0) return this.total_action_numer_of_this_nw - previous.total_action_numer_of_this_nw;
                else return this.total_action_numer_of_this_nw;
            }
           
        }
        public int Best_result
        {
            get
            {
                if (best_result > total_action_numer_of_this_nw && total_action_numer_of_this_nw > 0) best_result = total_action_numer_of_this_nw;
                return best_result;
            }
            set
            {
                best_result = value;
            }
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
            //Mother.Show_network_version();
            for (int i = 0; i < 5; i++)
            { 
                Initial_action_creation(ref initial_action[i], i);
                web[i] = new Neuron(initial_action[i]);
                web[i].num_of_mult += Multiply_amount;
                web[i].num_of_add += initial_amount - Multiply_amount;
            }
            for (int i = 0; i < 5; i++)
            { 
                do { next_neuron_index = Reach1000.sluchai.Next(0, 5); } while (next_neuron_index == i);
                web[i].Next = web[next_neuron_index];
                web[i].next_index = next_neuron_index;
            }
            //previous = (Neuroweb)this.Clone();
                
        }
        public void Start(ref Neuroweb sender)
        { 
            web[0].Act(ref sender);
        }
        public void Evolve() 
        {
                Reach1000.network_version++;                      
                /*if (total_action_numer_of_this_nw == 0) total_action_numer_of_this_nw = Reach1000.action_number;*/ // ?
                Reach1000.action_number = 0;
                previous = (Neuroweb)this.Clone();
            total_action_numer_of_this_nw = 0;
            reached_number = 0;
            ValueNeurons();
            for (int i = 0; i < web.Length; i++)
            {
                if (Reach1000.sluchai.Next(0, 101) <= Reach1000.chance * web[i].coeff) 
                {
                    string op_name;
                    Neuron_Action act;
                    int action_delta = 1;
                    if (Reach1000.sluchai.Next(0, 101) < 50) op_name = "Add"; else { op_name = "Delete"; action_delta = -1; } 
                    if (Reach1000.sluchai.Next(0, 101) < 50 * web[i].addmult_coeff) 
                    { 
                        act = Add;
                        web[i].num_of_add += action_delta;  
                    } 
                    else
                    { 
                        act = Multiply;
                        web[i].num_of_mult += action_delta; 
                    }
                    web[i].Change_action(op_name, act);
                    
                }
                if (Reach1000.sluchai.Next(0, 101) <= Reach1000.chance) //here
                {
                    int j;
                    do 
                    { 
                        j = Reach1000.sluchai.Next(0, web.Length); 
                        web[i].Next = web[j];
                        web[i].next_index = j;
                    }
                    while (i == j);
                }
                if (Reach1000.sluchai.Next(0, 101) <= Reach1000.chance * web[i].param_coeff )
                {
                    web[i].param += Reach1000.sluchai.Next(0, 5);
                    web[i].param_changed = true;
                }
            }
           
        }
        private void ValueNeurons()
        {
            int min = web[0].sum_of_delta;
            int max = web[0].sum_of_delta;

            for (int i = 1; i < web.Length; i++)
            {
                if (web[i].num_of_calls != 0)
                {
                    if (min > web[i].uspeshnost) min = web[i].sum_of_delta;
                    else
                    if (max < web[i].uspeshnost) max = web[i].sum_of_delta;
                }
            }
            if (max - min != 0)
                for (int i = 0; i < web.Length; i++)
                {
                    if (web[i].num_of_calls != 0 ) web[i].coeff = 1 - (web[i].sum_of_delta - min) / ((max - min) * web[i].num_of_calls);
                }
            for (int j  = 0; j <web.Length; j++)
            {
                if (web[j].uspeshnost > 0 && previous.web[j].uspeshnost >= 0)
                {
                    if (web[j].param_changed == true )
                    {
                        if (previous.web[j].uspeshnost < web[j].uspeshnost)
                            web[j].param_coeff -= 1 - previous.web[j].uspeshnost / web[j].uspeshnost;
                        else web[j].param_coeff += 1 - previous.web[j].uspeshnost / web[j].uspeshnost;
                        web[j].param_changed = false;
                    }
                    if (previous.web[j].num_of_add != web[j].num_of_add)
                    {
                        switch (previous.web[j].uspeshnost < web[j].uspeshnost)
                        {
                            case true:
                                    web[j].addmult_coeff += 1 - previous.web[j].uspeshnost / web[j].uspeshnost;
                                break;

                            case false:
                                    web[j].addmult_coeff -= 1 - previous.web[j].uspeshnost / web[j].uspeshnost; 
                                break; 
                        }
                    }
                    if (previous.web[j].num_of_mult != web[j].num_of_mult) 
                    {
                        switch (previous.web[j].uspeshnost < web[j].uspeshnost)
                        {
                            case true:
                                    web[j].addmult_coeff -= 1 - previous.web[j].uspeshnost / web[j].uspeshnost; 
                                break;

                            case false:
                                    web[j].addmult_coeff += 1 - previous.web[j].uspeshnost / web[j].uspeshnost;
                                break;
                        }
                    }
                }
                

            }
            for (int i = 0; i < web.Length; i++)
            {
                web[i].sum_of_delta = 0;
                web[i].num_of_calls = 0;
            }
        }
        void Initial_action_creation(ref Neuron_Action action, int web_num)
        {
            int i = 0;
            int j = 0;
            int who = 0; 
            // who отвечает за создание случайного порядка действий
            // Когда один из типов действий будет полностью внесен в коллекцию, 
            // who примет постоянное значение, соответствующее оставшемуся типу
            for (int k = 0; k < initial_amount; k++)
            {
                if (i < Multiply_amount && j < initial_amount - Multiply_amount) who = Reach1000.sluchai.Next(0, 1); 
                else if (i < Multiply_amount) who = 0;
                else who = 1;
                if( who == 0 && i < Multiply_amount )
                { 
                    action += Multiply;
                    i++;
                }
                if( who == 1 && j < initial_amount - Multiply_amount)
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
                initial_amount = this.initial_amount, 
                Multiply_amount = this.Multiply_amount,
                total_action_numer_of_this_nw = this.total_action_numer_of_this_nw
            };
            for (int i = 0; i < web.Length; i++)
            { old.web[i] = (Neuron)this.web[i].Clone(); }
            for (int i = 0; i < web.Length; i++)
            { old.web[i].Next = old.web[old.web[i].next_index]; }
            for (int i = 0; i < initial_action.Length; i++)
            { old.initial_action[i] = this.initial_action[i]; }
            return old;
        }
        public void Add(ref int x, int a)
        {
            if (Reach1000.action_number >= Reach1000.action_limit || x >= Reach1000.goal) return;
            x += a;
            Reach1000.action_number++;
            Reach1000.total_action_number++;
            this.total_action_numer_of_this_nw++;
            Mother.Process_text(x, a, "Add");
        }
        public void Multiply(ref int x, int a)                                                                                                                              
        {
            if (Reach1000.action_number >= Reach1000.action_limit || x >= Reach1000.goal) return;
            x *= a;
            Reach1000.action_number++;
            Reach1000.total_action_number++;
            this.total_action_numer_of_this_nw++;
            Mother.Process_text(x, a, "Multiply");
        }
        
    }
    
}
