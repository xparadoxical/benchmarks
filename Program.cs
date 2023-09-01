using BenchmarkDotNet.Running;

if (args.Length == 0)
{
	Console.Write("Filter: ");
	var filter = $"*{Console.ReadLine()}*";
	Console.WriteLine();

	BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(new string[] { "-d", "-f", filter });
	return;
}

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);