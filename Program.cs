using System;
using SplashKitSDK;

public class Program
{

    public enum MenuOption
    {
        BuyStock,
        SellStock,
        QueryStock,
        Quit
    }

        private static MenuOption ReadUserOption()
    {
        int option;
        Console.WriteLine("1: Buy Stock\n2: Sell Stock\n3: Query Stock\n4: Quit");
        //option = Convert.ToInt32(Console.ReadLine());

        do {
            Console.Write("Choose an option [1-4]: ");

            try
            {
                option = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please enter a valid selection [1-4]");
                option = -1;
            }
           
        } while (option < 1 || option > 4);

        return (MenuOption)(option - 1);
    }


    public static void Main()
    {
        Stock test = new Stock("Test Stock Item", 100);

        MenuOption userSelection;

        do
        {
            userSelection = ReadUserOption();
            switch(userSelection)
            {
                case MenuOption.BuyStock:
                    PerformBuyStock(test);
                    break;

                case MenuOption.SellStock:
                    PerformSellStock(test);
                    break;
                case MenuOption.QueryStock:
                    QueryStock(test);
                    break;
            }
        } while (userSelection != MenuOption.Quit);

        Console.WriteLine(userSelection);
    }

    private static void PerformBuyStock(Stock stock)
    {
        int quantity;
        decimal price;

        Console.WriteLine($"Quantity of {stock.Name} bought: ");
        quantity = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Purchase price per item bought: ");
        price = Convert.ToDecimal(Console.ReadLine());

        // Creating sale transaction:
        StockPurchaseTransaction purchase = new StockPurchaseTransaction(stock, price, quantity);

        purchase.Execute();
        purchase.PrintSummary();
    }

    private static void PerformSellStock(Stock stock)
    {
        int quantity;
        decimal price;

        Console.WriteLine($"Quantity of {stock.Name} sold: ");
        quantity = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Sale price per item sold: ");
        price = Convert.ToDecimal(Console.ReadLine());

        // Creating sale transaction:
        StockSaleTransaction sale = new StockSaleTransaction(stock, price, quantity);

        sale.Execute();
        sale.PrintSummary();
    }

    private static void QueryStock(Stock stock)
    {
        stock.PrintSummary();
    }
}
