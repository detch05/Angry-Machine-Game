using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class KeypadInput : MonoBehaviour
{
    public TMP_Text displayText;

    public GameObject uiPanel;

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
            displayText.text = "Enter the code.";

            // Deactivate previous object
            if (currentCodeIndex < objectsToDeactivate.Length)
                objectsToDeactivate[currentCodeIndex].SetActive(false);

            // Activate current object
            if (currentCodeIndex < objectsToActivate.Length)
                objectsToActivate[currentCodeIndex].SetActive(true);

            // Fecha o painel ao acertar o código
            if (uiPanel != null)
            {
                uiPanel.SetActive(false);
                GameState.isAnyScreenOpen = false;

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            

            currentCodeIndex++;

            if (currentCodeIndex == 3)
            {
                StartCoroutine(LoadSceneAfterDelay(3f));
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true; // Start the coroutine to wait and load the scene
            }
        }
        else
        {
            displayText.text = "Wrong, find the clues!";
        }

        currentInput = "";
    }

    private IEnumerator LoadSceneAfterDelay(float delay)

    {

        yield return new WaitForSeconds(delay); // Wait for the specified time

        SceneManager.LoadSceneAsync(3); // Load the next scene

    }
}
