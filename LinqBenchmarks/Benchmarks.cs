using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace LinqBenchmarks;

/// <summary>
/// Benchmarks class used for testing linq performance between .NET Core 6 and 7
/// </summary>
[SimpleJob(RuntimeMoniker.Net60)]
[SimpleJob(RuntimeMoniker.Net70)]
[MemoryDiagnoser(false)]
public class Benchmarks 
{
    /// <summary>
    /// Property for the amount or runs to perform to get average speed
    /// </summary>
    [Params(100)]
    public int Size { get; set;}

    /// <summary>
    /// Items to interate through (from 1 to 100)
    /// </summary>
    private IEnumerable<int>? _items;

    /// <summary>
    /// Setup this class to populate items from 1 to 100 in this case
    /// </summary>
    [GlobalSetup]
    public void Setup() => _items = Enumerable.Range(1, Size).ToArray();

	/// <summary>
	/// Function to obtain the Average value from the list
	/// </summary>
	/// <returns>Average value from the list</returns>
	[Benchmark]
	public double Average() => _items != null ? _items.Average() : 0;

	/// <summary>
	/// Function to obtain the Min value from the list
	/// </summary>
	/// <returns>Min value from the list</returns>
	[Benchmark]
    public int Min() => _items != null ? _items.Min() : 0;

	/// <summary>
	/// Function to obtain the Max value from the list
	/// </summary>
	/// <returns>Max value from the list</returns>
	[Benchmark]
    public int Max() => _items != null ? _items.Max() : 0;

	/// <summary>
	/// Function to obtain the Sum of all values in the items list
	/// </summary>
	/// <returns>Sum of all values in the items list</returns>
	[Benchmark]
    public int Sum() => _items != null ? _items.Sum() : 0;

    // TODO: Feel free to re-add this if you decide to follow the tutorial
    // TODO: Link for tutorial is in the README.md file
    // [Benchmark]
    // public int ManualMax()
    // {
    //     var biggest = int.MaxValue;

    //     if (_items?.Any() == true)
    //     {
    //         foreach (var item in _items)
    //         {
    //             if (item > biggest) biggest = item;
    //         }
    //     }

    //     return biggest;
    // }
}