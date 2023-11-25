// using UnityEngine;
//
// namespace FSM
// {
//     public class StateMachine : State
//     {
//         private State currentState;
//         
//         public override void OnEnter()
//         {
//             if (this.currentState != null)
//             {
//                 this.currentState.OnEnter();
//             }
//         }
//
//         public override void OnUpdate(float deltaTime)
//         {
//             if (this.currentState != null)
//             {
//                 Debug.Log($"CURRENT STATE {this.currentState.name}");
//                 this.currentState.OnUpdate(deltaTime);
//             }
//         }
//
//         public override void OnExit()
//         {
//             if (this.currentState != null)
//             {
//                 this.currentState.OnExit();
//             }
//         }
//
//         public void SwitchState(State state)
//         {
//             if (state == this.currentState)
//             {
//                 return;
//             }
//
//             if (this.currentState != null)
//             {
//                 this.currentState.OnExit();
//             }
//
//             this.currentState = state;
//
//             if (this.currentState != null)
//             {
//                 this.currentState.OnEnter();
//             }
//         }
//     }
// }