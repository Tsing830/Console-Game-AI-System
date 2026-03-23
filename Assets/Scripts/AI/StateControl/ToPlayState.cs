using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class ToPlayState : Action
{
    public override void OnStart()
    {

        ScoreController.Instance.isOpenVideo = true;
    }
}
