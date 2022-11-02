using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab04_1
{
    //Generice: Habitat pentru un singur tip de animale
    class Zoo
    {
        public List<Habitat<Animal>> habitate;

        public Zoo()
        {
            habitate = new List<Habitat<Animal>>();
        }
    }
}
