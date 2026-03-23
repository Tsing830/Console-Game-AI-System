using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class ChairMove : Action
{
    public GameObject Role;
    private Animator animator;
    public override void OnStart()
    {
        animator = Role.GetComponent<Animator>();
    }
    public override TaskStatus OnUpdate()
    {
        animator.SetTrigger("sitting");
        return TaskStatus.Success;

    }
}
