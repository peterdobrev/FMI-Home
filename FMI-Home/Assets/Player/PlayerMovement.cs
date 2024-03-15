using System;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // private Vector3 _direction;
    private Vector3 _direction = Vector3.zero;

    [SerializeField]
    private float speed = .25f;

    private void Update()
    {
        _direction.x = Input.GetAxisRaw("Horizontal");
        _direction.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        transform.position += (_direction * Time.deltaTime).normalized * speed;
    }
}