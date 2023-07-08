using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetItem {
	public enum InteractionType { Punch, Kick, CrouchPunch, CrouchKick }

	public int ID { get; }
	public InteractionType StreetItemInteractionType { get; }
	public bool IsFixed { get; set; }
	public bool InRange { get; set; }

	public StreetItem(int id, InteractionType interaction) {
		ID = id;
		StreetItemInteractionType = interaction;
	}
}