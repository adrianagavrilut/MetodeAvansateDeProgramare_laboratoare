using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab04_1
{
    class Mamifer : Animal
    {
        public char Gen { get; set; }
        public int NrMembre { get; set; }

        public Mamifer(string specia, string culoare, char gen, int nrMembre) 
            : base(specia, culoare)
        {
            Gen = gen;
            NrMembre = nrMembre;
        }

        public void Mananca(Animal prada)
        {
            Hranire(prada.NivelDeEnergie);
        }
    }
}
