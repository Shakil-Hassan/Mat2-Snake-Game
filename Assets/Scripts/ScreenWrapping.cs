
using UnityEngine;
using System.Collections;
using System;

public class ScreenWrapping : MonoBehaviour
{
    public SnakeController snakeLastBody;

    [Header("Screen Wrapping")]
    [SerializeField] float screenHeight;
    [SerializeField] float screenWidth;

    private void Update()
    {
        ScreenWrap();
    }

    private void ScreenWrap()
    {
        Vector2 snakePosition = snakeLastBody.newBody.transform.position;
        if(transform.position.y > screenHeight)
        {
            snakePosition.y = -screenHeight;
        }
        if(transform.position.y < screenHeight)
        {
            snakePosition.y = screenHeight;
        }

        transform.position = snakePosition;
    }
}