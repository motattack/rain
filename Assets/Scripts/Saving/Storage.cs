using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class Storage
{
    private string _filePath;

    public Storage()
    {
        var directory = Application.persistentDataPath + "/saves";
        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory);

        _filePath = directory + "/rain_data.json";
    }

    public T Load<T>(T saveDataByDefault)
    {
        if (!File.Exists(_filePath))
        {
            Save(saveDataByDefault);
            return saveDataByDefault;
        }

        var json = File.ReadAllText(_filePath);
        return JsonConvert.DeserializeObject<T>(json);
    }

    public void Save<T>(T saveData)
    {
        var json = JsonConvert.SerializeObject(saveData, Formatting.Indented);
        File.WriteAllText(_filePath, json);
    }
}