using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
                     
    [SerializeField] float screenWidth = 16f;

    //cached references
    GameSession theGameSession;
    Ball theBall;

    private void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
    }


    private void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if(theGameSession.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidth;
        }

    }

    /* void MyScript()
    {
        //Vector2 charPosition;
        if (Input.GetKeyDown(KeyCode.D))
        {
            
            Vector2 pogoPosition = new Vector2(transform.position.x, transform.position.y);
            transform.position = pogoPosition;
        }

        else if (Input.GetKeyDown(KeyCode.A))
        {
            Vector2 pogoPosition = new Vector2(transform.position.x, transform.position.y);
            transform.position = pogoPosition;
        }
        
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Vector2 pogoPosition = new Vector2(transform.position.x, transform.position.y);
            transform.position = pogoPosition;
        }
    }
    */
}
