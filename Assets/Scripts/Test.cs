using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    [Header("Screen Wrapping")]
    /*[SerializeField] float screenHeight;
    [SerializeField] float screenWidth;
*/
    public float speed;
    public float top;
    public float bottom;
    public float left;
    public float right;
    Vector2 direction;
    Vector2 moveVector;
    public GameObject body;


    void Update()
    {
        //moveSnakeOnUserInput();
        ScreenWrap();
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        MoveCharacter(horizontal, vertical);
        

        


    }

    void MoveCharacter(float horizontal, float vertical)
    {
        //horizontal
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

        //vertical
       
        
            position.y += vertical * speed * Time.deltaTime;
            transform.position = position;
        
    }

    void ScreenWrap()
    {
        
        //newBody.transform.position = transform.position;
        Vector3 snakePosition = transform.position;
        if (transform.position.y > top)
        {
            snakePosition.y = bottom;
        }
        else if (transform.position.y <bottom)
        {
            snakePosition.y = top;
        }
        else if (transform.position.x > right)
        {
            snakePosition.x = left;
        }
        else if (transform.position.x < left)
        {
            snakePosition.x = right;
        }

        transform.position = snakePosition;

    }
    void moveSnakeOnUserInput()
    {

        if (Input.GetKey(KeyCode.RightArrow) )
        {

            
            transform.rotation = Quaternion.Euler(0, 0, -90);
            direction = Vector2.right;
        }
        else if (Input.GetKey(KeyCode.UpArrow) )
        {
           
            transform.rotation = Quaternion.Euler(0, 0, 0);
            direction = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow) )
        {
           
            transform.rotation = Quaternion.Euler(0, 0, 180);
            direction = -Vector2.up;
        }
        else if (Input.GetKey(KeyCode.LeftArrow)  )
        {
            
            transform.rotation = Quaternion.Euler(0, 0, 90);
            direction = -Vector2.right;
        }
        moveVector = direction / 3f;
    }
}
