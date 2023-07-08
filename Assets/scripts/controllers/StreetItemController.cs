using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetItemController: MonoBehaviour {
	[SerializeField] private StreetItemView StreetItemViewRef;
	private StreetController StreetControllerRef;

	public int ID;
	public StreetItem.InteractionType InteractionType;

	private void Start() {
		StreetControllerRef = GameObject.FindGameObjectWithTag("Singletons").GetComponent<StreetController>();
		StreetControllerRef.AddStreetItem(this);
	}

	public void ChagneInRange(bool InRange) {
		StreetControllerRef.ChagneInRange(ID, InRange);
	}

	public void FixStreetItem() {
		StreetItemViewRef.FixStreetItem();
	}
}
