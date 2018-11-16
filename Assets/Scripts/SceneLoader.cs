using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] SceneAsset sceneAsset;
    public void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }

    public void LoadSpecificScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().ResetGame();
    }
    
    public void LoadSceneByDrag()
    {
        SceneManager.LoadScene(sceneAsset.name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
      
