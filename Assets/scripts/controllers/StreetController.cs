using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetController: MonoBehaviour {

	[SerializeField] private GameData GameDataRef;
	[SerializeField] private List<GameObject> StreetsPrefabs = new List<GameObject>();
	[SerializeField] private List<GameObject> ActiveStreets = new List<GameObject>();
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
		if (GameDataRef.IsStreetFixed()) {
			NextStreet();
		}
	}
	private void NextStreet() {
		GameDataRef.ResetGameData();
		ActiveStreets.Add(Instantiate(StreetsPrefabs[Random.Range(0, StreetsPrefabs.Count)], new Vector3(8.3f, -0.3f, 0), Quaternion.identity));
		StartCoroutine(MoveStreets());

	}

	private IEnumerator MoveStreets() {
		bool streetsShouldMove = true;
		while (streetsShouldMove) {
			foreach (var street in ActiveStreets) {
				street.transform.position = new Vector3(street.transform.position.x - .1f, street.transform.position.y, 0);
				streetsShouldMove = street.transform.position != new Vector3(-0.1f, -0.3f, 0);
			}
			yield return null;
		}
		if (ActiveStreets.Count > 1) {
			Destroy(ActiveStreets[0]);
			ActiveStreets.RemoveAt(0);
		}
		yield break;
	}
}
