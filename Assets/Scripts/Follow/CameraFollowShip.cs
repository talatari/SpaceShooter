using UnityEngine;

namespace SpaceShooter
{
    public class CameraFollowShip : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _targetPointToCamera;
        [SerializeField] private Transform _targetPointToCometSpawner;
        [SerializeField] private float _interpolationLinear;
        [SerializeField] private float _interpolationAngular;
        [SerializeField] private float _cameraOffsetZ;
        [SerializeField] private float _forwardOffset;

        private Vector2 _cameraPosition;
        private Vector2 _targetPosition;
        private Vector2 _newCameraPosition;

        private void FixedUpdate()
        {
            if (_camera == null || _targetPointToCamera == null || _targetPointToCometSpawner == null)
                return;

            _cameraPosition = _camera.transform.position;

            _targetPosition = _targetPointToCamera.position + _targetPointToCamera.transform.up * _forwardOffset;

            _newCameraPosition = Vector2.Lerp(_cameraPosition, _targetPosition, _interpolationAngular * Time.deltaTime);

            _camera.transform.position = new Vector3(_newCameraPosition.x, _newCameraPosition.y, _cameraOffsetZ);

            _targetPointToCometSpawner.transform.position = _camera.transform.position;

            if (_interpolationAngular > 0)
            {
                _camera.transform.rotation = Quaternion.Slerp(
                    _camera.transform.rotation, _targetPointToCamera.rotation, _interpolationAngular * Time.deltaTime);

                _targetPointToCometSpawner.transform.rotation = _camera.transform.rotation;
            }
        }

        public void SetTarget(Transform newTransform)
        {
            _targetPointToCamera = newTransform;
        }


    }
}