using System.Linq;
using Assets.Plugins;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using Resources = Assets.Singletons_Scripts.Resources;

namespace Assets.Scripts
{
    public abstract class Tech : MonoBehaviour {
        [Header("Game Objects")]
        public GameObject TechButton;
        public Button BuyButton;
        public Tech[] TechsToUnlock;
        public Tech[] TechsUnlocked;

        [Header ("Upgrade Cost")]
        public double Cost;

        private bool _bought;

        [UsedImplicitly]
        private void Awake () {
            _bought = PlayerPrefs2.GetBool (AddName ("Bought"), false);
        }

        [UsedImplicitly]
        private void Start () {
            if (CheckUnlock ()) {
                TechButton.GetComponent<Button> ().interactable = !_bought;
            }
            if (_bought) {
                Upgrade ();
            }
        }

        [UsedImplicitly]
        private void Update () {
            BuyButton.interactable = !_bought && Resources.Instance.CheckResources (Cost);
        }

        private string AddName (string str) {
            return gameObject.name + str;
        }

        public bool CheckUnlock () {
            var upgradesToUnlockBought = !TechsToUnlock.Any(tech => tech.WasntBought());
            TechButton.SetActive (upgradesToUnlockBought);
            return upgradesToUnlockBought;
        }

        public void BuyTech () {
            Upgrade ();
            Resources.Instance.TakeResources (Cost);
            _bought = true;
            TechButton.GetComponent<Button> ().interactable = !_bought;
            foreach (var tech in TechsUnlocked) {
                tech.CheckUnlock ();
            }
            PlayerPrefs2.SetBool (AddName ("Bought"), _bought);
        }

        public abstract void Upgrade ();

        public bool WasntBought ()
        {
            return !_bought;
        }
    }
}
