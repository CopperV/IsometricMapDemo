using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace _Demo
{
    public class IdleState : EntityState
    {

        private NavMeshAgent Agent;

        public IdleState(EntityStateMachine stateMachine, Entity entity) : base("IdleState", stateMachine, entity)
        {
            AController controller;
            if (controller = entity.GetComponentInParent<AController>()){
                Agent = controller.Agent;
            }
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
        }

        public override void Update()
        {
            if (!Agent)
                return;

            if (!Agent.velocity.Equals(Vector3.zero))
            {
                EntityState NewState;
                if(Entity.States.TryGetValue("RunState", out NewState))
                {
                    Entity.Animator.InterruptMatchTarget();
                    StateMachine.Change(NewState);
                }
            }
        }
    }
}

