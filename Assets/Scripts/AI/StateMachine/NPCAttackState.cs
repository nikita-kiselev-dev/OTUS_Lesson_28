using System;
using UnityEngine;

namespace Sample
{
    public sealed class NPCAttackState : State
    {
        [SerializeField]
        private NPCData data;

        public override void OnEnter()
        {
            data.agent.updatePosition = false;
        }

        public override void OnExit()
        {
            data.agent.enabled = false;
        }

        public override void OnUpdate(float deltaTime)
        {
            this.LookAtTarget(deltaTime);
            this.FollowOrShootTarget();
        }

        private void FollowOrShootTarget()
        {
            Vector3 myPosition = data.rootTransform.position;
            Vector3 targetPosition = this.data.target.transform.position;
            Vector3 distance = targetPosition - myPosition;

            float stoppingDistance = this.data.rangeDistance;
            var shouldMove = distance.sqrMagnitude > stoppingDistance * stoppingDistance;

            if (shouldMove)
            {
                data.agent.enabled = true;
                data.agent.destination = targetPosition;
                data.rootTransform.position = data.agent.nextPosition;
            }
            else
            {
                data.m_RifleWeapon.Shoot(distance.normalized);
                data.agent.enabled = false;
            }

            //Animation logic...
            data.animator.SetFloat(NPCData.animIDSpeed, shouldMove ? 1 : 0);
            data.animator.SetFloat(NPCData.animIDMotionSpeed, shouldMove ? 3 : 0);
        }

        private void LookAtTarget(float deltaTime)
        {
            Vector3 myPosition = data.rootTransform.position;
            Vector3 targetPosition = this.data.target.transform.position;
            Vector3 direction = (targetPosition - myPosition).normalized;

            Quaternion currentRotation = data.rootTransform.rotation;
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            Quaternion nextRotation = Quaternion.Slerp(currentRotation, targetRotation, data.rotationSpeed * deltaTime);

            data.rootTransform.rotation = nextRotation;
        }
    }
}