using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClickCounter : MonoBehaviour
{
    public TMP_Text counterText;
    private int counter = 0;

    public void IncrementCounter()
    {
        counter++;
        counterText.text = counter.ToString();
    }
    
}
