using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class Billboard : MonoBehaviour
    {
        private Transform _mainCameraTransfrom;

        private void Start()
        {
            _mainCameraTransfrom = Camera.main.transform;
        }

        private void LateUpdate()
        {
            transform.LookAt(transform.position + _mainCameraTransfrom.rotation * Vector3.forward, _mainCameraTransfrom.rotation * Vector3.up);
        }
    }
}
