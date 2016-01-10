using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Unit : MonoBehaviour {

	private GameManager gameManager;

	public Text unitNameText;
	public Text unitResourceText;
	public Text unitCostText;

	public Button buyButton;

	public Resource resourceUsed;
	public Resource resourceRewarded;

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

	void Start () {
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		refreshLoad ();
		refreshText ();
	}
	
	void Update () {
		resourceRewarded.amount += totalResourcePerSecond * Time.deltaTime;
		if (buyButton.interactable) {
			if (resourceUsed.amount < cost) {
				buyButton.interactable = false;
			}
		} else {
			if (resourceUsed.amount >= cost) {
				buyButton.interactable = true;
			}
		}
	}

	string addName(string str) {
		return gameObject.name + str;
	}
	void refreshLoad() {
		amount = GameManager.GetUlong (addName("Amount"), baseAmount); 
		techLevel = GameManager.GetUlong (addName("TechLevel"), baseTechLevel);
		cost = GameManager.GetDouble (addName("Cost"), baseCost);
		resourcePerSecondPerUnit = GameManager.GetDouble (addName("ResourcePerSecondPerUnit"), baseResourcePerSecondPerUnit);
	}

	void refreshText() {
		totalResourcePerSecond = resourcePerSecondPerUnit * amount;
		unitNameText.text = unitNames [techLevel] + " - " + gameManager.numberRound (amount);
		unitResourceText.text = "/sec: " + gameManager.numberRound (totalResourcePerSecond);
		unitCostText.text = "Cost: " + gameManager.numberRound (cost);
	}

	void refreshSave() {
		GameManager.SetUlong (addName("Amount"), amount);
		GameManager.SetUlong (addName("TechLevel"), techLevel);
		GameManager.SetDouble (addName("Cost"), cost);
		GameManager.SetDouble (addName("ResourcePerSecondPerUnit"), resourcePerSecondPerUnit);
	}

	public void fullRefresh() {
		refreshText ();
		refreshSave ();
	}


	public void buyUnit() {
		resourceUsed.amount -= cost;
		amount++;
		cost *= costGrowth;
		fullRefresh ();
	}
}