using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public List<GameObject> characterPrefabs;
    private int selectedCharacterIndex = 0;
    private int currentCharacter;
    public GameObject nicknameScreen;

    void Start()
    {
        foreach (var character in characterPrefabs)
        {
            character.gameObject.SetActive(false);
        }
        ShowSelectedCharacter();
    }

    public void SelectNextCharacter()
    {
        Debug.Log("Entre al Next");
        currentCharacter = selectedCharacterIndex;
        selectedCharacterIndex++;
        if (selectedCharacterIndex >= characterPrefabs.Count)
        {
            selectedCharacterIndex = 0;
        }
        ShowSelectedCharacter();
    }

    public void SelectPreviousCharacter()
    {
        Debug.Log("Entre al Previous");
        currentCharacter = selectedCharacterIndex;
        selectedCharacterIndex--;
        if (selectedCharacterIndex < 0)
        {
            selectedCharacterIndex = characterPrefabs.Count - 1;
        }
        ShowSelectedCharacter();
    }

    void ShowSelectedCharacter()
    {
        // Aquí puedes implementar la lógica para mostrar el personaje seleccionado en la UI.
     //   Debug.Log(currentCharacter);
        Debug.Log("Selected character: " + characterPrefabs[selectedCharacterIndex].name);
        characterPrefabs[currentCharacter].gameObject.SetActive(false);
        characterPrefabs[selectedCharacterIndex].gameObject.SetActive(true);
    }

    public void DisableCharactersActive()
    {
        Debug.Log("ENTRE");
        foreach (var character in characterPrefabs)
        {
            DestroyImmediate(character);
        }
    }
    public void ConfirmSelection()
    {
        Debug.Log("CONFIRMSELECTION INDEX: " + selectedCharacterIndex);
        PlayerPrefs.SetInt("SelectedCharacterIndex", selectedCharacterIndex);
        DisableCharactersActive();
        nicknameScreen.SetActive(true);
    }
}