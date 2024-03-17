using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class TriggerAnimation : MonoBehaviour
{
    // Reference to the Animator component
    private Animator animator;
    int collisionsCounter = 0;
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
            collisionsCounter++;
        }
    }

    // Method called when another collider exits the trigger collider
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check if the collider belongs to the player
        if (collision.CompareTag("Player"))
        {
            // Set the Close trigger to start the closing animation
                collisionsCounter--;
        }
    }

    public void Update()
    {
        if(collisionsCounter > 0)
        {
            animator.SetBool("IsOpen", true);
        }
        else
        {
            animator.SetBool("IsOpen", false);
        }
    }
}
