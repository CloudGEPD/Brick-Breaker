using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
                     
    [SerializeField] float screenWidth = 16f;


    private void Update()
    {
       float mousePosition = Input.mousePosition.x / Screen.width * screenWidth;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePosition, minX, maxX);
        transform.position = paddlePos;
    }
}
