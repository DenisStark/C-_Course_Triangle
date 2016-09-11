using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            LinkedList<string> strings = new LinkedList<string>();
            System.IO.StreamReader file = new System.IO.StreamReader(@"Triangle - 2.txt");
            while ((line = file.ReadLine()) != null)
            {
                strings.AddLast(line);
            }
            file.Close();

            int[,] Array = new int[strings.Count, strings.Count];
            for (int i = 0; i < strings.Count; i++)
            {
                var result = strings.ElementAt(i).Split(' ');
                for (int j = 0; j < result.Length; j++)
                {
                    int.TryParse(result[j], out Array[i, j]);
                }
            }

            for (int i = strings.Count - 2; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (j == 0)
                    {
                        Array[i, j] = Array[i, j] + Math.Max(Array[i + 1, j], Array[i + 1, j + 1]);
                    }
                    if (j > 0)
                    {
                        Array[i, j] = Array[i, j] + Math.Max(Math.Max(Array[i + 1, j], Array[i + 1, j + 1]), Array[i + 1, j - 1]);
                    }
                }
            }
            System.Console.WriteLine(Array[0, 0]);
            System.Console.ReadLine();
        }
    }
}
