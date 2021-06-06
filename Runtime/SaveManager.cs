//using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class SaveManager
{

    //Static Methods
    public static void Save(object data)
    {
        string m_jsonString = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.persistentDataPath + "/save.json", m_jsonString);
    }

    public static Data Load<Data>(Data newData)
    {
        Data m_data = newData;

        if (GetIfFileExists())
        {
            string m_raw = File.ReadAllText(Application.persistentDataPath + "/save.json");
            JsonUtility.FromJsonOverwrite(m_raw, m_data);
        }

        return m_data;
    }

    public static bool GetIfFileExists()
    {
        bool m_bool = false;

        if (File.Exists(Application.persistentDataPath + "/save.json"))
        {

            m_bool = true;
        }

        return m_bool;
    }
}