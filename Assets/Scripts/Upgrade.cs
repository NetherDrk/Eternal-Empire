using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Upgrade : MonoBehaviour {

	private GameManager gameManager;
	public enum UpgradeType {unitUnlock, unitUpgrade, unitTechUpgrade, techUnlock};

	[Header ("Type of Upgrade")]
	public UpgradeType upgradeType;
	[Header("Game Objects")]
	public GameObject upgradeButton;
	public Button buyButton;
	public Upgrade[] upgradesToUnlock;
	public Upgrade[] upgradesUnlocked;

	[Header ("If Units Upgrades or Unlock")]
	public Unit unitUpgraded;

	[Header ("If Units Upgrades(Not Unlock)")]
	public double multiplyFactor;

	[Header ("Upgrade Cost")]
	public double cost;

	[HideInInspector]
	public bool upgradeBought;

	void Awake () {
		upgradeBought = PlayerPrefs2.GetBool (addName("Bought"), false);
	}

	void Start () {
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();		
		if (checkUnlock()) {
			upgradeButton.GetComponent<Button> ().interactable = !upgradeBought;
		}
	}

	void Update () {
		if (buyButton.interactable) {
			if (gameManager.resourcesAmount < cost) {
				buyButton.interactable = false;
			}
		} else {
			if (gameManager.resourcesAmount >= cost) {
				buyButton.interactable = true;
			}
		}
	}

	string addName(string str) {
		return gameObject.name + str;
	}

	public bool checkUnlock() {
		bool upgradesToUnlockBought = true;
		for (int i = 0; i < upgradesToUnlock.Length; i++) {
			if (!upgradesToUnlock [i].upgradeBought) {
				upgradesToUnlockBought = false;
			}
		}
		if (upgradesToUnlockBought) {
			upgradeButton.SetActive (true);
		}
		return upgradesToUnlockBought;
	}

	public void buyUpgrade() {
		switch (upgradeType) {
		case UpgradeType.techUnlock:
			gameManager.techUnlock ();
			break;
		case UpgradeType.unitUnlock:
			unitUpgraded.unitUnlock ();
			break;
		case UpgradeType.unitUpgrade:
			unitUpgraded.unitUpgrade (multiplyFactor);
			break;
		case UpgradeType.unitTechUpgrade:
			unitUpgraded.unitTechUpgrade (multiplyFactor);
			break;
		}
		gameManager.resourcesAmount -= cost;
		upgradeBought = true;
		upgradeButton.GetComponent<Button> ().interactable = !upgradeBought;
		for (int i = 0; i < upgradesUnlocked.Length; i++) {
			upgradesUnlocked [i].checkUnlock ();
		}
		PlayerPrefs2.SetBool (addName("Bought"), upgradeBought);
	}
}
