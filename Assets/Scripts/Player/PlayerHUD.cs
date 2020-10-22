using Assets.Scripts.Managers;
using Assets.Scripts.Weapons;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerHUD : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI nameText;

        private IGun _gun;
        private int _ammoInClip, _magazineSize;

        private void OnEnable()
        {
            EventManager.StartListening(Events.Shoot, HandleShoot);
            EventManager.StartListening(Events.Reload, HandleReload);
        }

        private void OnDisable()
        {
            EventManager.StopListening(Events.Shoot, HandleShoot);
            EventManager.StopListening(Events.Reload, HandleReload);
        }

        private void Start()
        {
            _gun = GetComponentInChildren<IGun>();
            if (_gun != null)
            {
                _ammoInClip = _gun.AmmoInClip;
                _magazineSize = _gun.MagazineSize;
                SetAmmoCount();
            } else
            {
                Debug.LogError("ERROR: No gun found on player");
            }
        }

        private void RefreshText()
        {
            nameText.text = $"{_ammoInClip}/{_magazineSize}";
        }

        private void HandleShoot()
        {
            if(_ammoInClip > 0)
            {
                _ammoInClip--;
                RefreshText();
            }
        }

        private void HandleReload()
        {
            _ammoInClip = _magazineSize;
            RefreshText();
        }

        private void SetAmmoCount() => nameText.text = $"{_ammoInClip}/{_magazineSize}";
    }
}
