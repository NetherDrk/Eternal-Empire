using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TechUnitTechUpgrade : Tech {

	[Header("Unit Upgrade")]
	public Unit unitUpgraded;
	public double multiplyFactor;

	public override void Upgrade() {
		unitUpgraded.unitTechUpgrade (multiplyFactor);
	}
}
