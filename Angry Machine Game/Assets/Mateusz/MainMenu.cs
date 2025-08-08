using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
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

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void GotoAuthors()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}