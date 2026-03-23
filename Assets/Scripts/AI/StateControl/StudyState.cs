using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class StudyState : Action
{
    public override void OnStart()
    {
        ScoreController.Instance.state1 = 1;
    }
}
