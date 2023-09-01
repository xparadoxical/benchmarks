using System.Reflection;
using System.Runtime.CompilerServices;

namespace Benchmarks;

[MemoryDiagnoser(false)]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
public class CreatingInstances
{
	private ConstructorInfo _constructor;

	[GlobalSetup]
	public void GlobalSetup()
	{
		_constructor = typeof(R).GetConstructor(Type.EmptyTypes)!;
	}

	[Benchmark]
	public R ConstructorInfo() => (R)typeof(R).GetConstructor(Type.EmptyTypes).Invoke(null);

	[Benchmark]
	public R New() => new();

	[Benchmark]
	public R Cached_ConstructorInfo() => (R)_constructor.Invoke(null);

	[Benchmark]
	public R ActivatorCreateInstance() => Activator.CreateInstance<R>();

	[Benchmark]
	public R GetUninitializedObject() => (R)RuntimeHelpers.GetUninitializedObject(typeof(R));
}

public sealed record R();
