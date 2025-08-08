
using UnityEngine;
using UnityEngine.SceneManagement;
public class Authors : MonoBehaviour
{


    public void GotoMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}