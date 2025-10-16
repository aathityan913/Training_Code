
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace csharp.training.congruent.apps
{
    internal class Program
    {
        //everything that returns task is invariably a asychronous functions
        public static async Task<int> GetSquare(List<int> numbers)
        {
            await Task.Delay(30); // asynchronous delay
            int sum=0;
            foreach (int i in numbers)
            {
                sum+=i;
            }

            return sum;
        }

        static Task <int> GetNumber(int n)
        {
            Thread.Sleep(30);
            return Task.FromResult(n*n);
        }
        static async Task Main(string[] args)
        {
            Console.WriteLine(GetNumber(10));
            Console.WriteLine("Waiting");
            int d = await GetNumber(10);
            Console.WriteLine("Hello, World!" + " "+ d);
            Task.Delay(1000).Wait();
            Console.WriteLine("Waking up");
            Thread.Sleep(3000);
            Console.WriteLine("Waking up");

            int[] var1 = { 1, 2, 3 };
            for (int i = 0; i<var1.Length; i++) {
                Console.WriteLine(var1[i]);
            }
            Console.WriteLine("sum of squares");
            Task.Delay(1000).Wait();
            int result = await GetSquare(var1.ToList());
            Console.WriteLine("sum of sqauares is " + result);
        }
        
    }
}

