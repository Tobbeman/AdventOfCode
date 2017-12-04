using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\input.txt");
            Console.WriteLine("Reading for file at: " + path);
            var lines = File.ReadLines(path);

            DateTime dt = DateTime.Now;
            Console.WriteLine("First: " + first(lines));
            Console.WriteLine("Run time: " + (DateTime.Now - dt));
            dt = DateTime.Now;
            /*
            Console.WriteLine("Second: " + second(lines));
            Console.WriteLine("Run time: " + (DateTime.Now - dt));
            dt = DateTime.Now;*/
            Console.WriteLine("SecondImproved: " + secondImproved(lines));
            Console.WriteLine("Run time: " + (DateTime.Now - dt));
            //dt = DateTime.Now;
            Console.ReadKey();
        }
        static int first(IEnumerable<string> lines)
        {
            int score = 0;
            HashSet<string> wordSet;
            foreach(var line in lines)
            {
                wordSet = new HashSet<string>();
                string[] words = line.Split(' ');
                for(int i = 0; i < words.Length; i++)
                {
                    if (wordSet.Contains(words[i]))
                    {
                        break;
                    }
                    else
                    {
                        wordSet.Add(words[i]);
                        if (i == words.Length - 1)
                            score++;
                    }
                }
            }
            return score;
        }

        static int second(IEnumerable<string> lines)
        {
            int score = 0;
            Boolean pass = true ;
            HashSet<string> wordSet;
            foreach (var line in lines)
            {
                wordSet = new HashSet<string>();
                string[] words = line.Split(' ');
                pass = true;
                for (int i = 0; i < words.Length; i++)
                {
                    List<string> genWords = generateWords(words[i]);
                    for (int j = 0; j < genWords.Count; j++)
                    {
                        if (wordSet.Contains(genWords[j]))
                        {
                            pass = false;
                            break;
                        }
                        else
                        {
                            wordSet.Add(genWords[j]);                               
                        }
                    }
                }
                if (pass)
                    score++;
            }
            return score;
        }

        //
        static int secondImproved(IEnumerable<string> lines)
        {
            int score = 0;
            HashSet<string> wordSet;
            foreach (string line in lines)
            {
                wordSet = new HashSet<string>();
                string[] words = line.Split(' ');
                for (int i = 0; i < words.Length; i++)
                {
                    string w = String.Concat(words[i].OrderBy(c => c));
                    if (wordSet.Contains(w))
                    {
                        break;
                    }
                    else
                    {
                        wordSet.Add(w);
                        if (i == words.Length - 1)
                            score++;
                    }
                }
            }
            return score;
        }
    

        //recursion
        static List<string> getPerm(string word, int depth, int maxDepth)
        {
            List<string> perms = new List<string>();
            perms.Add(word);
            if (depth == maxDepth)
            {
                return perms;
            }
            for(int i = depth; i <= maxDepth; i++)
            {
                string swapped = SwapCharacters(word, depth, i);
                perms.Add(swapped);
                perms.AddRange(getPerm(swapped, depth + 1, maxDepth));
            }
            return perms;
                
        }


        static List<string> generateWords(string word)
        {
            List<string> l = getPerm(word,0,word.Length-1);
            List<string> n = new List<string>();
            HashSet<string> dict = new HashSet<string>();

            foreach(var w in l)
            {
                if (!dict.Contains(w))
                {
                    dict.Add(w);
                    n.Add(w);
                }
            }
            return n;
        }

        static string SwapCharacters(string value, int position1, int position2)
        {
            //
            // Swaps characters in a string.
            //
            char[] array = value.ToCharArray(); // Get characters
            char temp = array[position1]; // Get temporary copy of character
            array[position1] = array[position2]; // Assign element
            array[position2] = temp; // Assign element
            return new string(array); // Return string
        }
    }
}
