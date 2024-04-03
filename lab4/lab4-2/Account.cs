namespace lab4_2;

using System.Linq;

public class Account
{
    private Dictionary<string, Wallet> _wallets = new()
    {
        {"BTC",  new Wallet(new BTC(69774.80, 0.1100))},
        {"ETH",  new Wallet(new ETH(3500,     0.0181))},
        {"SOL",  new Wallet(new SOL(196.55,   0.0800))},
        {"DOGE", new Wallet(new DOGE(0.20,     0.4650))},
        {"TON",  new Wallet(new TON(5.33,     0.2300))},
        {"USDT", new Wallet(new USDT(1.00,     0.0000))}
    };
    private double _totalBalance = 0.0;
    private double _fiat = 0.0;

    public Account() {}

    public void PrintWallets()
    {
        foreach (var wallet in _wallets)
        {
            if (!wallet.Value.IsActive()) continue;
            Console.WriteLine($"{wallet.Key}");
            Console.WriteLine($"{wallet.Value.Amount()} {wallet.Key} = {wallet.Value.Balance()} USD");
            Console.WriteLine();
        }
    }
    
    public double TotalBalance()
    {
        return _totalBalance;
    }

    public int TopUp(string code, double amount)
    {
        code = code.ToUpper();
        if (_wallets.ContainsKey(code))
        {
            _wallets[code].TopUp(amount);
            _totalBalance += _wallets[code].Coin().ExchangeRate() * amount;
            
            return 0;
        }
        else
        {
            Console.WriteLine("Invalid currency code");
            return 1;
        }
    }

    public int TopUpFiat(double amount)
    {
        if (amount > 0)
        {
            _fiat += amount;
            Console.WriteLine("\nSuccess!");
            return 0;
        }
        else
        {
            Console.WriteLine("Invalid amount");
            return 1;
        }
    }

    public void SortWallets()
    {
        _wallets = _wallets.OrderByDescending(x => x.Value.Balance()).
            ToDictionary(x => x.Key, x => x.Value);
        PrintWallets();
    }

    public void CloseWallet(string code)
    {
        code = code.ToUpper();
        if (_wallets.ContainsKey(code))
        {
            TopUpFiat(_wallets[code].Balance());
            _wallets[code].Close();
        }
    }
    
    public void PrintInterest()
    {
        double totalDayInterest = 0.0, totalWeekInterest = 0.0, totalMonthInterest = 0.0;
        foreach(var wallet in _wallets)
        {
            if (wallet.Value.IsActive())
            {
                double dayInterest = wallet.Value.Interest(1);
                double weekInterest = wallet.Value.Interest(7);
                double monthInterest = wallet.Value.Interest(30);
                Console.WriteLine("============================");
                Console.WriteLine($"{wallet.Key}: ");
                Console.WriteLine($"Daily interest: {dayInterest}");
                Console.WriteLine($"Weekly interest: {weekInterest}");
                Console.WriteLine($"Monthly interest: {monthInterest}");
                totalDayInterest += dayInterest;
                totalWeekInterest += weekInterest;
                totalMonthInterest += monthInterest;
            }
        }

        Console.WriteLine("============================");
        Console.WriteLine($"Total daily interest: {totalDayInterest}");
        Console.WriteLine($"Total weekly interest: {totalWeekInterest}");
        Console.WriteLine($"Total monthly interest: {totalMonthInterest}");
        Console.WriteLine("============================");
    }

    public void PrintCoins()
    {
        Console.WriteLine("============================");
        foreach (var wallet in _wallets)
        {
            Console.WriteLine($"{wallet.Key}\t" +
                              $"{wallet.Value.Coin().ExchangeRate()}\t" +
                              $"{wallet.Value.Coin().GrowthRate() * 100}%");
        }
        Console.WriteLine("============================");
    }

    public string[] AvailableCoins()
    {
        return _wallets.Keys.ToArray();
    }
}
