using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelector : MonoBehaviour
{
    public GameObject[] characterObjects; // Sahnedeki karakter GameObject'leri
    private int currentIndex = 0;

    void Start()
    {
        UpdateCharacterVisibility();
    }

    public void NextCharacter()
    {
        currentIndex = (currentIndex + 1) % characterObjects.Length;
        UpdateCharacterVisibility();
    }

    public void PreviousCharacter()
    {
        currentIndex = (currentIndex - 1 + characterObjects.Length) % characterObjects.Length;
        UpdateCharacterVisibility();
    }

    void UpdateCharacterVisibility()
    {
        for (int i = 0; i < characterObjects.Length; i++)
        {
            characterObjects[i].SetActive(i == currentIndex);
        }
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("SelectedCharacter", currentIndex);
        SceneManager.LoadScene(2);
    }
}