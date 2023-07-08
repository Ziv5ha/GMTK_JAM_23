using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData: MonoBehaviour {

	private List<StreetItem> _streetItems = new List<StreetItem>();

	public bool IsStreetFixed() {
		bool streetFixed = true;
		foreach (var streetItem in _streetItems) {
			if (streetItem.IsFixed == false) streetFixed = false;
		}
		return streetFixed;
	}

	public void AddStreetItem(string ID, StreetItem.InteractionType interationType) {
		_streetItems.Add(new StreetItem(ID, interationType));
	}

	public string FixStreetItem(StreetItem.InteractionType interationType) {
		string itemFixed = "-1";
		foreach (var streetItem in _streetItems) {
			if (streetItem.StreetItemInteractionType == interationType && streetItem.InRange) {
				streetItem.IsFixed = true;
				itemFixed = streetItem.ID;
			}
		}
		return itemFixed;
	}

	public void ChagneInRange(string ID, bool InRange) {
		foreach (var streetItem in _streetItems) {
			if (streetItem.ID == ID) streetItem.InRange = InRange;
		}
	}

}
