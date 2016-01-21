using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
	[HideInInspector]
	public bool inTutorial = false;

	[Header("Resources")]
	public double resourcesBaseAmount;
	public Text resourcesAmountText;

	[HideInInspector]
	public double resourcesAmount;
	[HideInInspector]
	public double resourcesCollected;

	[Header("Number Suffixes")]
	public string[] suffixes;
	public bool scientificNotation;

	[Header("Statistics GameObjects")]
	public Text resourcesCollectedText;

	[Header("Settings GameObjects")]
	public GameObject confirmHardReset;

	[Header("Menu Tabs")]
	public GameObject[] menus;
	public Button[] buttons;

	// Refresh

	void Start() {
		refreshLoad ();
		refreshResourcesText ();
		refreshAgeText ();
		Time.timeScale = 1;
	}

	void LateUpdate() {
		refreshResourcesText ();
		if (Time.timeScale != 0) {
			refreshResourcesSave ();
			PlayerPrefs.Save ();
		}
	}

	void refreshLoad() {
		resourcesAmount = PlayerPrefs2.GetDouble ("resourcesAmount", resourcesBaseAmount);
		resourcesCollected = PlayerPrefs2.GetDouble ("resourcesCollected", resourcesAmount);
		if (PlayerPrefs.HasKey ("empireName")) {
			empireName = PlayerPrefs.GetString ("empireName");
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
		PlayerPrefs2.SetDouble ("resourcesCollected", resourcesCollected);
	}

	// Tutorial

	public void tutorialStarted() {
		inTutorial = true;
		insertEmpireName.SetActive (true);
	}

	public void chooseName() {
		insertEmpireName.SetActive (true);
		if (!inTutorial) {
			insertEmpireName.GetComponent<InputField> ().text = empireName;
		}
	}

	public void nameChoosed() {
		empireName = insertEmpireName.GetComponent<InputField>().text;
		PlayerPrefs.SetString ("empireName", empireName);
		empireNameText.text = empireName + " " + empireNameSuffixes [techLevel];
		insertEmpireName.SetActive (false);
		if (inTutorial) {
			finishTutorial ();
		}
	}

	public void finishTutorial() {
		inTutorial = false;
	}

	// Resets
	public void confirmReset() {
		confirmHardReset.SetActive (true);
	}

	public void cancelReset() {
		confirmHardReset.SetActive (false);
	}

	public void hardReset() {
		Time.timeScale = 0;
		PlayerPrefs.DeleteAll ();
		SceneManager.LoadScene ("MainScene");
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
