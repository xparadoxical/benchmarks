```
BenchmarkDotNet v0.13.7, Windows 11 (10.0.22621.2283/22H2/2022Update/SunValley2)
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 7.0.401
  [Host]     : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
```

|          Method | CorrectArgRate |        Mean |     Error |    StdDev | Ratio | Exceptions | Allocated |
|---------------- |--------------- |------------:|----------:|----------:|------:|-----------:|----------:|
|        TryCatch |             50 | 31,423.7 ns | 615.84 ns | 709.20 ns |  1.00 |     1.0085 |     891 B |
| If_InternalCall |             50 |    555.6 ns |   5.79 ns |   5.14 ns |  0.02 |          - |      80 B |
|                 |                |             |           |           |       |            |           |
|        TryCatch |             85 |  8,740.6 ns | 173.11 ns | 153.46 ns |  1.00 |     0.2966 |     307 B |
| If_InternalCall |             85 |    604.7 ns |   4.37 ns |   4.08 ns |  0.07 |          - |      91 B |
|                 |                |             |           |           |       |            |           |
|        TryCatch |             90 |  5,872.8 ns |  55.77 ns |  49.44 ns |  1.00 |     0.1989 |     227 B |
| If_InternalCall |             90 |    600.1 ns |   3.73 ns |   3.11 ns |  0.10 |          - |      93 B |
|                 |                |             |           |           |       |            |           |
|        TryCatch |             95 |  3,044.7 ns |  39.28 ns |  36.75 ns |  1.00 |     0.1020 |     148 B |
| If_InternalCall |             95 |    618.7 ns |   4.87 ns |   3.80 ns |  0.20 |          - |      94 B |
|                 |                |             |           |           |       |            |           |
|        TryCatch |             98 |  1,357.9 ns |  19.76 ns |  17.51 ns |  1.00 |     0.0395 |      96 B |
| If_InternalCall |             98 |    618.3 ns |   4.23 ns |   3.95 ns |  0.46 |          - |      95 B |
|                 |                |             |           |           |       |            |           |
|        TryCatch |            100 |    237.2 ns |   3.76 ns |   3.52 ns |  1.00 |          - |      64 B |
| If_InternalCall |            100 |    620.7 ns |   6.09 ns |   5.09 ns |  2.61 |          - |      96 B |
