using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Exporters.Json;
using BenchmarkDotNet.Exporters.Xml;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Loggers;

namespace BenchmarkDotNet.Samples;

public class Config : ManualConfig
{
    public Config()
    {
        AddJob(Job.Default);
        AddDiagnoser(Diagnosers.MemoryDiagnoser.Default);
        AddColumn(TargetMethodColumn.Method, RankColumn.Arabic, LogicalGroupColumn.Default, StatisticColumn.Mean, LogicalGroupColumn.Default, StatisticColumn.StdDev);
        AddExporter(CsvExporter.Default, HtmlExporter.Default);
        // AddExporter(CsvExporter.Default, HtmlExporter.Default, XmlExporter.Full, JsonExporter.Full, MarkdownExporter.Atlassian, MarkdownExporter.GitHub, MarkdownExporter.StackOverflow);
    }
}