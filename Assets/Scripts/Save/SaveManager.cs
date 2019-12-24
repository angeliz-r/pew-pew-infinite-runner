using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class SaveManager : MonoBehaviour
{
    public PlayerData data;
    private string file = "playerdata.txt";

    public static SaveManager instance;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    public void Save ()
    {
        string json = JsonUtility.ToJson(data);
        WriteToFile(file, json);
    }

    public void Save(PlayerData savedata)
    {
        PlayerPrefs.SetString("sysString", System.DateTime.Now.ToBinary().ToString());
        string json = JsonUtility.ToJson(savedata);
        WriteToFile(file, json);
    }


    public void Load ()
    {
        data = new PlayerData();
        string json = ReadFromFile(file);
        JsonUtility.FromJsonOverwrite(json, data);
        GameManager.instance.LoadFromSaveData(data);
    }

    private void WriteToFile (string fileName, string json)
    {
        string path = GetFilePath(fileName);
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }

    private string ReadFromFile(string fileName)
    {
        string path = GetFilePath(fileName);
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        }
        else
        {
            Debug.LogWarning("playerdata.txt not found");
            return null;
        }
    }

    private string GetFilePath (string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }
    private void OnApplicationPause(bool pause)
    {
        //for mobile
        if (pause)
            Save();
    }
}
