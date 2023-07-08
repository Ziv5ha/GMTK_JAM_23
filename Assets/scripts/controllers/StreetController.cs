using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetController: MonoBehaviour {

	[SerializeField] private GameData GameDataRef;
	[SerializeField] private Dictionary<int, StreetItemController> StreetItemsByID = new Dictionary<int, StreetItemController>();

	public void AddStreetItem(StreetItemController streetItemController) {
		GameDataRef.AddStreetItem(streetItemController.ID, streetItemController.InteractionType);
		StreetItemsByID[streetItemController.ID] = streetItemController;
	}

	public void ChagneInRange(int ID, bool InRange) {
		GameDataRef.ChagneInRange(ID, InRange);
	}

	public void FixStreetItem(int ID) {
		StreetItemsByID[ID].FixStreetItem();
	}
}
