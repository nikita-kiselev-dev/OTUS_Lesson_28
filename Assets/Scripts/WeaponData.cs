using UnityEngine;

namespace Sample
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WeaponData", order = 1)]
    public class WeaponData : ScriptableObject
    {
        public float shootCountdown;
        public float projectileDestroyDelayInSeconds;
        public Projectile projectilePreafab;
    }
}