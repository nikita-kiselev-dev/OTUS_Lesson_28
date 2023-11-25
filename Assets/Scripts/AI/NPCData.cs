using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace Sample
{
    public sealed class NPCData : MonoBehaviour
    {
        public static readonly int animIDSpeed = Animator.StringToHash("Speed");
        public static readonly int animIDMotionSpeed = Animator.StringToHash("MotionSpeed");
        
        public List<Transform> patrolPoints;
        public NavMeshAgent agent;
        public Animator animator;
        public Transform rootTransform;
        public GameObject target;
        public float rotationSpeed = 25;
        public float rangeDistance = 5.0f;
        [FormerlySerializedAs("m_Weapon1")] [FormerlySerializedAs("weapon")] public RifleWeapon m_RifleWeapon;
        public float visionRadius;
    }
}