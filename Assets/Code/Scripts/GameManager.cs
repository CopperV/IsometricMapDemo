using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace _Demo
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Inst;

        public PlayerController PlayerController;
        public List<AllyBotController> AllyBotControllers = new List<AllyBotController>();
        public List<EnemyBotController> EnemyBotControllers = new List<EnemyBotController>();

        private CameraController CameraController;

        public Outline Outline;
        public GameObject CharactersUI;

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
            OutlineImage(CharactersUI.transform.GetChild(0).GetChild(0).gameObject);

            CameraController = GameObject.FindGameObjectWithTag("MainPivot").GetComponent<CameraController>();
            CameraController.HookPivot(PlayerController.transform);
        }

        public void Start()
        {
            
        }

        public void Update()
        {
            
        }

        public void OnDisable()
        {
            
        }

        public void OnExit()
        {
            Debug.Log("EXIT");
            Application.Quit();
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
            newPlayer.Allies = PlayerController.Allies;
            newPlayer.PlayerInputs = PlayerController.PlayerInputs;

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

        public void OutlineImage(GameObject Image)
        {
            CharactersUI.transform.GetChild(0)
                .GetComponentsInChildren<Outline>()
                .ToList()
                .ForEach(Outline => Destroy(Outline));

            Outline _Outline = Image.AddComponent<Outline>();
            _Outline.effectColor = Outline.effectColor;
            _Outline.effectDistance = Outline.effectDistance;
        }

    }
}

