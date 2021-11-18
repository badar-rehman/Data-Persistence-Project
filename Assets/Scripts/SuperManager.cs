using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SuperManager : MonoBehaviour
{
    public static SuperManager Instance;
    public int highScore1;
    public int highScore2;
    public int highScore3;
    public string playerName;
    public string currentPlayer;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string playerName;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.highScore = highScore1;
        data.playerName = playerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore1 = data.highScore;
            playerName = data.playerName;
        }
    }

    public bool UpdateHighScore(string name, int currentScore)
    {
        if (currentScore > SuperManager.Instance.highScore1)
        {
            SuperManager.Instance.highScore1 = currentScore;
            SuperManager.Instance.playerName = name;
            SuperManager.Instance.SaveScore();

            return true;
        }
        else
        {
            return false;
        }
    }

}
