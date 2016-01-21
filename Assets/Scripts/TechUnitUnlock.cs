using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TechUnitUnlock : Tech {

	[Header("Unit Unlock")]
	public Unit unitUnlocked;

	public override void Upgrade() {
		unitUnlocked.unitUnlock ();
	}
}
