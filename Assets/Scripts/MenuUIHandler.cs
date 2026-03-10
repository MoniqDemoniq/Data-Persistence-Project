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
    public TextMeshProUGUI bestScoreText; // variable
    public TMP_InputField nameInputField; // variable


    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start() // method showing player's name and best player's name and score 
    {
        nameInputField.SetTextWithoutNotify(MenuManager.Instance.CurrentPlayerName);
        bestScoreText.text = $"Best Score: {MenuManager.Instance.BestPlayerName} : {MenuManager.Instance.BestScore}";
    }

    
    public void StartNew()
    {
        MenuManager.Instance.CurrentPlayerName = nameInputField.text; 
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
