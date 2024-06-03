using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Experimental.AI;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public string playerName;
    public int highScore;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }

        LoadInfo();
    }

    [Serializable]
    class SaveData
    {
        public string name;
        public int highScore;
    }

    public void SaveInfo()
    {
        SaveData data = new SaveData();
        data.name = playerName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "savefile.json", json);
    }

    public void LoadInfo()
    {
        string path = Application.persistentDataPath + "savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.name;
        }
    }
}
