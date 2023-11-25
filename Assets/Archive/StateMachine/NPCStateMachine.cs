// using UnityEngine;
//
// namespace FSM
// {
//     public sealed class NPCStateMachine : StateMachine
//     {
//         [SerializeField]
//         private NPCData data;
//         
//         [SerializeField]
//         private State patrolState;
//
//         [SerializeField]
//         private State attackState;
//
//         public override void OnUpdate(float deltaTime)
//         {
//             if (this.data.target != null)
//             {
//                 this.SwitchState(this.attackState);
//             }
//             else
//             {
//                 this.SwitchState(this.patrolState);
//             }
//             
//             base.OnUpdate(deltaTime);
//         }
//     }
// }