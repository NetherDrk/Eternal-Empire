using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	[Header ("Tutorial GameObjects")]
	public GameObject insertEmpireName;

	[Header ("GameObjects for TechLevels")]
	public Text empireNameText;
	public Text  ageText;
	public Image ageImage;
	[Header ("Names and Sprites for each tech level")]
	public string[] empireNameSuffixes;
	public string[] ageNames;
	public Sprite[] ageSprites;
	[HideInInspector]
	public string empireName;
	[HideInInspector]
	public ulong techLevel = 0;

	[Header("Resources")]
	public double resourcesBaseAmount;
	public Text resourcesAmountText;

	[HideInInspector]
	public double resourcesAmount;

	[Header("Number Suffixes")]
	public string[] suffixes;
	public bool scientificNotation;

	[Header("Menu Tabs")]
	public GameObject[] menus;
	public Button[] buttons;

	// Refresh

	void Start() {
		refreshLoad ();
		refreshResourcesText ();
		refreshAgeText ();
	}

	void LateUpdate() {
		refreshResourcesText ();
		refreshResourcesSave ();	
	}

	void refreshLoad() {
		resourcesAmount = PlayerPrefs2.GetDouble ("resourcesAmount", resourcesBaseAmount);
		if (PlayerPrefs.HasKey ("empireName")) {
			empireName = PlayerPrefs.GetString ("empireName");
			Destroy (insertEmpireName);
		} else {
			empireName = " \"Your Empire Name\" ";
			tutorialStarted ();
		}

	}

	void refreshAgeText() {
		empireNameText.text = empireName + " " + empireNameSuffixes [techLevel];
		ageText.text = ageNames [techLevel];
		ageImage.sprite = ageSprites [techLevel];
	}

	void refreshResourcesText() {
		resourcesAmountText.text = numberRound (resourcesAmount);
	}

	void refreshResourcesSave() {
		PlayerPrefs2.SetDouble ("resourcesAmount", resourcesAmount);
	}

	// Tutorial

	public void tutorialStarted() {
		insertEmpireName.SetActive (true);
	}

	public void nameChoosed() {
		empireName = insertEmpireName.GetComponent<InputField>().text;
		PlayerPrefs.SetString ("empireName", empireName);
		empireNameText.text = empireName + " " + empireNameSuffixes [techLevel];
		Destroy (insertEmpireName);
	}


	// Tech Unlock Upgrade
	public void techUnlock() {
		techLevel++;
		refreshAgeText();
	}

	// Tabs Control

	public void menuActive(GameObject menuClicked, Button buttonClicked) {
		for (int i = 0; i < menus.Length; i++) {
			menus [i].SetActive (false);
			buttons[i].interactable = true;
		}
		menuClicked.SetActive (true);
		buttonClicked.interactable = false;

	}

	// Suffixes Function
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
