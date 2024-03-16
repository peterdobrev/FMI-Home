using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Voice.Unity.UtilityScripts;

public class ConnectVoice : MonoBehaviourPunCallbacks
{
    private void OnConnectedToServer()
    {
        GetComponent<ConnectAndJoin>().ConnectNow();
    }
}
