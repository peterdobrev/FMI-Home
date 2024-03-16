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
    }

    private void Update()
    {
        if (view != null && view.IsMine)
        {
            _direction.x = Input.GetAxisRaw("Horizontal");
            _direction.y = Input.GetAxisRaw("Vertical");

            if ((_direction.x * speed) > 0) Flip(false); else Flip(true);
            // _playerAnimation.Move(_direction.x * speed);

            _animator.SetFloat("Horizontal", _direction.x);
            _animator.SetFloat("Vertical", _direction.y);
            _animator.SetFloat("Speed", _direction.sqrMagnitude);
        }
    }

    private void Flip(bool flipSprite)
    {
        Vector3 theScale = transform.localScale;
        theScale.x = flipSprite ? Mathf.Abs(theScale.x) * -1 : Mathf.Abs(theScale.x);
        transform.localScale = theScale;
    }

    void FixedUpdate()
    {
        transform.position += (_direction * Time.fixedDeltaTime).normalized * speed;
    }
}