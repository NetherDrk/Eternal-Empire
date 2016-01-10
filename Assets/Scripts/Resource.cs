using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Resource : MonoBehaviour {	

	private GameManager gameManager;

	public Text amountText;

	[HideInInspector]
	public double amount;

	void Start() {
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		refreshLoad ();
		refreshText ();
	}

	void LateUpdate() {
		fullRefresh ();
	}

	string addName(string str) {
		return gameObject.name + str;
	}

	void refreshLoad() {
		amount = GameManager.GetUlong (addName ("amount"), 0);
	}

	void refreshText() {
		amountText.text = gameManager.numberRound (amount);
	}

	void refreshSave() {
		GameManager.SetDouble (addName("Amount"), amount);
	}

	public void fullRefresh() {
		refreshText ();
		refreshSave ();
	}
}
