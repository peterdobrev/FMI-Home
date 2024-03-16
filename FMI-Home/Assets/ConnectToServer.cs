using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    private readonly RoomOptions roomOptions = new RoomOptions
    {
        IsVisible = true,
        IsOpen = true,
        MaxPlayers = 20 // Set the max players per room
    };

    // The name of the room to join. Keep this consistent across all clients.
    private string roomName = "GlobalRoom";

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined room: " + PhotonNetwork.CurrentRoom.Name);
        PhotonNetwork.LoadLevel("tilemap");//
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Failed to join room: " + message);
    }
}
