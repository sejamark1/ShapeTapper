using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public AudioSource audioSource;
    private scoreBoard _scoreBoard;
   

    void Start()
    {

        audioSource = GetComponent<AudioSource>();
        _scoreBoard = FindObjectOfType<scoreBoard>(); 

    }
    public void PlayGame()
    {
        audioSource.Play(); 
        SceneManager.LoadScene("GamePlay"); 

    }
    public void GameQuit()
    {
        audioSource.Play(); 
        Application.Quit(); 
    }


    public void Restart()
    {
        _scoreBoard.resetScoreDamageValue();
        SceneManager.LoadScene("GamePlay"); 
    }




}
