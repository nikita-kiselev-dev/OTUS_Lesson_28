using UnityEngine;

namespace Sample
{
    public sealed class StateController : MonoBehaviour
    {
        [SerializeField]
        private State rootState;

        private void OnEnable()
        {
            this.rootState.OnEnter();
        }

        private void Update()
        {
            this.rootState.OnUpdate(Time.deltaTime);
        }

        private void OnDisable()
        {
            this.rootState.OnExit();
        }
    }
}