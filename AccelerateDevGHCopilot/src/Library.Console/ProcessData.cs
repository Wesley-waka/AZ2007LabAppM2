using System;
using System.Data;

public class DataProcessor
{
    public void ProcessData(string item, string price)
    {
        // Cleanse the data
        item = item.Trim();    // Remove leading and trailing whitespace
        price = price.Trim();  // Remove leading and trailing whitespace
        double priceValue = double.Parse(price);   // Convert price to a double
        // More cleansing operations can be added here

        // Create and print a DataTable
        DataTable table = new DataTable();
        table.Columns.Add("Item", typeof(string));
        table.Columns.Add("Price", typeof(double));
        table.Rows.Add(item, priceValue);
        foreach (DataRow row in table.Rows)
        {
            Console.WriteLine($"Item: {row["Item"]}, Price: {row["Price"]}");
        }
    }

    private (string CleanItem, double CleanPrice) CleanseData(string item, string price)
    {
        string cleanItem = item.Trim();
        string cleanPriceStr = price.Trim();
        double cleanPrice = double.Parse(cleanPriceStr);
        return (cleanItem, cleanPrice);
    }

    private void PrintData(DataTable table)
    {
        foreach (DataRow row in table.Rows)
        {
            Console.WriteLine($"Item: {row["Item"]}, Price: {row["Price"]}");
        }
    }

    public void ProcessData(string item, string price)
    {
        var cleansed = CleanseData(item, price);

        DataTable table = new DataTable();
        table.Columns.Add("Item", typeof(string));
        table.Columns.Add("Price", typeof(double));
        table.Rows.Add(cleansed.CleanItem, cleansed.CleanPrice);

        PrintData(table);
    }
// Example usage
class Program
{
    static void Main()
    {
        string item = "  Apple  ";
        string price = "  1.50  ";
        var processor = new DataProcessor();
        processor.ProcessData(item, price);
    }
}