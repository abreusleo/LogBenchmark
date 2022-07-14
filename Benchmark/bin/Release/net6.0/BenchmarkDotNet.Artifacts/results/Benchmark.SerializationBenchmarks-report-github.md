``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
AMD Ryzen 9 3900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK=6.0.202
  [Host]     : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT
  DefaultJob : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT


```
|                     Method | Categories |     Mean |   Error |  StdDev | Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|--------------------------- |----------- |---------:|--------:|--------:|------:|--------:|--------:|--------:|----------:|
|          ClassicSerializer |     Stream | 219.7 μs | 4.29 μs | 5.42 μs |  1.00 |    0.00 | 18.3105 |  4.3945 |    150 KB |
|        GeneratedSerializer |     Stream | 121.7 μs | 2.39 μs | 4.66 μs |  0.55 |    0.02 | 18.0664 |  5.9814 |    150 KB |
|                            |            |          |         |         |       |         |         |         |           |
|   ClassicSerializer_String |     String | 232.6 μs | 4.50 μs | 5.70 μs |  1.00 |    0.00 | 32.2266 |  6.3477 |    265 KB |
| GeneratedSerializer_String |     String | 141.1 μs | 2.51 μs | 5.82 μs |  0.62 |    0.02 | 32.2266 | 10.4980 |    264 KB |
