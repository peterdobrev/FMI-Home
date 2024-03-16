using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CustomizePlayer : MonoBehaviour
{
    [SerializeField]
    TMP_InputField username;

    [SerializeField]
    List<Sprite> visuals = new List<Sprite>();

    [SerializeField]
    Image profilePicture;

    private int currentSprite = 0;

    private void Awake()
    {
        if (visuals.Count > 0)
            ApplySprite();
    }

    private void ApplySprite()
    {
        profilePicture.sprite = visuals[currentSprite];
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

    string GetUsername()
    {
        return username.text;
    }
}
