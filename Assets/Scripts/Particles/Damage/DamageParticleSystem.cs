using Assets.Scripts.Particles;
using UnityEngine;

namespace Assets.Scripts
{
    public class DamageParticleSystem : MonoBehaviour, IParticleSystem
    {
        [SerializeField] ParticleData hitParticleData;
        [SerializeField] ParticleData deadParticleData;

        public ParticleData HitParticleData { get; private set; }
        public ParticleData DeadParticleData { get; private set; }

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
                HitParticleData = hitParticleData;
                _hitParticleSystem = Instantiate(HitParticleData.ParticleSystem.GetComponent<ParticleSystem>(), transform);
            }
            else
            {
                Debug.LogError($"ERROR: Missing HitParticleData in {gameObject.name}");
            }

            if (deadParticleData)
            {
                DeadParticleData = deadParticleData;
                _deadParticleSystem = Instantiate(DeadParticleData.ParticleSystem.GetComponent<ParticleSystem>(), transform);
            }
            else
            {
                Debug.LogError($"ERROR: Missing DeadParticleData in {gameObject.name}");
            }
        }
    }
}
