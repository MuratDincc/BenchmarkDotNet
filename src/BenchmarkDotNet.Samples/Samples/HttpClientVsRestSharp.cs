using System.Net.Http.Json;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Samples.Models;
using RestSharp;

namespace BenchmarkDotNet.Samples.Samples;

[Config(typeof(Config))]
public class HttpClientVsRestSharp
{
    private static readonly HttpClient httpClient = new HttpClient();
    private static readonly RestClient restClient = new RestClient("https://jsonplaceholder.typicode.com/");
    
    public HttpClientVsRestSharp()
    {
        httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
    }
    
    [Benchmark]
    public async Task<List<Post>?> GetWithHttpClient()
    {
        var response = await httpClient.GetAsync("posts");
        var posts = await response.Content.ReadFromJsonAsync<List<Post>>();
        Thread.Sleep(1000);
        return posts;
    }

    [Benchmark]
    public async Task<List<Post>?> GetWithRestSharp()
    {
        var request = new RestRequest("posts");
        var posts = await restClient.GetAsync<List<Post>>(request);
        Thread.Sleep(1000);
        return posts;
    }
}