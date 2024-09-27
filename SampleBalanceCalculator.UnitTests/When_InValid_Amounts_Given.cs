using NUnit.Framework;

namespace SampleBalanceCalculator.UnitTests;

public class WhenInValidAmountsGiven
{
    [Test]
    public void When_Invalid_Amounts_Given()
    {
        var res =BalanceCalculator.Calculate(500,1001);
        Assert.That(res.Count.Equals(0));
       
    }
    
    [Test]
    public void When_Invalid_Amounts_Given_2()
    {
        var res =BalanceCalculator.Calculate(1,1001);
        Assert.That(res.Count.Equals(0));
       
    }
    
    [Test]
    public void When_Invalid_Amounts_Given_3()
    {
        var res =BalanceCalculator.Calculate(0,1001);
        Assert.That(res.Count.Equals(0));
       
    }
    
    [Test]
    public void When_Invalid_Amounts_Given_4()
    {
        var res =BalanceCalculator.Calculate(10,0);
        Assert.That(res.Count.Equals(0));
       
    }
}