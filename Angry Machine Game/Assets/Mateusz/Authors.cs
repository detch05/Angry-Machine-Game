using UnityEngine;
using UnityEngine.SceneManagement;

public class Authors : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Find the AudioSource component on the BackgroundMusic GameObject
        audioSource = FindObjectOfType<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play(); // Start playing the music
        }
    }

    public void GotoMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
