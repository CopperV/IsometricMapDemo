using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Demo
{
    public class RunState : EntityState
    {
        public RunState(EntityStateMachine stateMachine, Entity entity) : base("RunState", stateMachine, entity)
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

