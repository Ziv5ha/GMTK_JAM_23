using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData: MonoBehaviour {

	private List<StreetItem> _streetItems = new List<StreetItem>();
	[SerializeField] private StreetController StreetControllerRef;

	public bool IsStreetFixed() {
		bool streetFixed = true;
		foreach (var streetItem in _streetItems) {
			if (streetItem.IsFixed == false) streetFixed = false;
		}
		return streetFixed;
	}

	public void AddStreetItem(int ID, StreetItem.InteractionType interationType) {
		_streetItems.Add(new StreetItem(ID, interationType));
	}

	public void FixStreetItem(StreetItem.InteractionType interationType) {
		int itemFixed = 0;
		foreach (var streetItem in _streetItems) {
			if (streetItem.StreetItemInteractionType == interationType && streetItem.InRange) {
				streetItem.IsFixed = true;
				itemFixed = streetItem.ID;
			}
		}
		if (itemFixed != 0) {
			StreetControllerRef.FixStreetItem(itemFixed);
		}
	}

	public void ChagneInRange(int ID, bool InRange) {
		foreach (var streetItem in _streetItems) {
			if (streetItem.ID == ID) streetItem.InRange = InRange;
		}
	}

}
