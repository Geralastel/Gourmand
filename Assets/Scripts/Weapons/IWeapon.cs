using Assets.Scripts.Entity;

namespace Assets.Scripts.Weapons
{
    public interface IWeapon : IHasSprite
    {
        float WeaponRange { get; }
        float Damage { get; }
        float KnockbackForce { get; }
        float RateOfFire { get; }
        void PrimaryAction();
        void SecondaryAction();
    }
}
