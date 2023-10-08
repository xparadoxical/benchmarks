using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarks;

[MemoryDiagnoser(false)]
[ExceptionDiagnoser]
[HideColumns("RatioSD", "Alloc Ratio", "Code Size")]
public unsafe class TryMakeGenericType
{
	private static delegate*<Type, nint*, int, nint*, int, Type, bool> _RuntimeHandles_SatisfiesConstraints;

	[Params(50, 85, 90, 95, 98, 100)]
	public double CorrectArgRate { get; set; }

	private readonly Type[] randomTypeDefinitions = new[] { typeof(INumber<>), typeof(IParsable<>) };
	public Type TypeDefinition => randomTypeDefinitions[Random.Shared.Next(randomTypeDefinitions.Length)];

	//private Type[] randomTypeArguments = new[] { typeof(int), typeof(string), typeof(double), typeof(ConsoleKeyInfo) };
	private readonly Type typeArgT = typeof(int), typeArgF = typeof(string);
	public Type TypeArgument => Random.Shared.Next(100) < CorrectArgRate ? typeArgT : typeArgF;// => randomTypeArguments[Random.Shared.Next(randomTypeArguments.Length)];

	[GlobalSetup]
	public void GlobalSetup()
	{
		var rt = Type.GetType("System.RuntimeType")!;
		_RuntimeHandles_SatisfiesConstraints = (delegate*<Type, nint*, int, nint*, int, Type, bool>)typeof(RuntimeTypeHandle)
			.GetMethod("SatisfiesConstraints", BindingFlags.Static | BindingFlags.NonPublic,
				new[] { rt, typeof(nint*), typeof(int), typeof(nint*), typeof(int), rt })!
			.MethodHandle.GetFunctionPointer();
	}

	[Benchmark(Baseline = true)]
	public bool TryCatch() => TryMakeGenericType1(TypeDefinition, out _, TypeArgument);

	public static bool TryMakeGenericType1(Type genericType, out Type closedGenericType, params Type[] typeArguments)
	{
		try
		{
			closedGenericType = genericType.MakeGenericType(typeArguments);
			return true;
		}
		catch
		{
			closedGenericType = default;
			return false;
		}
	}

	[Benchmark]
	public bool If_InternalCall() => TryMakeGenericType2(TypeDefinition, out _, TypeArgument);

	public static bool TryMakeGenericType2(Type genericType, out Type closedGenericType, params Type[] typeArguments)
	{
		if (CanMakeGenericType(genericType, typeArguments))
		{
			closedGenericType = genericType.MakeGenericType(typeArguments);
			return true;
		}

		closedGenericType = default;
		return false;
	}

	private static unsafe bool CanMakeGenericType(Type definition, ReadOnlySpan<Type> genericArguments)
	{
		//type-only RuntimeType.ValidateGenericArguments
		var parameters = definition.GetGenericArguments();

		for (int i = 0; i < genericArguments.Length; i++)
		{
			//var argument = genericArguments[i];
			//var parameter = parameters[i];
			if (!RuntimeHandles_SatisfiesConstraints(parameters[i], genericArguments, genericArguments[i]))
				return false;
		}

		return true;
	}

	private static unsafe bool RuntimeHandles_SatisfiesConstraints(Type parameter, ReadOnlySpan<Type> arguments, Type argument)
	{
		Span<nint> handles = stackalloc nint[arguments.Length];
		CopyRuntimeTypeHandles(arguments, handles);

		fixed (nint* pHandles = handles)
		{
			return _RuntimeHandles_SatisfiesConstraints(parameter, pHandles, handles.Length, null, 0, argument);
		}
	}

	private static void CopyRuntimeTypeHandles(ReadOnlySpan<Type> inTypes, Span<nint> outHandles)
	{
		for (int i = 0; i < inTypes.Length; i++)
			outHandles[i] = inTypes[i].TypeHandle.Value;
	}
}
