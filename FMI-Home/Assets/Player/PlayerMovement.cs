using UnityEngine;
using Photon.Pun;
using UnityStandardAssets.CrossPlatformInput;
using TMPro;

public class PlayerMovement : MonoBehaviourPunCallbacks
{
    private Vector3 _direction = Vector3.zero;

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private float speed = .25f;

    [SerializeField]
    private TMP_Text usernameText;

    private PhotonView view;

    private void Awake()
    {
        view = GetComponent<PhotonView>();
    }

    private void Start()
    {
        UpdatePlayerAppearance();
    }
    private void UpdatePlayerAppearance()
    {
        if (photonView.IsMine)
        {
            // If this is the local player, set the properties from the local saved data.
            object username;
            if (PhotonNetwork.LocalPlayer.CustomProperties.TryGetValue("username", out username))
            {
                Debug.Log((string)username);
                usernameText.text = (string)username;
            }

            object skinIndex;
            if (PhotonNetwork.LocalPlayer.CustomProperties.TryGetValue("skinIndex", out skinIndex))
            {
                Debug.Log((int)skinIndex);
                _animator.SetInteger("Character", (int)skinIndex);
            }
        }
        else
        {
            // For other players, use their custom properties.
            object username;
            if (photonView.Owner.CustomProperties.TryGetValue("username", out username))
            {
                usernameText.text = (string)username;
            }

            object skinIndex;
            if (photonView.Owner.CustomProperties.TryGetValue("skinIndex", out skinIndex))
            {
                _animator.SetInteger("Character", (int)skinIndex);
            }
        }
    }



    private void Update()
    {
        if (view != null && view.IsMine)
        {
            _direction.x = Input.GetAxisRaw("Horizontal");
            _direction.y = Input.GetAxisRaw("Vertical");

            _animator.SetFloat("X", _direction.x);
            _animator.SetFloat("Y", _direction.y);
            _animator.SetBool("moving", _direction != Vector3.zero);
        }
    }

    void FixedUpdate()
    {
        transform.position += (_direction * Time.fixedDeltaTime).normalized * speed;
    }

    public override void OnPlayerPropertiesUpdate(Photon.Realtime.Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        base.OnPlayerPropertiesUpdate(targetPlayer, changedProps);

        // Check if the targetPlayer is the owner of this photonView
        if (targetPlayer == photonView.Owner)
        {
            // Update appearance if relevant properties have changed.
            // You can check for specific keys in changedProps if necessary
            UpdatePlayerAppearance();
        }
    }
}