using UnityEngine;

namespace SpaceShooter
{
    public class CometMovement : MonoBehaviour
    {
        [SerializeField] private float _speedFlyComet;

        private Vector3 _targetForComet;
        private int _incrementDistanceForTarget = 13;

        private void FixedUpdate()
        {
            MoveComet();
        }

        private void MoveComet()
        {
            transform.position = Vector3.MoveTowards(
                (Vector2)transform.position, (Vector2)_targetForComet, _speedFlyComet * Time.deltaTime);
        }

        public void SetTargetForComet(Vector3 target)
        {
            _targetForComet += target * _incrementDistanceForTarget;
        }


    }
}