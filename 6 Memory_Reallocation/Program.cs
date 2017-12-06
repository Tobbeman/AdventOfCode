using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_Memory_Reallocation
{
    class Program
    {
        static void Main(string[] args)
        {
            //Setup
            var path = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\input.txt");
            Console.WriteLine("Reading for file at: " + path);

            var file = File.ReadLines(path);
            string line = file.First();
            string[] blocks = line.Split('\t');

            List<int> banks = new List<int>();
            for (int i=0; i < blocks.Length; i++)
            {
                banks.Add(int.Parse(blocks[i]));
            }
            int[] array = banks.ToArray();
            

            //Running program
            DateTime dt = DateTime.Now;
            Console.WriteLine("First: " + first((int[])array.Clone()));
            Console.WriteLine("Run time: " + (DateTime.Now - dt));
            dt = DateTime.Now;
            Console.WriteLine("Second: " + second((int[])array.Clone()));
            Console.WriteLine("Run time: " + (DateTime.Now - dt));
            dt = DateTime.Now;



            Console.ReadKey();
        }
        static int first(int[] banks)
        {
            int cycles = 0;
            int blocks = 0;
            int loopIndex = 0;
            string order = "";
            HashSet<string> orders = new HashSet<string>();
            while (true)
            {
                order = "";
                blocks = 0;
                for(int i = 0; i<banks.Length; i++)
                {
                    order += banks[i].ToString();
                    if (banks[i] > blocks)
                    {
                        blocks = banks[i];
                        loopIndex = i;
                    }
                }

                if (orders.Contains(order))
                    break;
                else
                    orders.Add(order);

                banks[loopIndex] = 0;
                loopIndex++;
                while (blocks > 0)
                {
                    if(loopIndex >= banks.Length)
                    {
                        loopIndex = 0;
                    }
                    banks[loopIndex]++;
                    blocks--;
                    loopIndex++;
                }
                cycles++;
            }

            return cycles;
        }
        static int second(int[] banks)
        {
            int cycles = 0;
            int blocks = 0;
            int loopIndex = 0;
            string order = "";
            Dictionary<string, int> orders = new Dictionary<string, int>();
            while (true)
            {
                order = "";
                blocks = 0;
                for (int i = 0; i < banks.Length; i++)
                {
                    order += banks[i].ToString();
                    if (banks[i] > blocks)
                    {
                        blocks = banks[i];
                        loopIndex = i;
                    }
                }

                if (orders.ContainsKey(order))
                    break;
                else
                    orders.Add(order, 0);

                foreach(string key in orders.Keys.ToList())
                    orders[key]++;

                banks[loopIndex] = 0;
                loopIndex++;
                while (blocks > 0)
                {
                    if (loopIndex >= banks.Length)
                    {
                        loopIndex = 0;
                    }
                    banks[loopIndex]++;
                    blocks--;
                    loopIndex++;
                }
                cycles++;
            }

            return orders[order];
        }
    }
}
