using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;

namespace BenchmarkDotNet.Samples.Samples;

[Config(typeof(Config))]
public class Md5vsSha256vsSha512
{
    private const int N = 10000;
    private readonly byte[] data;

    private readonly SHA256 sha256 = SHA256.Create();
    private readonly SHA512 sha512 = SHA512.Create();
    private readonly MD5 md5 = MD5.Create();

    public Md5vsSha256vsSha512()
    {
        data = new byte[N];
        new Random(42).NextBytes(data);
    }

    [Benchmark]
    public byte[] Sha256() => sha256.ComputeHash(data);
    
    [Benchmark]
    public byte[] Sha512() => sha512.ComputeHash(data);

    [Benchmark]
    public byte[] Md5() => md5.ComputeHash(data);
}