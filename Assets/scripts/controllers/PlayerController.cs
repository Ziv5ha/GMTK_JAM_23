using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController: MonoBehaviour {
	[SerializeField] private Rigidbody2D playerRigidBody;
	[SerializeField] private PlayerView PlayerViewRef;
	//[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private GameData GameDataRef;

	private bool _isCrouching;
	public bool IsCrouching {
		get {
			return _isCrouching;
		}
	}

	[Header("Physics")]
	[SerializeField] private float speed = 3.5f;


	void Update() {
	}

	public void Move(InputAction.CallbackContext context) {
		Vector2 inputVector = context.ReadValue<Vector2>();
		float x = inputVector.x;
		// check if x == 0 so as not to set the flipX when no button pressed
		if(x!=0){
			this.GetComponent<SpriteRenderer>().flipX = x<0 ;
		}
		if(IsCrouching){
			return;
		}
		playerRigidBody.velocity = new Vector2(inputVector.x, inputVector.y) * speed;
	}

	public void Crouch(InputAction.CallbackContext context) {
		_isCrouching = context.performed;
		//if (context.performed) {
		//	Debug.Log($"Crouch! performed: {IsCrouching}");
		//} else if (context.canceled) {
		//	Debug.Log($"Crouch! cancelled: {IsCrouching}");
		//}
	}
	public void Punch(InputAction.CallbackContext context) {
		// call view punch.
		if (context.performed) {
			GameDataRef.FixStreetItem(
				IsCrouching
				? StreetItem.InteractionType.CrouchPunch
				: StreetItem.InteractionType.Punch
			);
			PlayerViewRef.TriggerPunch();
		}
	}
	public void Kick(InputAction.CallbackContext context) {
		// call view kick.
		if (context.performed) {
			GameDataRef.FixStreetItem(IsCrouching
				? StreetItem.InteractionType.CrouchKick
				: StreetItem.InteractionType.Kick);
			PlayerViewRef.TriggerKick();
		}

	}
}