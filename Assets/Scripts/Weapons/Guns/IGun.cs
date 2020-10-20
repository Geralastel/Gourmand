namespace Assets.Scripts.Weapons
{
    public interface IGun : IWeapon
    {
        int MagazineSize { get; }
        float ReloadSpeed { get; }
        int AmmoInClip { get; }
        void Reload();
        void Shoot();
    }
}
