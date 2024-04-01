namespace lab4_2;

public class Wallet
{
    private bool _active = false;
    private Coin _currency;
    private double _amount = 0.0;

    public Wallet(Coin coin)
    {
        _currency = coin;
    }

    public void TopUp(double amount)
    {
        if (amount > 0)
        {
            if (!_active) Console.WriteLine($"Successfully activated {_currency.Code()} wallet");
            _amount += amount;
            _active = true;
        }
        else Console.WriteLine("Invalid amount");
    }
    
    public double Interest(int days)
    {
        return Balance() * Math.Pow(Math.E, _currency.GrowthRate() * days / 365) - Balance();
    }

    public double Amount()
    {
        return _amount;
    }

    public double Balance()
    {
        return _amount * _currency.ExchangeRate();
    }

    public Coin Coin()
    {
        return _currency;
    }
    
    public bool IsActive()
    {
        return _active;
    }

    public void Close()
    {
        _active = false;
        _amount = 0.0;
    }
}
