``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
AMD Ryzen 9 3900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK=6.0.202
  [Host]     : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT
  DefaultJob : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT


```
|               Method | Categories |      Mean |     Error |    StdDev | Ratio |  Gen 0 | Allocated |
|--------------------- |----------- |----------:|----------:|----------:|------:|-------:|----------:|
|         IfLog_Params |     Params |  4.157 ns | 0.1086 ns | 0.1016 ns |  0.05 |      - |         - |
|     NormalLog_Params |     Params | 91.579 ns | 1.4523 ns | 1.2127 ns |  1.00 | 0.0105 |      88 B |
| LoggerAdapter_Params |     Params | 11.676 ns | 0.2112 ns | 0.1976 ns |  0.13 |      - |         - |
|                      |            |           |           |           |       |        |           |
|                IfLog |   NoParams |  3.888 ns | 0.0415 ns | 0.0388 ns |  0.17 |      - |         - |
|            NormalLog |   NoParams | 22.508 ns | 0.3569 ns | 0.3339 ns |  1.00 |      - |         - |
|        LoggerAdapter |   NoParams |  4.660 ns | 0.0553 ns | 0.0462 ns |  0.21 |      - |         - |
