using System;

public class Stock
{
    private int _quantityOnHand;
    private string _name;

    public Stock(string name, int initialLevel)
    {
        _name = name;
        _quantityOnHand = initialLevel;
    }

    public bool AddStock(int quantityAdded)
    {
        if (quantityAdded > 0)
        {
            _quantityOnHand = _quantityOnHand + quantityAdded;
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool RemoveStock(int quantityRemoved)
    {
        if (quantityRemoved < _quantityOnHand && quantityRemoved > 0)
        {
            _quantityOnHand -= quantityRemoved;
            return true;
        } 
        else
        {
            return false;
        }
    }

    public string Name
    {
        get {return _name; }
        set {_name = value; }
    }

    public int QuantityOnHand
    {
        get { return _quantityOnHand; }
        set { _quantityOnHand = value; }
    }

    public void PrintSummary()
    {
        Console.WriteLine($"{Name}: {QuantityOnHand}");
    }
}