using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Demo
{
    public class EntityState
    {

        public readonly string AnimBoolName;
        public readonly EntityStateMachine StateMachine;
        public readonly Entity Entity;

        public EntityState(string animBoolName, EntityStateMachine stateMachine, Entity entity)
        {
            AnimBoolName = animBoolName;
            StateMachine = stateMachine;
            Entity = entity;
        }

        public virtual void Enter()
        {
            Entity.Animator.SetBool(AnimBoolName, true);
        }

        public virtual void Update()
        {

        }

        public virtual void Exit()
        {
            Entity.Animator.SetBool(AnimBoolName, false);
        }

    }
}

