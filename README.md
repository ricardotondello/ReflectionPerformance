# ReflectionPerformance

## Results

``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19042.1052 (20H2/October2020Update)
Intel Xeon W-10855M CPU 2.80GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=5.0.301
  [Host]     : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT


```

|                         Method |       Mean |     Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |-----------:|----------:|----------:|-------:|------:|------:|----------:|
|                      SimpleGet |   5.572 ns | 0.0797 ns | 0.0707 ns | 0.0051 |     - |     - |      32 B |
|          TraditionalReflection | 111.890 ns | 2.1603 ns | 2.2185 ns | 0.0050 |     - |     - |      32 B |
| OptimizedTraditionalReflection |  67.126 ns | 1.1596 ns | 1.0847 ns | 0.0050 |     - |     - |      32 B |
|               CompiledDelegate |   7.778 ns | 0.2193 ns | 0.2437 ns | 0.0051 |     - |     - |      32 B |