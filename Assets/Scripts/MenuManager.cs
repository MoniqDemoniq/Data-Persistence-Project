using UnityEngine;
using System.IO;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance; // Store the data you want to persist between scenes
    public string playerName;

    

    private void Awake()
    {
        
        if (Instance != null) // Singleton Modify the Awake method, only a single instance of the MenuManager can ever exist
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);

        

    }


    [System.Serializable] // dodala
    class SaveData
    {
        public string currentPlayerName;
        
    }

    
}
