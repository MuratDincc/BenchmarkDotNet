using BenchmarkDotNet.Running;
using BenchmarkDotNet.Samples.Samples;

BenchmarkRunner.Run<Md5vsSha256vsSha512>();
// BenchmarkRunner.Run<NewtonsoftVsSystemTextJson>();
// BenchmarkRunner.Run<HttpClientVsRestSharp>();
// BenchmarkRunner.Run<IntroColdStart>();
// BenchmarkRunner.Run<NameParserBenchmarks>();
// BenchmarkRunner.Run<RandomStringBenchmarks>();

// BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);