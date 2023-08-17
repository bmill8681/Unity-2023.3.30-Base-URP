using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine playerStateMachine;


    public virtual void EnterState() { }
    public virtual void ExitState() { }
    public virtual void UpdateState() { }
    public virtual void FixedUpdateState() { }
    public virtual void AnimationTriggerEvent() { }
}
