using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;



#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField playerNameTextField; //dodala
    

    private void SetPlayerName() // dodala
    {
        string textValue = playerNameTextField.text;
        if (string.IsNullOrEmpty(textValue))
        {
            textValue = "Default player";
        }
        MenuManager.Instance.playerName = textValue;
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        
    }


    public void StartNew()
    {
        SetPlayerName(); // dodala

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
