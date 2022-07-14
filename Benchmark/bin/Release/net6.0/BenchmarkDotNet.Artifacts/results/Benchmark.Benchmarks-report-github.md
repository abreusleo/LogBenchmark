``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
AMD Ryzen 9 3900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK=6.0.202
  [Host]     : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT
  DefaultJob : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT


```
|                      Method |      Mean |     Error |    StdDev |  Gen 0 | Allocated |
|---------------------------- |----------:|----------:|----------:|-------:|----------:|
|       Log_WithIf_WithParams |  4.118 ns | 0.0206 ns | 0.0172 ns |      - |         - |
|    Log_WithIf_WithoutParams |  3.863 ns | 0.1013 ns | 0.0948 ns |      - |         - |
|    Log_WithoutIf_WithParams | 88.348 ns | 1.3546 ns | 1.1311 ns | 0.0105 |      88 B |
| Log_WithoutIf_WithoutParams | 22.355 ns | 0.4739 ns | 0.7918 ns |      - |         - |
|    LoggerAdapter_WithParams | 12.459 ns | 0.2733 ns | 0.2807 ns |      - |         - |
| LoggerAdapter_WithoutParams |  4.750 ns | 0.1250 ns | 0.1669 ns |      - |         - |
