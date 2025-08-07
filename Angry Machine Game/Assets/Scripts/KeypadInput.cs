using TMPro;
using UnityEngine;

public class KeypadInput : MonoBehaviour
{
    public TMP_Text displayText;

    private string currentInput = "";
    private int currentCodeIndex = 0;

    // The codes in order
    private string[] correctCodes = { "4211", "9921", "9205" };

    // Objects that appear for each correct code
    public GameObject[] objectsToActivate;    // PlantCup, MoneyCup, CoffeeCup
    public GameObject[] objectsToDeactivate;  // Crayon, PlantCup, MoneyCup

    public void OnNumberButtonClick(string number)
    {
        if (currentInput.Length < 4)
        {
            currentInput += number;
            displayText.text = currentInput;
        }
    }

    public void OnClearButtonClick()
    {
        currentInput = "";
        displayText.text = "";
    }

    public void OnSubmitButtonClick()
    {
        if (currentCodeIndex >= correctCodes.Length)
        {
            displayText.text = "All codes entered!";
            return;
        }

        if (currentInput == correctCodes[currentCodeIndex])
        {
            displayText.text = "Correct!";

            // Deactivate previous object
            if (currentCodeIndex < objectsToDeactivate.Length)
                objectsToDeactivate[currentCodeIndex].SetActive(false);

            // Activate current object
            if (currentCodeIndex < objectsToActivate.Length)
                objectsToActivate[currentCodeIndex].SetActive(true);

            currentCodeIndex++;
        }
        else
        {
            displayText.text = "Wrong, find the clues!";
        }

        currentInput = "";
    }
}
