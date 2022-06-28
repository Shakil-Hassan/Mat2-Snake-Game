using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoisonFood : MonoBehaviour
{
    //Food Prefab
    public GameObject poisonFood;
    // Borders
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;
    // Start is called before the first frame update
    void Start()
    {
        spawnOnRandomPosition();
    }

    // Spawn one piece of food
    void spawnOnRandomPosition()
    {
        // x position between left & right border
        int x = (int)Random.Range(borderLeft.position.x / 2,
                                  borderRight.position.x / 2);

        // y position between top & bottom border
        int y = (int)Random.Range(borderBottom.position.y / 2,
                                  borderTop.position.y / 2);

        transform.position = new Vector2(x, y);
        /*Vector3 pos;
        pos.x = Mathf.Round(Random.Range(Bounds.minX, Bounds.maxX));
        pos.y = Mathf.Round(Random.Range(Bounds.minY, Bounds.maxY));
        pos.z = 0;
        */

        // Instantiate the food at (x, y)
        /* Instantiate(food,
                     new Vector2(x, y),
                     Quaternion.identity); // default rotation
 */
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        spawnOnRandomPosition();
        if (other.gameObject.GetComponent<SnakeController>() != null)
        {
            SnakeController snakeController = (SnakeController)other.gameObject.GetComponent<SnakeController>();
            snakeController.RemoveBodyPart();

        }
    }
}
