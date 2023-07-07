using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController: MonoBehaviour {
	[SerializeField] private Rigidbody2D playerRigidBody;
	[SerializeField] private SpriteRenderer spriteRenderer;
	//[SerializeField] private Animator animator;
	[SerializeField]
	private InputActionReference Movement;//, Crouch, Punch, Kick;

	private enum MovementState {
		idle, running//, jumping, falling, doubleJump
	}

	public bool IsCrouching;

	[Header("Physics")]
	[SerializeField] private float speed = 7f;


	void Update() {
		//if (playerRigidBody.bodyType != RigidbodyType2D.Static) {
		Move();
		if (IsCrouching) {
			spriteRenderer.color = new Color(0, 0, 255);
		} else {
			spriteRenderer.color = new Color(255, 255, 255);
		}
		//UpdateAnimation();
		//}
	}

	private void Move() {
		Vector2 inputVector = Movement.action.ReadValue<Vector2>();
		playerRigidBody.velocity = new Vector2(inputVector.x, inputVector.y) * speed;
	}
	public void Crouch(InputAction.CallbackContext context) {
		IsCrouching = context.performed;
		if (context.performed) {
			Debug.Log($"Crouch! performed: {IsCrouching}");
		}
	}
	public void Punch(InputAction.CallbackContext context) {
		// call view punch.
		if (context.performed) {
			if (IsCrouching) {
				Debug.Log($"!@# Crouch Punch!");
			} else {
				Debug.Log("Punch!");
			}
		}
	}
	public void Kick(InputAction.CallbackContext context) {
		// call view kick.
		if (context.performed) {
			if (IsCrouching) {
				Debug.Log($"!@# Crouch Kick!");
			} else {
				Debug.Log("Kick!");
			}
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

	//public void JumpHandler(InputAction.CallbackContext context) {
	//	if (playerRigidBody.bodyType != RigidbodyType2D.Static) {
	//		if (CanJump()) {
	//			Jump();
	//		}
	//	}
	//}

	//private void Jump() {
	//	playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
	//}

	//private bool CanJump() {
	//	return (playerRigidBody.velocity.y > -.1f && playerRigidBody.velocity.y < .1f);
	//}
	//private void CheckDoubleJump() {
	//	if (CanJump()) {
	//		CanDoubleJump = true;
	//	}
	//}
}