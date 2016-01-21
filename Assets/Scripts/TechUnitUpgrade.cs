using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TechUnitUpgrade : Tech {

	[Header("Unit Upgrade")]
	public Unit unitUpgraded;
	public double multiplyFactor;

	public override void Upgrade() {
		unitUpgraded.unitUpgrade (multiplyFactor);
	}
}
