using UnityEngine;

public class TeleportationPoint : MonoBehaviour
{
    [SerializeField]
    private TeleportationPoint other;

    [SerializeField]
    private Vector3 spawnOffset = Vector2.zero;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);

        if (collision.gameObject.tag != "Player") return;

        if (other == null) return;

        collision.gameObject.transform.position = other.transform.position + spawnOffset;
    }

}
