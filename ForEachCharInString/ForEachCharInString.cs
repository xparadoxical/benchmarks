namespace Benchmarks;

[MemoryDiagnoser(false)]
[HideColumns("RatioSD", "Alloc Ratio")]
public class ForEachCharInString
{
	public string _s;

	[GlobalSetup]
	public void GlobalSetup()
	{
		_s = string.Create(50 * ushort.MaxValue, Random.Shared, (span, rand) =>
		{
			for (int i = 0; i < span.Length; i++)
				span[i] = (char)rand.Next(1, char.MaxValue);
		});
	}

	//https://stackoverflow.com/a/19661491/6416482

	[Benchmark(Baseline = true)]
	public int CharInString()
	{
		int hash = 0;

		foreach (char c in _s)
		{
			hash += (hash << 5) + c + (c << 7);
		}

		return ((hash) ^ (hash >> 16)) & 0xffff;
	}

	[Benchmark]
	public int CharInSpan()
	{
		int hash = 0;

		foreach (char c in _s.AsSpan())
		{
			hash += (hash << 5) + c + (c << 7);
		}

		return ((hash) ^ (hash >> 16)) & 0xffff;
	}

	[Benchmark]
	public unsafe int CharInPinnedString()
	{
		int hash = 0;

		fixed (char* ch = _s)
		{
			int len = _s.Length;
			for (int i = 0; i < len; i++)
			{
				char c = *(ch + i);
				hash += (hash << 5) + c + (c << 7);
			}
		}

		return ((hash) ^ (hash >> 16)) & 0xffff;
	}

	[Benchmark]
	public unsafe int CharInPinnedString_NoIteratorVar()
	{
		int hash = 0;

		fixed (char* ch = _s)
		{
			int len = _s.Length;
			for (int i = 0; i < len; i++)
			{
				hash += (hash << 5) + *(ch + i) + (*(ch + i) << 7);
			}
		}

		return ((hash) ^ (hash >> 16)) & 0xffff;
	}

	[Benchmark]
	public unsafe int CharInPinnedString_LengthInCondition()
	{
		int hash = 0;

		fixed (char* ch = _s)
		{
			for (int i = 0; i < _s.Length; i++)
			{
				char c = *(ch + i);
				hash += (hash << 5) + c + (c << 7);
			}
		}

		return ((hash) ^ (hash >> 16)) & 0xffff;
	}

	[Benchmark]
	public unsafe int CharInPinnedString_LengthInCondition_NoIteratorVar()
	{
		int hash = 0;

		fixed (char* ch = _s)
		{
			for (int i = 0; i < _s.Length; i++)
			{
				hash += (hash << 5) + *(ch + i) + (*(ch + i) << 7);
			}
		}

		return ((hash) ^ (hash >> 16)) & 0xffff;
	}
}
