
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{

    [SerializeField] ScoreSO scoreSO;
    [SerializeField] TMP_Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = scoreSO.score.ToString();
    }


}
