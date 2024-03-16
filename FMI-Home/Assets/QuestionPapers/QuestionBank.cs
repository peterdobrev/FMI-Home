using UnityEngine;
using System.Collections.Generic;

public class QuestionBank
{
    private List<QuestionData> questions;

    // Constructor to initialize the question bank
    public QuestionBank()
    {
        questions = new List<QuestionData>();

        // Initialize your questions here
        AddQuestion("What is the capital of France?", "Paris", "London", 0);
        AddQuestion("What is 2 + 2?", "4", "5", 0);
        AddQuestion("Which one is a fruit?", "Carrot", "Apple", 1);
        // Add more questions as needed
    }

    private void AddQuestion(string questionText, string answerA, string answerB, int correctAnswer)
    {
        QuestionData newQuestion = ScriptableObject.CreateInstance<QuestionData>();
        newQuestion.questionText = questionText;
        newQuestion.answerA = answerA;
        newQuestion.answerB = answerB;
        newQuestion.correctAnswer = correctAnswer;
        questions.Add(newQuestion);
    }

    // Method to get a random question from the bank
    public QuestionData GetRandomQuestion()
    {
        if (questions.Count == 0)
        {
            Debug.LogError("No questions available.");
            return null;
        }

        int randomIndex = Random.Range(0, questions.Count);
        return questions[randomIndex];
    }
}
