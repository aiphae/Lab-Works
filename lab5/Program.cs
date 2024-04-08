﻿namespace lab5;

class Program
{
    static void Main()
    {
        HotBeverage coffee = new Coffee(250);
        HotBeverage tea = new Tea(200);
        HotBeverage americano = new Americano(300);
        HotBeverage cappuccino = new Cappuccino(200);
        HotBeverage latte = new Latte(350);
        HotBeverage puer = new Puer(150);
        HotBeverage milkOolong = new MilkOolong(250);
        HotBeverage blackTea = new BlackTea(200);

        coffee.Info();
        tea.Info();
        americano.Info();
        cappuccino.Info();
        latte.Info();
        puer.Info();
        milkOolong.Info();
        blackTea.Info();

        Console.ReadKey();
    }
}