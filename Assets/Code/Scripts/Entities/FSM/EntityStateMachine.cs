using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Demo
{
    public class EntityStateMachine
    {
        public EntityState CurrentState { get; private set; }

        public void Initialize(EntityState State)
        {
            CurrentState = State;
        }

        public void Change(EntityState NewState)
        {
            CurrentState.Exit();
            CurrentState = NewState;
            CurrentState.Enter();
        }
    }
}

