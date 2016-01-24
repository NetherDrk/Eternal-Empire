using Assets.Plugins;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Singletons_Scripts
{
    public class MenuManager : Singleton<MenuManager> {

        public GameObject[] Menus;
        public Button[] Buttons;

        public void MenuActive (GameObject menuClicked, Button buttonClicked) {
            for (int i = 0; i < Menus.Length; i++) {
                Menus [i].SetActive (false);
                Buttons[i].interactable = true;
            }
            menuClicked.SetActive (true);
            buttonClicked.interactable = false;
        }
    }
}
