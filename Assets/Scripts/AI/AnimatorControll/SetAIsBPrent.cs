using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class SetAIsBParent : Action
{
    public GameObject A;
    public GameObject B;


    public override TaskStatus OnUpdate()
    {
        B.transform.parent = A.transform;
        return TaskStatus.Success;
    }
}
