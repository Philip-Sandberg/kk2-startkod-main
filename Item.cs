// One item on the shopping list.
using System.Numerics;

class Item
{
    public string Name { get; set; }
    public int Price { get; set; }

    public Item(string name, int price)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException ("Varans namn får inte vara tomt");
        }
        if (price <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(price), "Varans pris måste vara ett positivt heltal");
        }
        Name = name;
        Price = price;
    }

    public override string ToString()
    {
        return $"{Name} - {Price} kr";
    }
}
