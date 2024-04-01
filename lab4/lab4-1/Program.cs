namespace lab4
{
    class Program
    {
        static void Main()
        {
            Point start = new Point(0, 0);
            Point end = new Point(5, 0);
            Line upper = new Line(start, end);

            Square square = new Square(upper, "Blue");
            Console.WriteLine(square);
            
            square.ChangeColor("Red");
            square.Stretch(2);
            Console.WriteLine(square);
            
            square.Rotate();
            Console.WriteLine(square);
        }
    }   
}