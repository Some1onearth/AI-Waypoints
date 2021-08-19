using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    //avoid static variables for now since they bring about bad habits
    [SerializeField]
    private StateMachine aiStateMachine; //by default class variables are null
    public void Wander()
    {
        aiStateMachine.state = State.Wander;
    }

    public void Stop()
    {
        aiStateMachine.state = State.Stop;
    }

    public void Flash()
    {
        aiStateMachine.state = State.Flash;
    }
}
