using Assets.Plugins;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Singletons_Scripts
{
    public class Resets : Singleton<Resets> {

        public GameObject ConfirmHardResetObject;
        public GameObject ConfirmSoftResetObject;

        [UsedImplicitly]
        private void Start () {
            Time.timeScale = 1;
        }

        public void ConfirmHardReset () {
            ConfirmHardResetObject.SetActive (!ConfirmHardResetObject.activeSelf);
            ConfirmSoftResetObject.SetActive (false);
        }

        public void ConfirmSoftReset () {
            ConfirmSoftResetObject.SetActive (!ConfirmSoftResetObject.activeSelf);
            ConfirmHardResetObject.SetActive (false);
        }

        public void HardReset () {
            Time.timeScale = 0;
            PlayerPrefs.DeleteAll ();
            SceneManager.LoadScene ("MainScene");
        }

        public void SoftReset () {
            Time.timeScale = 0;
            PlayerPrefs.DeleteAll ();
            EmpireTechLevel.Instance.Save ();
            SceneManager.LoadScene ("MainScene");
        }
    }
}
