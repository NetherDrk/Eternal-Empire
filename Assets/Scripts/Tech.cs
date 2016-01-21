using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class Tech : MonoBehaviour {
	protected GameManager gameManager;

	[Header("Game Objects")]
	public GameObject techButton;
	public Button buyButton;
	public Tech[] techsToUnlock;
	public Tech[] techsUnlocked;

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
			techButton.GetComponent<Button> ().interactable = !upgradeBought;
		}
		if (upgradeBought) {
			Upgrade ();
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
		for (int i = 0; i < techsToUnlock.Length; i++) {
			if (!techsToUnlock [i].upgradeBought) {
				upgradesToUnlockBought = false;
			}
		}
		if (upgradesToUnlockBought) {
			techButton.SetActive (true);
		}
		return upgradesToUnlockBought;
	}

	public void buyTech() {
		Upgrade ();
		gameManager.resourcesAmount -= cost;
		upgradeBought = true;
		techButton.GetComponent<Button> ().interactable = !upgradeBought;
		for (int i = 0; i < techsUnlocked.Length; i++) {
			techsUnlocked [i].checkUnlock ();
		}
		PlayerPrefs2.SetBool (addName("Bought"), upgradeBought);
	}

	public abstract void Upgrade ();
}
