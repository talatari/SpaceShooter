using UnityEngine;

namespace SpaceShooter
{
    public class CometMovement : MonoBehaviour
    {
        [SerializeField] private float _speedFlyComet;
        [SerializeField] private int _incrementDistanceForTarget = 13;

        private Vector2 _targetForComet;

        private void FixedUpdate()
        {
            MoveComet();
        }

        private void MoveComet()
        {
            Vector2 currentCoemtPosition = transform.position;

            float speed = _speedFlyComet * Time.deltaTime;

            transform.position = Vector3.MoveTowards(currentCoemtPosition, _targetForComet, speed);
        }

        public void SetTargetForComet(Vector2 target)
        {
            _targetForComet += target * _incrementDistanceForTarget;
        }


    }
}