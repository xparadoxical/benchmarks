```
BenchmarkDotNet v0.13.7, Windows 11 (10.0.22621.2134/22H2/2022Update/SunValley2)
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 7.0.306
  [Host]     : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
```

| Method | _iterations |         Mean |      Error |     StdDev | Ratio | Allocated |
|------- |------------ |-------------:|-----------:|-----------:|------:|----------:|
|   Span |         100 |     55.19 ns |   1.128 ns |   1.254 ns |  0.76 |         - |
|  Array |         100 |     73.18 ns |   1.489 ns |   1.593 ns |  1.00 |         - |
| Stream |         100 |    246.26 ns |   3.422 ns |   2.857 ns |  3.35 |         - |
|        |             |              |            |            |       |           |
|   Span |       10000 |  4,651.84 ns |  45.611 ns |  38.087 ns |  0.74 |         - |
|  Array |       10000 |  6,297.51 ns | 117.251 ns | 156.527 ns |  1.00 |         - |
| Stream |       10000 | 23,243.75 ns | 250.667 ns | 222.210 ns |  3.71 |         - |