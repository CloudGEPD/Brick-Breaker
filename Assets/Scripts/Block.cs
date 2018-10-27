using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    Level level;
    GameStatus gamestatus;
    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBreakAbleBlocks();
        gamestatus = FindObjectOfType<GameStatus>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlocksDestroyed();
        gamestatus.AddToScore();
        
    }
}
