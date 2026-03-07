using UnityEngine;
using System.IO;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance; // Store the data you want to persist between scenes
    public string CurrentPlayerName; // dodala
    public string BestPlayerName; // dodala
    public int BestScore; // dodala

    private void Awake()
    {
        
        if (Instance != null) // Singleton Modify the Awake method, only a single instance of the MenuManager can ever exist
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadGame(); // dodala

    }


    [System.Serializable] // dodala
    class SaveData
    {
        public string currentPlayerName;
        public string bestPlayerName;
        public int bestScore;

    }

    public void SaveGame() // dodala
    {
        SaveData data = new SaveData
        {
            currentPlayerName = CurrentPlayerName,
            bestPlayerName = BestPlayerName,
            bestScore = BestScore
        };

        string json = JsonUtility.ToJson(data);
        string path = Application.persistentDataPath + "/savefile.json";

        File.WriteAllText(path, json);
    }

    public void LoadGame() // dodala
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (!File.Exists(path))
            return;

        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        if (data != null)
        {
            CurrentPlayerName = data.currentPlayerName;
            BestPlayerName = data.bestPlayerName;
            BestScore = data.bestScore;
        }
    }


}
