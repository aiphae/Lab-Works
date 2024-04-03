namespace lab4_2;

public class Coin
{
    protected string _code;
    protected readonly double _exchangeRate;
    protected readonly double _growthRate;

    public Coin(string code, double exchangeRate, double growthRate)
    {
        _code = code;
        _exchangeRate = exchangeRate;
        _growthRate = growthRate;
    }

    public Coin()
    {
        _code = "";
        _exchangeRate = 0.0;
        _growthRate = 0.0;
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
