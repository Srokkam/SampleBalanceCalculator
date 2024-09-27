namespace SampleBalanceCalculator;

public class BalanceCalculator
{
    private static readonly Dictionary<string, double> Denominations =
        new Dictionary<string, double> {
            { "1000", 1000 },
            { "500", 500 },
            { "100", 100 },
            { "50", 50 },
            { "20", 20 },
            { "10", 10 },
            { "5", 5 },
            { "2", 2 },
            { "1", 1 },
            { "50p", 0.50 },
            { "20p", 0.20 },
            { "10p", 0.10 },
            { "5p", 0.05 },
            { "2p", 0.02 },
            { "1p", 0.01 }
        };

    public static void Main(string[] args)
    {
        Console.WriteLine(
            "Welcome to Balance Calculator!: Enter an amount (will be rounded off to 2 digits in decimals)");
        double amount =
            Math.Round(double.Parse(Console.ReadLine() ?? string.Empty), 2);

        Console.Write("Enter an Product amount");

        double productAmount =
            Math.Round(double.Parse(Console.ReadLine() ?? string.Empty), 2);

        var res = Calculate(amount, productAmount);
        foreach (var item in res)
        {
            Console.WriteLine($"{item.Value}X {item.Key}");
        }
        Console.WriteLine("Thank You.!!!");
    }


    public static Dictionary<string, int> Calculate(double amount,
        double productAmount)
    {
        var result = new Dictionary<string, int>();
        if (amount == 0 || productAmount == 0)
        {
            Console.WriteLine("Please enter a valid amounts");
        }

        else if (productAmount > amount)
        {
            Console.WriteLine(
                "Insufficient amount, Please enter a valid amount");
        }
        else
        {
            result = CalculateDenominations(amount - productAmount);
        }
        return result;
    }

    private static Dictionary<string, int> CalculateDenominations(double blc)
    {
        var result = new Dictionary<string, int>();
        foreach (var denomination in Denominations)
        {
            var count = (int)(blc / denomination.Value);
            if (count > 0)
            {
                result.Add(denomination.Key, count);
                blc = Math.Round(blc - (count * denomination.Value), 2);
            }
        }
        return result;
    }
}