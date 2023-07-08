using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView: MonoBehaviour {
	[SerializeField] private Rigidbody2D playerRigidBody;
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private Animator animator;
	[SerializeField] private PlayerController PlayerControllerRef;

	private enum MovementState {
		idle, running, crouch
	}
	private void Update() {
		UpdateAnimation();
	}
	private void UpdateAnimation()
    {
        MovementState movementState = GetAnimationState();
		if(animator.GetInteger("movement") != (int)movementState){

		Debug.Log(movementState);
		}
        animator.SetInteger("movement", (int)movementState);

    }

	public void TriggerPunch(){
		animator.SetTrigger("punch");
	}
    private MovementState GetAnimationState()
    {
		if (PlayerControllerRef.IsCrouching){
			return MovementState.crouch;
		}
        if (playerRigidBody.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
            return MovementState.running;
        }
        else if (playerRigidBody.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
            return MovementState.running;
        }
        else if (playerRigidBody.velocity.y > 0)
        {
            return MovementState.running;
        }
        else if (playerRigidBody.velocity.y < 0)
        {
            return MovementState.running;
        }
        return MovementState.idle ;
    }
}
