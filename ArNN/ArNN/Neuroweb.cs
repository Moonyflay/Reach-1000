using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArNN
{
    class Neuroweb
    {
        private int chance
        { get { return Reach1000.chance; } }
        public static int reached_number = 0;
        public static int random_param;
        public Neuroweb()
        {
            
            while (reached_number < Reach1000.goal)
            { 
                if (Reach1000.network_version == 1) Spawn();
                // здесь должна быть активация первого нейрона. Его номер зависит от версии нейросети
                Evolve();
            } 
        }

        void Spawn() 
        { 
        }
        void Evolve() 
        {
            Reach1000.network_version++;
        }

        public int Add(int x)
        { return x + x; }
        public int Multiply(int x) // Добавить параметр а: a*x, зависящий от версии сети
        { return x * x; }

    }
    
}
