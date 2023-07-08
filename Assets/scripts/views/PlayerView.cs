using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView: MonoBehaviour {
	[SerializeField] private Rigidbody2D playerRigidBody;
	[SerializeField] private SpriteRenderer spriteRenderer;
	//[SerializeField] private Animator animator;

	private enum MovementState {
		idle, running
	}

	public void SetCrouching(bool IsCrouching) {
		if (IsCrouching) {
			spriteRenderer.color = new Color(0, 0, 255);
		} else {
			spriteRenderer.color = new Color(255, 255, 255);
		}
	}

	private void UpdateAnimation() {
		MovementState movementState = MovementState.idle;

		if (playerRigidBody.velocity.x > 0) {
			spriteRenderer.flipX = false;
			movementState = MovementState.running;
		} else if (playerRigidBody.velocity.x < 0) {
			spriteRenderer.flipX = true;
			movementState = MovementState.running;
		} else if (playerRigidBody.velocity.y > 0) {
			movementState = MovementState.running;
		} else if (playerRigidBody.velocity.y < 0) {
			movementState = MovementState.running;
		} else {
			movementState = MovementState.idle;
		}


		//animator.SetInteger("movement", (int)movementState);

	}
}
