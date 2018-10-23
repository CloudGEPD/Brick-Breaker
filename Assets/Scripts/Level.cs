using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Level : MonoBehaviour 
{
    [SerializeField] int breakableBlocks; //serialized for debugging purposes.
                                          // Use this for initialization
    SceneLoader sceneloader;

    public void Start()
    {
    sceneloader = FindObjectOfType<SceneLoader>();
    }

    public void CountBreakAbleBlocks()
    {
        breakableBlocks++;
    }

    public void BlocksDestroyed()
    {
        breakableBlocks--;

        if (breakableBlocks <= 0)
        {
            sceneloader.LoadNextScene();

        }
    }
}
