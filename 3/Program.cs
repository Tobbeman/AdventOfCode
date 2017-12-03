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
            Console.WriteLine(second(input));
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
            int size = 501;
            int[,] circle = new int[size, size]; 

            //Create empty 2d list
            for(int i=0; i< size; i++)
            {
                for(int j=0; j < size; j++)
                {
                    circle[i,j] = 0;
                }
            }


            //Init
            int sideLength = 3;
            int sideCounter = 1;
            int posX = size / 2;
            int posY = size / 2;
            circle[posY, posX] = 1;
            posX++;
            circle[posY, posX] = 1;
            posY--;
            circle[posY, posX] = 2;
            string dir = "left";

            while (true)
            {
                if (circle[posY, posX] > 265149)
                    return circle[posY, posX];
                if (dir == "left")
                {
                    posX--;
                    sideCounter++;
                    circle[posY, posX] = returnQuadrantSum(posY,posX, circle);
                    if (sideCounter >= sideLength)
                    {
                        dir = "down";
                        sideCounter = 1;
                    }
                }
                if (dir == "down")
                {
                    posY++;
                    sideCounter++;
                    circle[posY, posX] = returnQuadrantSum(posY, posX, circle);
                    if (sideCounter >= sideLength)
                    {
                        dir = "right";
                        sideCounter = 1;
                    }
                }
                if (dir == "right")
                {
                    posX++;
                    sideCounter++;
                    circle[posY, posX] = returnQuadrantSum(posY, posX, circle);
                    if (sideCounter >= sideLength)
                    {
                        dir = "up";
                        sideCounter = 1;
                    }
                }
                if (dir == "up") // new circle layer
                {
                    posX++;
                    circle[posY, posX] = returnQuadrantSum(posY, posX, circle);
                    sideLength += 2;
                    while (true)
                    {
                        posY--;
                        circle[posY, posX] = returnQuadrantSum(posY, posX, circle);
                        sideCounter++;
                        if (sideCounter >= sideLength - 1)
                        {
                            dir = "left";
                            sideCounter = 1;
                            break;
                        }
                    }
                }
            }

            //writeCircle(circle);


            return 0;
        }
        static void writeCircle(int[,]cirlce)
        {
            for(int i = 0; i < cirlce.GetLength(0); i++)
            {
                for(int j=0;j<cirlce.GetLength(1); j++)
                {
                    Console.Write(cirlce[i, j] + " ");
                }
                Console.Write('\n');
            }
        }
        static int returnQuadrantSum(int posX,int posY, int[,] circle)
        {
            int sum = 0; 
            sum += circle[posX - 1, posY];
            sum += circle[posX + 1, posY];
            sum += circle[posX, posY - 1];
            sum += circle[posX, posY + 1];
            sum += circle[posX - 1, posY - 1];
            sum += circle[posX + 1, posY - 1];
            sum += circle[posX - 1, posY + 1];
            sum += circle[posX + 1, posY + 1];
            return sum;
        }
    }
}
