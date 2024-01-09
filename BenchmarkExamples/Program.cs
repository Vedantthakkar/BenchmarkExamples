
using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class MyBenchmarkDemo
{
    [GlobalSetup]
    public void GlobalSetup()
    {
        //Write your initialization code here
    }

    [Benchmark]
    public void MyFirstBenchmarkMethod()
    {
        //Write your code here   
    }
    [Benchmark]
    public void MySecondBenchmarkMethod()
    {
        //Write your code here
    }
}
