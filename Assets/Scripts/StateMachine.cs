using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Wander,
    Stop,
    Flash,
    Chase,
}
public class StateMachine : MonoBehaviour
{
    #region Variables
    public State state;
    public float chaseDistance = 5f;

    private SpriteRenderer sprite = null;
    private WaypointAI waypointAI = null;// null is not necessary as it usually starts off null

    private GameObject player;
    #endregion
    private IEnumerator WanderState()
    {
        Debug.Log("Wander: Enter");
        sprite.color = Color.green;
        waypointAI.isAIMoving = true;

        while (state == State.Wander)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);

            if (distance < chaseDistance && player.activeSelf == true) // && both sides have to be true
            {
                state = State.Chase;
            }
            yield return null; //come back the next frame
        }
        Debug.Log("Wander: Exit");
        NextState();
    }

    private IEnumerator StopState()
    {

        float startTime = Time.time;
        float waitTime = 3f;

        Debug.Log("Stop: Enter");
        sprite.color = Color.red;
        waypointAI.isAIMoving = false;

        while (state == State.Stop)
        {
            float distance = Vector2.Distance(transform.position, player.transform.position);

            if(Time.time > startTime + waitTime)
            {
                state = State.Wander;
            }
            else if (distance < chaseDistance)
            {
                state = State.Chase;
            }
            yield return null; //Wait for seconds waits and then the next line activates
        }
        waypointAI.isAIMoving = true;
        Debug.Log("Stop: Exit");
        NextState();
    }

    private IEnumerator FlashState()
    {
        Debug.Log("Stop: Enter");
        //change the alpha and 
        sprite.color = Color.cyan;
        while (state == State.Flash)
        {
            waypointAI.isAIMoving = true;
            yield return null; //come back the next frame

            sprite.color = Color.white;
            yield return new WaitForSeconds(0.1f);
            sprite.color = Color.cyan;
            yield return new WaitForSeconds(0.1f);
        }
        Debug.Log("Stop: Exit");
        NextState();
    }

    private IEnumerator ChaseState()
    {
        //0 - 1              //R    G    B   Alpha/Transparency
        Debug.Log("Chase: Enter");
        sprite.color = new Color(0.7f, 0, 1, 1);
        while (state == State.Chase)
        {
            waypointAI.target = player;

            float distance = Vector2.Distance(transform.position, player.transform.position);

            if (distance < waypointAI.speed *Time.deltaTime) // && both sides have to be true
            {
                player.SetActive(false);
                state = State.Wander;
            }

            if(distance > chaseDistance)//leaves the player alone after the distance further than chaseDistance (5f)
            {
                state = State.Stop;
            }
            
            yield return null; //come back the next frame
        }

        waypointAI.target = null;
        Debug.Log("Stop: Exit");
        NextState();
    }

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        if(sprite == null)
        {
            Debug.LogError("Hey me, sprite is null, there is no SpriteRenderer on this object");
        }

        waypointAI = GetComponent<WaypointAI>();
        if(waypointAI == null)
        {
            Debug.LogError("Hey me, Waypoint is null, there is no SpriteRenderer on this object");
        }

        Player playerFound = FindObjectOfType<Player>(); //FindObjectofType might not tbe the best choice to use. Not recommended.
        if(playerFound !=null)
        {
            player = playerFound.gameObject;
        }

        NextState();
    }

    private void NextState()
    {
        //like if statements but in a more readable manner.
        //grabbing the state string, and comparing to the cases.
        switch (state)
        {
            case State.Wander:
                StartCoroutine(WanderState());
                break;
            case State.Stop:
                StartCoroutine(StopState());
                break;
            case State.Flash:
                StartCoroutine(FlashState());
                break;
            case State.Chase:
                StartCoroutine(ChaseState());
                break;
            default:
                StartCoroutine(StopState());
                break;

        }
    }
}
