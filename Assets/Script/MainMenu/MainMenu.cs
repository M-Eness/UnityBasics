using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject panel;
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(2);
    }

    public void OpenCharacterChooser()
    {
        SceneManager.LoadSceneAsync(1);
    }
    
    public void CloseCharacterChooser()
    {
       SceneManager.LoadSceneAsync(0);
    }
}
