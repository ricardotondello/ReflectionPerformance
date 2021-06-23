using BenchmarkDotNet.Attributes;

namespace ReflectionPerformance
{
    [HtmlExporter]
    [MemoryDiagnoser]
    public class Benchmarks
    {
        [Benchmark]
        public string SimpleGet() => ReflectionUsage.SingleGet();

        [Benchmark]
        public string TraditionalReflection() => ReflectionUsage.TraditionalReflection();

        [Benchmark]
        public string OptimizedTraditionalReflection() => ReflectionUsage.OptimizedTraditionalReflection();

        [Benchmark]
        public string CompiledDelegate() => ReflectionUsage.CompiledDelegate();
    }
}
