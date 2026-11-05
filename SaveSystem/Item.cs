namespace RPGSaveSystem;

public class Item
{
    public string Name { get; set; }
    public int Quantity { get; set; }

    public Item() { }

    public Item(string name, int quantity)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Cannot be empty");
        if (quantity < 0)
            throw new ArgumentException("Cannot be negative");

        Name = name;
        Quantity = quantity;
    }
public override string ToString() => $"{Name} x{Quantity}";
}