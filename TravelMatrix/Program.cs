using System;

namespace TravelMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = @"2
3 3
2 8";
            input = input.Replace("\r", "");
            Test[] tests = parseInput(input);
            
            foreach (Test t in tests)
            {
                int possibilities = 0;
                possibilities = t.travelMatrix(0,0);
                Console.WriteLine(possibilities);
            }
        }

        static Test[] parseInput(string input)
        {
            string[] inputs = input.Split("\n");
            
            int num_of_tests = Int32.Parse(inputs[0]);
            Test[] tests = new Test[num_of_tests];

            for (int i = 1; i < inputs.Length; i++)
            {
                string[] sizes = inputs[i].Split(" ");
                Test t = new Test(Int32.Parse(sizes[0]), Int32.Parse(sizes[1]));
                tests[i - 1] = t;
            }

            return tests;
        }
    }

    class Test
    {
        int[,] matrix;
        int x;
        int y;

        public Test(int a, int b)
        {
            matrix = new int[a, b];
            x = a - 1;
            y = b - 1;
        }

        public int travelMatrix(int a, int b)
        {
            int possibilities = 0;

            if(x > a)
            {
                possibilities += travelMatrix(a + 1, b);
                
            }
            if(y > b)
            {
                possibilities += travelMatrix(a, b + 1);
                
            }
            if(x == a && y == b)
            {
                return 1;
            }

            return possibilities;
        }
    }
}
