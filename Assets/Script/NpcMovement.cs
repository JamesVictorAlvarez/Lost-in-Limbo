using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcMovement : MonoBehaviour
{
    public NavMeshAgent ai;
    public Transform character;
    public Animator animator;
    Vector3 dest;

    void Update()
    {
        dest = character.position;
        ai.destination = dest;
        Debug.Log(dest);
        
        if(ai.remainingDistance <= ai.stoppingDistance)
        {
            animator.ResetTrigger("walking");
            animator.SetTrigger("idle");
        }
        else
        {
            animator.ResetTrigger("idle");
            animator.SetTrigger("walking");
        }
    }
}
