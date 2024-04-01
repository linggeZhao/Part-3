using UnityEngine;
using TMPro; 

public class CharacterController : MonoBehaviour
{
    public TMP_Dropdown dropdown; // Drop-down menu button component
    public GameObject[] characters; // Array of character game objects
    static Character characterSelected;

    private void Start()
    {
        // Activate selected character at the beginning of the game...
        ActivateCharacter(dropdown.value);
    }

    public void OnDropdownValueChanged(int value)
    {
        // Change to update moveable character
        ActivateCharacter(value);
    }

    private void ActivateCharacter(int index)
    {
        if (characterSelected != null)
        {
            characterSelected.Selected(false);
        }
        characterSelected = characters[index].GetComponent<Character>();
        characterSelected.Selected(true);
    }
}