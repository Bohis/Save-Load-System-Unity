using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using UnityEngine;

/// <summary>
/// Система загрузки и сохранения данных
/// </summary>
public static class SaveSystem {
    /// <summary>
    /// Cохрание класса в файл
    /// </summary>
    /// <typeparam name="T">Тип сохраняймого класса</typeparam>
    /// <param name="data">объект класса T</param>
    /// <param name="path">название файла, без расширения</param>
    public static void SaveData<T>(T data, string path) where T : class {
        path = Application.persistentDataPath + "/" + path + ".bin";

        using (FileStream stream = new FileStream(path, FileMode.Create)) {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, data);
        }
    }


    /// <summary>
    /// Загрузка класса из файла
    /// </summary>
    /// <typeparam name="T">Тип загружаймого класса</typeparam>
    /// <param name="path">Название загружаймого файла</param>
    /// <returns>Результат загрузки</returns>
    public static T LoadData<T>(string path) where T : class {
        path = Application.persistentDataPath + "/" + path + ".bin";

        using (FileStream stream = new FileStream(path, FileMode.Open)) {
            BinaryFormatter formatter = new BinaryFormatter();
            T data = formatter.Deserialize(stream) as T;
            return data;
        }
    }
}