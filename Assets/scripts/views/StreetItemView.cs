using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetItemView: MonoBehaviour {

	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private Sprite BrokenSprite;
	[SerializeField] private Sprite FixedSprite;
	[SerializeField] private BoxCollider2D boxCollider2;

	[SerializeField] private StreetItemController StreetItemControllerRef; //theoriticy should be an action/event and not function call but hey. We have 24 hours.

	private void OnTriggerEnter2D(Collider2D col) {
		StreetItemControllerRef.ChagneInRange(true);
		Debug.Log("enter " + col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
	}
	private void OnTriggerExit2D(Collider2D col) {
		StreetItemControllerRef.ChagneInRange(false);
		Debug.Log("exit " + col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
	}

	public void FixStreetItem() {
		spriteRenderer.color = new Color(0, 255, 0);
	}
}
