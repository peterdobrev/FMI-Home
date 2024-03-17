using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; } // Singleton instance
    public AudioClip[] songs; // Array to hold your songs
    public AudioClip buttonClick;
    public float delayBetweenSongs = 2.0f; // Delay in seconds between songs
    private AudioSource audioSource;
    private AudioSource audioSource2 = null;

    void Awake()
    {
        // Check if instance already exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Makes the object persistent across scenes
        }
        else if (Instance != this)
        {
            Destroy(gameObject); // Destroys duplicates
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource2 = gameObject.GetComponentInChildren<AudioSource>();
        StartCoroutine(PlaySongsWithDelay());
    }

    IEnumerator PlaySongsWithDelay()
    {
        // Initial delay before the first song
        yield return new WaitForSeconds(delayBetweenSongs);

        foreach (var song in songs)
        {
            audioSource.clip = song;
            audioSource.Play();

            // Wait for the song to finish and the delay before playing the next one
            yield return new WaitForSeconds(audioSource.clip.length + delayBetweenSongs);
        }
    }

    public void PlayButtonSound()
    {
        audioSource.clip = buttonClick;

        audioSource.Play();
    }
}
