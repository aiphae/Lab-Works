namespace lab4;

class Square
{
    public Line Upper { get; set; }
    public Line Bottom { get; set; }
    public Line Left { get; set; }
    public Line Right { get; set; }
    public double Length { get; set; }
    public string Color { get; set; }

    public Square(Line upper, string color)
    {
        Length = upper.End.X - upper.Start.X;
        Upper = upper;
        Bottom = new Line(new Point(upper.Start.X, upper.Start.Y + Length), new Point(Upper.End.X, upper.End.Y + Length));
        Left = new Line(upper.Start, Bottom.Start);
        Right = new Line(upper.End, Bottom.End);
        Color = color;
    }
    
    public void Stretch(double factor)
    {
        Resize(Length * factor);
        Console.WriteLine("Розтягнення квадрату у " + factor + " разів");
    }

    public void Compress(double factor)
    {
        Resize(Length / factor);
        Console.WriteLine("Зтиснення квадрату у " + factor + " разів");
    }

    public void Rotate()
    {
        (Upper, Left, Bottom, Right) = (Right, Upper, Left, Bottom);
        Console.WriteLine("Поворот квадрата");
    }

    public void ChangeColor(string newColor)
    {
        Color = newColor;
        Console.WriteLine("Зміна кольору на " + newColor);
    }
    
    private void Resize(double newLength)
    {
        Length = newLength;
        
        Upper.End.X = Upper.Start.X + newLength;
        
        Bottom.Start.Y = Bottom.End.Y = Upper.Start.Y + newLength;
        Bottom.End.X = Bottom.Start.X + newLength;

        Right.Start.X = Right.End.X = Upper.Start.X + newLength;
        Right.End.Y = Bottom.Start.Y;

        Left.End.Y = Bottom.Start.Y;
    }
    
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType()) return false;
        Square other = (Square) obj;
        return Upper.Equals(other.Upper) && Bottom.Equals(other.Bottom) && Left.Equals(other.Left) && Right.Equals(other.Right);
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(Upper, Bottom, Left, Right);
    }
    
    public override string ToString()
    {
        return $"Квадрат: Верхня сторона: {Upper}\n" +
               $"Нижня сторона: {Bottom}\n" +
               $"Ліва сторона: {Left}\n " +
               $"Права сторона: {Right}\n" +
               $"Довжина: {Length}\n " +
               $"Колір: {Color}";
    }
};