namespace lab4_2;

public class Coin
{
    private string _code;
    private readonly double _exchangeRate;
    private readonly double _growthRate;

    public Coin(string code, double exchangeRate, double growthRate)
    {
        _code = code;
        _exchangeRate = exchangeRate;
        _growthRate = growthRate;
    }

    public double ExchangeRate()
    {
        return _exchangeRate;
    }

    public double GrowthRate()
    {
        return _growthRate;
    }

    public string Code()
    {
        return _code;
    }
}
