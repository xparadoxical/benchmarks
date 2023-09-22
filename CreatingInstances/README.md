```
BenchmarkDotNet v0.13.7, Windows 11 (10.0.22621.2283/22H2/2022Update/SunValley2)
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 7.0.306
  [Host]     : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
```

|                  Method |  Count |        Mean |     Error |     StdDev |  Ratio |
|------------------------ |------- |------------:|----------:|-----------:|-------:|
|                     New | 100000 |    29.04 us |  0.578 us |   0.666 us |   1.00 |
|           NewExpression | 100000 |   484.66 us |  6.822 us |   5.697 us |  16.81 |
|           DynamicMethod | 100000 |   601.57 us |  6.562 us |   5.480 us |  20.86 |
| ActivatorCreateInstance | 100000 |   995.04 us |  9.859 us |   8.740 us |  34.49 |
|  ConstructorInfo_Cached | 100000 | 1,636.82 us | 17.921 us |  16.763 us |  56.65 |
|         ConstructorInfo | 100000 | 5,239.04 us | 98.139 us | 116.827 us | 180.55 |
|  GetUninitializedObject | 100000 | 5,260.88 us | 70.262 us |  65.723 us | 182.11 |
