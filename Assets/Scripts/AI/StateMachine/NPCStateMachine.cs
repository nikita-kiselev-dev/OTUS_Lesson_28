using UnityEngine;

namespace Sample
{
    public sealed class NPCStateMachine : StateMachine
    {
        [SerializeField]
        private NPCData data;
        
        [SerializeField, Space]
        private State patrolState;

        [SerializeField]
        private State attackState;

        public override void OnUpdate(float deltaTime)
        {
            if (this.data.target == null)
            {
                this.SwitchState(this.patrolState);
            }
            else
            {
                this.SwitchState(this.attackState);
            }

            base.OnUpdate(deltaTime);
        }
    }
}