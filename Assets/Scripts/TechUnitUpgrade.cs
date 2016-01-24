namespace Assets.Scripts
{
    public class TechUnitUpgrade : Tech {

        public Unit UnitUpgraded;
        public double MultiplyFactor;

        public override void Upgrade () {
            UnitUpgraded.UnitUpgrade (MultiplyFactor);
        }
    }
}
