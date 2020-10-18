namespace Assets.Scripts
{
    public interface IHealth
    {
        float Health { get; set; }
        float HealthMax { get; }
        float ModifyHealth(float amount);
    }
}
