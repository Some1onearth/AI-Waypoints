using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Wander,
    Stop,
    Flash
}
public class StateMachine : MonoBehaviour
{
    [SerializeField] private State state;

    private SpriteRenderer sprite = null;
    private WaypointAI waypointAI = null;
    private IEnumerator WanderState()
    {
        Debug.Log("Wander: Enter");
        sprite.color = Color.green;
        while (state == State.Wander)
        {
            waypointAI.isAIMoving = true; //you can enter code here to make it move
            yield return null; //come back the next frame
        }
        Debug.Log("Wander: Exit");
        NextState();
    }

    private IEnumerator StopState()
    {
        Debug.Log("Stop: Enter");
        sprite.color = Color.red;
        while (state == State.Stop)
        {
            waypointAI.isAIMoving = false;
            yield return null; //come back the next frame
        }
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
        }
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
            default:
                StartCoroutine(StopState());
                break;

        }
    }
}
