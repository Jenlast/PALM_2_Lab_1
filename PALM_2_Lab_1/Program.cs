using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_1
{
    class Program
    {
        static void Main()
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Введіть числа через пробіл: ");
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

            FindPairs(arr);
        }
        static void FindPairs(int[] arr)
        {
            if (arr.Length % 2 != 0)
            {
                Console.WriteLine("Неможливо");
                return;
            }
            for (int i = 1; i < arr.Length; ++i)
            {
                int key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }

            int sum = arr[0] + arr[arr.Length - 1];  
            List<Tuple<int, int>> pairs = new List<Tuple<int, int>>();
            pairs.Add(new Tuple<int, int>(arr[0], arr[arr.Length - 1]));
            
            for (int i = 1; i < arr.Length / 2; i++)
            {
                if (arr[i] + arr[arr.Length - 1 - i] != sum)
                {
                    Console.WriteLine("Неможливо");
                    return;
                }
                pairs.Add(new Tuple<int, int>(arr[i], arr[arr.Length - 1 - i]));
            }
            Console.WriteLine("Пари, які можна утворити з цього набору чисел: ");

            foreach (var i in pairs)
            {
                Console.WriteLine(i.Item1 + " " + i.Item2);
            }
        }
    }
}