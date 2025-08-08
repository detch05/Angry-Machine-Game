using UnityEngine;
using UnityEngine.InputSystem; // New Input System namespace

public class Interactable : MonoBehaviour
{
    public GameObject uiPanel;  // assign in inspector
    public static bool isUIOpen = false;

    public virtual void Interact()
    {
        Debug.Log("Interacted with: " + gameObject.name);

        if (uiPanel != null)
        {
            GameState.isAnyScreenOpen = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            uiPanel.SetActive(true);
            isUIOpen = true;
        }
    }

    void Update()
    {
        // Use the new Input System to detect ESC
        if (isUIOpen && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            GameState.isAnyScreenOpen = false;
            
            uiPanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isUIOpen = false;
        }
    }
}

