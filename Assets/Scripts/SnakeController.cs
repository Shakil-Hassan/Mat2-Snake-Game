using System.Collections.Generic;
using UnityEngine;


public class SnakeController : MonoBehaviour
{
    [Header("Screen Wrapping")]
    public float top;
    public float bottom;
    public float left;
    public float right;

    Vector2 direction;
    Vector2 moveVector;
    public GameObject body;
    public GameObject newBody;
    List<GameObject> bodies = new List<GameObject>();
    
    public SnakeScoreController score;//Creating object of Snake Score Controller
    
    public GameOverController gameOverController;
    public int scoreValue;

    //Movement
    bool vertical = false;
    bool horizontal = true;

    
    public void Eaten()
    {
        //Debug.Log("Snake ate the food");
        score.IncreaseScore(scoreValue);
        //finalScore.IncreaseScore(scoreValue);
    }

    void Start()
    {
        
        reset();
    }

    void reset()
    {
        //position, direction, time
        transform.position = new Vector2(0, -35);
        direction = Vector2.up;
        Time.timeScale = 0.2f;
        resetBody();

    }

    void resetBody()
    {
        //Destroy bodies
        for (int i = 1; i < bodies.Count; i++)
        {
            Destroy(bodies[i].gameObject);
        }
        bodies.Clear(); //Clear List
        bodies.Add(gameObject);//add head

        //put the initial bodies on top of the head
        for (int i = 0; i < 3; i++)
        {
            grow();
        }
    }

    void grow()
    {
        newBody = Instantiate(body);
        
        newBody.transform.position = bodies[bodies.Count - 1].transform.position;
        bodies.Add(newBody);

        
    }


    //Remove section
    public void RemoveBodyPart()
    {

        Destroy(bodies[bodies.Count - 1]);
        bodies.RemoveAt(bodies.Count - 1);
    }  

    void Update()
    {
        ScreenWrap();
        moveSnakeOnUserInput();
    }

    void ScreenWrap()
    {

        //newBody.transform.position = transform.position;
        Vector3 snakePosition = transform.position;
        if (transform.position.y > top)
        {
            snakePosition.y = bottom;
        }
        else if (transform.position.y < bottom)
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
        
        if (Input.GetKey(KeyCode.RightArrow) && horizontal) {
            
            horizontal = false;
            vertical = true;
            transform.rotation = Quaternion.Euler(0, 0, -90);
            direction = Vector2.right;
        } else if (Input.GetKey(KeyCode.UpArrow) && vertical) {
            horizontal = true;
            vertical = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            direction = Vector2.up;
        } else if (Input.GetKey(KeyCode.DownArrow) && vertical) {
            horizontal = true;
            vertical = false;
            transform.rotation = Quaternion.Euler(0, 0, 180);
            direction = -Vector2.up;
        } else if (Input.GetKey(KeyCode.LeftArrow) && horizontal) {
            horizontal = false;
            vertical = true;
            transform.rotation = Quaternion.Euler(0, 0, 90);
            direction = -Vector2.right;
        }
        moveVector = direction / 3f;
    }
    void FixedUpdate()
    {
        
        moveBodies();
        moveSnakeContinuesly();
    }

    
    void moveBodies()
    {
        // put on top of the one in front
        for (int i = bodies.Count - 1; i > 0; i--)
        {
            bodies[i].transform.position = bodies[i - 1].transform.position;

        }
    }
    void moveSnakeContinuesly()
    {
        float x = transform.position.x + direction.x;
        float y = transform.position.y + direction.y;
        transform.position = new Vector2(x, y);
    }

    private void AteBody()
    {
        
        Debug.Log("Player Dead");
        Time.timeScale = 0;
        gameOverController.SnakeDied();


    }
    void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.tag == "Food")
        {
            grow();
        }
        else if(other.tag == "Body")
        {
            AteBody();
            
        }
        else if (other.tag == "PoisonFood")
        {
            RemoveBodyPart();
        }

    }

   
}