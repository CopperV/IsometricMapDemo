using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviour : StateMachineBehaviour
{
    [SerializeField]
    private int AmountOfIdleStates;

    private int NextState = 0;

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NextState = Random.Range(0, AmountOfIdleStates);
        animator.SetFloat("IdleAnimTree", NextState);
    }
}
