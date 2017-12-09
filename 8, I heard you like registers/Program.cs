using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8__I_heard_you_like_registers
{
    class Program
    {
        struct line
        {
            public string register;
            public string change;
            public string ifRegister;
            public string ifOperator;
            public int ifValue;
        }

        static line parseLine(string line)
        {
            line l = new line();

            string[] segments = line.Split(' ');
            /*
             b  
             inc 
             5 <-(IF statement after this, not needed in this though) 
             a, 
             >, 
             1
             */

            l.register = segments[0];
            l.change = segments[1];
            l.ifRegister = segments[2];
            l.ifOperator = segments[3];
            l.ifValue = int.Parse(segments[4]);

            return l;
        
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

        static int first(IEnumerable<string> lines)
        {
            Dictionary<string, int> registers = new Dictionary<string, int>();
            bool pass = false;
            int highest = 0;
            foreach(var line in lines)
            {
                line l = parseLine(line);
                if (!registers.ContainsKey(l.register))
                {
                    registers.Add(l.register, 0);
                }
                if (!registers.ContainsKey(l.ifRegister))
                {
                    registers.Add(l.ifRegister, 0);
                }

                if (l.ifOperator == ">")
                {
                    if (registers[l.ifRegister] > l.ifValue) pass = true;
                }
                else if (l.ifOperator == "<")
                {
                    if (registers[l.ifRegister] < l.ifValue) pass = true;
                }
                else if(l.ifOperator == ">=")
                {
                    if (registers[l.ifRegister] >= l.ifValue) pass = true;
                }
                else if(l.ifOperator == "<=")
                {
                    if (registers[l.ifRegister] <= l.ifValue) pass = true;
                }
                else // ==
                {
                    if (registers[l.ifRegister] == l.ifValue) pass = true;
                }

                if (pass)
                {
                    if(l.change == "inc")
                    {
                        registers[l.register]++;
                        if (registers[l.register] > highest) highest = registers[l.register];
                    }
                    else registers[l.register]--;
                }
                    
            }
            return 0;
        }
        static int second(IEnumerable<string> lines)
        {
            return 0;
        }
    }
}
