// using UnityEngine;
//
// namespace FSM
// {
//     public sealed class NPCPatrolState : State
//     {
//         [SerializeField]
//         private NPCData data;
//
//         private Transform _goal;
//         private Vector3 _worldDeltaPos;
//         private int _indexOfPatrolPoint;
//         
//         public override void OnEnter()
//         {
//             data._agent.updatePosition = false;
//         
//             _indexOfPatrolPoint = 0;
//             _goal = data.patrolPoints[_indexOfPatrolPoint];
//
//             data._agent.enabled = true;
//         }
//
//         public override void OnUpdate(float deltaTime)
//         {
//             if (Mathf.Approximately(data.moveTransform.position.x, _goal.position.x) &&
//                 Mathf.Approximately(data.moveTransform.position.z, _goal.position.z))
//             {
//                 _indexOfPatrolPoint++;
//
//                 if (data.patrolPoints.Count <= _indexOfPatrolPoint)
//                 {
//                     _indexOfPatrolPoint = 0;
//                 }
//
//                 _goal = data.patrolPoints[_indexOfPatrolPoint];
//             }
//         
//             data._agent.destination = _goal.position;
//             _worldDeltaPos = data._agent.nextPosition - data.moveTransform.position;
//             bool shouldMove = _worldDeltaPos.magnitude != 0;
//             data._animator.SetFloat(NPCData._animIDSpeed, shouldMove ? 1 : 0);
//             data._animator.SetFloat(NPCData._animIDMotionSpeed, shouldMove ? 3 : 0);
//
//             data.moveTransform.position = data._agent.nextPosition;
//         }
//
//         public override void OnExit()
//         {
//             data._agent.enabled = false;
//         }
//     }
// }