using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreLabel;
    ScoreKeeper scoreKeeper;
    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        ShowFinalScore();
    }

    public void ShowFinalScore()
    {
        finalScoreLabel.text = "Congratulations!\n Your score: " +
                                scoreKeeper.calcScore() + "%";
    }
}
