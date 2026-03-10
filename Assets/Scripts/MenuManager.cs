using UnityEngine;
using System.IO;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance; // Store the data you want to persist between scenes

    // added Persistent Objects
    public string BestPlayerName; 
    public int BestScore; 
    public string CurrentPlayerName; 
    
    
    private void Awake()
    {
        
        if (Instance != null) // Singleton Modify the Awake method, only a single instance of the MenuManager can ever exist
        {
            Destroy(gameObject);
            return; // stops the rest of the method from executing any more logic
        }

        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            LoadGame(); 
        }

    }


    [System.Serializable] // Data persistence between sessions
    class SaveData
    {
        public string currentPlayerName;
        public string bestPlayerName;
        public int bestScore;

    }

    public void SaveGame()  // Save method that transforms that class into JSON format and writes it to a file
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

    public void LoadGame() // Load method that transforms the data from the JSON file back into the SaveData class
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
