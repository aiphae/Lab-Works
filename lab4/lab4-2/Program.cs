namespace lab4_2
{ 
    class Program {
        static void Main()
        {
            var mainAccount = new Account();
            var active = true;
            int[] choices = { 1, 2, 3, 4, 5, 6, 7 };
            string code;
            double amount;
            
            while (active)
            {
                Console.WriteLine("============================");
                Console.WriteLine("Cryptocurrency Exchange");
                Console.WriteLine("1: View wallets");
                Console.WriteLine("2: Buy crypto");
                Console.WriteLine("3: Total balance");
                Console.WriteLine("4: Calculate interest");
                Console.WriteLine("5: Sort wallets");
                Console.WriteLine("6: Close a wallet");
                Console.WriteLine("7: Top up fiat account");
                Console.WriteLine("8: Exit");
                Console.WriteLine("============================");

                int choice;
                do
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                } while (!choices.Contains(choice));

                switch (choice)
                {
                    case 1:
                        mainAccount.PrintWallets();
                        break;
                    
                    case 2:
                        do
                        {
                            mainAccount.PrintCoins();
                            Console.Write("Coin to buy: ");
                            code = Console.ReadLine();
                            Console.Write("Amount: ");
                            amount = Convert.ToDouble(Console.ReadLine());
                        } while (mainAccount.TopUp(code, amount) == 1);
                        break;
                    
                    case 3:
                        Console.WriteLine($"Total balance: {mainAccount.TotalBalance()}");
                        break;
                    
                    case 4:
                        mainAccount.PrintInterest();
                        break;
                    
                    case 5:
                        mainAccount.SortWallets();
                        mainAccount.PrintWallets();
                        break;
                    
                    case 6:
                        Console.WriteLine("Wallet to close: ");
                        do code = Console.ReadLine();
                        while (!mainAccount.AvailableCoins().Contains(code.ToUpper()));
                        
                        mainAccount.CloseWallet(code);
                        break;
                    
                    case 7:
                        Console.Write("Amount to top up: ");
                        amount = Convert.ToDouble(Console.ReadLine());
                        mainAccount.TopUpFiat(amount);
                        break;
                    
                    case 8:
                        active = false;
                        break;
                }
            }
        }
    }
}