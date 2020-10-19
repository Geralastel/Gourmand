using Assets.Scripts.Particles;
using UnityEngine;

namespace Assets.Scripts
{
    public class BulletTracersParticleSystem : MonoBehaviour
    {
#pragma warning disable CS0649
        [SerializeField] ParticleData bulletTracerParticleData;
#pragma warning restore CS0649

        private ParticleSystem _bulletTracerParticleSystem;

        void Awake()
        {
            if (bulletTracerParticleData)
            {
                _bulletTracerParticleSystem = Instantiate(bulletTracerParticleData.ParticleSystem.GetComponent<ParticleSystem>(), transform);
            }
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
    }
}
