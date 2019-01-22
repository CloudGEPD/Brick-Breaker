using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Block : MonoBehaviour
{
    //Configuration parameters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprite;

    //cached references
    Level level;
    GameSession gamestatus;

    //debug purposes
    [SerializeField] int timesHit;

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprite.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprite[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprite[spriteIndex];
        }

        else
        {
            Debug.LogError("Block sprite is missing from array " + gameObject.name);
        }
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
