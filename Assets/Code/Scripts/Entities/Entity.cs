using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Demo
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody))]
    public class Entity : MonoBehaviour
    {
        public string Id { get; private set; } = Guid.NewGuid().ToString();
        [SerializeField]
        public Animator Animator;
        [SerializeField]
        public Rigidbody Rigidbody;
        [SerializeField]
        public StatisticContainer Statistics;

        public EntityStateMachine StateMachine {  get; private set; }
        public Dictionary<string, EntityState> States { get; private set; } = new Dictionary<string, EntityState>();

        private void Awake()
        {
            Initialize();
        }

        private void Update()
        {
            StateMachine.CurrentState.Update();
        }

        protected virtual void Initialize()
        {
            StateMachine = new EntityStateMachine();

            EntityState idleState = new IdleState(StateMachine, this);
            EntityState runState = new RunState(StateMachine, this);

            StateMachine.Initialize(idleState);

            States.Add(idleState.AnimBoolName, idleState);
            States.Add(runState.AnimBoolName, runState);
        }

    }
}

