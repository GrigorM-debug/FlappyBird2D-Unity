using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;

    [SerializeField] private Text scoreText;

    public void IncreaseScore()
    {
        score++;

        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        ScoreManager.TryUpdateBestScore(score);

        //Load the gameover scene
        SceneManager.LoadScene("FlappyBird.GameOver");
    }
}
