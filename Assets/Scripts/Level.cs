using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour 
{
    [SerializeField] int breakableBlocks; //serialized for debugging purposes.
	// Use this for initialization
	public void CountBreakAbleBlocks()
    {
        breakableBlocks++;
    }
}
