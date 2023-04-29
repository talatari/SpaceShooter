using UnityEngine;

namespace SpaceShooter
{
    public partial class LevelBoundary : SingletonBase<LevelBoundary>
    {
        [SerializeField] private float _radius;
        [SerializeField] private Mode _limitMode;

        public float Radius => _radius;
        public Mode LimitMode => _limitMode;



#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            UnityEditor.Handles.color = Color.green;
            UnityEditor.Handles.DrawWireDisc(transform.position, transform.forward, _radius);
        }
#endif
    }
}