using UnityEngine;

namespace Assets.Scripts.Particles
{
    [CreateAssetMenu(fileName = "New ParticleData", menuName = "Particle Data", order = 52)]
    public class ParticleData : ScriptableObject
    {
        [SerializeField] private GameObject particleSystem;

        #region Getters and Setters
        public GameObject ParticleSystem { get => particleSystem; set => particleSystem = value; }
        #endregion
    }
}
