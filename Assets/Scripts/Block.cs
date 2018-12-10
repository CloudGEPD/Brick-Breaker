using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{
    
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
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
        PlayBlockDestroyedSFX();
        Destroy(gameObject);
        TriggerParticles();
        level.BlocksDestroyed();

    }

    private void PlayBlockDestroyedSFX()
    {
        FindObjectOfType<GameSession>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerParticles()
    {
        if (tag == "Breakable")
        {
            GameObject sparkes = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
            Destroy(sparkes, 1f);
        }
    }
}
