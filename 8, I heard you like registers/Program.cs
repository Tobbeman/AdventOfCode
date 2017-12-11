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
            public int value;
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
            l.value = int.Parse(segments[2]);
            l.ifRegister = segments[4];
            l.ifOperator = segments[5];
            l.ifValue = int.Parse(segments[6]);

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
            Console.ReadKey();
        }

        static Dictionary<string,int> runCode(IEnumerable<string> lines)
        {
            Dictionary<string, int> registers = new Dictionary<string, int>();
            int highest = 0; 
            foreach (var line in lines)
            {
                bool pass = false;
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
                else if (l.ifOperator == ">=")
                {
                    if (registers[l.ifRegister] >= l.ifValue) pass = true;
                }
                else if (l.ifOperator == "<=")
                {
                    if (registers[l.ifRegister] <= l.ifValue) pass = true;
                }
                else if(l.ifOperator == "==") 
                {
                    if (registers[l.ifRegister] == l.ifValue) pass = true;
                }
                else // ==
                {
                    if (registers[l.ifRegister] != l.ifValue) pass = true;
                }

                if (pass)
                {
                    if (l.change == "inc")
                    {
                        registers[l.register] += l.value;
                    }
                    else registers[l.register] -= l.value;
                }
                if (registers[l.register] > highest) highest = registers[l.register];
            }
            Console.WriteLine("Highest: " + highest);
            return registers;
        }

        static int first(IEnumerable<string> lines)
        {
            Dictionary<string, int> registers = runCode(lines);

            int highest = 0;
            foreach(var key in registers.Keys.ToArray())
            {
                if (registers[key] > highest) highest = registers[key];
            }
            return highest;
        }
        static int second(IEnumerable<string> lines)
        {
            return 0;
        }
    }
}
