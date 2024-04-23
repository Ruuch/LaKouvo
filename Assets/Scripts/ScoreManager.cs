using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json;
using System;

public class ScoreManager : MonoBehaviour
{
    //[SerializeField] EventManagerSO eventManager;
    [SerializeField] ScoreSO scoreKeeper;
    [SerializeField] public TextMeshProUGUI scoreText;
    [SerializeField] public TextMeshProUGUI mentalText;
    float score = 0;
    int mentalScore = 10;
    float elapsedTime;
    public static ScoreManager instance;

    private void Awake()
    {
        score = 0;
        score = Convert.ToInt32(score);
        scoreKeeper.score = (int)score;
        instance = this;
    }


    void Start()
    {
        scoreText.text = score.ToString();
        StartCoroutine(ScoreUp(0.1f));
        StartCoroutine(MentalHealthDown(1));

    }

    private void Update()
    {
       /*elapsedTime += Time.deltaTime;
        //scoreText.text = elapsedTime.ToString();
        float minutes = Mathf.FloorToInt(elapsedTime / 60);
        float seconds = Mathf.FloorToInt(elapsedTime % 60);
        scoreText.text = string.Format("{0:00},{1:00}", minutes, seconds);
        // 36e tuntipalkka*/
    }
        
    IEnumerator ScoreUp(float amount = 0.1f)
    {
        while(true)
        {
            score += amount;
            scoreText.text = score.ToString("n2");
            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator MentalHealthDown(int amount = 1)
    {
        while(true)
        {
            mentalScore -= amount;
            mentalText.text = mentalScore.ToString();
            yield return new WaitForSeconds(2);

        }
    }
    public void AddPoint50()
    {
        score += 50;
        scoreKeeper.score = (int)score;
        scoreText.text = score.ToString();
    }

    public void AddPoint200()
    {
        score += 200;
        scoreKeeper.score = (int)score;
        scoreText.text = score.ToString();
    }

    public void AddSalary()
    {
        Debug.Log("Salary");
        score += 0.06f;
        scoreKeeper.score = (int)score;
        scoreText.text = score.ToString("n2"); //n2 m‰‰ritt‰‰ et n‰kyy vaa 2 desimaalia
        
    }

}
