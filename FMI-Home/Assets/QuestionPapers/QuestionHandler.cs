using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class QuestionHandler : MonoBehaviour
{
    private QuestionData questionData;

    [SerializeField]
    private TextMeshProUGUI textQuestion;
    [SerializeField]
    private TextMeshProUGUI textAnswerA;
    [SerializeField]
    private TextMeshProUGUI textAnswerB;

    public UnityEvent onCorrectAnswer;
    public UnityEvent onWrongAnswer;

    void OnEnable()
    {
        QuestionBank questionBank = new QuestionBank(); // Initialize the question bank
        questionData = questionBank.GetRandomQuestion(); // Get a random question


        textQuestion.text = questionData.questionText;
        textAnswerA.text = questionData.answerA;
        textAnswerB.text = questionData.answerB;
    }

    public void HandleAnswer(bool clickedAnswerA)
    {
        int answer = clickedAnswerA ? 0 : 1;
        if(questionData.correctAnswer == answer)
        {
            HandleCorrectAnswer();
        }
        else
        {
            HandleWrongAnswer();
        }
    }

    private void HandleWrongAnswer()
    {
        Debug.Log("Wrong Answer");
        onWrongAnswer.Invoke();
        StartCoroutine(SayAnswer("Wrong!"));
    }

    private IEnumerator SayAnswer(string text)
    {
        var tmp = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        tmp.text = text;
        tmp.fontSize = 44;
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }

    private void HandleCorrectAnswer()
    {
        Debug.Log("Correct Answer");
        onCorrectAnswer.Invoke();
        StartCoroutine(SayAnswer("Correct!"));
    }

}

public static class PlayerUtils
{
    public static GameObject GetLocalPlayer()
    {
        // Find all PhotonView components in the scene
        PhotonView[] photonViews = GameObject.FindObjectsOfType<PhotonView>();

        foreach (var view in photonViews)
        {
            // Check if the PhotonView is owned by the local player
            if (view.IsMine)
            {
                // Return the GameObject that the PhotonView is attached to
                return view.gameObject;
            }
        }

        // Return null if no local player is found (should not happen if the local player is in the scene)
        return null;
    }
}

