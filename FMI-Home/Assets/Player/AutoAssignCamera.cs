using UnityEngine;
using Cinemachine;
using Photon.Pun;

public class AutoAssignCamera : MonoBehaviourPunCallbacks
{
    public CinemachineVirtualCamera virtualCamera;

    void Start()
    {
        virtualCamera = GameObject.FindGameObjectWithTag("VirtualCamera").GetComponent<CinemachineVirtualCamera>();

        // Check if this is the local player's GameObject
        if (virtualCamera != null && photonView.IsMine)
        {
            virtualCamera.gameObject.SetActive(true);

            // Set the follow target of the Cinemachine Virtual Camera to this player
            virtualCamera.Follow = transform;
        }
    }
}
