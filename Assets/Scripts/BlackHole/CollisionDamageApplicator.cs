using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceShooter
{
    public class CollisionDamageApplicator : MonoBehaviour
    {
        [SerializeField] private float _velocityDamageModifier;
        [SerializeField] private float _damageConstant;

        private string _finish = "Finish";
        private string _spaceShipView = "SpaceShipView";

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log($"collision.collider.name = {collision.collider.name}");

            if (collision.collider.name == _finish)
                SceneManager.LoadScene(1);

            if (collision.collider.name != _spaceShipView)
            {
                if (transform.root.TryGetComponent(out Destructible destructible))
                {
                    int damage = (int)(_damageConstant + _velocityDamageModifier * collision.relativeVelocity.magnitude);

                    destructible.ApplyDamage(damage);
                }
            }
        }


    }
}