using System.Text.Json;

namespace RPGSaveSystem;

public static class SaveManager
{
    private const string SaveFolder = "Saves";

    private const string DefaultFileName = "player.json";

    public static void Save(ISaveable entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        Directory.CreateDirectory(SaveFolder);

        string fullPath = Path.Combine(SaveFolder, DefaultFileName);
        string json = entity.ToJson();

        File.WriteAllText(fullPath, json);
    }

    public static T? Load<T>(string path)
    {
        if (string.IsNullOrEmpty(path) || !File.Exists(path))
            return default;

        string json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<T>(json);
    }
}