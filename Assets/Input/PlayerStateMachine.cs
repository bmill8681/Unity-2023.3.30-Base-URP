using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{

    public PlayerState State { get; private set; }

    public void Initialize(PlayerState startingState)
    {
        State = startingState;
        State.EnterState();
    }

    public void ChangeState(PlayerState newState)
    {
        State.ExitState();
        State = newState;
        State.EnterState();
    }
}
