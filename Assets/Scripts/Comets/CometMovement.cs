using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace SpaceShooter
{
    public class CometMovement : MonoBehaviour
    {
        [SerializeField] private float _speedFlyComet;
        //[SerializeField] private int _incrementDistanceForTarget = 13;

        private Vector3 _targetForComet;
        private Vector3 _currentCometPosition;
        private float _speed;

        private void FixedUpdate()
        {
            MoveComet();
        }

        private void MoveComet()
        {
            _currentCometPosition = transform.position;

            _speed = _speedFlyComet * Time.deltaTime;

            //transform.position = Vector2.MoveTowards(_currentCometPosition, _targetForComet, _speed);

            transform.Translate(_targetForComet * Time.deltaTime);
        }

        public void SetTargetForComet(Vector3 target)
        {
            _targetForComet = target;
        }


    }
}