using NUnit.Framework.Internal.Execution;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    private void Update()
    {
        // Check for mouse button click
        if (Input.GetMouseButtonDown(0)) // 0 is the left mouse button
        {
            GoToMainMenu();
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}