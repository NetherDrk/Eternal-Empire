namespace Assets.Scripts
{
    public class TechUnitTechUpgrade : Tech
    {
        public double MultiplyFactor;

        public Unit UnitUpgraded;

        public override void Upgrade()
        {
            UnitUpgraded.UnitTechUpgrade(MultiplyFactor);
        }
    }
}