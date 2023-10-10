```
BenchmarkDotNet v0.13.7, Windows 11 (10.0.22621.2283/22H2/2022Update/SunValley2)
Intel Core i7-8550U CPU 1.80GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
.NET SDK 7.0.401
  [Host]     : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.11 (7.0.1123.42427), X64 RyuJIT AVX2
```

|                 Method |      Median | Code Size |   Gen0 | Allocated |
|----------------------- |------------:|----------:|-------:|----------:|
|          Dict_00Values |    17.74 ns |     154 B | 0.0191 |      80 B |
|          Dict_01Values |    63.35 ns |   1,373 B | 0.0516 |     216 B |
|          Dict_02Values |    81.12 ns |   1,417 B | 0.0516 |     216 B |
|          Dict_03Values |    96.70 ns |   1,461 B | 0.0516 |     216 B |
|          Dict_04Values |   180.44 ns |   1,505 B | 0.1109 |     464 B |
|          Dict_05Values |   205.58 ns |   1,549 B | 0.1109 |     464 B |
|          Dict_06Values |   220.91 ns |   1,593 B | 0.1109 |     464 B |
|          Dict_07Values |   243.72 ns |   1,637 B | 0.1106 |     464 B |
|          Dict_08Values |   363.00 ns |   1,681 B | 0.2370 |     992 B |
|          Dict_09Values |   382.85 ns |   1,725 B | 0.2370 |     992 B |
|          Dict_10Values |   404.27 ns |   1,769 B | 0.2370 |     992 B |
|                        |             |           |        |           |
| ExpandoObject_00Fields |    17.23 ns |     120 B | 0.0172 |      72 B |
| ExpandoObject_01Fields |   207.86 ns |   1,301 B | 0.0477 |     200 B |
| ExpandoObject_02Fields |   374.61 ns |   1,673 B | 0.0572 |     240 B |
| ExpandoObject_03Fields |   534.20 ns |   2,062 B | 0.0668 |     280 B |
| ExpandoObject_04Fields |   692.00 ns |   2,420 B | 0.0763 |     320 B |
| ExpandoObject_05Fields |   878.65 ns |   2,790 B | 0.0858 |     360 B |
| ExpandoObject_06Fields | 1,038.58 ns |   3,169 B | 0.0954 |     400 B |
| ExpandoObject_07Fields | 1,258.49 ns |   3,555 B | 0.1049 |     440 B |
| ExpandoObject_08Fields | 1,409.75 ns |   3,934 B | 0.1144 |     480 B |
| ExpandoObject_09Fields | 1,568.00 ns |   4,313 B | 0.1602 |     672 B |
| ExpandoObject_10Fields | 1,744.94 ns |   4,674 B | 0.1698 |     712 B |
