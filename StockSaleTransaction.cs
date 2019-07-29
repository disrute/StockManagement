using System;

public class StockSaleTransaction
{
    private readonly Stock _stock;
    private readonly decimal _price;
    private readonly int _quantity;
    private bool _hasExecuted = false;
    private bool _success = false;

    public bool Success
    {
        get //read only property meaning only has a getter not a setter.
        {
            return _success;
        }
    }
    public bool HasExecuted
    {
        get
        {
            return _hasExecuted;
        }
    }

    public StockSaleTransaction(Stock stock, decimal price, int quantity)
    {
        _stock = stock;
        _price = price;
        _quantity = quantity;
    }

    public void Execute()
    {
        if (HasExecuted)
        {
            throw new InvalidOperationException("Executing a transaction more than once is forbidden.");
        }

        _hasExecuted = true;

        _success = _stock.RemoveStock(_quantity);
    }

    public void PrintSummary()
    {
        Console.Write($"SELL - {_stock.Name} x {_quantity} @ ${_price}");

        if (!HasExecuted)
        {
            Console.Write("PROPOSED");
        }
        else if (!Success)
        {
            Console.Write("FAILED");
        }

        Console.WriteLine();
    }

}