namespace Sample
{
    public class StateMachine : State
    {
        private State currentState;

        public override void OnEnter()
        {
            if (this.currentState != null)
            {
                this.currentState.OnEnter();
            }
        }

        public override void OnUpdate(float deltaTime)
        {
            if (this.currentState != null)
            {
                this.currentState.OnUpdate(deltaTime);
            }
        }

        public override void OnExit()
        {
            if (this.currentState != null)
            {
                this.currentState.OnExit();
            }
        }

        public void SwitchState(State state)
        {
            if (this.currentState == state)
            {
                return;
            }
            
            if (this.currentState != null)
            {
                this.currentState.OnExit();
            }

            this.currentState = state;
            
            if (this.currentState != null)
            {
                this.currentState.OnEnter();
            }
        }
    }
}