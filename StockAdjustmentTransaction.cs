using System;

public class StockAdjustmentTransaction
{
    private readonly Stock _stock;
    private readonly decimal _price;
    private readonly int _quantity;
    private bool _hasExecuted = false;
    private bool _success = false;

    public bool Success
    {
        get
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

    public StockAdjustmentTransaction(Stock stock, int quantity)
    {
        _stock = stock;
        _quantity = quantity;
    }

    
    public void Execute()
    {
        if (HasExecuted)
        {
            throw new InvalidOperationException("Executing a transaction more than once is forbidden.");
        }

        _hasExecuted = true;

        //_success = _stock.RemoveStock(_quantity);

        if (_stock.QuantityOnHand <= 0)
        {
            _stock.AddStock(_quantity);
        }
    }
}