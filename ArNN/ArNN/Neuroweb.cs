using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArNN
{
    class Neuroweb
    {
        static Reach1000 Mother;
        private int Сhance
        { get { return Reach1000.chance; } }
        public static int reached_number = 0;
        public static int random_param;
        private static int initial_amount = Reach1000.sluchai.Next(1,6);  // Исходное количество действий для нейрона
        private static int multiply_amount = Reach1000.sluchai.Next(0, 6);// Исходное количество действий умножения в нейроне
        public static Neuron[] web = new Neuron[5];                       // Разница initial_amount и multiply_amount дает исходное количество действий сложения в нейроне
        Neuron_Action[] action = new Neuron_Action[5];
        
        public Neuroweb(Reach1000 mother)
        {
            Mother = mother;
            if (Reach1000.network_version == 0) Spawn();
           
        }

        void Spawn() 
        {
            int next_neuron_index;
            Reach1000.network_version++;
            Mother.Show_network_version();
            for (int i = 0; i < 5; i++)
            { 
                do { next_neuron_index = Reach1000.sluchai.Next(0, 5); } while (next_neuron_index == i);
                Initial_action_creation(action[i]);
                web[i] = new Neuron(action[i], web[next_neuron_index]);
            }
            web[0].Act();
        }
        public static void Evolve() 
        {
                Reach1000.network_version++;
                Mother.Show_network_version();
            

        }
        void Initial_action_creation(Neuron_Action action)
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
        public void Add(ref int x, int a = 0)
        { 
            if (a == 0) x += x; else x += a;
            Reach1000.action_number++;
            Mother.Show_action_number();
        }
        public void Multiply(ref int x, int a = 0)                                                                                                                              
        { 
            if (a == 0) x *= x; else x *= a;
            Reach1000.action_number++;
            Mother.Show_action_number();
        }
        
    }
    
}
