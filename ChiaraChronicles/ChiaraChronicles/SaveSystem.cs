using System;
using System.IO;
using System.Text.Json;

public static class SaveSystem
{
    private static readonly string SavePath =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "ChiaraChronicles", "save.json");

    public static bool SaveExists()
    {
        return File.Exists(SavePath);
    }

    public static void Save(SaveState state)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(SavePath));

        var json = JsonSerializer.Serialize(state, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(SavePath, json);
    }

    public static SaveState Load()
    {
        if (!SaveExists())
            return null;

        var json = File.ReadAllText(SavePath);
        return JsonSerializer.Deserialize<SaveState>(json);
    }
}