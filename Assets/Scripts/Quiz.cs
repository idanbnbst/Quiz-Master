using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionLabel;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    QuestionSO currectQuestion;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButton;
    int correctAnswerIndex;
    bool hasAnsweredEarly;

    [Header("Buttons")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreLabel;
    ScoreKeeper scoreKeeper;
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextQuestion)
        {
            hasAnsweredEarly = false;
            DisplayNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if (!hasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }
    void OnAnswerSelected(int index)
    {
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
        scoreLabel.text = "Score: " + scoreKeeper.calcScore() + "%";
    }
    void DisplayAnswer(int index)
    {
        Image buttonImage;
        if (index == currectQuestion.GetCorrectAnswerIndex())
        {
            questionLabel.text = "Correct!";
            buttonImage = answerButton[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            scoreKeeper.CorrectAnswers++;
        }
        else
        {
            string correctAnswerLabel = currectQuestion.GetAnswer(correctAnswerIndex);
            questionLabel.text = "Wrong. The correct answer is " + correctAnswerLabel;
            buttonImage = answerButton[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }
    void DisplayQuestion()
    {
        questionLabel.text = currectQuestion.GetQuestion();
        for (int i = 0; i < answerButton.Length; i++)
        {
            TextMeshProUGUI buttonLabel = answerButton[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonLabel.text = currectQuestion.GetAnswer(i);
        }
        correctAnswerIndex = currectQuestion.GetCorrectAnswerIndex();
    }
    void DisplayNextQuestion()
    {
        if (questions.Count > 0)
        {
            SetButtonState(true);
            SetDefaultButtonSprite();
            GetRandomQuestion();
            DisplayQuestion();
            scoreKeeper.QuestionsViewed++;
        }
    }
    void GetRandomQuestion()
    {
        int random = Random.Range(0, questions.Count);
        currectQuestion = questions[random];
        if (questions.Contains(currectQuestion))
            questions.Remove(currectQuestion);
    }
    void SetDefaultButtonSprite()
    {
        Image buttonImage = answerButton[correctAnswerIndex].GetComponent<Image>();
        buttonImage.sprite = defaultAnswerSprite;
    }
    void SetButtonState(bool state)
    {
        for (int i = 0; i < answerButton.Length; i++)
        {
            Button button = answerButton[i].GetComponent<Button>();
            button.interactable = state;
        }
    }
}
