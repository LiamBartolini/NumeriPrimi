using System;

namespace ripasso1
{
    class Program
    {
        static int nPrimi = 0;

        static void Main(string[] args)
        {
            ConsoleColor colore = Console.ForegroundColor;

            Console.WriteLine("Inserisci la lunghezza del vettore:");   //output
            string strN = Console.ReadLine();   //input
            int N;
            const int MAX = 10000;

            bool controllo = int.TryParse(strN, out N);

            if (controllo)
            {
                Console.WriteLine("Il numero inserito è corretto!");
            }
            else
            {
                Console.WriteLine("Non hai inserito un numero!");
            }

            //int[] vettore = new int[N];
            int[] vettore = new int[] {1, 3, 5, 6, 11, 8, 9, 997, 24, 56, 97, 523};
            
            for(int i = 0; i < vettore.Length; i++)
                stampaPrimo(vettore[i], true);

            Console.WriteLine("------------------------");
            
            for (int i = 0; i < MAX; i++)
                stampaPrimo(i, false);

            Console.WriteLine($"da 0 a {MAX} ho trovato {nPrimi} numeri primi");

            Console.ForegroundColor = colore;
        }

        static void stampaPrimo(int val, bool mode)
        {
            if (isPrime(val))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(val + " è primo");
                nPrimi++;
            }
            else 
            {
                if(mode)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(val + " non è primo");
                }
            }
        }

        static bool isPrime(int val)
        {
            if (val <= 1)
                return false;
            else
                for(int i = 2; i <= val/2; i++)
                    if (val % i == 0)
                        return false;

            return true;
        }
    }
}