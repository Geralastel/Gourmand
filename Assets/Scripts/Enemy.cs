using Assets.Scripts;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, IHealth, IShield, IEmitDamageParticles
{
    [SerializeField] float health = 10f;
    [SerializeField] float shield = 0f;

    public float Health { get => health; set => health = value; }

    public float HealthMax => 10f;

    public float Shield { get => shield; set => shield = value; }

    public float ShieldMax => 10f;

    public DamageParticleSystem DamageParticleSystem { get; set; }

    private void Awake()
    {
        DamageParticleSystem = GetComponent<DamageParticleSystem>();
    }

    public float ModifyHealth(float amount)
    {
        Health += amount;
        return Health;
    }

    public float ModifyShield(float amount)
    {
        float remainingDamage = 0;
        if(Shield + amount < 0)
        {
            Shield = 0;
            remainingDamage = Shield + amount; ;
        } else
        {
            Shield += amount;
        }
        return remainingDamage;
    }

    public void TakeDamage(float damage, Vector2? hitDirection)
    {
        DamageParticleSystem?.EmitHit(hitDirection);

        var remainingDamage = ModifyShield(-damage);
        if (remainingDamage < 0) ModifyHealth(remainingDamage);

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
