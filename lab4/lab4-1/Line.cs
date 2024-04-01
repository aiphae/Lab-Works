namespace lab4;

class Line
{
    public Point Start { get; set; }
    public Point End { get; set; }

    public Line(Point start, Point end)
    {
        Start = start;
        End = end;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType()) return false;
        Line other = (Line)obj;
        return Start.Equals(other.Start) && End.Equals(other.End);
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(Start, End);
    }
    
    public override string ToString()
    {
        return $"[{Start} -> {End}]";
    }
};