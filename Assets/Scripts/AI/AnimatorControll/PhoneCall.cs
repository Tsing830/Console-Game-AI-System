using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class PhoneCall : Action
{
    public GameObject Role;
    private Animator animator;
    public override void OnStart()
    {
        animator = Role.GetComponent<Animator>();
    }
    public override TaskStatus OnUpdate()
    {
        animator.SetTrigger("message");
        return TaskStatus.Success;
    }
}
