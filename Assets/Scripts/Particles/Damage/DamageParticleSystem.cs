using Assets.Scripts.Particles;
using UnityEngine;

namespace Assets.Scripts
{
    public class DamageParticleSystem : MonoBehaviour, IParticleSystem
    {
#pragma warning disable CS0649
        [SerializeField] ParticleData hitParticleData;
        [SerializeField] ParticleData deadParticleData;
#pragma warning restore CS0649

        private ParticleSystem _hitParticleSystem;
        private ParticleSystem _deadParticleSystem;

        private void Awake()
        {
            Initialize();
        }

        public void EmitHit(Vector2? hitDirection)
        {
            if (_hitParticleSystem != null)
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
        }

        public void EmitDead()
        {
            if (_deadParticleSystem != null)
            {
                if (_deadParticleSystem.isPlaying)
                {
                    _deadParticleSystem.Stop();
                }

                _deadParticleSystem.Play();
            }
        }

        public void Initialize()
        {
            if (hitParticleData)
            {
                _hitParticleSystem = Instantiate(hitParticleData.ParticleSystem.GetComponent<ParticleSystem>(), transform);
            }

            if (deadParticleData)
            {
                _deadParticleSystem = Instantiate(deadParticleData.ParticleSystem.GetComponent<ParticleSystem>(), transform);
            }
        }
    }
}
