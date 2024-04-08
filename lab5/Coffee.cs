namespace lab5;

public class Coffee : HotBeverage
{
    public Coffee(int volume) : base(volume)
    {
        Color = "Brown";
    }
    
    public override void Info()
    {
        Console.WriteLine($"Coffee, color: {Color}, volume: {Volume} ml");
    }
}

public class Americano : Coffee
{
    public Americano(int volume) : base(volume)
    {
        Color = "Black";
    }
    
    public override void Info()
    {
        Console.WriteLine($"Americano, color: {Color}, volume: {Volume} ml");
    }
}

public class Cappuccino : Coffee
{
    public Cappuccino(int volume) : base(volume)
    {
        Color = "Brown with milk flavor";
    }
    
    public override void Info()
    {
        Console.WriteLine($"Cappuccino, color: {Color}, volume: {Volume} ml");
    }
}

public class Latte : Coffee
{
    public Latte(int volume) : base(volume)
    {
        Color = "Brown with a lot of milk";
    }
    
    public override void Info()
    {
        Console.WriteLine($"Latte, color: {Color}, volume: {Volume} ml");
    }
}