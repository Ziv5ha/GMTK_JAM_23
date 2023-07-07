using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView: MonoBehaviour {
	[SerializeField] private Rigidbody2D playerRigidBody;
	[SerializeField] private SpriteRenderer spriteRenderer;
	//[SerializeField] private Animator animator;

	private enum MovementState {
		idle, running//, jumping, falling, doubleJump
	}

	private void UpdateAnimation() {
		MovementState movementState = MovementState.idle;

		if (playerRigidBody.velocity.x > 0) {
			spriteRenderer.flipX = false;
			movementState = MovementState.running;
		} else if (playerRigidBody.velocity.x < 0) {
			spriteRenderer.flipX = true;
			movementState = MovementState.running;
		} else {
			movementState = MovementState.idle;
		}

		//if (playerRigidBody.velocity.y > .1f && !CanDoubleJump) {
		//	movementState = MovementState.doubleJump;
		//} else if (playerRigidBody.velocity.y > .1f && CanDoubleJump) {
		//	movementState = MovementState.jumping;
		//} else if (playerRigidBody.velocity.y < -.1f) {
		//	movementState = MovementState.falling;
		//}

		//animator.SetInteger("movement", (int)movementState);

	}
}
