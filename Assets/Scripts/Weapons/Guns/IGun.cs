using Assets.Scripts.Weapons;

namespace Assets.Scripts
{
    internal interface IGun : IWeapon
    {
        void Reload();
    }
}
