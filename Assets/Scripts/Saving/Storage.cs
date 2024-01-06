using System.IO;
using UnityEngine;


public class Storage
{
    private string _filePath;

    public Storage()
    {
        var directory = Application.persistentDataPath + "/saves";
        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory);

        _filePath = directory + "/data.m";
    }

    public T Load<T>(T saveDataByDefault)
    {
        if (!File.Exists(_filePath))
        {
            Save(saveDataByDefault);
            return saveDataByDefault;
        }

        var json = File.ReadAllText(_filePath);
        return JsonUtility.FromJson<T>(json);
    }

    public void Save<T>(T saveData)
    {
        var json = JsonUtility.ToJson(saveData, prettyPrint: true);
        File.WriteAllText(_filePath, json);
    }
}