namespace Benchmarks;

[MemoryDiagnoser(false)]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
public class StreamVsSpan
{
	public byte[] _array;
	public MemoryStream _stream;

	[Params(100, 10_000)]
	public int Count { get; set; }

	[GlobalSetup]
	public void GlobalSetup()
	{
		_array = new byte[10_000];
		Random.Shared.NextBytes(_array);
		_stream = new MemoryStream(_array);
	}

	[Benchmark(Baseline = true)]
	public ulong Array()
	{
		ulong sum = 0;

		for (int i = 0; i < Count; i++)
			sum += _array[i];

		return sum;
	}

	[Benchmark]
	public ulong Span()
	{
		ulong sum = 0;
		var span = _array.AsSpan();

		for (int i = 0; i < Count; i++)
			sum += span[i];

		return sum;
	}

	[Benchmark]
	public ulong Stream()
	{
		ulong sum = 0;
		_stream.Position = 0;

		for (int i = 0; i < Count; i++)
			sum += (byte)_stream.ReadByte();

		return sum;
	}
}
