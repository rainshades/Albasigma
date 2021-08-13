using UnityEngine;
using Albasigma.ARPG;

public class ClimbUpBehaviour : StateMachineBehaviour
{
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var player = animator.GetComponentInParent<PlayerMovement>();
        player.ClimbUpFromLedge(); 
    }
}