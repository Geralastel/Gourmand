using Assets.Scripts;
using Assets.Scripts.Entity;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, IHealth, IShield
{
    [SerializeField] float health = 10f;
    [SerializeField] float shield = 0f;

    public float Health { get => health; set => health = value; }

    public float HealthMax => 10f;

    public float Shield { get => shield; set => shield = value; }

    public float ShieldMax => 10f;
    public float ModifyHealth(float amount)
    {
        Health += amount;
        return Health;
    }

    public float ModifyShield(float amount)
    {
        Shield += amount;
        return Shield;
    }

    public void TakeDamage(float damage)
    {
        var remainingDamage = ModifyShield(-damage);
        if (remainingDamage < 0) ModifyHealth(remainingDamage);

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
