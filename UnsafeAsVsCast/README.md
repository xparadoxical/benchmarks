```
BenchmarkDotNet v0.13.7, Windows 11 (10.0.22621.2134/22H2/2022Update/SunValley2)
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 7.0.306
  [Host]     : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
```

|                  Method | Count |        Mean |      Error |    StdDev | Ratio | Allocated |
|------------------------ |------ |------------:|-----------:|----------:|------:|----------:|
|      IntToByte_UnsafeAs |   100 |    68.57 ns |   1.094 ns |  0.970 ns |  0.85 |         - |
| IntToByte_UncheckedCast |   100 |    81.58 ns |   1.830 ns |  5.308 ns |  1.00 |         - |
|   IntToByte_CheckedCast |   100 |    69.28 ns |   1.213 ns |  2.663 ns |  0.87 |         - |
|                         |       |             |            |           |       |           |
|      IntToByte_UnsafeAs | 10000 | 6,327.32 ns |  78.748 ns | 69.808 ns |  1.00 |         - |
| IntToByte_UncheckedCast | 10000 | 6,312.56 ns |  78.020 ns | 69.163 ns |  1.00 |         - |
|   IntToByte_CheckedCast | 10000 | 6,363.24 ns | 112.525 ns | 93.964 ns |  1.01 |         - |
