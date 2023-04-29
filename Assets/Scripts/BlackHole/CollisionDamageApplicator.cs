using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceShooter
{
    public class CollisionDamageApplicator : MonoBehaviour
    {
        [SerializeField] private float _velocityDamageModifier;
        [SerializeField] private float _damageConstant;

        private string _finish = "Finish";

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.name == _finish)
                SceneManager.LoadScene(1);

            if (transform.root.TryGetComponent<Destructible>(out Destructible destructible))
            {
                destructible.ApplyDamage(
                    (int)(_damageConstant + _velocityDamageModifier * collision.relativeVelocity.magnitude));
            }
        }


    }
}