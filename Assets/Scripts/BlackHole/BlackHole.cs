using UnityEngine;

namespace SpaceShooter
{
    [RequireComponent(typeof(CircleCollider2D))]
    public class BlackHole : MonoBehaviour
    {
        [SerializeField] private float _forceGravity;
        [SerializeField] private float _radiusGravity;

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.attachedRigidbody == null)
                return;

            Vector2 direction = transform.position - collision.transform.position;
            float distance = direction.magnitude;

            if (distance < _radiusGravity)
            {
                Vector2 forceGravity = direction.normalized * _forceGravity * (distance / _radiusGravity);

                collision.attachedRigidbody.AddForce(
                    force: forceGravity,
                    mode: ForceMode2D.Force);
            }
        }



#if UNITY_EDITOR
        private void OnValidate()
        {
            GetComponent<CircleCollider2D>().radius = _radiusGravity;
        }
#endif
    }
}