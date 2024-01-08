using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Demo
{
    [Serializable]
    public class Entity
    {
        [SerializeField]
        public string Id {  get; private set; }
        [SerializeField]
        public Animator Animator { get; private set; }
        [SerializeField]
        public Rigidbody Rigidbody { get; private set; }
        [SerializeField]
        public StatisticContainer Statistics { get; private set; }

        public readonly EntityStateMachine StateMachine;
        public Dictionary<string, EntityState> States { get; private set; }

    }
}

