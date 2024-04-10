namespace lab5;

public abstract class HotBeverage
{
    protected string Color;
    
    protected HotBeverage(int volume)
    {
        Volume = volume;
        Color = "";
    }
    
    protected int Volume { get; }
    
    public abstract void Info();
}