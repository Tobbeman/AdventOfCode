using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _7__Recursive_Circus
{
    class Program
    {
        struct disc
        {
            public string name;
            public int weight;
            public int totWeight;
            public List<disc> children;
        }

        static disc parseLine(string line)
        {
            disc d = new disc();

            string[] segments = line.Split(' ');
            /*
             mypyemv  
             (1058) 
             -> 
             tdssotr, 
             pebnvks, 
             zaulju
             */

            d.name = segments[0];

            d.weight = int.Parse(segments[1].Substring(1, segments[1].Length - 1));

            disc[] arr = new disc[segments.Length - 2];
            for(int i = 2; i < segments.Length; i++)
            {
                //arr[i - 2] = segments[i].Substring(0, segments[i].Length - 1);
            }

            return d;
        }

        static void Main(string[] args)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\input.txt");
            Console.WriteLine("Reading for file at: " + path);
            var lines = File.ReadLines(path);

            DateTime dt = DateTime.Now;
            Console.WriteLine("First: " + first(lines));
            Console.WriteLine("Run time: " + (DateTime.Now - dt));
            dt = DateTime.Now;
            Console.WriteLine("Second: " + second(lines));
            Console.WriteLine("Run time: " + (DateTime.Now - dt));
            Console.ReadKey();
        }
        static string first(IEnumerable<string> lines)
        {
            HashSet<string> hasParent = new HashSet<string>();

            foreach(var line in lines)
            {
                string[] segments = line.Split(' ');
                for (int i = 3; i < segments.Length; i++)
                {
                    if (i == segments.Length - 1)
                        hasParent.Add(segments[i]);
                    else
                        hasParent.Add(segments[i].Substring(0, segments[i].Length - 1));
                }
            }
            foreach(var line in lines)
            {
                string[] segments = line.Split(' ');
                if (!hasParent.Contains(segments[0]))
                    return segments[0];
            }
            return "Error";
        }

        static int second(IEnumerable<string> lines)
        {
            Dictionary<string, disc> discMap = new Dictionary<string, disc>();
            List<string> linesWithChildren = new List<string>();
            foreach (var line in lines)
            {
                string[] segments = line.Split(' ');
                disc d = new disc();
                d.name = segments[0];
                string f = segments[1].Substring(1, segments[1].Length - 2);
                d.weight = int.Parse(f);
                d.totWeight = d.weight;
                discMap.Add(d.name, d);

                if(segments.Length >= 3)
                {
                    linesWithChildren.Add(line);
                }
            }

            foreach (var line in linesWithChildren)
            {
                string[] segments = line.Split(' ');
                disc d = discMap[segments[0]];
                int layerWeight = 0;
                for (int i = 3; i < segments.Length; i++)
                {
                    string name;
                    if (i == segments.Length - 1)
                        name = segments[i];
                    else
                        name = segments[i].Substring(0, segments[i].Length - 1);

                    disc child = discMap[name];

                    if (i == 3)
                        layerWeight = child.totWeight;

                    if (child.totWeight != layerWeight)
                        return child.totWeight - layerWeight;

                    d.totWeight += child.weight;
                }
                discMap[d.name] = d;
            }
            return 0;
        }
    }
}
