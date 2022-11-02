using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab04_1
{
    internal class Animal
    {
        string specia;
        double nivelDeEnergie;

        public string GetSpecia 
        {
            get
            {
                return specia;
            }
            set
            {
                specia = value;
            } 
        }
        public int Varsta { get; protected set; }
        public string Culoare { get; set; }
        public double NivelDeEnergie 
        { 
            get 
            {
                return nivelDeEnergie;
            } 
            protected set 
            {
                nivelDeEnergie = value / 2;
            } 
        }

        public Animal(string specia, string culoare)
        {
            this.specia = specia;
            this.Varsta = 0;
            this.Culoare = culoare;
            this.nivelDeEnergie = 0.7;
        }

        public virtual void Hranire(double sursaDeEnergie)
        {
            Console.WriteLine($"{specia} a gasit mancare in valoare de {sursaDeEnergie.ToString("0.00")}");
            nivelDeEnergie += sursaDeEnergie / 2;
        }

        public virtual void Imbatranire(int nrZile)
        {
            if (nrZile < 0)
                return;
            Varsta += nrZile;
            nivelDeEnergie -= 0.1 * nrZile;
        }
    }
}