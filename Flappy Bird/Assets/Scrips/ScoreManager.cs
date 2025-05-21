using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Getting and storing the BestScore in PlayerPrefs
public class ScoreManager : MonoBehaviour
{
    private const string BestScoreKey = "BestScore";
    public static ScoreManager instance;
    public static int BestScore
    {
        get { return PlayerPrefs.GetInt(BestScoreKey, 0); }
        private set { PlayerPrefs.SetInt(BestScoreKey, value); }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);    // survive scene loads
        }
        else if (instance != this)
        {
            Destroy(gameObject);               // enforce single instance
        }
    }

    public static void TryUpdateBestScore(int score)
    {
        if (score > BestScore)
        {
            BestScore = score;
            PlayerPrefs.Save();
        }
    }
}
