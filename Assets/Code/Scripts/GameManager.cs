using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace _Demo
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Inst {  get; private set; }

        public PlayerController PlayerController;
        public List<AllyBotController> AllyBotControllers = new List<AllyBotController>();
        public List<EnemyBotController> EnemyBotControllers = new List<EnemyBotController>();

        private CameraController CameraController;

        private void Awake()
        {
            if(Inst != null)
            {
                Destroy(Inst.gameObject);
            }

            Inst = this;
            DontDestroyOnLoad(gameObject);
        }

        public void OnEnable()
        {
            CameraController = GameObject.FindGameObjectWithTag("MainPivot").GetComponent<CameraController>();
        }

        public void Start()
        {
            List<Button> buttons = UIManager.Inst.CharactersUI.GetComponentsInChildren<Button>().ToList();
            buttons[Random.Range(0, buttons.Count)].onClick.Invoke();
        }

        public void Update()
        {
            
        }

        public void OnDisable()
        {
            
        }

        public void ChangeCharacter(GameObject Object)
        {
            AllyBotController controller;
            if (!Object.TryGetComponent(out controller))
                return;

            if (!AllyBotControllers.Contains(controller))
                return;

            AllyBotController newAlly = PlayerController.AddComponent<AllyBotController>();
            newAlly.Entity = PlayerController.Entity;
            newAlly.Agent = PlayerController.Agent;
            newAlly.Agent.stoppingDistance = 5;
            
            PlayerController newPlayer = controller.AddComponent<PlayerController>();
            newPlayer.Entity = controller.Entity;
            newPlayer.Agent = controller.Agent;
            newPlayer.LayerMask = PlayerController.LayerMask;
            newPlayer.Destination = PlayerController.Destination;
            newPlayer.Agent.stoppingDistance = 0;
            newPlayer.Agent.destination = newPlayer.transform.position;
            newPlayer.Allies = PlayerController.Allies;
            newPlayer.SelectedObject = PlayerController.SelectedObject;
            newPlayer.ClickEffect = PlayerController.ClickEffect;
                
            newPlayer.Allies.Remove(controller);
            newPlayer.Allies.Add(newAlly);

            AllyBotControllers.Remove(controller);
            AllyBotControllers.Add(newAlly);

            newPlayer.Allies.ForEach(Ally => Ally.Owner = newPlayer);

            Destroy(newAlly.GetComponent<PlayerController>());
            Destroy(newPlayer.GetComponent<AllyBotController>());

            PlayerController = newPlayer;
            CameraController = GameObject.FindGameObjectWithTag("MainPivot").GetComponent<CameraController>();
            CameraController.HookPivot(PlayerController.transform);
        }

    }
}

