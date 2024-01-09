using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Demo
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Inst;

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
    }
}

