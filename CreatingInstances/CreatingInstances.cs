using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace Benchmarks;

[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[HideColumns("RatioSD", "Alloc Ratio", "Code Size")]
public class CreatingInstances
{
	private ConstructorInfo _constructor;
	private Func<R> _factoryFromExpression, _factoryFromDynamicMethod;

	[Params(100_000)]
	public int Count { get; set; }

	[GlobalSetup]
	public void GlobalSetup()
	{
		_constructor = typeof(R).GetConstructor(Type.EmptyTypes)!;

		Expression<Func<R>> newExpr = () => new R();
		_factoryFromExpression = newExpr.Compile();

		var dynMethod = new DynamicMethod("Create", typeof(R), null, typeof(R), true);
		var il = dynMethod.GetILGenerator();
		il.Emit(OpCodes.Newobj, _constructor);
		il.Emit(OpCodes.Ret);
		_factoryFromDynamicMethod = dynMethod.CreateDelegate<Func<R>>();
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

	[Benchmark]
	public void NewExpression()
	{
		for (int i = 0; i < Count; i++)
			_ = _factoryFromExpression();
	}

	[Benchmark]
	public void DynamicMethod()
	{
		for (int i = 0; i < Count; i++)
			_ = _factoryFromDynamicMethod();
	}
}

public sealed record R();
