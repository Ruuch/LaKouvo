using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public int gameOverScreen;
    [SerializeField] TextMeshProUGUI mentalScore;
    int mentalNro;
    

    /*private void Awake()
    {
        GetComponent<TextMeshProUGUI>();
       int.TryParse(mentalScore.GetParsedText(), out mentalNro);
       mentalScore = mentalNro;

    }*/

    public void gameOverMentalHealthLoppu()
    {
        //if (mentalScore = 0)
        
            SceneManager.LoadScene(gameOverScreen);
        
    }
}
