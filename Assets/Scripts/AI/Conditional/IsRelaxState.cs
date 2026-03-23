using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;

public class IsRelaxState : Conditional
{
    public override TaskStatus OnUpdate()
    {
        if (ScoreController.Instance.state1 == 0)
            return TaskStatus.Success;
        else
            return TaskStatus.Failure;
    }
}
