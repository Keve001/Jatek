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

            var a = new Harcos(nev, statusz);
            harcosok.Add(a);
          
            foreach (var item in harcosok)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();

        }
    }
}
