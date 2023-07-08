using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController: MonoBehaviour {
	[SerializeField] private Rigidbody2D playerRigidBody;
	[SerializeField] private PlayerView PlayerViewRef;
	//[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private GameData GameDataRef;

	public bool IsCrouching;

	[Header("Physics")]
	[SerializeField] private float speed = 7f;


	void Update() {
		PlayerViewRef.SetCrouching(IsCrouching);
	}

	public void Move(InputAction.CallbackContext context) {
		Vector2 inputVector = context.ReadValue<Vector2>();
		playerRigidBody.velocity = new Vector2(inputVector.x, inputVector.y) * speed;
	}
	public void Crouch(InputAction.CallbackContext context) {
		IsCrouching = context.performed;
		if (context.performed) {
			PlayerViewRef.SetCrouching(true);
			Debug.Log($"Crouch! performed: {IsCrouching}");
		} else if (context.canceled) {
			PlayerViewRef.SetCrouching(false);
			Debug.Log($"Crouch! cancelled: {IsCrouching}");
		}
	}
	public void Punch(InputAction.CallbackContext context) {
		// call view punch.
		if (context.performed) {
			if (IsCrouching) {
				GameDataRef.FixStreetItem(StreetItem.InteractionType.CrouchPunch);
				Debug.Log($"!@# Crouch Punch!");
			} else {
				GameDataRef.FixStreetItem(StreetItem.InteractionType.Punch);
				Debug.Log("Punch!");
			}
		}
	}
	public void Kick(InputAction.CallbackContext context) {
		// call view kick.
		if (context.performed) {
			if (IsCrouching) {
				GameDataRef.FixStreetItem(StreetItem.InteractionType.CrouchKick);
				Debug.Log($"!@# Crouch Kick!");
			} else {
				GameDataRef.FixStreetItem(StreetItem.InteractionType.Kick);
				Debug.Log("Kick!");
			}
		}
	}
}