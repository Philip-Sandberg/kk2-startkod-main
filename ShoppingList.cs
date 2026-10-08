// Holds the items and takes care of loading and saving them.
class ShoppingList
{
    private List<Item> items = new List<Item>();
    private string path;
    private int priceLimit = 1000;

    public ShoppingList(string path)
    {
        this.path = path;
    }

    public void Add(Item item)
    {
        if (Total() + item.Price > priceLimit)
        {
            throw new InvalidOperationException($"Totalen får inte bli mer än {priceLimit} kr");
        }
        items.Add(item);
    }

    // Removes the item the user sees as number 1, 2, 3 ...
    public void RemoveAt(int number)
    {
        if(number > 0 && number <= items.Count)
        {
            items.RemoveAt(number - 1);
        } else
        {
            Console.WriteLine("Välj ett nummer från listan");
        }
    }

    // Adds up the price of every item on the list.
    public int Total()
    {
        int sum = 0;

        for (int i = 0; i < items.Count; i++)
        {
            sum += items[i].Price;
        }

        return sum;
    }

    // Looks up an item by its name. Returns null if there is no such item.
    public Item Find(string name)
    {
        foreach (Item item in items)
        {
            if (item.Name == name)
            {
                return item;
            }
        }

        return null;
    }

    public void Print()
    {
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i]}");
        }

        Console.WriteLine($"Totalt: {Total()} kr");
    }

    // Writes one item per line, as "price;name".
    public void Save()
    {
        List<string> lines = new List<string>();

        foreach (Item item in items)
        {
            lines.Add($"{item.Price};{item.Name}");
        }

       try
        {
            File.WriteAllText(path, string.Join("\r\n", lines) + "\r\n");
            Console.WriteLine("Listan är sparad.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Det gick inte att spara listan");
        }
    }

    // Reads the file back into the list.
    public void Load()
    {
        try{
        string text = File.ReadAllText(path);
        string[] lines = text.Split('\n');
        foreach (string line in lines)
        {
            if(line != null && line != "")
            {
            string[] parts = line.Trim().Split(';');
            items.Add(new Item(parts[1], int.Parse(parts[0])));
            } else
            {
                continue;
            }
        }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Ingen sparad lista hittades");
        }
    }
}
