using System;
using Unity.Mathematics;
using Unity.Netcode;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    private Vector3 _direction = Vector3.zero;

    [SerializeField]
    private float speed = 1f;

    private void Update()
    {
        if(IsOwner)
        {
            _direction.x = Input.GetAxisRaw("Horizontal");
            _direction.y = Input.GetAxisRaw("Vertical");
        }
    }

    void FixedUpdate()
    {
        transform.position += (_direction * Time.deltaTime ).normalized * speed;
    }
}