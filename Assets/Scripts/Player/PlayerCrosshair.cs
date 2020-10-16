using Assets.Scripts;
using UnityEngine;

public class PlayerCrosshair : MonoBehaviour
{
    [SerializeField] GameObject CrossHair;
    private WeaponData _weaponData;

    private void Awake()
    {
        _weaponData = GetComponent<Gun>().gunData;
    }

    private void Start()
    {
        var pos = CrossHair.transform.position;
        CrossHair.transform.position = new Vector2(_weaponData.Range, pos.y);
    }
}