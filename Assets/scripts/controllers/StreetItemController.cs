using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetItemController: MonoBehaviour {
	[SerializeField] private GameData GameDataRef;

	[SerializeField] private string ID;
	[SerializeField] private StreetItem.InteractionType InteractionType;

	private void Start() {
		GameDataRef.AddStreetItem(ID, InteractionType);
	}

	public void ChagneInRange(bool InRange) {
		GameDataRef.ChagneInRange(ID, InRange);
	}
}
