using UnityEngine;

namespace Sample
{
    public abstract class Weapon : MonoBehaviour
    {
        public abstract void Shoot(Vector3 direction);
    }
}