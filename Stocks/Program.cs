using System;
using System.Collections.Generic;

namespace Stocks
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> stocks = new Dictionary<string, string>();
            stocks.Add("GME", "GameStop");
            stocks.Add("AMC", "AMC Entertainment Holding Inc");
            stocks.Add("TSLA", "Tesla Inc");
            stocks.Add("GM", "General Motors");

            List<(string ticker, int shares, double price)> purchases = new List<(string, int, double)>();

            purchases.Add((ticker: "GM", shares: 150, price: 23.21));
            purchases.Add((ticker: "GM", shares: 32, price: 17.87));
            purchases.Add((ticker: "GM", shares: 80, price: 19.02));
            // Add more for each stock you added to the stocks dictionary
            purchases.Add((ticker: "GME", shares: 120, price: 151.3));
            purchases.Add((ticker: "AMC", shares: 12, price: 32.01));
            purchases.Add((ticker: "TSLA", shares: 6, price: 203.41));
            purchases.Add((ticker: "GME", shares: 30, price: 124.3));
            //Create a total ownership report that computes the total value of each stock that you have purchased.
            //This is the basic relational database join algorithm between two tables.
            Dictionary<string, double> stockValues = new Dictionary<string, double>();
            foreach (var purchase in purchases)
            {
                var val = purchase.shares * purchase.price;

                if (stockValues.ContainsKey(purchase.ticker))
                {
                    stockValues[purchase.ticker] += val;
                } else
                {
                    stockValues.Add(purchase.ticker, val);
                }
            }

            foreach(var s in stockValues)
            {
                Console.WriteLine($"{s.Key}: {s.Value}");
            }

            /*
             * Define a new Dictionary to hold the aggregated purchase information. - The key should be a string that is the full company name.
             * The value will be the valuation of each stock (price*amount) { "General Electric": 35900, "AAPL": 8445, ... }
            */
            // Iterate over the purchases and update the valuation for each stock
            Dictionary<string, double> stockInfo = new Dictionary<string, double>();

            foreach (var stock in stocks)
            {
                foreach (var s in stockValues)
                {
                    if (stock.Key == s.Key)
                    {
                        stockInfo.Add(stock.Value, s.Value);
                    }
                }
            }

            foreach (var s in stockInfo)
            {
                Console.WriteLine($"{s.Key}: {s.Value}");
            }
        }
    }
}
