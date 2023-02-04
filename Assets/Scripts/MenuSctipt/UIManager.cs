using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public string playerName;
    public string bestPlayer;
    public int bestPoint;
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    [System.Serializable]
    class SaveDate
    {
        public string bestPlayer;
        public int bestPoint; 
    }
    public void SaveBestPlayer()
    {
        SaveDate data = new SaveDate();
        data.bestPlayer = bestPlayer;
        data.bestPoint = bestPoint;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadBestPlayer()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveDate data = JsonUtility.FromJson<SaveDate>(json);
            bestPlayer = data.bestPlayer;
            bestPoint = data.bestPoint;
        }
        else
        {
            bestPlayer = "None";
            bestPoint = 0;
        }
    }
}
