using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointAI : MonoBehaviour
{
    /*
     //these are all variables
     //we can store data in it
     int x;                      // counting, stats, lives, health, ammo
     float y;                    //health, sliders, energy levels, stamina, mana, stats, per second, movement speed, attack speed
     string theseAreWords = "33" + "onfaosnsnlfkdwn" + "12"; //players name, display numbers,
     bool trueOrFalse;           //true or false
    */

    //homework: once it has reached the goal move towards a second goal
    [SerializeField] private float speed = 1f; //camelCasing
    [SerializeField] private GameObject goal;
    [SerializeField] private GameObject goal1;
    [SerializeField] private GameObject goal2;
    [SerializeField] private float distanceCutoff;
    //float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        goal = goal1;
        distanceCutoff = 0.01f;
        speed = 5.0f;
         
    }

    // Update is called once per frame
    void Update()
    {
        //this gets the distance to the goal
        float distance = Vector2.Distance(transform.position, goal.transform.position);

        if(distance > distanceCutoff)

        {
            //finds the direction to goal (to the circle)
            Vector2 direction = (goal.transform.position - transform.position).normalized;
            Vector2 position = transform.position;
            //moves ai towards the direction set (which was the goal)
            position += (direction * speed * Time.deltaTime);
            transform.position = position;
        }
        else
        {
            goal = goal2;
        }
    }
}

//Explain later

/*
//position.x =+ speed; <-- this is the shortcut for position.x = position.x
//save for later: movement

change private float speed to: 0f
speedY = 0f;
speedX = 0f;
if (Input.GetKey(KeyCode.W))
{
    speedY = 1f;
}

if (Input.GetKey(KeyCode.S))
{
    speedY = -1f;
}
if (Input.GetKey(KeyCode.A))
{
    speedX = -1f;
}
if (Input.GetKey(KeyCode.D))
{
    speedX = 1f;
}
*/

//if we want to get a direction from A to B
// direction = B - A
//direction = direction.normalized
//direction.Normalize();

//if(X == y) is X equal to Y
// !=       no equal
// <        less than
// >        greater than
// <=       less than or equal
// >= greater than or equal

