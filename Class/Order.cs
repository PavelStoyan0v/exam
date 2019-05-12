using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

public class Order
{
    public int orderNumber;
    public List<Product> productsList;
    public static int OrdersCount = 0;

    public Order(int orderNumber, List<Product> productsList)
    {
        this.orderNumber = orderNumber;
        this.productsList = productsList;
        Interlocked.Increment(ref OrdersCount);
    }

    ~Order()
    {
        Interlocked.Decrement(ref OrdersCount);
    }

    public void AddProduct(Product product)
    {
        this.productsList.Add(product);
    }



    public double GetOrderTotalPrice()
    {
        double price = 0;
        foreach (var product in productsList)
        {
            price += product.Price;
        }

        return price;
    }



    public double GetDiscountedProductsTotalPrice()

    {
        double price = 0;
        foreach(var product in productsList)
        {
            if(product.isOnPromotion)
                price += product.Price;
        }

        return price;
    }


    //double ?
    public double GetDiscountedProductsCount()
    {
        int count = 0;
        foreach(var product in productsList)
        {
            if (product.isOnPromotion)
                count++;
        }

        return count;
    }



    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Order #{this.orderNumber} has the following products:");
        foreach (var product in this.productsList)
        {
            sb.AppendLine($"### {product}");
        }

        return sb.ToString();
    }
}
