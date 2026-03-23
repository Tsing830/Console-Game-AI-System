using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;


public class ToWalk: Action
{
    public GameObject Role;
    private Animator animator;
    public override void OnStart()
    {
        animator=Role.GetComponent<Animator>();
    }
    public override TaskStatus OnUpdate()
    {
        animator.SetBool("Opendoor", false);
        
        animator.SetBool("walking", true);
        return TaskStatus.Success;
    }

}
