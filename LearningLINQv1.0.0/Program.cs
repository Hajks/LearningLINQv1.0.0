using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace LearningLINQv1._0._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] linqtest = new int[] {1, 2, 3, 4, 5};
            var result = from i in linqtest where i > 3 select i;
            foreach (int x in result)
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("\n //////////////////////////////////////////////// \n");

            int[] values = new int[] {0, 12, 44, 36, 92, 54, 13, 8};

            var result2 = from v in values // that's how linq looks like
                where v < 37 //So we take from our values, value which is lower then 37
                orderby v //We sort it from lowest to highest
                select v; // At the end we simply pick our group. 
            foreach (int number in result2)
            {
                Console.WriteLine(number);
            }


            Console.WriteLine("Kliknij dowolny przycisk, jesli chcesz zobaczyć wyniki kolejnego zadania :) ");
            Console.ReadKey();

            // *New task*

            Console.WriteLine("\n New task below: \n");

            IEnumerable<Comic> BuildCatalog() //static method which create our Catalog
            {
                return new List<Comic>
                {
                    new Comic() {Name = "Johny Amercia vs. the Pinko", Issue = 6},
                    new Comic() {Name = "Rock and Roll(edycja limitowana)", Issue = 19},
                    new Comic() {Name = "Woman's Work", Issue = 36},
                    new Comic() {Name = "Hippie Madness(źle wydrukowany)", Issue = 57},
                    new Comic() {Name = "Revenge of the New Wave Freak (uszkodzony)", Issue = 68},
                    new Comic() {Name = "Black Monday", Issue = 74},
                    new Comic() {Name = "Tribal Tattoo Madness", Issue = 83},
                    new Comic() {Name = "The Death of an Object", Issue = 97}
                };
            }

            Dictionary<int, decimal> GetPrices() // connecting issues number and price
            {
                return new Dictionary<int, decimal>
                {
                    {6, 3600M},
                    {19, 500M},
                    {36, 650M},
                    {57, 13525M},
                    {68, 250M},
                    {74, 75M},
                    {83, 25.75M},
                    {97, 35.25M},
                };
            }

            IEnumerable<Comic> comics = BuildCatalog(); 
            Dictionary<int, decimal> values2 = GetPrices();


            var mostExpensive =
                from comic in comics
                where values2[comic.Issue] > 500
                orderby values2[comic.Issue] descending
                select comic;

            foreach (Comic comic in mostExpensive)
            {
                Console.WriteLine("{0} jest warty {1:c}", comic.Name, values2[comic.Issue]); // Summarizing we selected comics with price higher then 500.
            }

            Console.ReadKey();
        }
    }
}