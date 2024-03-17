using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    // Reference to the Animator component
    private Animator animator;

    private void Start()
    {
        // Get the Animator component from the game object
        animator = GetComponent<Animator>();
    }

    // Method called when another collider enters the trigger collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collider belongs to the player
        if (collision.CompareTag("Player"))
        {
            // Set the Open trigger to start the opening animation
            animator.SetTrigger("Open");
        }
    }

    // Method called when another collider exits the trigger collider
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check if the collider belongs to the player
        if (collision.CompareTag("Player"))
        {
            // Set the Close trigger to start the closing animation
            animator.ResetTrigger("Open"); // Optional: Reset the Open trigger
            animator.SetTrigger("Close");
        }
    }
}
