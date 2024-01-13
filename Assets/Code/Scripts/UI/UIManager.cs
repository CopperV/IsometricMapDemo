using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Demo
{
    public class UIManager : MonoBehaviour
    {

        public static UIManager Inst {  get; private set; }

        public Outline Outline;
        public GameObject CharactersUI;

        private void Awake()
        {
            if (Inst != null)
            {
                Destroy(Inst.gameObject);
            }

            Inst = this;
            DontDestroyOnLoad(gameObject);
        }

        private void OnEnable()
        {
            OutlineImage(CharactersUI.transform.GetChild(0).GetChild(0).gameObject);
        }

        public void OnExitButton()
        {
            Application.Quit();
        }

        public void OnCharacterButton(GameObject Object)
        {
            GameManager.Inst.ChangeCharacter(Object);
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
    
