using System.Reflection;
using System.Runtime.CompilerServices;

namespace Benchmarks;

[MemoryDiagnoser(false)]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[HideColumns("RatioSD", "Alloc Ratio", "Code Size")]
public class CreatingInstances
{
	private ConstructorInfo _constructor;

	[Params(100, 10_000)]
	public int Count { get; set; }

	[GlobalSetup]
	public void GlobalSetup()
	{
		_constructor = typeof(R).GetConstructor(Type.EmptyTypes)!;
	}

	[Benchmark]
	public void ConstructorInfo()
	{
		for (int i = 0; i < Count; i++)
			_ = typeof(R).GetConstructor(Type.EmptyTypes).Invoke(null);
	}

	[Benchmark(Baseline = true)]
	public void New()
	{
		for (int i = 0; i < Count; i++)
			_ = new R();
	}

	[Benchmark]
	public void ConstructorInfo_Cached()
	{
		for (int i = 0; i < Count; i++)
			_ = _constructor.Invoke(null);
	}

	[Benchmark]
	public void ActivatorCreateInstance()
	{
		for (int i = 0; i < Count; i++)
			_ = Activator.CreateInstance(typeof(R));
	}

	[Benchmark]
	public void GetUninitializedObject()
	{
		for (int i = 0; i < Count; i++)
			_ = RuntimeHelpers.GetUninitializedObject(typeof(R));
	}
}

public sealed record R();
