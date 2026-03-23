using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;


public class GetMessage : Conditional
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
        probability.Value = 120 - ScoreController.Instance.DailyAnxious - ScoreController.Instance.Concentration;

        System.Random rand = new System.Random();
        int i = rand.Next(100);




        animator.SetTrigger("getMessage");
        return TaskStatus.Success;
    }
}
