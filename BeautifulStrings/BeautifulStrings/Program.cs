using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautifulStrings
{
    class BeautifulStrings
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (null == line)
                        continue;
                    CalculateStringBeauty(line);
                }
            }
        }

        static void CalculateStringBeauty(string hopefullyNotUgly)
        {
            var characterCounts = new Dictionary<char, int>();
            var stringToCalculate = hopefullyNotUgly.ToLower().ToCharArray();
            
            foreach(var letter in stringToCalculate)
            {
                if (letter < 'a' || letter > 'z') continue;
                characterCounts.Increment(letter); 
            }

            //sort the letters in descending order by count
            var sorted = characterCounts.OrderByDescending(a => a.Value);

            var beautyScore = 0;
            var currentBeautyValue = 26;

            foreach(var count in sorted)
            {
                beautyScore += (currentBeautyValue * count.Value);
                currentBeautyValue--;
            }

            Console.WriteLine(beautyScore);         
        }
    }

    public static class DictionaryHelper
    {
        /// <summary>
        /// If the dictionary contains the specified key, increments its value by 1. If the dictionary does not contain the
        /// key, adds it and sets its initial value to 1. 
        /// </summary>
        /// <param name="keyToIncrement">The key of the dictionary value to increment</param>
        public static void Increment(this Dictionary<char, int> dict, char keyToIncrement)
        {
            if(dict.ContainsKey(keyToIncrement))
            {
                dict[keyToIncrement]++;
            }
            else
            {
                dict[keyToIncrement] = 1;
            }
        }
    }
}
