using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class IsMessageIn : Conditional
{
    public SharedGameObject button;


    public override TaskStatus OnUpdate()
    {
        if (ScoreController.Instance.sendaNews)
        {

            ScoreController.Instance.sendaNews = false;
            return TaskStatus.Success;

        }
        else
            return TaskStatus.Failure;
    }
}
