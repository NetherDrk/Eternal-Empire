using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Unit : MonoBehaviour {

	private GameManager gameManager;

	public GameObject unitButton;

	public Text unitNameText;
	public Text unitResourceText;
	public Text unitCostText;

	public Button buyButton;

	public string[] unitNames;
	public Image[] unitImages;

	public ulong baseAmount;
	public ulong baseTechLevel;
	public double baseCost;
	public double costGrowth;
	public double baseResourcePerSecondPerUnit;

	[HideInInspector]
	public ulong amount;
	[HideInInspector]
	public ulong techLevel;
	[HideInInspector]
	public double cost;
	[HideInInspector]
	public double resourcePerSecondPerUnit;
	[HideInInspector]
	public double totalResourcePerSecond;
	[HideInInspector]
	public bool unitUnlocked;

	void Start () {
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		refreshLoad ();
		refreshText ();
	}
	
	void Update () {
		gameManager.resourcesAmount += totalResourcePerSecond * Time.deltaTime;
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

	public void unitUnlock() {
		unitUnlocked = true;
		unitButton.SetActive (unitUnlocked);
		fullRefresh ();
	}

	public void unitUpgrade(double multiplyFactor) {
		resourcePerSecondPerUnit *= multiplyFactor;
		fullRefresh ();
	}

	public void unitTechUpgrade(double multiplyFactor) {
		techLevel++;
		unitUpgrade (multiplyFactor);
	}

	void refreshLoad() {
		amount = PlayerPrefs2.GetUlong (addName("Amount"), baseAmount); 
		techLevel = PlayerPrefs2.GetUlong (addName("TechLevel"), baseTechLevel);
		cost = PlayerPrefs2.GetDouble (addName("Cost"), baseCost);
		resourcePerSecondPerUnit = PlayerPrefs2.GetDouble (addName("ResourcePerSecondPerUnit"), baseResourcePerSecondPerUnit);
		unitUnlocked = PlayerPrefs2.GetBool (addName ("Unlocked"), false);
		unitButton.SetActive (unitUnlocked);
	}

	void refreshText() {
		totalResourcePerSecond = resourcePerSecondPerUnit * amount;
		unitNameText.text = unitNames [techLevel] + " - " + gameManager.numberRound (amount);
		unitResourceText.text = "R/sec: " + gameManager.numberRound (totalResourcePerSecond);
		unitCostText.text = "Cost: " + gameManager.numberRound (cost);
	}

	void refreshSave() {
		PlayerPrefs2.SetUlong (addName("Amount"), amount);
		PlayerPrefs2.SetUlong (addName("TechLevel"), techLevel);
		PlayerPrefs2.SetDouble (addName("Cost"), cost);
		PlayerPrefs2.SetDouble (addName("ResourcePerSecondPerUnit"), resourcePerSecondPerUnit);
		PlayerPrefs2.SetBool (addName ("Unlocked"), unitUnlocked);
	}

	public void fullRefresh() {
		refreshText ();
		refreshSave ();
	}


	public void buyUnit() {
		gameManager.resourcesAmount -= cost;
		amount++;
		cost *= costGrowth;
		fullRefresh ();
	}
}