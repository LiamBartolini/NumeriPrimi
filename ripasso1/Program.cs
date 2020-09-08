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

            //ci sono numeri consecutivi
            //int[] vettore = new int[] { 1, 3, 5, 6, 11, 8, 9, 997, 24, 56, 97, 523 };
            
            //non ci sono numeri consecutivi
            int[] vettore = new int[] { 3, 7, 13, 23};

            for (int i = 0; i < vettore.Length; i++)
                stampaPrimo(vettore[i], true);

            if (nPrimi >= 2)
                Console.WriteLine("Ci sono almeno due numeri primi!");

            Console.WriteLine("------------------------");

            //numeri da 1 a 10000
            for (int i = 0; i < MAX; i++)
                stampaPrimo(i, false);

            Console.WriteLine($"da 0 a {MAX} ho trovato {nPrimi} numeri primi");

            Console.WriteLine("------------------------");
            
            int cont = 0;

            //conto quanti sono i numeri primi nella serie
            for (int i = 0; i < vettore.Length; i++)
                if (isPrime(vettore[i]))
                    cont++;

            //istanzio un vettore di lunghezza 'cont' e lo sorto
            int[] prime = new int[cont];
            cont = 0;
            
            for (int i = 0; i < vettore.Length; i++)
            {
                if (isPrime(vettore[i]))
                {
                    prime[cont] = vettore[i];
                    cont++;
                }
            }

            Array.Sort(prime);

            bool flag = false;

            for (int i = 0; i < prime.Length - 1; i++)
            {
                int val1 = prime[i];
                int val2 = prime[i + 1];

                flag = isConsecutivePrime(prime[i] + 1, prime[i + 1]);
                
                if (flag)
                {
                    Console.WriteLine($"i numeri {val1} e {val2} sono consecutivi");
                    break;
                }
            }

            if (!flag)
                Console.WriteLine("non ci sono dei numeri primi consecutivi");

            Console.ForegroundColor = colore;
        }

        static bool isConsecutivePrime(int val1, int val2)
        {
            //cerco un valore primo tra val1 e val2
            while (val1 < val2)
            {
                if (isPrime(val1))
                {
                    Console.WriteLine($"i numeri {val1} e {val2} non sono consecutivi");
                    return false;
                }
                else
                {
                    Console.Write(".");
                }

                val1++;
            };

            return true;
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