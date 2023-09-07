```
BenchmarkDotNet v0.13.7, Windows 11 (10.0.22621.2134/22H2/2022Update/SunValley2)
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 7.0.306
  [Host]     : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
```

|                  Method | Count |          Mean |         Error |        StdDev |  Ratio | Allocated |
|------------------------ |------ |--------------:|--------------:|--------------:|-------:|----------:|
|                     New |   100 |      38.61 ns |      0.697 ns |      0.618 ns |   1.00 |         - |
| ActivatorCreateInstance |   100 |   1,090.06 ns |     18.758 ns |     15.664 ns |  28.27 |    2400 B |
|  ConstructorInfo_Cached |   100 |   1,845.53 ns |     27.795 ns |     23.210 ns |  47.85 |    2400 B |
|         ConstructorInfo |   100 |   5,459.63 ns |    101.802 ns |     99.983 ns | 141.38 |    2400 B |
|  GetUninitializedObject |   100 |   5,721.31 ns |     92.100 ns |     98.546 ns | 148.09 |    2400 B |
|                         |       |               |               |               |        |           |
|                     New | 10000 |   2,961.37 ns |     27.452 ns |     22.924 ns |   1.00 |         - |
| ActivatorCreateInstance | 10000 | 108,259.81 ns |  2,059.904 ns |  1,720.113 ns |  36.56 |  240000 B |
|  ConstructorInfo_Cached | 10000 | 181,275.44 ns |  2,778.049 ns |  2,462.668 ns |  61.26 |  240000 B |
|         ConstructorInfo | 10000 | 527,352.00 ns | 10,430.043 ns | 10,243.697 ns | 177.88 |  240001 B |
|  GetUninitializedObject | 10000 | 608,327.25 ns |  8,076.923 ns |  7,159.982 ns | 205.24 |  240001 B |
