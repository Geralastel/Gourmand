namespace Assets.Scripts.Entity
{
    public interface IShield
    {
        float Shield { get; set; }
        float ShieldMax { get; }
        float ModifyShield(float amount);
    }
}
