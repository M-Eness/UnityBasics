using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public CharacterData[] characters;  
    public Transform spawnPoint; 

    void Start()
    {
        int index = PlayerPrefs.GetInt("SelectedCharacter", 0); // Seçili karakteri al
        Instantiate(characters[index].characterPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}