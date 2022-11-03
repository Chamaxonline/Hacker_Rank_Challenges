using System;
using System.Collections.Generic;
using System.Linq;

namespace Hacker_Rank_Challenges
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new List<int>() { 17, 28, 30 };
            var b = new List<int>() { 99, 16, 8 };
            var c = new List<int> { 1, 2, 3, 4, 5, 3 };
            CompareTriplets(a, b);
            MiniMaxSum(c);
            BirthdayCakeCandles(c);
        }

        public static int BirthdayCakeCandles(List<int> candles)
        {
            var numCollection = new Dictionary<long, int>();
            var finalCollection = new Dictionary<long, long>();
            var numArray = candles.ToArray();

            for (int i = 0; i < numArray.Length; i++)
            {
                if (!numCollection.ContainsKey(numArray[i]))
                {
                    numCollection.Add(numArray[i], 1);
                }
                else
                {
                    numCollection[numArray[i]]++;
                }
            }
            long max = int.MinValue;
            foreach (var item in numCollection)
            {
                var x = item.Key * item.Value;
                finalCollection.Add(item.Key, x);

                if (x >= max)
                {
                    max = x;
                }
            }
            var selectedCandle = finalCollection.FirstOrDefault(x => x.Value == max).Key;
            var selectedCount = numCollection.FirstOrDefault(x => x.Key == selectedCandle).Value;
            Console.WriteLine("{0}", selectedCandle);
            return selectedCount;


        }
        public static void MiniMaxSum(List<int> arr)
        {
            var min = long.MinValue;
            var max = long.MinValue;
            var numArray = arr.ToArray();

            for (int i = 0; i < numArray.Length; i++)
            {
                long sum = 0;
                long temp;
                for (int j = 0; j < numArray.Length; j++)
                {
                    if (i != j)
                    {
                        sum += numArray[j];
                    }
                }
                temp = sum;
                if (i == 0 || min >= temp)
                {
                    min = temp;
                }
                if (temp > max)
                {
                    max = temp;
                }
            }
            Console.WriteLine("{0} {1}", min, max);
        }
        public static List<int> CompareTriplets(List<int> a, List<int> b)
        {
            int scoreA = 0;
            int scoreB = 0;
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] > b[i])
                {
                    scoreA += 1;
                }
                else if (b[i] > a[i])
                {
                    scoreB = +1;
                }
            }
            var final = new List<int>();
            final.Add(scoreA);
            final.Add(scoreB);

            return final;
        }
    }
}
