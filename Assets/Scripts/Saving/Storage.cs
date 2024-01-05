using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Storage
{
    private string _filePath;
    private BinaryFormatter _formatter;

    public Storage()
    {
        var directory = Application.persistentDataPath + "/saves";
        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory);
        
        _filePath = directory + "/data.m";
        InitBinFormatter();
    }

    private void InitBinFormatter()
    {
        _formatter = new BinaryFormatter();
        var surSelector = new SurrogateSelector();

        var vc3Surrogate = new Vector3Serialization();
        var quSurrogate = new QuaternionSerialization();
        
        surSelector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), vc3Surrogate);
        surSelector.AddSurrogate(typeof(Quaternion), new StreamingContext(StreamingContextStates.All), quSurrogate);
        _formatter.SurrogateSelector = surSelector;
    }

    public object Load(object saveDataByDefault)
    {
        if (!File.Exists(_filePath))
        {
            if (saveDataByDefault != null)
            {
                Save(saveDataByDefault);;
            }

            return saveDataByDefault;
        }

        var file = File.Open(_filePath, FileMode.Open);
        var savedData = _formatter.Deserialize(file);
        file.Close();;
        return savedData;
    }

    public void Save(object saveData)
    {
        var file = File.Create(_filePath);
        _formatter.Serialize(file, saveData);
        file.Close();
    }
}
