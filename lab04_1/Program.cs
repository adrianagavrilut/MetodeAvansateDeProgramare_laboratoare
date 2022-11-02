using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab04_1
{
    static class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            Animal amiba = new Animal("Amiba", "albastra");
            Console.WriteLine(amiba.GetSpecia);

            while (amiba.Varsta < 20)
            {
                Console.WriteLine($"----------------------ziua {amiba.Varsta}----------------------");
                bool gasesteMancare = random.Next(2) == 1;
                if (gasesteMancare)
                {
                    double valoareMancare = random.NextDouble() * 0.3 + 0.1;
                    amiba.Hranire(valoareMancare);
                }
                amiba.Imbatranire(1);
                if (amiba.NivelDeEnergie <= 0)
                    break;
            }
            Console.WriteLine($"{amiba.GetSpecia} a murit dupa {amiba.Varsta} zile");

            /*Animal caine = new Caine("Labrador", "Golden", 'M', 4, "Marcel");
            (caine as Caine).Latra();*/
            Console.WriteLine();
            Caine caine = new Caine("Labrador", "Golden", 'M', 4, "Marcel");
            Console.WriteLine(caine.GetSpecia);
            //TODO: caine.Mananca(), care hranire foloseste
            caine.Latra();
            caine.Imbatranire(1);
            Console.WriteLine($"Varsta: {caine.Varsta}");


            Console.WriteLine();


            //Extension Methods

            string propozitie = "Ana are mere. Ana ! nu ! are alte fructe?";
            //string[] cuvinte = ToWords(propozitie);
            string[] cuvinte = propozitie.ToWords();
            foreach (string cuvant in cuvinte)
            {
                Console.WriteLine(cuvant);
            }

            //Generics
            Zoo zoo = new Zoo();
            //zoo.habitate.Add(new Habitat<Caine>());
        }

        public static string[] ToWords(this string sentence)
        {
            return sentence
                .Split(' ', '.', ',', ';', '!', '?')
                .Where(x => !string.IsNullOrEmpty(x))
                .ToArray();
        }

        public static void Suma<T>(T vanator, T prada)
            where T : Mamifer
        {
            if (random.Next(4) != 0)
            {
                vanator.Mananca(prada);
            }
        }
    }
}
