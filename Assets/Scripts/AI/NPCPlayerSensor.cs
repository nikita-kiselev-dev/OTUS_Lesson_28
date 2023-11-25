using UnityEngine;

namespace Sample
{
    public sealed class NPCPlayerSensor : MonoBehaviour
    {
        [SerializeField]
        private NPCData data;
        
        private void FixedUpdate()
        {
            if (this.FindTarget(out var target))
            {
                this.data.target = target;
            }
            else
            {
                this.data.target = null;
            }
        }

        private bool FindTarget(out GameObject target)
        {
            Collider[] colliders = Physics.OverlapSphere(this.data.rootTransform.position, data.visionRadius);
            
            foreach (var collider in colliders)
            {
                if (collider.CompareTag("Player"))
                {
                    target = collider.gameObject;
                    return true;
                }
            }

            target = null;
            return false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(this.data.rootTransform.position, this.data.visionRadius);
        }
    }
}