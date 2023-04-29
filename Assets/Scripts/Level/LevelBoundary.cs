using UnityEngine;

namespace SpaceShooter
{
    public class LevelBoundary : MonoBehaviour
    {
        public enum Mode
        {
            Limit,
            Teleport
        }

        [SerializeField] private float _radius;
        [SerializeField] private Mode _limitMode;

        public float Radius => _radius;
        public Mode LimitMode => _limitMode;
        public static LevelBoundary Instance;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            DontDestroyOnLoad(gameObject);
        }



#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            UnityEditor.Handles.color = Color.green;
            UnityEditor.Handles.DrawWireDisc(transform.position, transform.forward, _radius);
        }
#endif
    }
}