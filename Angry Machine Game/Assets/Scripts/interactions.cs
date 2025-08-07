using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject uiPanel;  // assign in inspector if this object has a UI to open

    public virtual void Interact()
    {
        Debug.Log("Interagiu com: " + gameObject.name);

        if (uiPanel != null)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            uiPanel.SetActive(true);
        }
    }
}