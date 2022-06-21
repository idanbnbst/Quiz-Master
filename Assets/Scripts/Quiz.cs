using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionLabel;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerButton;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    int correctAnswerIndex;

    void Start()
    {
        questionLabel.text = question.GetQuestion();
        for (int i = 0; i < answerButton.Length; i++)
        {
            TextMeshProUGUI buttonLabel = answerButton[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonLabel.text = question.GetAnswer(i);
        }
        correctAnswerIndex = question.GetCorrectAnswerIndex();
    }

    public void OnAnswerSelected(int index)
    {
        Image buttonImage;
        if (index == question.GetCorrectAnswerIndex())
        {
            questionLabel.text = "Correct!";
            buttonImage = answerButton[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            string correctAnswerLabel = question.GetAnswer(correctAnswerIndex);
            questionLabel.text = "Wrong. The correct answer is " + correctAnswerLabel;
            buttonImage = answerButton[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }
}
