namespace Assets.Scripts.Entity
{
    public interface IHealth
    {
        float Health { get; set; }
        float HealthMax { get; }
        float ModifyHealth(float amount);
    }
}
