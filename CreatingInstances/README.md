```
BenchmarkDotNet v0.13.7, Windows 11 (10.0.22621.2134/22H2/2022Update/SunValley2)
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 7.0.306
  [Host]     : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
```

|                  Method |      Mean |     Error |    StdDev | Code Size | Allocated |
|------------------------ |----------:|----------:|----------:|----------:|----------:|
|                     New |  4.836 ns | 0.1632 ns | 0.1814 ns |      25 B |      24 B |
| ActivatorCreateInstance | 12.967 ns | 0.3253 ns | 0.3043 ns |      66 B |      24 B |
|  Cached_ConstructorInfo | 19.396 ns | 0.4424 ns | 0.5906 ns |     147 B |      24 B |
|  GetUninitializedObject | 54.510 ns | 1.0804 ns | 1.0106 ns |     553 B |      24 B |
|         ConstructorInfo | 68.023 ns | 1.4420 ns | 2.9128 ns |     891 B |      24 B |
