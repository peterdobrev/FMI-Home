using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationPoint : MonoBehaviour
{
    [SerializeField]
    private TeleportationPoint other;

    public bool passed = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player") return;

        if(other == null) return;
        if (other.passed) return;

        collision.gameObject.transform.position = other.transform.position;
        passed = true;
        Debug.Log("passed");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        other.passed = false;
    }

}
