using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jatek
{
    class Program
    {
        
        static void Main(string[] args)
        {
            List<Harcos> harcosok = new List<Harcos>();
            harcosok.Add(new Harcos("TRE", 1));
            harcosok.Add(new Harcos("TRETT", 2));
            harcosok.Add(new Harcos("TREG", 3));

            Random p = new Random();
            

            StreamReader r = new StreamReader("harcosok 1.csv");
            try
            {
                while (!r.EndOfStream)
                {
                    string[] sor = r.ReadLine().Split(';');
                    harcosok.Add(new Harcos(sor[0], Convert.ToInt32(sor[1])));
                }
                
            }
            catch (Exception)
            {

                throw;
            }
            r.Close();
            //foreach (var item in harcosok)
            //{
            //    Console.WriteLine(item);
            //}
            Console.WriteLine("Adja meg a nevet:");
            string nev = Console.ReadLine();
            Console.WriteLine("Adja meg a statuszsablont(1/2/3):");
            int statusz = Convert.ToInt32(Console.ReadLine());

            var uj = new Harcos(nev, statusz);
            harcosok.Add(uj);
          
            foreach (var item in harcosok)
            {
                Console.WriteLine(item);
            }
            for (int i = 0; i < harcosok.Count; i++)
            {
                Console.WriteLine("{0}.{1}",i+1,harcosok[i]);
            }
            //meccs
            char valasztas;
            do
            {
                Console.WriteLine("Válasszon a lehetőségek közül:\n " +
                   "a)Megküzdeni egy harcossal\n" +
                   "b)Gyogyulás\n" +
                   "c)Kilép");
                valasztas = Convert.ToChar(Console.ReadLine());
                while (valasztas != 'a' && valasztas != 'b' && valasztas != 'c')
                {
                    Console.WriteLine("Válasszon a lehetőségek közül:\n " +
                   "a)Megküzdeni egy harcossal\n" +
                   "b)Gyogyulás\n" +
                   "c)Kilép");
                    valasztas = Convert.ToChar(Console.ReadLine());
                    
                }
                if (valasztas == 'a')
                {
                    int ellVal;
                    do
                    {
                        Console.WriteLine("Hányadik ellenfelet akarja?");
                        for (int i = 0; i < harcosok.Count; i++)
                        {
                            Console.WriteLine(harcosok[i]);
                        }
                        ellVal = Convert.ToInt32(Console.ReadLine());
                        uj.Megkuzd(harcosok[ellVal - 1]);

                    } while (ellVal < 0 && ellVal > harcosok.Count );
                    
                    
                    
                }
                else if (valasztas == 'b')
                {
                    uj.Gyogyul();
                }
                else
                {
                    Console.WriteLine("Adjon meg másik betűt!");
                }

            } while (valasztas != 'c');


            Console.ReadLine();

        }
    }
}
