using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;

namespace BenchmarkDotNet.Samples.Samples;

[Config(typeof(Config))]
public class RandomStringBenchmarks
{
    private int length = 10;
    
    [Benchmark]
    public void GetRandomStrings()
    {
        var rnd = new Random();
        var chars = new char[length];
        for (var i = 0; i < length; i++)
        {
            chars[i] = (char)(rnd.Next(0, 10) + '0');
        }
    }

    [Benchmark]
    public void GetRandomStringsWithEnumerable()
    {
        var rnd = new Random();
        var chars = Enumerable.Repeat("", length)
            .Select(w => (char)(rnd.Next(0, 10) + '0')).ToArray();
    }

    [Benchmark]
    public void GetRandomStringsWithSpan()
    {
        var rnd = new Random();
        var text = string.Create(length, rnd, ((span, random) =>
        {
            for (var i = 0; i < length; i++)
            {
                span[i] = (char)(random.Next(0, 10) + '0');
            }
        }));
    }
}