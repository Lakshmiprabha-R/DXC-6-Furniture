// See https://aka.ms/new-console-template for more information

using System;

class Furniture
{
    public double Height { get; set; }
    public double Width { get; set; }
    public string Color { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }

    public Furniture() { }

    public virtual void Accept()
    {
        Console.WriteLine("Enter furniture details:");
        Console.Write("Height: ");
        Height = Convert.ToDouble(Console.ReadLine());
        Console.Write("Width: ");
        Width = Convert.ToDouble(Console.ReadLine());
        while (true)
        {
            Console.Write("Color: ");
            Color = Console.ReadLine();
            if (!int.TryParse(Color, out int result))
            {
                break;
            }
            Console.WriteLine("Invalid input. Enter correct color.");
        }
        Console.Write("Quantity: ");
        Quantity = Convert.ToInt32(Console.ReadLine());
        Console.Write("Price: ");
        Price = Convert.ToDouble(Console.ReadLine());
    }

    public virtual void Display()
    {
        Console.WriteLine($"Type of furniture: {this.GetType().Name}");
        Console.WriteLine($"Height: {Height}");
        Console.WriteLine($"Width: {Width}");
        Console.WriteLine($"Colour: {Color}");
        Console.WriteLine($"Quantity: {Quantity}");
        Console.WriteLine($"Price: {Price}");
    }
}

class Bookshelf : Furniture
{
    public int NumShelves { get; set; }

    public override void Accept()
    {
        base.Accept();
        Console.Write("Number of shelves: ");
        NumShelves = Convert.ToInt32(Console.ReadLine());
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Number of shelves: {NumShelves}");
    }
}

class DiningTable : Furniture
{
    public int NumberLegs { get; set; }

    public override void Accept()
    {
        base.Accept();
        Console.Write("Number of legs: ");
        NumberLegs = Convert.ToInt32(Console.ReadLine());
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"Number of legs: {NumberLegs}");
    }
}

class Program
{
    static int AddToStock(Furniture[] stock)
    {
        Console.WriteLine("Adding furniture to stock:");
        int numItems = 0;
        while (numItems < stock.Length)
        {
            Console.Write($"Enter item {numItems + 1} (1 for Bookshelf, 2 for Dining Table): ");
            string choice = Console.ReadLine();
            switch (choice.ToUpper())
            {
                case "1":
                    stock[numItems] = new Bookshelf();
                    break;
                case "2":
                    stock[numItems] = new DiningTable();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    continue;
            }
            stock[numItems].Accept();
            numItems++;
        }
        Console.WriteLine("Stock added successfully.");
        return numItems;
    }

    static double TotalStockValue(Furniture[] stock)
    {
        double totalValue = 0;
        foreach (Furniture item in stock)
        {
            totalValue += item.Quantity * item.Price;
        }
        return totalValue;
    }

    static void ShowStockDetails(Furniture[] stock)
    {
        Console.WriteLine("Showing stock details:");
        foreach (Furniture item in stock)
        {
            item.Display();
        }
    }

    static void Main(string[] args)
    {
        Furniture[] stock = new Furniture[3];
        int numItems = AddToStock(stock);
        ShowStockDetails(stock);
        double totalValue = TotalStockValue(stock);
        Console.WriteLine($"Total stock value: INR {totalValue}");
    }
}