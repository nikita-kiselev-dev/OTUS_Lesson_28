using UnityEngine;

namespace Sample
{
    public class Bullet : Projectile
    {
        private void OnCollisionEnter(Collision other)
        {
            Destroy(gameObject);
        }
    }
}