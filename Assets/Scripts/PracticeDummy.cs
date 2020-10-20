using Assets.Scripts;
using Assets.Scripts.Entity;
using Assets.Scripts.Particles;
using UnityEngine;

public class PracticeDummy : MonoBehaviour, IDamageable, IHealth, IShield, ICanDie, IEmitDamageParticles
{
    [SerializeField] float health = 10f;
    [SerializeField] float healthMax = 10f;
    [SerializeField] float shield = 0f;
    [SerializeField] float shieldMax = 10f;

    public float Health { get => health; set => health = value; }

    public float HealthMax => healthMax;

    public float Shield { get => shield; set => shield = value; }

    public float ShieldMax => shieldMax;

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
            Die();
        }
    }

    public void Die()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;

        DamageParticleSystem?.EmitDead();
    }
}
