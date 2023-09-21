using System.Runtime.CompilerServices;

namespace Benchmarks.UnsafeAsVsCast;

[MemoryDiagnoser(false)]
[HideColumns("RatioSD", "Alloc Ratio", "Code Size")]
public class UnsafeAsVsCast
{
	public int[] _ints;

	[Params(100, 10_000)]
	public int Count { get; set; }

	[GlobalSetup]
	public void GlobalSetup()
	{
		_ints = Enumerable.Range(0, 10_000).Select(_ => Random.Shared.Next(byte.MaxValue)).ToArray();
	}

	[Benchmark]
	public ulong IntToByte_UnsafeAs()
	{
		ulong u = 0;

		for (int i = 0; i < Count; i++)
			u += Unsafe.As<int, byte>(ref _ints[i]);

		return u;
	}

	[Benchmark(Baseline = true)]
	public ulong IntToByte_UncheckedCast()
	{
		ulong u = 0;

		for (int i = 0; i < Count; i++)
			u += unchecked((byte)_ints[i]);

		return u;
	}

	[Benchmark]
	public ulong IntToByte_CheckedCast()
	{
		ulong u = 0;

		for (int i = 0; i < Count; i++)
			u += (byte)_ints[i];

		return u;
	}
}
