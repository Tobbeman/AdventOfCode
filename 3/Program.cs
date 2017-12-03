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
            int input = 265149;
            Console.WriteLine(first(input));
            Console.ReadKey();
        }
        static int first(int input)
        {
            if (input == 1)
                return 0;

            int distance = 0;
            int circle = 1;
            int circleLength = 8;
            int start = 2;
            int finish = 9;

            while (true)
            {
                if(start <= input && input <= finish)
                {
                    int sideLenght = 3 + ((circle-1) * 2);
                    int topRight = start + sideLenght - 2;
                    int topLeft = start + sideLenght * 2 - 3;
                    int botLeft = start + sideLenght * 3 - 4;
                    int botRight = finish;

                    
                    if (input < topRight){
                        //Right side
                        distance += Math.Abs(input - (topRight - sideLenght / 2));
                        return distance + circle;
                    }
                    else if(topRight <= input && input < topLeft ){
                        //Top side
                        distance += Math.Abs(input - (topRight + sideLenght / 2));
                        return distance + circle;
                    }
                    else if (topLeft <= input && input < botLeft){
                        //Left side
                        distance += Math.Abs(input - (topLeft + sideLenght / 2));
                        return distance + circle;
                    }
                    else if(botLeft <= input && input <= finish){
                        //Bot side
                        distance += Math.Abs(input - (botLeft + sideLenght / 2));
                        return distance + circle;
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
        static int second(int input)
        {
            var circle = new List<int>();
            
            //Init
            int depth = 1;
            int sideLength = 3;
            circle.Add(1);

            while (true)
            {

            }
            return 0;
        }
    }
}
