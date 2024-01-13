using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

        private ISelectable SelectedObject;

        [SerializeField]
        private ParticleSystem ClickEffect;

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
            PlayerInputs.Disable();
            PlayerInputs.PlayerActions.LeftClick.performed -= OnLeftClick;
            PlayerInputs.PlayerActions.RightClick.performed -= OnRightClick;
        }

        public void OnLeftClick(CallbackContext ctx)
        {
            ApplyMovement();
        }
        public void OnRightClick(CallbackContext ctx)
        {
            ApplyMovement();

            if(SelectedObject != null)
            {
                SelectedObject.Unselect(gameObject);
                SelectedObject = null;
            }

            RaycastHit hit;

            Vector3 mousePosition = Input.mousePosition + new Vector3(0, 0, -10);
            Vector3 hitPosition = mousePosition + new Vector3(0, 0, 35);
            Vector3 origin = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 point = Camera.main.ScreenToWorldPoint(hitPosition);
            Vector3 dir = (point - origin);

            if (Physics.Raycast(origin, dir, out hit, 1000, LayerMask))
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

            Vector3 mousePosition = Input.mousePosition + new Vector3(0, 0, -10);
            Vector3 hitPosition = mousePosition + new Vector3(0, 0, 35);
            Vector3 origin = Camera.main.ScreenToWorldPoint(mousePosition);
            Vector3 point = Camera.main.ScreenToWorldPoint(hitPosition);
            Vector3 dir = (point - origin);

            if (Physics.Raycast(origin, dir, out hit, 1000, LayerMask))
            {
                Destination = hit.point;
                Agent.destination = Destination;
                Allies.ForEach(Ally => Ally.OnSignal("follow"));

                ParticleSystem effect = Instantiate(ClickEffect, Destination + new Vector3(0, 0.1f, 0), ClickEffect.transform.rotation);
                Destroy(effect, 1f);
            }
        }

        public override void StopMovement()
        {
            Agent.isStopped = true;
        }
    }
}

