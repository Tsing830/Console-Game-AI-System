using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class SetPlayPhoneAndGet : Action
{
    public GameObject Role;
    private Animator animator;
    public override void OnStart()
    {
        animator = Role.GetComponent<Animator>();
    }
    public override TaskStatus OnUpdate()
    {

        animator.SetBool("PlayPhone", true);
        animator.SetTrigger("getMessage");
        return TaskStatus.Success;
    }

}
