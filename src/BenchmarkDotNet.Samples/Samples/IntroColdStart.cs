using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Order;

namespace BenchmarkDotNet.Samples.Samples;

[SimpleJob(RunStrategy.ColdStart, targetCount: 5)]
public class IntroColdStart
{
    private bool firstCall;

    [Benchmark]
    public void Foo()
    {
        if (firstCall == false)
        {
            firstCall = true;
            Console.WriteLine("// First call");
        }
    }
}