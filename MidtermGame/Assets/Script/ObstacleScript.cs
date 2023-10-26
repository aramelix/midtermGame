using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    //variables 
    public BoxCollider2D grid; 
 

    // Start is called before the first frame update
    void Start()
    {
        RandomPos(); //randomize the position 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RandomPos()
    {
        Bounds bounds = grid.bounds;  //declaring the limits of the space 

        float x = Random.Range(bounds.min.x, bounds.max.x);  //give random value to x within the limit 
        float y = Random.Range(bounds.min.y, bounds.min.y);  //give random value to y within the limit 

        transform.position = new Vector2(Mathf.Round(x), Mathf.Round(y)); 
        // ^Tells the obstacles to spawn in a location where Player and obstacle line up every time 
    }
}
