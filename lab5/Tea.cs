namespace lab5;

public class Tea : HotBeverage
{
    public Tea(int volume) : base(volume)
    {
        Color = "Green";
    }
    
    public override void Info()
    {
        Console.WriteLine($"Tea, color: {Color}, volume: {Volume} ml");
    }
}

public class Puer : Tea
{
    public Puer(int volume) : base(volume)
    {
        Color = "Black";
    }
    
    public override void Info()
    {
        Console.WriteLine($"Puer, color: {Color}, volume: {Volume} ml");
    }
}

public class MilkOolong : Tea
{
    public MilkOolong(int volume) : base(volume)
    {
        Color = "Green";
    }
    
    public override void Info()
    {
        Console.WriteLine($"Milk oolong, color: {Color}, volume: {Volume} ml");
    }
}

public class BlackTea : Tea
{
    public BlackTea(int volume) : base(volume)
    {
        Color = "Black";
    }
    
    public override void Info()
    {
        Console.WriteLine($"Black tea, color: {Color}, volume: {Volume} ml");
    }
}