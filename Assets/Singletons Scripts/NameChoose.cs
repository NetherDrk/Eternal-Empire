using Assets.Plugins;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Singletons_Scripts
{
    public class NameChoose : Singleton<NameChoose> {

        public GameObject InsertEmpireName;
        private bool _firstChoose;

        public void ChooseName () {
            InsertEmpireName.SetActive (true);
            InsertEmpireName.GetComponent<InputField> ().text = EmpireTechLevel.Instance.GetName ();
        }

        public void NameChoosed () {
            EmpireTechLevel.Instance.SetName (InsertEmpireName.GetComponent<InputField>().text);
            InsertEmpireName.SetActive (false);
            if (!_firstChoose) return;
            GameObject.Find("TechMenuButton").GetComponent<MenuButton>().ButtonClicked();
            _firstChoose = false;
        }

        public void FirstChoose()
        {
            _firstChoose = true;
            ChooseName ();
        }
    }
}
