using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class FollowTarget : MonoBehaviour
    {
        [SerializeField] Transform _targetTransform;
        [SerializeField] float _offsetX;
        [SerializeField] float _offsetY;

        private void Update()
        {
            transform.position = new Vector2(_targetTransform.position.x + _offsetX, _targetTransform.position.y + _offsetY);
        }
    }
}
