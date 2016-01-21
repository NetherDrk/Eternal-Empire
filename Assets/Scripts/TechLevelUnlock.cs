using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TechLevelUnlock : Tech {

	public override void  Upgrade() {
		gameManager.techUnlock ();
	}
}
