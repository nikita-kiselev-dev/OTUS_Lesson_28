using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Sample
{
    public class Mine : Projectile
    {
        [SerializeField] private float m_ExplosionForce;
        [SerializeField] private float m_ExplosionRadius;

        [SerializeField] private float m_BangDelay;
        
        [SerializeField] private ParticleSystem m_BangEffect;

        public void Start()
        {
            StartCoroutine(Bang(m_BangDelay));
        }

        private void OnCollisionEnter(Collision other)
        {
            var isPlayer = other.gameObject.TryGetComponent(out PlayerController player);
            var isEnemy = other.gameObject.TryGetComponent(out NavMeshAgent enemy);
            if (isPlayer || isEnemy)
            {
                StartCoroutine(Bang(0.0f));
            }
        }

        private IEnumerator Bang(float bangDelay)
        {
            yield return new WaitForSeconds(bangDelay);
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
            Instantiate(m_BangEffect, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(gameObject.transform.position, m_ExplosionRadius);
        }
    }
}