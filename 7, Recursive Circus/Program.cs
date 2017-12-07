using System;
using System.Collections.Generic;
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
            public disc[] children;
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

        }
    }
}
