using System.Text;

Console.OutputEncoding = Encoding.UTF8;

const int PRICE = 300;

var prices = new Dictionary<string, int>
{
    {"Молоко", 43},
    {"Хліб", 25},
    {"Чай зелений", 60},
    {"Ікра лососева", 399},
    {"Вино", 339},
    {"Кава зернова", 629},
    {"Сир", 69},
    {"Шоколад Milka", 38},
    {"Яловичий стейк", 144},
    {"Банани", 70}
};

var moreExpensive = prices.Where(p => p.Value > PRICE);
var lessExpensive = prices.Where(p => p.Value <= PRICE);

Console.WriteLine("Товари дорожчі за 300 грн:");
foreach (var product in moreExpensive)
{
    Console.WriteLine($"{product.Key}: {product.Value}");
}

Console.WriteLine("\nТовари за 300 грн або дешевше:");
foreach (var product in lessExpensive)
{
    Console.WriteLine($"{product.Key}: {product.Value}");
}

Console.ReadKey();