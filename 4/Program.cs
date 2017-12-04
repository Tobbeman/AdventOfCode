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


            generateWords("abcd");
            //Console.WriteLine("First: " + first(lines));
            Console.WriteLine("Second: " + second(lines));
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


        static List<string> generateWords(string word)
        {
            List<string> words = new List<string>();
            HashSet<string> dup = new HashSet<string>();
            for(int i = 0; i < word.Length; i++)
            {
                for(int j = 0; j < word.Length; j++)
                {
                    string anagram = SwapCharacters(word, i, j);
                    if (!dup.Contains(anagram))
                    {
                        words.Add(SwapCharacters(word, i, j));
                        dup.Add(anagram);
                    }
                }
            }
            return words;
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
