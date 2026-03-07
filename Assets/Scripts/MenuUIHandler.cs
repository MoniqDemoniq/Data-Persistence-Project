using UnityEngine;
using UnityEngine.SceneManagement;
using System.Drawing;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif


public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI bestScoreText; // dodala
    public TMP_InputField inputField; // dodala


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start() // ubacila
    {
        bestScoreText.text = $"Best Score: {MenuManager.Instance.BestPlayerName} : {MenuManager.Instance.BestScore}";
    }

    
    public void StartNew()
    {
        MenuManager.Instance.CurrentPlayerName = inputField.text; // dodala
        
        SceneManager.LoadScene(1);


    }

    public void Exit()
    {
        
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
     #else
        Application.Quit(); // original code to quit Unity player
     #endif
    }

    


}
