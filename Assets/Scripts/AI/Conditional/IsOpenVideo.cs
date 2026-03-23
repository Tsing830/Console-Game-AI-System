using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System;

public class IsOpenVideo : Conditional
{
    public GameObject Role;
    private Animator animator;
    public SharedFloat probability;
    public override void OnStart()
    {
        animator = Role.GetComponent<Animator>();
    }

    public override TaskStatus OnUpdate()
    {
        //probability.Value =150- ScoreController.Instance.DailyAnxious - ScoreController.Instance.Concentration;
        probability.Value =100;

        System.Random rand = new System.Random();
        int i = rand.Next(100);

        if (probability.Value < i)
        {
            Debug.Log("未进入短视频");
            animator.SetBool("PlayPhone",false);

            animator.SetTrigger("getMessage");
            return TaskStatus.Success;
        }

        else
        {
            Debug.Log("进入短视频");


            animator.SetBool("PlayPhone", true);

            animator.SetTrigger("getMessage");

            return TaskStatus.Failure;
        }


    }
}
