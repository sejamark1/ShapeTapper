using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 



public class scoreBoard : MonoBehaviour
{

    private bool isHighScore = false; 
    private static int score = 0;
    private static int damage = 3;
    public Text scoreText;
    public Text damageText;
    public Text highScoreAlert; 
    public List<GameObject> shapeObjects = new List<GameObject>();

    
    private void Start()
    {
               
    }
    public void addScore()
    {
        score++;
    }
    public void damageCount()
    {
        // Increase by 0.5 because when two object collide they both ends up callling this funciton [MUST COUNT THEM AS ONE SO 0.5]
        damage--;
    }


    void Update()
    {
        if(damageText != null)
        {
            damageText.text = (damage).ToString();
        }
        if(scoreText != null)
        {
            scoreText.text = score.ToString();
        }


        if (damage <= 0 & SceneManager.GetActiveScene().name != "LoseScreen")
        {
            SceneManager.LoadScene("LoseScreen");
            damage += 1;
        }





    }


    public int returnScore()
    {
        return score; 
    }

    public void resetScoreDamageValue()
    {
        score = 0;
        //damage = damage; 
    }


    public void addDamage(int d) {
        damage += d; 
    }



}
