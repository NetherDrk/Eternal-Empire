using Assets.Singletons_Scripts;

namespace Assets.Scripts
{
    public class TechEmpireLevelUnlock : Tech {

        public override void  Upgrade () {
            EmpireTechLevel.Instance.TechUnlock ();
        }
    }
}
