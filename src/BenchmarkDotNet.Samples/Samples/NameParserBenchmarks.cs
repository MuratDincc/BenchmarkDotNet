using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace BenchmarkDotNet.Samples.Samples;

[Config(typeof(Config))]
public class NameParserBenchmarks
{
    private const string FullName = "Steve J Gordon";
    private static readonly NameParser Parser = new NameParser();

    [Benchmark(Baseline = true)]
    public void GetLastName()
    {
        Parser.GetLastName(FullName);
    }

    [Benchmark]
    public void GetLastNameUsingSubstring()
    {
        Parser.GetLastNameUsingSubstring(FullName);
    }

    [Benchmark]
    public void GetLastNameWithSpan()
    {
        Parser.GetLastNameWithSpan(FullName);
    }
}

public class NameParser
{
    public string GetLastName(string fullName)
    {
        var names = fullName.Split(" ");

        var lastName = names.LastOrDefault();

        return lastName ?? string.Empty;
    }

    public string GetLastNameUsingSubstring(string fullName)
    {
        var lastSpaceIndex = fullName.LastIndexOf(" ", StringComparison.Ordinal);

        return lastSpaceIndex == -1
            ? string.Empty
            : fullName.Substring(lastSpaceIndex + 1);
    }

    public ReadOnlySpan<char> GetLastNameWithSpan(ReadOnlySpan<char> fullName)
    {
        var lastSpaceIndex = fullName.LastIndexOf(' ');

        return lastSpaceIndex == -1 
            ? ReadOnlySpan<char>.Empty 
            : fullName.Slice(lastSpaceIndex + 1);
    }
}