using BenchmarkDotNet.Running;

namespace ReflectionPerformance
{
    public class Program
    {
        static void Main(string[] args) =>
            BenchmarkRunner.Run<Benchmarks>();
    }
}
