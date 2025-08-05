using UnityEngine;

public class Interactable : MonoBehaviour
{
    // Chame este método quando o jogador interagir (ex: apertar E)
    public virtual void Interact()
    {
        Debug.Log("Interagiu com: " + gameObject.name);
    }
}