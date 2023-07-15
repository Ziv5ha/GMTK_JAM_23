using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetController: MonoBehaviour {

	[SerializeField] private GameData GameDataRef;
	[SerializeField] private List<GameObject> StreetsPrefabs = new List<GameObject>();
	[SerializeField] private List<GameObject> ActiveStreets = new List<GameObject>();
	[SerializeField] private Dictionary<int, StreetItemController> StreetItemsByID = new Dictionary<int, StreetItemController>();

	private float _startTime;
	[SerializeField] private float _animationDuration;

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
		_startTime = Time.time;
		StartCoroutine(MoveStreets());

	}

	private IEnumerator MoveStreets() {
        float delta = (Time.time - _startTime) / _animationDuration;
		while (delta < 1) {
			ActiveStreets[0].transform.position = Vector3.Lerp(new Vector3(-0.1f, -0.3f, 0), new Vector3(-8.4f, -0.3f, 0), delta);
			ActiveStreets[1].transform.position = Vector3.Lerp(new Vector3(8.3f, -0.3f, 0), new Vector3(-0.1f, -0.3f, 0), delta);
			delta = (Time.time - _startTime) / _animationDuration;
			yield return null;
		}
		if (ActiveStreets.Count > 1) {
			Destroy(ActiveStreets[0]);
			ActiveStreets.RemoveAt(0);
		}
		yield break;
	}
}
