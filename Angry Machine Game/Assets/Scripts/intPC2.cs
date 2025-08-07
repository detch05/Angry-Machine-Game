using UnityEngine;

public class Interactable2: MonoBehaviour
{
    public GameObject uiPanel; // Assign your UI Panel in the Inspector
    private bool isPanelOpen = false;

    // Chame este método quando o jogador interagir (ex: apertar E)
    public virtual void IntPC2()
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
        if (isPanelOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            if (uiPanel != null)
            {
                uiPanel.SetActive(false);
                isPanelOpen = false;
            }
        }
    }
}