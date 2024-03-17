using System;
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
using UnityEngine.Networking;
using System.Text;
using System.Collections.Specialized;
using System.Net.Http;

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

    public void GetRequest()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{URI}/{username.text}/{facultyNumber.text}");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
        {
            string json = reader.ReadToEnd();
            string wrappedJson = "{\"data\":" + json + "}";

            PlayerDataArray playerDataArray = JsonUtility.FromJson<PlayerDataArray>(wrappedJson);

            if (playerDataArray.data.Count <= 0)
            {
                try
                {
                    HttpWebRequest postRequest = (HttpWebRequest)WebRequest.Create(URI);
                    postRequest.Method = "POST";
                    postRequest.ContentType = "application/json";

                    string jsonData = $@"{{
                    ""playerName"": ""{username.text}"",
                    ""facultyNumber"": ""{facultyNumber.text}"",
                    ""points"": ""0""
                }}";

                    using (StreamWriter postWriter = new StreamWriter(postRequest.GetRequestStream()))
                        postWriter.Write(jsonData);

                    using (HttpWebResponse postResponse = (HttpWebResponse)postRequest.GetResponse())
                    {
                        if (postResponse.StatusCode == HttpStatusCode.OK ||
                            postResponse.StatusCode == HttpStatusCode.Created)
                            EnterLoading();
                    }
                }
                catch (Exception ex)
                {
                    Debug.LogError("Error sending POST request: " + ex.Message);
                }
            }
        }

        if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created)
            EnterLoading();
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
}
