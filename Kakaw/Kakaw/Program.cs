using System;

namespace Kakaw
{
    public static class Program
    {
        public static void Main()
        {
            var sum = Add(2, 3);
        
            Console.WriteLine("Kakaw!");
        }

        public static int Add(int a, int b)
        {
            return a + b;
        }
    }
}