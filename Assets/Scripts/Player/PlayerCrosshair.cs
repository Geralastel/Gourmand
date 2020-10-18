using Assets.Scripts;
using Assets.Scripts.Weapons;
using UnityEngine;

public class PlayerCrosshair : MonoBehaviour
{
#pragma warning disable CS0649
    [SerializeField] GameObject CrossHair;
#pragma warning restore CS0649

    private WeaponData _weaponData;

    public void Initialize(WeaponData weaponData)
    {
        _weaponData = weaponData;

        var pos = CrossHair.transform.position;
        CrossHair.transform.position = new Vector2(_weaponData.Range, pos.y);
    }
}