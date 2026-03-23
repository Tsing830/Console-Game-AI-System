using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;

public class IsRestartBehavior : Conditional
{
    public override TaskStatus OnUpdate()
    {
        if (ScoreController.Instance.times > 1497)
            return TaskStatus.Success;
        else
            return TaskStatus.Failure;

    }
}
