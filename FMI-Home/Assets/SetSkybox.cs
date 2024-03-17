using UnityEngine;

public class SetSkybox : MonoBehaviour
{
    // Reference to the camera
    public Camera cameraToChange;

    // Function to change the camera's clear color to black
    public void ChangeClearColorToBlack()
    {
        if (cameraToChange != null)
        {
            cameraToChange.backgroundColor = Color.black;
        }
    }

    // Function to change the camera's clear color to sky blue
    public void ChangeClearColorToSkyBlue()
    {
        if (cameraToChange != null)
        {
            cameraToChange.backgroundColor = new Color(0.529f, 0.808f, 0.922f); // Sky blue color
        }
    }

    // If you want these to run on start for testing
    void Start()
    {
        ChangeClearColorToBlack(); // To set the clear color to black on start
        // ChangeClearColorToSkyBlue(); // To set the clear color to sky blue on start
    }
}
