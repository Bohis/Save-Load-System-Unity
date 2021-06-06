using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using UnityEngine;

/// <summary>
/// ������� �������� � ���������� ������
/// </summary>
public static class SaveSystem {
    /// <summary>
    /// C������� ������ � ����
    /// </summary>
    /// <typeparam name="T">��� ������������ ������</typeparam>
    /// <param name="data">������ ������ T</param>
    /// <param name="path">�������� �����, ��� ����������</param>
    public static void SaveData<T>(T data, string path) where T : class {
        path = Application.persistentDataPath + "/" + path + ".bin";

        using (FileStream stream = new FileStream(path, FileMode.Create)) {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, data);
        }
    }


    /// <summary>
    /// �������� ������ �� �����
    /// </summary>
    /// <typeparam name="T">��� ������������ ������</typeparam>
    /// <param name="path">�������� ������������ �����</param>
    /// <returns>��������� ��������</returns>
    public static T LoadData<T>(string path) where T : class {
        path = Application.persistentDataPath + "/" + path + ".bin";

        using (FileStream stream = new FileStream(path, FileMode.Open)) {
            BinaryFormatter formatter = new BinaryFormatter();
            T data = formatter.Deserialize(stream) as T;
            return data;
        }
    }
}