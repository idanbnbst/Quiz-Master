using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int questionsViewed = 0, correctAnswers = 0;
    public int QuestionsViewed { get => questionsViewed; set => questionsViewed = value; }
    public int CorrectAnswers { get => correctAnswers; set => correctAnswers = value; }
    public int calcScore()
    {
        return Mathf.RoundToInt((correctAnswers / (float)questionsViewed) * 100);
    }
}