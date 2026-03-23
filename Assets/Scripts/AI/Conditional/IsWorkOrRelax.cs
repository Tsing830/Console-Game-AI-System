using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;

public class IsWorkOrRelax : Conditional
{
    public SharedFloat probability;

    public override TaskStatus OnUpdate()
    {
        probability.Value = ScoreController.Instance.maxConcentration + ScoreController.Instance.DailyAnxious;

        System.Random rand=new System.Random();
        int i = rand.Next(100);

        if (probability.Value > i)
        {

            return TaskStatus.Success;
        }

        else
        {

            return TaskStatus.Failure;
        }

    
    }
}
