namespace Assets.Scripts
{
    internal interface IGun : IWeapon
    {
        int AmmoInClip { get; }
        void Reload();
        void Shoot();
    }
}
