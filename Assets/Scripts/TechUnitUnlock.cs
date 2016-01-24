namespace Assets.Scripts
{
    public class TechUnitUnlock : Tech {

        public Unit UnitUnlocked;

        public override void Upgrade () {
            UnitUnlocked.UnitUnlock ();
        }
    }
}
