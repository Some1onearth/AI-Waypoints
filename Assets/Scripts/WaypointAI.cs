using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointAI : MonoBehaviour
{
    #region Notes
    /*
    //these are all variables
    //we can store data in it
    int x;                      // counting, stats, lives, health, ammo
     float y;                    //health, sliders, energy levels, stamina, mana, stats, per second, movement speed, attack speed
     string theseAreWords = "33" + "onfaosnsnlfkdwn" + "12"; //players name, display numbers,
     bool trueOrFalse;           //true or false
    */
    #endregion
    //homework: once it has reached the goal move towards a second goal
    [SerializeField] public float speed = 1f; //camelCasing
    [SerializeField] private GameObject[] goal;
    private int goalIndex = 0;
    private GameObject currentGoal;

    public bool isAIMoving = true;

    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        currentGoal = goal[goalIndex]; 
    }

    // Update is called once per frame
    void Update()
    {
        if(isAIMoving == false)
        {
            return; //exit the method early
        }
        if(target == null)
        {
            Wander(currentGoal, speed);
        }
        else
        {
            Chase(target, speed);
        }
    }
    void Chase(GameObject goal, float currentSpeed) //placing the variables makes it transferable.
    {
        //finds the direction to goal (to the circle)
        Vector2 direction = (goal.transform.position - transform.position).normalized;

        Vector2 position = transform.position;
        //moves ai towards the direction set (which was the goal)
        position += (direction * currentSpeed * Time.deltaTime);
        transform.position = position;
    }
    void Wander(GameObject goal, float currentSpeed)
    {
        //this gets the distance to the goal
        float distance = Vector2.Distance(transform.position, goal.transform.position);

        if (distance > 0.05f)
        {
            Chase(goal, currentSpeed); //passing along the floats
        }
        else
        {
            NextGoal();
        }
    }
    void NextGoal()
    {
        //Increase goalIndex by 1 (all 3 work the same)
        //goalIndex = goalIndex + 1;
        //goalIndex += 1;
        goalIndex++;


        //goal.Length = 3
        //goalIndex >= goal.Length)
        if (goalIndex > goal.Length - 1)
        {
            goalIndex = 0;
        }

        currentGoal = goal[goalIndex];
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

