using BenchmarkDotNet.Running;
using LinqBenchmarks;

// This will run all benchmarks against the Benchmarks class
BenchmarkRunner.Run<Benchmarks>();