using NUnit.Framework.Internal.Execution;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void GotoAuthors()
    {
        SceneManager.LoadSceneAsync(3);
    }
    public void ExitGame()
    {
        Application.Quit(); 
    }
}