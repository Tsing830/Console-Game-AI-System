using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;

public class IsCloseVideo : Conditional
{

    public override TaskStatus OnUpdate()
    {
        if (ScoreController.Instance.isOpenVideo ==true)
        {
            if (ScoreController.Instance.joy < 0 || ScoreController.Instance.DailyAnxious > 80)
            {
                ScoreController.Instance.isCloseVideo = true;

                Debug.Log("退出短视频");
                return TaskStatus.Failure;
            }

            else
            {
                Debug.Log("未退出短视频");
                return TaskStatus.Success;
            }
        }
        else
            return TaskStatus.Success;




    }
}
