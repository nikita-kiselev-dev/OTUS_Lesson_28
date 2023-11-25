// using System;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.AI;
//
// namespace FSM
// {
//     [Serializable]
//     public sealed class NPCData : MonoBehaviour
//     {
//         public static readonly int _animIDSpeed = Animator.StringToHash("Speed");
//         public static readonly int _animIDMotionSpeed = Animator.StringToHash("MotionSpeed");
//         
//         public NavMeshAgent _agent;
//         public Animator _animator;
//         public Transform moveTransform;
//         
//         [Space]
//         public List<Transform> patrolPoints;
//
//         [Space]
//         public GameObject target;
//
//         public float rotationSpeed = 25f;
//         public float stoppingDistance = 5.0f;
//         public float detectionRadius = 10.0f;
//         public Weapon weapon;
//     }
// }