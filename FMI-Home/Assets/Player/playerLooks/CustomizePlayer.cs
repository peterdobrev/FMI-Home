using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CustomizePlayer : MonoBehaviour
{
    [SerializeField]
    TMP_InputField username;

    [SerializeField]
    List<Sprite> visuals = new List<Sprite>();

    [SerializeField]
    Image profilePicture;

    public static int currentSprite = 0;
    public static string _username;

    private void Awake()
    {
        if (visuals.Count > 0)
            ApplySprite();
    }

    private void ApplySprite()
    {
        profilePicture.sprite = visuals[currentSprite];
        profilePicture.GetComponent<RectTransform>().sizeDelta = visuals[currentSprite].bounds.size.normalized * 125;
    }

    public void nextSprite()
    {
        currentSprite++;
        if (currentSprite == visuals.Count)
            currentSprite = 0;
        ApplySprite();
    }

    public void prevSprite()
    {
        currentSprite--;
        if (currentSprite < 0)
            currentSprite = visuals.Count - 1;
        ApplySprite();
    }

    public void EnterLoading()
    {
        _username = username.text;
        SceneManager.LoadScene("Loading");
    }
}
