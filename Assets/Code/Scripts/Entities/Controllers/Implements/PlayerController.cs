using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace _Demo
{
    public class PlayerController : AController
    {
        public Transform Destination;
        public List<AllyBotController> Allies = new List<AllyBotController>();

        public void OnEnable()
        {
            
        }

        public void OnLeftClick(CallbackContext ctx)
        {

        }
        public void OnRightClick(CallbackContext ctx)
        {

        }

        public override void Update()
        {
            throw new System.NotImplementedException();
        }

        public override void ApplyMovement()
        {
            throw new System.NotImplementedException();
        }

        public override void StopMovement()
        {
            throw new System.NotImplementedException();
        }
    }
}

