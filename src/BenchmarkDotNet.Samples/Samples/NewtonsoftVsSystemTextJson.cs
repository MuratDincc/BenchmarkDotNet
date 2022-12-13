using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Samples.Enums;
using BenchmarkDotNet.Samples.Models;
using Bogus;
using Newtonsoft.Json;

namespace BenchmarkDotNet.Samples.Samples;

[Config(typeof(Config))]
public class NewtonsoftVsSystemTextJson
{
    private List<User> FakeUserList;

    [GlobalSetup]
    public void Setup()
    {
        Faker<User> FakeData = new Faker<User>()
            .RuleFor(p => p.Id, f => Guid.NewGuid())
            .RuleFor(p => p.FirstName, f => f.Name.FirstName())
            .RuleFor(p => p.MiddleName, f => f.Name.FirstName())
            .RuleFor(p => p.LastName, f => f.Name.LastName())
            .RuleFor(p => p.Title, f => f.Name.Prefix(f.Person.Gender))
            .RuleFor(p => p.Email, (f, p) => f.Internet.Email(p.FirstName, p.LastName))
            .RuleFor(p => p.DateOfBirth, f => f.Person.DateOfBirth)
            .RuleFor(p => p.Gender, f => f.PickRandom<Gender>())
            .RuleFor(p => p.Phone, f => f.Phone.PhoneNumber("###-###-###"));

        FakeUserList=FakeData.Generate(20).ToList();

        Console.WriteLine(JsonConvert.SerializeObject(FakeUserList, Formatting.Indented));
    }

    [Benchmark]
    public string SerializeWithNewtonsoft()
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(FakeUserList);
    }

    [Benchmark]
    public string SerializeWithSystemTextJson()
    {
        return System.Text.Json.JsonSerializer.Serialize(FakeUserList);
    }
}