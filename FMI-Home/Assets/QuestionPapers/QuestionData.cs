using UnityEngine;

[CreateAssetMenu(fileName = "New Question", menuName = "Quiz/Question")]
public class QuestionData : ScriptableObject
{
    [TextArea(2, 5)]
    public string questionText;
    public string answerA;
    public string answerB;
    public int correctAnswer; // 0 for A, 1 for B
}