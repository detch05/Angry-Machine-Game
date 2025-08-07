using UnityEngine;
using UnityEngine.InputSystem;

public class Interactable1: MonoBehaviour
{
    public GameObject uiPanel; // Assign your UI Panel in the Inspector
    private bool isPanelOpen = false;

    // Chame este método quando o jogador interagir (ex: apertar E)
    public virtual void IntPC1()
    {
        Debug.Log("Interagiu com: " + gameObject.name);
        if (uiPanel != null)
        {
            uiPanel.SetActive(true);
            isPanelOpen = true;     
        }
    }

    void Update()
    {
        if (isPanelOpen && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (uiPanel != null)
            {
                uiPanel.SetActive(false);
                isPanelOpen = false;
            }
        }
    }
}