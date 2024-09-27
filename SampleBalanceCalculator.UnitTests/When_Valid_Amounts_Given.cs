using NUnit.Framework;

namespace SampleBalanceCalculator.UnitTests;

public class SampleBalanceCalculatorTests
{
    [Test]
    public void When_Valid_Amounts_Given()
    {
        var res =BalanceCalculator.Calculate(1000, 500);
        Assert.That(res["500"].Equals(1));
    }
    
    [Test]
    public void When_Valid_Decimal_Amounts_Given()
    {
        var res =BalanceCalculator.Calculate(500,1.01);
        Assert.That(res.TryGetValue("500",out _).Equals(false));
        Assert.That(res["100"].Equals(4));
        Assert.That(res["50"].Equals(1));
        Assert.That(res["20"].Equals(2));
        Assert.That(res["50p"].Equals(1));
        Assert.That(res["20p"].Equals(2));
        Assert.That(res["5p"].Equals(1));
        Assert.That(res["2p"].Equals(2));
    }
    
    [Test]
    public void It_Should_Round_Off_Decimal_To_2_Decimal_Places_1()
    {
        var res =BalanceCalculator.Calculate(500,10.09999);
        Assert.That(res["100"].Equals(4));
        Assert.That(res["50"].Equals(1));
        Assert.That(res["20"].Equals(1));
        Assert.That(res["50p"].Equals(1));
        Assert.That(res["20p"].Equals(2));
    }
    
    [Test]
    public void It_Should_Round_Off_Decimal_To_2_Decimal_Places_2()
    {
        var res =BalanceCalculator.Calculate(500,10.009999);
        Assert.That(res["100"].Equals(4));
        Assert.That(res["50"].Equals(1));
        Assert.That(res["20"].Equals(1));
        Assert.That(res["50p"].Equals(1));
        Assert.That(res["20p"].Equals(2));
        Assert.That(res["5p"].Equals(1));
        Assert.That(res["2p"].Equals(2));
    }
    
    [Test]
    public void It_Should_Round_Off_Decimal_To_2_Decimal_Places_3()
    {
        var res =BalanceCalculator.Calculate(500.01,10.009999);
        Assert.That(res["100"].Equals(4));
        Assert.That(res["50"].Equals(1));
        Assert.That(res["20"].Equals(2));
    }
    
    [Test]
    public void When_Valid_Change_Is_Given()
    {
        var res =BalanceCalculator.Calculate(500.01,10.009999);
        Assert.That(res["100"].Equals(4));
        Assert.That(res["50"].Equals(1));
        Assert.That(res["20"].Equals(2));
    }
    
    [Test]
    public void When_Exact_Amount_Is_Given()
    {
        var res = BalanceCalculator.Calculate(500.01, 500.01);
       Assert.That(res.Count.Equals(0));
    }
}