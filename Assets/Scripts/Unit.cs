using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Unit : MonoBehaviour {

	private GameManager gameManager;

	[Header("Game Objects")]
	public GameObject unitButton;
	public Image unitImage;
	public Text unitNameText;
	public Text unitResourceText;
	public Text unitCostText;
	public Button buyButton;

	[Header("Names and Sprites in each Tech Level")]
	public string[] unitNames;
	public Sprite[] unitSprites;
	
	[Header("Initial Values")]
	public double baseCost;
	public float costGrowth;
	public double resourcePerSecondPerUnit;
	public ulong techLevel;
	public ulong amount;
	public bool unitUnlocked;
	[HideInInspector]
	public double cost;
	[HideInInspector]
	public double totalResourcePerSecond;

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
		unitImage.sprite = unitSprites [techLevel];
		unitUpgrade (multiplyFactor);
	}

	void refreshLoad() {
		amount = PlayerPrefs2.GetUlong (addName("Amount"), 0); 
		unitButton.SetActive (unitUnlocked);
		unitImage.sprite = unitSprites [techLevel];
	}

	void refreshText() {
		totalResourcePerSecond = resourcePerSecondPerUnit * amount;
		cost = baseCost * Mathf.Pow (costGrowth, amount);
		unitNameText.text = unitNames [techLevel] + " - " + gameManager.numberRound (amount);
		unitResourceText.text = "R/sec: " + gameManager.numberRound (totalResourcePerSecond);
		unitCostText.text = "Cost: " + gameManager.numberRound (cost);
	}

	void refreshSave() {
		PlayerPrefs2.SetUlong (addName("Amount"), amount);
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