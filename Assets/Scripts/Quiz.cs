using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionLabel;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerButton;

    void Start()
    {
        questionLabel.text = question.GetQuestion();
        for (int i = 0; i < answerButton.Length; i++)
        {
            TextMeshProUGUI buttonLabel = answerButton[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonLabel.text = question.GetAnswer(i);
        }
    }
}
