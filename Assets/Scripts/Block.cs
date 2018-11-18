using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{
    
    [SerializeField] AudioClip breakSound;
    Level level;
    GameSession gamestatus;
    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBreakAbleBlocks();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        FindObjectOfType<GameSession>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlocksDestroyed();
        
        
    }
}
