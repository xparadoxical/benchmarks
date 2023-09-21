https://stackoverflow.com/a/19661491/6416482

```
BenchmarkDotNet v0.13.7, Windows 11 (10.0.22621.2283/22H2/2022Update/SunValley2)
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 7.0.306
  [Host]     : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.9 (7.0.923.32018), X64 RyuJIT AVX2
```

|                                             Method |     Mean |     Error |    StdDev | Ratio | Code Size | Allocated |
|--------------------------------------------------- |---------:|----------:|----------:|------:|----------:|----------:|
|                                       CharInString | 4.145 ms | 0.0239 ms | 0.0212 ms |  1.00 |      67 B |       5 B |
|                                         CharInSpan | 3.848 ms | 0.0364 ms | 0.0341 ms |  0.93 |      82 B |       5 B |
|                                 CharInPinnedString | 3.832 ms | 0.0508 ms | 0.0424 ms |  0.92 |     105 B |       5 B |
|                   CharInPinnedString_NoIteratorVar | 3.827 ms | 0.0464 ms | 0.0387 ms |  0.92 |     103 B |       5 B |
|               CharInPinnedString_LengthInCondition | 3.859 ms | 0.0380 ms | 0.0356 ms |  0.93 |     105 B |       5 B |
| CharInPinnedString_LengthInCondition_NoIteratorVar | 3.847 ms | 0.0586 ms | 0.0548 ms |  0.93 |     103 B |       5 B |
