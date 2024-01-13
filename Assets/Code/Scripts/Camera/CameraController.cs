using UnityEngine;

namespace _Demo
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private Camera DefaultCamera;
        [SerializeField]
        private Transform DefaultPivot;
        [SerializeField]
        private Vector3 DefaultPosition;
        [SerializeField]
        private Vector3 DefaultRotation;

        [HideInInspector]
        public Camera Camera;
        [HideInInspector]
        public Transform Pivot;
        [HideInInspector]
        public Vector3 Position;
        [HideInInspector]
        public Vector3 Rotation;

        private void OnValidate()
        {
            ResetAll();
            UpdateCamera();
        }

        public void OnEnable()
        {
            ResetAll();
            UpdateCamera();
        }

        private void Update()
        {
            UpdateCamera();
        }

        public void UpdateCamera()
        {
            Camera.transform.localPosition = Position;
            Pivot.transform.rotation = Quaternion.Euler(Rotation);
            Pivot.transform.localPosition = Vector3.zero;
        }

        public void ResetAll()
        {
            ResetCamera();
            ResetPivot();
            ResetPosition();
            ResetRotation();
        }

        public void ResetCamera()
        {
            Camera = DefaultCamera;
        }

        public void ResetPivot()
        {
            Pivot = DefaultPivot;
        }

        public void ResetPosition()
        {
            Position = DefaultPosition;
        }

        public void ResetRotation()
        {
            Rotation = DefaultRotation;
        }

        public void HookPivot(Transform Hook)
        {
            Pivot.SetParent(Hook);
        }

    }
}