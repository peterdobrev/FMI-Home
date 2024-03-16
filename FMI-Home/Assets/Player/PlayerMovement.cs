using System;
using Unity.Mathematics;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 _direction = Vector3.zero;

    [SerializeField]
    private float speed = .25f;

    private PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if(view != null && view.IsMine) { 
            _direction.x = Input.GetAxisRaw("Horizontal");
            _direction.y = Input.GetAxisRaw("Vertical");
        }
    }

    void FixedUpdate()
    {
        transform.position += (_direction * Time.deltaTime).normalized * speed;
    }
}