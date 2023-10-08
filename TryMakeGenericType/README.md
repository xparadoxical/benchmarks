```
BenchmarkDotNet v0.13.7, Windows 11 (10.0.22621.2283/22H2/2022Update/SunValley2)
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 7.0.401
  [Host]     : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
```

|             Method | CorrectArgRate |        Mean |     Error |    StdDev | Ratio | Exceptions | Allocated |
|------------------- |--------------- |------------:|----------:|----------:|------:|-----------:|----------:|
|     Check_TryCatch |             50 | 30,971.2 ns | 583.21 ns | 671.62 ns |  1.00 |     0.9847 |     872 B |
| Check_InternalCall |             50 |    469.5 ns |   8.05 ns |   7.14 ns |  0.02 |          - |      32 B |
|                    |                |             |           |           |       |            |           |
|     Check_TryCatch |             85 |  8,578.4 ns | 162.69 ns | 159.78 ns |  1.00 |     0.3019 |     312 B |
| Check_InternalCall |             85 |    457.6 ns |   4.47 ns |   4.18 ns |  0.05 |          - |      32 B |
|                    |                |             |           |           |       |            |           |
|     Check_TryCatch |             90 |  5,752.5 ns |  81.58 ns |  76.31 ns |  1.00 |     0.1998 |     228 B |
| Check_InternalCall |             90 |    480.6 ns |   6.48 ns |   6.06 ns |  0.08 |          - |      32 B |
|                    |                |             |           |           |       |            |           |
|     Check_TryCatch |             95 |  2,958.0 ns |  48.21 ns |  45.09 ns |  1.00 |     0.0994 |     145 B |
| Check_InternalCall |             95 |    479.0 ns |   7.50 ns |   7.02 ns |  0.16 |          - |      32 B |
|                    |                |             |           |           |       |            |           |
|     Check_TryCatch |             98 |  1,356.5 ns |  26.29 ns |  28.13 ns |  1.00 |     0.0399 |      97 B |
| Check_InternalCall |             98 |    472.6 ns |   6.45 ns |   6.03 ns |  0.35 |          - |      32 B |
|                    |                |             |           |           |       |            |           |
|     Check_TryCatch |            100 |    255.0 ns |   2.46 ns |   2.30 ns |  1.00 |          - |      64 B |
| Check_InternalCall |            100 |    485.5 ns |   6.44 ns |   6.03 ns |  1.90 |          - |      32 B |
|                    |                |             |           |           |       |            |           |
|   TryMake_TryCatch |             50 | 27,459.0 ns | 321.00 ns | 250.61 ns |  1.00 |     1.0057 |     889 B |
|         TryMake_If |             50 |    537.7 ns |   5.52 ns |   5.17 ns |  0.02 |          - |      80 B |
|                    |                |             |           |           |       |            |           |
|   TryMake_TryCatch |             85 |  8,547.4 ns | 162.71 ns | 205.77 ns |  1.00 |     0.3002 |     310 B |
|         TryMake_If |             85 |    586.8 ns |   4.72 ns |   3.94 ns |  0.07 |          - |      91 B |
|                    |                |             |           |           |       |            |           |
|   TryMake_TryCatch |             90 |  5,702.8 ns |  54.62 ns |  51.09 ns |  1.00 |     0.1995 |     228 B |
|         TryMake_If |             90 |    598.3 ns |   5.73 ns |   5.08 ns |  0.10 |          - |      93 B |
|                    |                |             |           |           |       |            |           |
|   TryMake_TryCatch |             95 |  2,948.9 ns |  35.57 ns |  33.27 ns |  1.00 |     0.0992 |     145 B |
|         TryMake_If |             95 |    605.8 ns |   4.08 ns |   3.41 ns |  0.21 |          - |      94 B |
|                    |                |             |           |           |       |            |           |
|   TryMake_TryCatch |             98 |  1,350.6 ns |  19.48 ns |  17.27 ns |  1.00 |     0.0393 |      96 B |
|         TryMake_If |             98 |    615.5 ns |   6.72 ns |   6.29 ns |  0.46 |          - |      95 B |
|                    |                |             |           |           |       |            |           |
|   TryMake_TryCatch |            100 |    240.8 ns |   3.28 ns |   2.91 ns |  1.00 |          - |      64 B |
|         TryMake_If |            100 |    610.0 ns |   4.89 ns |   4.09 ns |  2.53 |          - |      96 B |
