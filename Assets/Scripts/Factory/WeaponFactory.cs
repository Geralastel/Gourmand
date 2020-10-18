using Assets.Scripts.Weapons;
using UnityEngine;

namespace Assets.Scripts.Factory
{
    public class WeaponFactory : MonoBehaviour
    {
        public GameObject Create(WeaponData data, Transform parent)
        {
            return Instantiate(data.Prefab, parent);
        }

        public GameObject Create(WeaponData data)
        {
            return Instantiate(data.Prefab);
        }
    }
}
