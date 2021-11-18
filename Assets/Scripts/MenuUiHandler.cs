using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUiHandler : MonoBehaviour
{
    public TMP_InputField nameEnter;
    public TextMeshProUGUI highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "High Score: " + SuperManager.Instance.playerName + " : " + SuperManager.Instance.highScore1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NameEnter()
    {
        string name = nameEnter.text;
        Debug.Log(name);

        SuperManager.Instance.currentPlayer = name;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit(); // original code to quit Unity player
        #endif
    }
}
