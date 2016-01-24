using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Achievement : MonoBehaviour {

        public Unit UnitToAchiev;
        public Button AchievementButton;
        public ulong AmountToAchiev;
        public double MultiplyFactor;
        private bool _achieved;

        public void CheckAchievement () {
            if (_achieved || UnitToAchiev.GetAmount() < AmountToAchiev) return;
            _achieved = true;
            UnitToAchiev.UnitUpgrade (MultiplyFactor);
            AchievementButton.interactable = _achieved;
        }
    }
}