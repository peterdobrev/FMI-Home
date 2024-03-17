using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void LoadSelection()
    {
        PhotonNetwork.LoadLevel("selectPlayer");
    }
}
