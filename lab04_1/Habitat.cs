using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab04_1
{
    class Habitat<T>
        where T: Animal
    {
        public List<T> locuitori;

        public Habitat()
        {
            locuitori = new List<T>();
        }
    }
}
