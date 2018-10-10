using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] SceneAsset asset;
    public void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }

    public void LoadSpecificScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    
    public void LoadSceneByDrag()
    {
        SceneManager.LoadScene(asset.name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
      
