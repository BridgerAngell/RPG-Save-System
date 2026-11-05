using System.Text.Json;

namespace RPGSaveSystem;

public class Player : IGameCharacter, ISaveable
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Level { get; set; }
    public List<Item> Inventory { get; set; }

    public Player()
    {
        Name = string.Empty;
        Health = 100;
        Level = 1;
        Inventory = new List<Item>();
    }

    public Player(string name, int health = 100, int level = 1)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Cannot be empty");
        if (health < 0)
            throw new ArgumentException("Cannot be negative");

        Name = name;
        Health = health;
        Level = level;
        Inventory = new List<Item>();
    }

    public void AddItem(Item item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));
        Inventory.Add(item);
    }

    public void TakeDamage(int amount)
    {
        if (amount < 0)
            throw new ArgumentException("Cannot be negative");
        Health = Math.Max(0, Health - amount);
    }

    public void LevelUp()
    {
        Level++;
    }

    public string ToJson()
    {
        return JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
    }
}