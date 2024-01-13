using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace _Demo
{
    public class PlayerController : AController
    {
        public PlayerInputs PlayerInputs;
        public LayerMask LayerMask;

        public Vector3 Destination;
        public List<AllyBotController> Allies = new List<AllyBotController>();

        public ISelectable SelectedObject;

        public ParticleSystem ClickEffect;

        private void Awake()
        {
            PlayerInputs = new PlayerInputs();
            Allies.ForEach(Ally => Ally.Owner = this);
        }

        public void OnEnable()
        {
            PlayerInputs.Enable();
            PlayerInputs.PlayerActions.LeftClick.performed += OnLeftClick;
            PlayerInputs.PlayerActions.RightClick.performed += OnRightClick;
        }

        private void Start()
        {
            Statistic MovementSpeed = Entity.Statistics.GetStatistic("MovementSpeed");
            if (MovementSpeed != null)
                Agent.speed = MovementSpeed.Value;
            Statistic Agility = Entity.Statistics.GetStatistic("Agility");
            if (Agility != null)
                Agent.angularSpeed = Agility.Value;
        }

        private void OnDisable()
        {
            PlayerInputs.PlayerActions.LeftClick.performed -= OnLeftClick;
            PlayerInputs.PlayerActions.RightClick.performed -= OnRightClick;
            PlayerInputs.Disable();
        }

        public void OnLeftClick(CallbackContext ctx)
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            ApplyMovement();
        }
        public void OnRightClick(CallbackContext ctx)
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            ApplyMovement();

            if(SelectedObject != null)
            {
                SelectedObject.Unselect(gameObject);
                SelectedObject = null;
            }

            RaycastHit hit;

            Vector3 srcPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            Ray ray = Camera.main.ScreenPointToRay(srcPoint);

            if (Physics.Raycast(ray, out hit, 1000, LayerMask))
            {
                Transform transform = hit.transform;
                ISelectable target;
                if (!transform.TryGetComponent<ISelectable>(out target))
                    return;
                
                SelectedObject = target;
                SelectedObject.Select(gameObject);
            }
        }

        public override void Update()
        {
            //throw new System.NotImplementedException();
        }

        public override void ApplyMovement()
        {
            RaycastHit hit;

            Vector3 srcPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
            Ray ray = Camera.main.ScreenPointToRay(srcPoint);

            if (Physics.Raycast(ray, out hit, 1000, LayerMask))
            {
                Destination = hit.point;
                Agent.destination = Destination;
                Allies.ForEach(Ally => Ally.OnSignal("follow"));

                ParticleSystem effect = Instantiate(ClickEffect, Destination + new Vector3(0, 0.1f, 0), ClickEffect.transform.rotation);
                Destroy(effect.gameObject, 1f);
            }
        }

        public override void StopMovement()
        {
            Agent.isStopped = true;
        }
    }
}

