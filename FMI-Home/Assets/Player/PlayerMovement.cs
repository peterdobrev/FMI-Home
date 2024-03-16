using UnityEngine;
using Photon.Pun;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 _direction = Vector3.zero;

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private float speed = .25f;

    private PhotonView view;

    private void Start()
    {
        // InitializeComponents();
        view = GetComponent<PhotonView>();

        _animator.SetInteger("Character", CustomizePlayer.currentSprite);
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
}