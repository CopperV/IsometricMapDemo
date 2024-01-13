using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace _Demo
{
    public class RunState : EntityState
    {

        private NavMeshAgent Agent;

        public RunState(EntityStateMachine stateMachine, Entity entity) : base("RunState", stateMachine, entity)
        {
            AController controller;
            if (controller = entity.GetComponentInParent<AController>())
            {
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

            if (Agent.velocity.Equals(Vector3.zero))
            {
                EntityState NewState;
                if (Entity.States.TryGetValue("IdleState", out NewState))
                {
                    Entity.Animator.InterruptMatchTarget();
                    StateMachine.Change(NewState);
                }
            }
        }
    }
}

