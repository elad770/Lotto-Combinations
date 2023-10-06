using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoCombinations
{
    internal class Program
    {

        //It is a program that generates all the possible combinations in the lottery
        //16,273,488 options, the program creates every combination without repetitions using a recursive function with backtracking, relatively fast.
        //So then, save all the combinations in a text file

        static IList<IList<int>> CreateAllLottoCombination()
        {
            IList<IList<int>> listCombination = new List<IList<int>>();
            int[] arrLottoNums = new int[37];
            for (int i = 1; i <= arrLottoNums.Length; i++)
            {
                arrLottoNums[i - 1] = i;
            }
            int[] arr = new int[7];
            CreateCombinationReco(arrLottoNums, listCombination, arr, 6, arrLottoNums.Length, 0, 0);
            return listCombination;
        }

        private static void CreateCombinationReco(int[] arrLottoNums, IList<IList<int>> listCombination, int[] combination, int k, int n, int start, int len)
        {
            if (k == len)
            {
                return;
            }

            for (int i = start; i < n; i++)
            {
                combination[len] = arrLottoNums[i];
                CreateCombinationReco(arrLottoNums, listCombination, combination, k, n, i + 1, len + 1);
                if (len == k - 1)
                {
                    for (int j = 1; j < 8; j++)
                    {
                        combination[len + 1] = j;
                        listCombination.Add(new List<int>(combination));
                    }
                }
            }
        }

        static void Main(string[] args)
        {

            string filePath = "output.txt";
            var listOfCombinations = CreateAllLottoCombination();
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (List<int> combination in listOfCombinations)
                {
                    string line = string.Join(", ", combination);
                    writer.WriteLine(line);
                }
            }

        }

    }
}