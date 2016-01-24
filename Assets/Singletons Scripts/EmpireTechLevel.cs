using Assets.Plugins;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Singletons_Scripts
{
    public class EmpireTechLevel : Singleton<EmpireTechLevel> {

        [Header("Game Objects")]
        public Text EmpireNameText;
        public Text  AgeText;
        public Image AgeImage;
        public Image MapImage;

        [Header("Names and Sprites in each Tech Level")]
        public string[] EmpireNameSuffixes;
        public string[] AgeNames;
        public Sprite[] AgeSprites;
        public Sprite[] MapSprites;

        private string _empireName;
        private ulong _techLevel;


        // Use this for initialization
        [UsedImplicitly]
        private void Start () {
            Load ();
            Refresh ();
        }

        public void Load () {
            if (PlayerPrefs.HasKey ("empireName")) {
                _empireName = PlayerPrefs.GetString ("empireName");
            } else {
                _empireName = "\"Your Empire Name\"";
                NameChoose.Instance.FirstChoose();
            }
        }

        public void Save () {
            PlayerPrefs.SetString ("empireName", _empireName);
        }

        public void RefreshName () {
            EmpireNameText.text = _empireName + " " + EmpireNameSuffixes [_techLevel];
        }

        private void Refresh () {
            RefreshName ();
            AgeText.text = AgeNames [_techLevel];
            AgeImage.sprite = AgeSprites [_techLevel];
            MapImage.sprite = MapSprites [_techLevel];
        }

        public void TechUnlock () {
            _techLevel++;
            Refresh ();
        }

        public void SetName (string empireName) {
            _empireName = empireName;
            Save ();
            RefreshName ();
        }

        public string GetName () {
            return _empireName;
        }
    }
}
