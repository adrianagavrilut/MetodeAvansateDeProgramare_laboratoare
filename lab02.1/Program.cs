using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab02._1
{
    class Program
    {
        static void Main(string[] args)
        {
            ExSmartSearch();
            
        }

        private static void ExSmartSearch()
        {
            string nume = "Popa Bota";
            string prenume = "Ana-Maria";

            char[] separatori = new char[] { ' ', '-' };
            string numePrenume = $"{nume} {prenume}";
            string[] numeComplet = numePrenume.Split(separatori);

            for (int i = 0; i < numeComplet.Length; i++)
            {
                Console.Write($"{numeComplet[i]} ");
            }
            Console.WriteLine();

            Console.Write("Search: ");
            string input = Console.ReadLine();
            string[] inputs = input.Split(separatori);


            bool ok = true;
            for (int i = 0; i < inputs.Length; i++)
            {
                bool ok2 = false;
                for (int j = 0; j < numeComplet.Length; j++)
                {
                    if (numeComplet[j].ToLower().Contains(inputs[i].ToLower()))
                    {
                        ok2 = true;

                    }
                }
                ok = ok && ok2;
            }
            if(ok)
            {
                Console.WriteLine($"User with name {nume} {prenume} found");
            }
            else
            {
                Console.WriteLine("User not found");
            }
        }
    }
}
