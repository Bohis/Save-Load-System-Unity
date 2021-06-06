using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using UnityEngine;

public static class SaveSystem {
    
    public static void SaveData<T>(T data, string path) where T : class {
        path = Application.persistentDataPath + "/" + path;

        using (FileStream stream = new FileStream(path, FileMode.Create)) {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, data);
        }
    }

    public static T LoadData<T>(string path) where T : class {
        path = Application.persistentDataPath + "/" + path;

        using (FileStream stream = new FileStream(path, FileMode.Open)) {
            BinaryFormatter formatter = new BinaryFormatter();
            T data = formatter.Deserialize(stream) as T;
            return data;
        }
    }
}