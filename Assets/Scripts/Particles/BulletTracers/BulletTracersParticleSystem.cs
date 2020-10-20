using Assets.Scripts.Particles;
using UnityEngine;

namespace Assets.Scripts.Particles
{
    public class BulletTracersParticleSystem : MonoBehaviour, IParticleSystem
    {
        [SerializeField] ParticleData bulletTracerParticleData;
        public ParticleData BulletTracerParticleData { get; private set; }

        private ParticleSystem _bulletTracerParticleSystem;

        void Awake()
        {
            Initialize();
        }

        public void EmitBulletTracer()
        {
            if (_bulletTracerParticleSystem != null)
            {
                if (_bulletTracerParticleSystem.isPlaying)
                {
                    _bulletTracerParticleSystem.Stop();
                }

                _bulletTracerParticleSystem.Play();
            }
        }

        public void Initialize()
        {
            if (bulletTracerParticleData)
            {
                BulletTracerParticleData = bulletTracerParticleData;
                _bulletTracerParticleSystem = Instantiate(bulletTracerParticleData.ParticleSystem.GetComponent<ParticleSystem>(), transform);
            }
            else
            {
                Debug.LogError($"ERROR: Missing ParticleData in {gameObject.name}");
            }
        }
    }
}
