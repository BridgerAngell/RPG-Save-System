namespace RPGSaveSystem;

class Program
{
    static void Main()
    {
        string savePath = Path.Combine("Saves", "player.json");

        Console.WriteLine("-RPG Save System-");
        Console.WriteLine("1 - New Player");
        Console.WriteLine("2 - Load Player");

        string? choice = Console.ReadLine();

        if (choice == "1")
        {
            Console.Write("Enter player name: ");
            string? name = Console.ReadLine();

            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Invalid name");
                return;
            }

            var player = new Player(name);
            player.AddItem(new Item("Sword", 1));
            player.AddItem(new Item("Potion", 3));

            SaveManager.Save(player);
            Console.WriteLine($"\nPlayer '{player.Name}' created and saved");
        }

        else if (choice == "2")
        {
            var player = SaveManager.Load<Player>(savePath);

            if (player == null)
            {
                Console.WriteLine("No save file found");
                return;
            }

            Console.WriteLine($"\nLoaded Player: {player.Name}");
            Console.WriteLine($"Level: {player.Level}");
            Console.WriteLine($"Health: {player.Health}");
            Console.WriteLine("Inventory:");
            foreach (var item in player.Inventory)
            {
                Console.WriteLine($"  - {item}");
            }

            Console.WriteLine("\nDemonstrating actions:");
            player.TakeDamage(20);
            player.LevelUp();

            Console.WriteLine($"After TakeDamage(20) and LevelUp: Level {player.Level}, Health {player.Health}");

            SaveManager.Save(player);
            Console.WriteLine("Updated data and saved");
        }

        else
        {
            Console.WriteLine("Invalid option");
        }
    }
}