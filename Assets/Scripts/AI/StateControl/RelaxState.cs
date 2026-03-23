using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class RelaxState : Action
{
    public override void OnStart()
    {
        ScoreController.Instance.state1 = 0;
    }
}
