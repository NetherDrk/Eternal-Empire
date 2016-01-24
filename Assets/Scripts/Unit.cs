using Assets.Plugins;
using Assets.Singletons_Scripts;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using Resources = Assets.Singletons_Scripts.Resources;

namespace Assets.Scripts
{
    public class Unit : MonoBehaviour {

        [Header("Game Objects")]
        public GameObject UnitButton;
        public Image UnitImage;
        public Text UnitNameText;
        public Text UnitResourceText;
        public Text UnitCostText;
        public Button BuyButton;
        public Achievement[] AchievementsUnlocked;

        [Header("Names and Sprites in each Tech Level")]
        public string[] UnitNames;
        public Sprite[] UnitSprites;
	
        [Header("Initial Values")]
        public double BaseCost;
        public float CostGrowth;
        public double ResourcePerSecondPerUnit;
        public ulong TechLevel;
        private ulong _amount;
        private double _cost;
        private double _totalResourcePerSecond;

        [UsedImplicitly]
        private void Start () {
            Load ();
            Refresh ();
        }

        [UsedImplicitly]
        private void Update () {
            Resources.Instance.AddResources (_totalResourcePerSecond * Time.deltaTime);
            BuyButton.interactable = Resources.Instance.CheckResources (_cost);
        }

        private string AddName (string str) {
            return gameObject.name + str;
        }

        public void UnitUnlock () {
            UnitButton.SetActive (true);
            Refresh ();
        }

        public void UnitUpgrade (double multiplyFactor) {
            ResourcePerSecondPerUnit *= multiplyFactor;
            Refresh ();
        }

        public void UnitTechUpgrade (double multiplyFactor) {
            TechLevel++;
            UnitImage.sprite = UnitSprites [TechLevel];
            UnitUpgrade (multiplyFactor);
        }

        private void Load () {
            _amount = PlayerPrefs2.GetUlong (AddName ("Amount"), 0); 
            UnitImage.sprite = UnitSprites [TechLevel];
        }

        private void Refresh () {
            _totalResourcePerSecond = ResourcePerSecondPerUnit * _amount;
            _cost = BaseCost * Mathf.Pow (CostGrowth, _amount);
            UnitNameText.text = UnitNames [TechLevel] + " - " + NumberSuffixes.Instance.AddSuffixes (_amount);
            UnitResourceText.text = "R/sec: " + NumberSuffixes.Instance.AddSuffixes (_totalResourcePerSecond);
            UnitCostText.text = "Cost: " + NumberSuffixes.Instance.AddSuffixes (_cost);
            foreach (Achievement achiev in AchievementsUnlocked) {
                achiev.CheckAchievement ();
            }
        }

        private void Save () {
            PlayerPrefs2.SetUlong (AddName ("Amount"), _amount);
        }

        public void BuyUnit () {
            Resources.Instance.TakeResources (_cost);
            _amount++;
            Save ();
            Refresh ();
        }

        public ulong GetAmount () {
            return _amount;
        }
    }
}