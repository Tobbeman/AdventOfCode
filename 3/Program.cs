using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = 12;
            first(input);
        }
        static int first(int input)
        {
            if (input == 1)
                return 0;

            int circle = 1;
            int circleLength = 8;
            int start = 2;
            int finish = 9;

            while (true)
            {
                if(start < input && input < finish)
                {
                    int sideLenght = 3 + (circle * 2);
                    int diff = input - start;
                    if(diff < sideLenght){
                        //Right side
                        
                    }
                }
                else
                {
                    circleLength += 8;
                    circle++;
                    start = finish + 1;
                    finish = finish + circleLength;
                }
            }
        }
    }
}
