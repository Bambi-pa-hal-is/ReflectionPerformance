using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionPerformance.Benchmarking
{
    public class Benchmarker
    {
        public List<BenchmarkingStats> Statistics { get; set; }
        public Stopwatch Stopwatch { get; set; }

        public Benchmarker()
        {
            Stopwatch = new Stopwatch();
            Statistics = new List<BenchmarkingStats>();
        }

        public void Reset()
        {
            Statistics.Clear();
        }

        public void Execute(string method,Action action)
        {
            Stopwatch.Reset();
            Stopwatch.Start();
            for(int i=0;i!=100000000;i++)
            {
                action();
            }
            Stopwatch.Stop();
            Statistics.Add(new BenchmarkingStats()
            {
                Method = method,
                Time = Stopwatch.ElapsedMilliseconds
            });
        }

        public void PrintResult()
        {
            PrintFastest();
            PrintCompareWithFastest();
        }

        private void PrintCompareWithFastest()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            var sorted = Statistics.OrderBy(x => x.Time);
            var fastest = sorted.FirstOrDefault();
            foreach(var item in sorted)
            {
                if(item != fastest)
                    Console.WriteLine($"{item.Method} is {((float)item.Time/ (float)fastest.Time).ToString("0.00")} times slower");
            }
            Console.ForegroundColor = ConsoleColor.White;

        }

        private void PrintFastest()
        {
            foreach(var item in Statistics.OrderBy(x => x.Time))
            {
                Console.WriteLine(item);
            }
        }


    }
}
