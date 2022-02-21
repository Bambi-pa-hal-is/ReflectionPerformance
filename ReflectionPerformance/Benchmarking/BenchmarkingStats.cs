using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionPerformance.Benchmarking
{
    public class BenchmarkingStats
    {
        public string Method { get; set; }
        public long Time { get; set; }

        public override string ToString()
        {
            return $"{Method} - {Time} milliseconds";
        }
    }
}
