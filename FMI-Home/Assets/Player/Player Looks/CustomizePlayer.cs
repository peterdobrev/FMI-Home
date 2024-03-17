using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Photon.Pun;
using SimpleJSON;

public class CustomizePlayer : MonoBehaviour
{
    [SerializeField]
    TMP_InputField username;

    [SerializeField]
    TMP_InputField facultyNumber;

    [SerializeField]
    List<Sprite> visuals = new List<Sprite>();

    [SerializeField]
    Image profilePicture;

    public static int currentSprite = 0;

    private string URI = "https://fmi-home.onrender.com/api/players";

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
        var props = new ExitGames.Client.Photon.Hashtable
    {
        {"username", username.text},
        {"facultyNumber", facultyNumber.text},
        {"skinIndex", currentSprite}
    };
        PhotonNetwork.LocalPlayer.SetCustomProperties(props);

        PhotonNetwork.LoadLevel("Loading");
    }

    public void GetRequest()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{URI}/{username.text}/{facultyNumber.text}");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
        {
            string json = reader.ReadToEnd();
            string wrappedJson = "{\"data\":" + json + "}";

            PlayerDataArray playerDataArray = JsonUtility.FromJson<PlayerDataArray>(wrappedJson);

            // foreach (PlayerData playerData in playerDataArray.data)
            // {
            //     Debug.Log("ID: " + playerData._id);
            //     Debug.Log("Name: " + playerData.playerName);
            //     Debug.Log("Faculty Number: " + playerData.facultyNumber);
            //     Debug.Log("Points: " + playerData.points);
            // }
        }
    }
}
