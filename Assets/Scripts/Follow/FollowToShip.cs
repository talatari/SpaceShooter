using UnityEngine;

namespace SpaceShooter
{
    public class FollowToShip : MonoBehaviour
    {
        public Transform _objectFollow;

        private Vector3 _deltaPosition;

        private void Start()
        {
            _deltaPosition = transform.position - _objectFollow.position;
        }

        private void Update()
        {
            transform.position = _objectFollow.position + _deltaPosition;
        }


    }
}