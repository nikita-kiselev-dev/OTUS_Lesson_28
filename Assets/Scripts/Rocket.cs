using UnityEngine;

namespace Sample
{
    public class Rocket : Projectile
    {
        [SerializeField] private float m_ExplosionForce;
        [SerializeField] private float m_ExplosionRadius;
        private void OnCollisionEnter(Collision other)
        {
            Collider[] colliders = Physics.OverlapSphere(this.gameObject.transform.position, m_ExplosionRadius);

            foreach (var collider in colliders)
            {
                var rigidbody = collider.GetComponent<Rigidbody>();
                if (rigidbody && gameObject != rigidbody.gameObject)
                {
                    rigidbody.AddExplosionForce(m_ExplosionForce, gameObject.transform.position, m_ExplosionRadius);
                    Debug.Log($"{rigidbody.gameObject} was damaged by {gameObject}!");
                }
            }
            Destroy(gameObject);
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(gameObject.transform.position, m_ExplosionRadius);
        }
    }
}