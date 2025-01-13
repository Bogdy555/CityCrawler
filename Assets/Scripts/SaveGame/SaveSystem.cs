using Newtonsoft.Json;
using UnityEngine;
using System.IO;
public static class SaveSystem
{
    public static void SavePlayer(Character player)
    {
        string directory = Application.dataPath + "/SaveData";
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        int freeNumber = 0;
        string path = "";

        while (path == "" && freeNumber < 100)
        {
            freeNumber += 1;
            string potentialPath = directory + "/player" + freeNumber.ToString() + ".json";
            if (!File.Exists(potentialPath))
            {
                path = potentialPath;
            }
        }
        string jsonData = JsonConvert.SerializeObject(new PlayerData(player), Formatting.Indented);

        File.WriteAllText(path, jsonData);
        Debug.Log("Player saved to " + path);
    }

    public static PlayerData LoadPlayer(string path)
    {
        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            PlayerData data = JsonConvert.DeserializeObject<PlayerData>(jsonData);
            return data;
        }
        Debug.LogWarning("Save file not found at " + path);
        return null;
    }
}





