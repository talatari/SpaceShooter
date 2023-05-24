using UnityEngine;

namespace SpaceShooter
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class BlackHole : MonoBehaviour
    {
        [SerializeField] private float _forceGravity;
        [SerializeField] private float _radiusGravity;

        private void OnTriggerStay2D(Collider2D collider)
        {
            if (collider.attachedRigidbody == null)
                return;

            Vector2 direction = transform.position - collider.transform.position;

            float distance = direction.magnitude;

            if (distance < _radiusGravity)
            {
                Vector2 forceGravity = direction.normalized * _forceGravity * (distance / _radiusGravity);

                collider.attachedRigidbody.AddForce(forceGravity, ForceMode2D.Force);
            }
        }



#if UNITY_EDITOR
        private void OnValidate()
        {
            if (TryGetComponent(out CircleCollider2D circleCollider))
            {
                _radiusGravity = circleCollider.radius;
            }
        }
#endif
    }
}