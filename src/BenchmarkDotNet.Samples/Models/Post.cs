namespace BenchmarkDotNet.Samples.Models;

public record Post
{
    public int UserId { get; init; }
    public int Id { get; init; }
    public string Title { get; init; }
    public string Body { get; init; }
}