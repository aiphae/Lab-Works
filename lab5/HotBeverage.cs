namespace lab5;

public abstract class HotBeverage
{
    protected string Color;
    
    public HotBeverage(int volume)
    {
        Volume = volume;
    }
    
    public int Volume { get; }
    
    public abstract void Info();
}