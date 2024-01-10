using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Demo
{
    public class IdleState : EntityState
    {
        public IdleState(EntityStateMachine stateMachine, Entity entity) : base("IdleState", stateMachine, entity)
        {
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
            base.Update();
        }
    }
}

