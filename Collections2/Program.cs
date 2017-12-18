using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Collections2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inFile = @"..\..\..\in.txt";
                StreamReader sr = new StreamReader(inFile);
                string s;
                int len, index;
                double x1, y1, x2, y2;
                List<Segment> list = new List<Segment>();
                Segment segment;
                string[] numbers;

                while ((s = sr.ReadLine()) != null)
                {
                    numbers = Regex.Split(s, @"\s*\(\s*|\s*;\s*|\s*\)\s*");

                    x1 = double.Parse(numbers[1]);
                    y1 = double.Parse(numbers[2]);
                    x2 = double.Parse(numbers[4]);
                    y2 = double.Parse(numbers[5]);
                    len = (int)(Math.Round(Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2)), MidpointRounding.AwayFromZero));
                    segment = new Segment(len);

                    index = list.BinarySearch(segment);
                    if (index < 0)
                    {
                        list.Insert(~index, segment);
                    }
                    else
                    {
                        list[index].Num++;
                    }
                }

                list.Sort(new Segment());

                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }           

            Console.Read();
        }
    }
}
