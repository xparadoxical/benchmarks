using System.Dynamic;

using BenchmarkDotNet.Configs;

namespace Benchmarks;

[MemoryDiagnoser]
[HideColumns("Mean", "Error", "StdDev", "Ratio", "RatioSD")]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
public class DictVsExpandoObject
{
	public Dictionary<string, object> dict;
	public dynamic expando;

	[Benchmark]
	[BenchmarkCategory("Dict")]
	public void Dict_00Values()
	{
		dict = new Dictionary<string, object>();
	}

	[Benchmark]
	[BenchmarkCategory("ExpandoObject")]
	public void ExpandoObject_00Fields()
	{
		expando = new ExpandoObject();
	}

	[Benchmark]
	[BenchmarkCategory("Dict")]
	public void Dict_01Values()
	{
		dict = new Dictionary<string, object>();
		dict["field1"] = "1";
	}

	[Benchmark]
	[BenchmarkCategory("ExpandoObject")]
	public void ExpandoObject_01Fields()
	{
		expando = new ExpandoObject();
		expando.field1 = "1";
	}

	[Benchmark]
	[BenchmarkCategory("Dict")]
	public void Dict_02Values()
	{
		dict = new Dictionary<string, object>();
		dict["field1"] = "1";
		dict["field2"] = "2";
	}

	[Benchmark]
	[BenchmarkCategory("ExpandoObject")]
	public void ExpandoObject_02Fields()
	{
		expando = new ExpandoObject();
		expando.field1 = "1";
		expando.field2 = "2";
	}

	[Benchmark]
	[BenchmarkCategory("Dict")]
	public void Dict_03Values()
	{
		dict = new Dictionary<string, object>();
		dict["field1"] = "1";
		dict["field2"] = "2";
		dict["field3"] = "3";
	}

	[Benchmark]
	[BenchmarkCategory("ExpandoObject")]
	public void ExpandoObject_03Fields()
	{
		expando = new ExpandoObject();
		expando.field1 = "1";
		expando.field2 = "2";
		expando.field3 = "3";
	}

	[Benchmark]
	[BenchmarkCategory("Dict")]
	public void Dict_04Values()
	{
		dict = new Dictionary<string, object>();
		dict["field1"] = "1";
		dict["field2"] = "2";
		dict["field3"] = "3";
		dict["field4"] = "4";
	}

	[Benchmark]
	[BenchmarkCategory("ExpandoObject")]
	public void ExpandoObject_04Fields()
	{
		expando = new ExpandoObject();
		expando.field1 = "1";
		expando.field2 = "2";
		expando.field3 = "3";
		expando.field4 = "4";
	}

	[Benchmark]
	[BenchmarkCategory("Dict")]
	public void Dict_05Values()
	{
		dict = new Dictionary<string, object>();
		dict["field1"] = "1";
		dict["field2"] = "2";
		dict["field3"] = "3";
		dict["field4"] = "4";
		dict["field5"] = "5";
	}

	[Benchmark]
	[BenchmarkCategory("ExpandoObject")]
	public void ExpandoObject_05Fields()
	{
		expando = new ExpandoObject();
		expando.field1 = "1";
		expando.field2 = "2";
		expando.field3 = "3";
		expando.field4 = "4";
		expando.field5 = "5";
	}

	[Benchmark]
	[BenchmarkCategory("Dict")]
	public void Dict_06Values()
	{
		dict = new Dictionary<string, object>();
		dict["field1"] = "1";
		dict["field2"] = "2";
		dict["field3"] = "3";
		dict["field4"] = "4";
		dict["field5"] = "5";
		dict["field6"] = "6";
	}

	[Benchmark]
	[BenchmarkCategory("ExpandoObject")]
	public void ExpandoObject_06Fields()
	{
		expando = new ExpandoObject();
		expando.field1 = "1";
		expando.field2 = "2";
		expando.field3 = "3";
		expando.field4 = "4";
		expando.field5 = "5";
		expando.field6 = "6";
	}

	[Benchmark]
	[BenchmarkCategory("Dict")]
	public void Dict_07Values()
	{
		dict = new Dictionary<string, object>();
		dict["field1"] = "1";
		dict["field2"] = "2";
		dict["field3"] = "3";
		dict["field4"] = "4";
		dict["field5"] = "5";
		dict["field6"] = "6";
		dict["field7"] = "7";
	}

	[Benchmark]
	[BenchmarkCategory("ExpandoObject")]
	public void ExpandoObject_07Fields()
	{
		expando = new ExpandoObject();
		expando.field1 = "1";
		expando.field2 = "2";
		expando.field3 = "3";
		expando.field4 = "4";
		expando.field5 = "5";
		expando.field6 = "6";
		expando.field7 = "7";
	}

	[Benchmark]
	[BenchmarkCategory("Dict")]
	public void Dict_08Values()
	{
		dict = new Dictionary<string, object>();
		dict["field1"] = "1";
		dict["field2"] = "2";
		dict["field3"] = "3";
		dict["field4"] = "4";
		dict["field5"] = "5";
		dict["field6"] = "6";
		dict["field7"] = "7";
		dict["field8"] = "8";
	}

	[Benchmark]
	[BenchmarkCategory("ExpandoObject")]
	public void ExpandoObject_08Fields()
	{
		expando = new ExpandoObject();
		expando.field1 = "1";
		expando.field2 = "2";
		expando.field3 = "3";
		expando.field4 = "4";
		expando.field5 = "5";
		expando.field6 = "6";
		expando.field7 = "7";
		expando.field8 = "8";
	}

	[Benchmark]
	[BenchmarkCategory("Dict")]
	public void Dict_09Values()
	{
		dict = new Dictionary<string, object>();
		dict["field1"] = "1";
		dict["field2"] = "2";
		dict["field3"] = "3";
		dict["field4"] = "4";
		dict["field5"] = "5";
		dict["field6"] = "6";
		dict["field7"] = "7";
		dict["field8"] = "8";
		dict["field9"] = "9";
	}

	[Benchmark]
	[BenchmarkCategory("ExpandoObject")]
	public void ExpandoObject_09Fields()
	{
		expando = new ExpandoObject();
		expando.field1 = "1";
		expando.field2 = "2";
		expando.field3 = "3";
		expando.field4 = "4";
		expando.field5 = "5";
		expando.field6 = "6";
		expando.field7 = "7";
		expando.field8 = "8";
		expando.field9 = "9";
	}

	[Benchmark]
	[BenchmarkCategory("Dict")]
	public void Dict_10Values()
	{
		dict = new Dictionary<string, object>();
		dict["field1"] = "1";
		dict["field2"] = "2";
		dict["field3"] = "3";
		dict["field4"] = "4";
		dict["field5"] = "5";
		dict["field6"] = "6";
		dict["field7"] = "7";
		dict["field8"] = "8";
		dict["field9"] = "9";
		dict["field10"] = "10";
	}

	[Benchmark]
	[BenchmarkCategory("ExpandoObject")]
	public void ExpandoObject_10Fields()
	{
		expando = new ExpandoObject();
		expando.field1 = "1";
		expando.field2 = "2";
		expando.field3 = "3";
		expando.field4 = "4";
		expando.field5 = "5";
		expando.field6 = "6";
		expando.field7 = "7";
		expando.field8 = "8";
		expando.field9 = "9";
		expando.field10 = "10";
	}
}
