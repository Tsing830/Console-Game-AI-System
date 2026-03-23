using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;

public class IsReleaseState : Conditional
{
    public override TaskStatus OnUpdate()
    {
        if (ScoreController.Instance.state1 == 2)
            return TaskStatus.Success;
        else
            return TaskStatus.Failure;
    }
}
