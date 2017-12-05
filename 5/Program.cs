using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\input.txt");
            Console.WriteLine("Reading for file at: " + path);
            int[] array = File.ReadLines(path)
            .Where(r => !string.IsNullOrWhiteSpace((r)))
            .Select(r => int.Parse((r)))
            .ToArray();

            DateTime dt = DateTime.Now;
            Console.WriteLine("First: " + first((int[])array.Clone()));
            Console.WriteLine("Run time: " + (DateTime.Now - dt));
            dt = DateTime.Now;
            Console.WriteLine("Second: " + second((int[])array.Clone()));
            Console.WriteLine("Run time: " + (DateTime.Now - dt));
            Console.ReadKey();
        }
        static int first(int[] array)
        {
            int jumps = 0;
            int index = 0;
            int offset = 0;
            while (true)
            {
                if (index > array.Length - 1 || index < 0)
                    return jumps;
                offset = array[index];
                array[index]++;
                index += offset;
                jumps++;
            }
        }

        static int second(int[] array)
        {
            int jumps = 0;
            int index = 0;
            int offset = 0;
            while (true)
            {
                if (index > array.Length - 1 || index < 0)
                    return jumps;
                offset = array[index];
                if(offset >= 3)
                    array[index]--;
                else
                    array[index]++;
                index += offset;
                jumps++;
            }
        }
    }
}
