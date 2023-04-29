using UnityEngine;

namespace SpaceShooter
{
    public class CollisionDamageApplicator : MonoBehaviour
    {
        [SerializeField] private float _velocityDamageModifier;
        [SerializeField] private float _damageConstant;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (transform.root.TryGetComponent<Destructible>(out Destructible destructible))
            {
                destructible.ApplyDamage(
                    (int)(_damageConstant + _velocityDamageModifier * collision.relativeVelocity.magnitude));
            }
        }


    }
}