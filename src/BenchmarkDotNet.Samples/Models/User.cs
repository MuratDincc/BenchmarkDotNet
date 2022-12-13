using BenchmarkDotNet.Samples.Enums;

namespace BenchmarkDotNet.Samples.Models;

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Title { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public Gender Gender { get; set; }
    public string Phone { get; set; }
}