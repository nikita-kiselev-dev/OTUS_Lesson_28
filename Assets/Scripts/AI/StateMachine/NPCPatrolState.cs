using UnityEngine;

namespace Sample
{
    public sealed class NPCPatrolState : State
    {
        [SerializeField]
        private NPCData data;

        private Transform _goal;
        private Vector3 _worldDeltaPos;
        private int _indexOfPatrolPoint;

        public override void OnEnter()
        {
            data.agent.updatePosition = false;
            data.agent.enabled = true;
            
            _indexOfPatrolPoint = 0;
            _goal = data.patrolPoints[_indexOfPatrolPoint];
        }

        public override void OnUpdate(float deltaTime)
        {
            if (Mathf.Approximately(data.rootTransform.position.x, _goal.position.x) &&
                Mathf.Approximately(data.rootTransform.position.z, _goal.position.z))
            {
                _indexOfPatrolPoint++;

                if (data.patrolPoints.Count <= _indexOfPatrolPoint)
                {
                    _indexOfPatrolPoint = 0;
                }

                _goal = data.patrolPoints[_indexOfPatrolPoint];
            }

            data.agent.destination = _goal.position;
            _worldDeltaPos = data.agent.nextPosition - data.rootTransform.position;

            var shouldMove = _worldDeltaPos.magnitude != 0;
            data.animator.SetFloat(NPCData.animIDSpeed, shouldMove ? 1 : 0);
            data.animator.SetFloat(NPCData.animIDMotionSpeed, shouldMove ? 3 : 0);

            data.rootTransform.position = data.agent.nextPosition;
        }

        public override void OnExit()
        {
            data.agent.enabled = false;
        }
    }
}