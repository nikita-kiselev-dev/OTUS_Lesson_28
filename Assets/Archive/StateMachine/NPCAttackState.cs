// using System;
// using UnityEngine;
//
// namespace FSM
// {
//     public sealed class NPCAttackState : State
//     {
//         [SerializeField]
//         private NPCData data;
//         
//         public override void OnUpdate(float deltaTime)
//         {
//             this.LookAtTarget(deltaTime);
//             this.MoveOrAttackTarget(deltaTime);
//         }
//
//         private void LookAtTarget(float deltaTime)
//         {
//             Vector3 targetPosition = data.target.transform.position;
//             Vector3 myPosition = data.moveTransform.position;
//
//             Vector3 direction = (targetPosition - myPosition).normalized;
//             Quaternion currentRotation = this.data.moveTransform.rotation;
//             Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
//
//             data.moveTransform.rotation = Quaternion.Slerp(
//                 currentRotation,
//                 targetRotation,
//                 this.data.rotationSpeed * deltaTime
//             );
//         }
//
//         private void MoveOrAttackTarget(float deltaTime)
//         {
//             Vector3 targetPosition = data.target.transform.position;
//             Vector3 myPosition = data.moveTransform.position;
//             Vector3 distance = targetPosition - myPosition;
//
//             bool shouldMove = distance.magnitude > data.stoppingDistance;
//             if (shouldMove)
//             {
//                 data._agent.enabled = true;
//                 data._agent.updatePosition = false;
//                 data._agent.destination = targetPosition;
//                 
//                 data.moveTransform.position = data._agent.nextPosition;
//             }
//             else
//             {
//                 this.data.weapon.Shoot(distance.normalized);
//                 data._agent.enabled = false;
//             }
//
//             data._animator.SetFloat(NPCData._animIDSpeed, shouldMove ? 1 : 0);
//             data._animator.SetFloat(NPCData._animIDMotionSpeed, shouldMove ? 3 : 0);
//         }
//     }
// }