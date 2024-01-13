using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Demo
{
    public class AllyBotController : ABotController
    {
        [HideInInspector]
        public PlayerController Owner;

        private void Start()
        {
            Statistic MovementSpeed = Entity.Statistics.GetStatistic("MovementSpeed");
            if (MovementSpeed != null)
                Agent.speed = MovementSpeed.Value;
            Statistic Agility = Entity.Statistics.GetStatistic("Agility");
            if (Agility != null)
                Agent.angularSpeed = Agility.Value;
            Agent.stoppingDistance = 5;
        }

        public override void Update()
        {

        }

        public override void ApplyMovement()
        {
            Agent.destination = Owner.transform.position;
        }

        public override void StopMovement()
        {
            Agent.isStopped = true;
        }

        public override void OnSignal(string Signal)
        {
            switch(Signal.ToLower())
            {
                case "follow":
                    ApplyMovement();
                    break;
            }
        }

    }
}

