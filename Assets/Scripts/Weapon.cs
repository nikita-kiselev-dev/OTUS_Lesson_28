using UnityEngine;

namespace Sample
{
    public abstract class Weapon : MonoBehaviour
    {
        public abstract WeaponList.Weapons Name { get; set; }
        public abstract void Shoot(Vector3 direction);
    }
}