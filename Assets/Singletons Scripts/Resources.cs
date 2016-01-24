using Assets.Plugins;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Singletons_Scripts
{
    public class Resources : Singleton<Resources> {

        public double ResourcesBaseAmount;
        public Text ResourcesAmountText;
        public Text ResourcesCollectedText;
        private double _resourcesAmount;
        private double _resourcesCollected;

        [UsedImplicitly]
        private void Start () {
            Load ();
            Refresh ();
        }

        [UsedImplicitly]
        private void LateUpdate () {
            Refresh ();
            if (!(Time.timeScale > 0)) return;
            Save ();
            PlayerPrefs.Save ();
        }

        private void Load () {
            _resourcesAmount = PlayerPrefs2.GetDouble ("resourcesAmount", ResourcesBaseAmount);
            _resourcesCollected = PlayerPrefs2.GetDouble ("resourcesCollected", _resourcesAmount);
        }

        private void Refresh () {
            ResourcesAmountText.text = NumberSuffixes.Instance.AddSuffixes (_resourcesAmount);
            ResourcesCollectedText.text = NumberSuffixes.Instance.AddSuffixes (_resourcesCollected);
        }

        private void Save () {
            PlayerPrefs2.SetDouble ("resourcesAmount", _resourcesAmount);
            PlayerPrefs2.SetDouble ("resourcesCollected", _resourcesCollected);
        }

        public void AddResources (double amount) {
            _resourcesAmount += amount;
            _resourcesCollected += amount;
        }

        public void TakeResources (double amount) {
            _resourcesAmount -= amount;
        }

        public bool CheckResources (double amount) {
            return _resourcesAmount >= amount;
        }
    }
}
