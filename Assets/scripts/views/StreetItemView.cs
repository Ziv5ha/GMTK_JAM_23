using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetItemView: MonoBehaviour {

	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private List<Sprite> Sprites;
	[SerializeField] private Sprite FixedSprite;
	[SerializeField] private BoxCollider2D boxCollider2;
	//[SerializeField] private bool _isPickableTrash;

	[SerializeField] private StreetItemController StreetItemControllerRef; //theoriticy should be an action/event and not function call but hey. We have 24 hours.

	private void OnTriggerEnter2D(Collider2D col) {
		StreetItemControllerRef.ChagneInRange(true);
		//Debug.Log("enter " + col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
	}
	private void OnTriggerExit2D(Collider2D col) {
		StreetItemControllerRef.ChagneInRange(false);
		//Debug.Log("exit " + col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
	}

	private void Start() {
		if (Sprites.Count > 0) {
			spriteRenderer.sprite = Sprites[Random.Range(0, Sprites.Count - 1)];
		}
	}

	public void FixStreetItem() {
		//if (_isPickableTrash) {
		//spriteRenderer.sprite = null;
		//} else {
		spriteRenderer.sprite = FixedSprite;
		//}
		//spriteRenderer.color = new Color(0, 255, 0);
	}
}
