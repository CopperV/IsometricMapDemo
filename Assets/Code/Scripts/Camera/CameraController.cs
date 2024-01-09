using UnityEngine;

namespace _Demo
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        private readonly Camera DefaultCamera;
        [SerializeField]
        private readonly Transform DefaultPivot;
        [SerializeField]
        private readonly Vector3 DefaultPosition;
        [SerializeField]
        private readonly Vector3 DefaultRotation;

        [HideInInspector]
        public Camera Camera;
        [HideInInspector]
        public Transform Pivot;
        [HideInInspector]
        public Vector3 Position;
        [HideInInspector]
        public Vector3 Rotation;

        public void OnEnable()
        {
            ResetAll();
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