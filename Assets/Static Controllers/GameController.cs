using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public enum GAMESTATE
    {
        PAUSED,
        RUNNING
    }

    public GAMESTATE State { get; private set; } = GAMESTATE.RUNNING;
    public GAMESTATE PreviousState { get; private set; } = GAMESTATE.PAUSED;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public event Action<GAMESTATE, GAMESTATE> OnStateChanged;
    public void SetState(GAMESTATE newState)
    {
        PreviousState = State;
        State = newState;
        OnStateChanged?.Invoke(State, PreviousState);
    }
}


