using Assets.Singletons_Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class MenuButton : MonoBehaviour {
        public GameObject MenuToggled;

        public void ButtonClicked () {
            Button thisButton = GetComponent<Button>();
            MenuManager.Instance.MenuActive (MenuToggled, thisButton);
        }
    }
}
