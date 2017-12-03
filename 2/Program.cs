using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\test.txt");
            Console.WriteLine("Reading for file at: " + path);
            var lines = File.ReadLines(path);

            //Console.WriteLine("First: " + first(lines));
            Console.WriteLine("Second: " + second(lines));
            Console.ReadKey();
        }

        static int first(IEnumerable<string> lines)
        {
            int score = 0;
            foreach (var line in lines)
            {
                int lowest = 999999999;
                int highest = 0;
                string[] data = line.Split('\t');

                for (int i = 0; i < data.Length; i++)
                {
                    int curr = int.Parse(data[i]);
                    if (curr > highest)
                        highest = curr;
                    if (curr < lowest)
                        lowest = curr;
                }
                score += (highest - lowest);
            }
            return score;
        }
        static int second(IEnumerable<string> lines)
        {
            int score = 0;
            foreach (var line in lines)
            {
                int low = 0;
                int high = 0;
                string[] data = line.Split('\t');

                for (int i = 0; i < data.Length; i++)
                {
                    int first = int.Parse(data[i]);
                    for(int j = i + 1; j < data.Length; j++)
                    {
                        int second = int.Parse(data[j]);
                        if ((second%first==0 || first % second == 0) && first != second)
                        {
                            if(first > second)
                            {
                                high = first;
                                low = second;
                            }
                            else
                            {
                                high = second;
                                low = first;
                            }
                            j = i = data.Length;                    
                        }
                    }
                }
                score += high / low;
            }
            return score;
        }
    }
}
