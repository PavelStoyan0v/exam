using System;
using System.Text.RegularExpressions;

public class Product
{
    private string _name;
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            if (value.Length < 3)
                throw new ArgumentException("Invalid product name!");

            if (!Regex.IsMatch(value, "[a-zA-Z0-9]+"))
                throw new Exception("Invalid product name!");

            this._name = value;
        }
    }

    private double _price;

    public double Price
    {
        get
        {
            if (this.isOnPromotion)
                return _price * 0.8;
            return _price;
        }
        set
        {
            if (value < 0)
                throw new ArgumentException("Price should be positive!");

            _price = value;
        }
    }
    public bool isOnPromotion;

    public Product(string name, double price)
    {
        this.Name = name;
        this.Price = price;
    }

    public Product(string name, double price, bool isOnPromotion)
    {
        this.Name = name;
        this.Price = price;
        this.isOnPromotion = isOnPromotion;
    }

    public override string ToString()
    {
        string promotion = this.isOnPromotion ? "YES" : "NO";
        return $"Product -> {this.Name} with price {this.Price:f2}. On promotion: {promotion}";
    }
}
