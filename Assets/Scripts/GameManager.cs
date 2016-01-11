using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager manager;

	public double resourcesBaseAmount;
	public Text resourcesAmountText;

	[HideInInspector]
	public double resourcesAmount;

	public string[] suffixes;

	public bool scientificNotation;

	public GameObject[] menus;
	public Button[] buttons;

	// Refresh

	void Start() {
		refreshLoad ();
		refreshText ();
	}

	void LateUpdate() {
		refreshText ();
		refreshSave ();	
	}

	void refreshLoad() {
		resourcesAmount = PlayerPrefs2.GetDouble ("resourcesAmount", resourcesBaseAmount);
	}

	void refreshText() {
		resourcesAmountText.text = numberRound (resourcesAmount);
	}

	void refreshSave() {
		PlayerPrefs2.SetDouble ("resourcesAmount", resourcesAmount);
	}

	// 

	public void techUnlock(ulong techLevel) {

	}

	// Controle do Menu

	public void menuActive(GameObject menuClicked, Button buttonClicked) {
		for (int i = 0; i < menus.Length; i++) {
			menus [i].SetActive (false);
			buttons[i].interactable = true;
		}
		menuClicked.SetActive (true);
		buttonClicked.interactable = false;

	}

	// Funções Genericas
	public string numberRound(double number) {
		if (number < 1000) {
			return number.ToString ("N0");
		}
		else {
			if (scientificNotation) {
				return number.ToString ("E3");
			} else {
				double newNumber = number;
				int i = 0;
				while (newNumber >= 1000) {
					newNumber /= 1000;
					i++;
				}
				if (i >= suffixes.Length) {
					return number.ToString ("E3");
				} else {
					return newNumber.ToString ("N2") + " " + suffixes [i];
				}
			}
		}
	}
}
