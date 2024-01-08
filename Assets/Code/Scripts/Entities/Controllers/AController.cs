using UnityEngine;
using UnityEngine.AI;

namespace _Demo
{
    public abstract class AController : MonoBehaviour, IMovable
    {
        [SerializeField]
        public readonly Entity Entity;
        [SerializeField]
        public readonly NavMeshAgent Agent;

        public abstract void ApplyMovement();

        public abstract void StopMovement();

        public abstract void Update();
    }
}

