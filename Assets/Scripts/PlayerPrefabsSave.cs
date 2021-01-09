using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefabsSave : MonoBehaviour
{
    private scoreBoard scoreboard;
    private static bool isHighScore = false; 
    public Text highScoreText;
    private int currentScore; 
    private void Start()
    {
        scoreboard = FindObjectOfType<scoreBoard>();
        currentScore = scoreboard.returnScore();
        isHighScore = saveHighScore(currentScore);
        if (isHighScore == true)
        {
            highScoreText.text = "Highscore";
        }
        else
        {
            highScoreText.text = "";
        }
    }



    private bool saveHighScore(int currentScore)
    {
        int highScore = PlayerPrefs.GetInt("highscore");
        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("highscore", currentScore);
            return true;
        }
        return false;

    }









}
