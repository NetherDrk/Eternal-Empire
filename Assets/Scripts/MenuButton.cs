using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuButton : MonoBehaviour {
	public GameObject menuToggled;

	public void buttonClicked() {
		GameManager gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
		Button thisButton = GetComponent<Button>();
		gameManager.menuActive (menuToggled, thisButton);
	}
}
