using Assets.Scripts.Particles;
using UnityEngine;

namespace Assets.Scripts
{
    public class DamageParticleSystem : MonoBehaviour
    {
#pragma warning disable CS0649
        [SerializeField] ParticleData hitParticleData;
        [SerializeField] ParticleData deadParticleData;
#pragma warning restore CS0649

        private ParticleSystem _hitParticleSystem;
        private ParticleSystem _deadParticleSystem;

        void Awake()
        {
            if (hitParticleData)
            {
                _hitParticleSystem = Instantiate(hitParticleData.ParticleSystem.GetComponent<ParticleSystem>(), transform);
            }

            if (deadParticleData)
            {
                _deadParticleSystem = deadParticleData.ParticleSystem.GetComponent<ParticleSystem>();
            }
        }

        public void EmitHit(Vector2? hitDirection)
        {
            if (_hitParticleSystem.isPlaying)
            {
                _hitParticleSystem.Stop();
            }

            if (hitDirection.Value is Vector2 direction)
            {
                var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                _hitParticleSystem.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }

            _hitParticleSystem.Play();
        }
        public void EmitDead()
        {
            transform.position = transform.parent.position;
            Emit(_deadParticleSystem);
        }
        private void Emit(ParticleSystem particle)
        {
            particle?.Play();
        }
    }
}
