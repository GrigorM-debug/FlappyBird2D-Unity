using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUi : MonoBehaviour
{
    [SerializeField] private Text bestScoreText;

    private void Start()
    {
        int bestScore = ScoreManager.BestScore;
        bestScoreText.text = bestScore.ToString();
    }
}
