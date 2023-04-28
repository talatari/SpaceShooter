using UnityEngine;

namespace SpaceShooter
{
    public class CameraFollowShip : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _targetPointToCamera;
        [SerializeField] private float _interpolationLinear;
        [SerializeField] private float _interpolationAngular;
        [SerializeField] private float _cameraOffsetZ;
        [SerializeField] private float _forwardOffset;

        private void FixedUpdate()
        {
            if (_camera == null || _targetPointToCamera == null)
            {
                //Debug.Log("Camera Or Transform drop in CameraFollowShip.Update()");
                return;
            }

            // TODO: refactoring all call transform in cash links;

            Vector2 cameraPosition = _camera.transform.position;
            Vector2 targetPosition = _targetPointToCamera.position + _targetPointToCamera.transform.up * _forwardOffset;

            Vector2 newCameraPosition = Vector2.Lerp(
                cameraPosition, targetPosition, _interpolationAngular * Time.deltaTime);

            _camera.transform.position = new Vector3(
                newCameraPosition.x, newCameraPosition.y, _cameraOffsetZ);

            if (_interpolationAngular > 0)
            {
                _camera.transform.rotation = Quaternion.Slerp(
                    _camera.transform.rotation, _targetPointToCamera.rotation, _interpolationAngular * Time.deltaTime);
            }
        }

        public void SetTarget(Transform newTransform)
        {
            _targetPointToCamera = newTransform;
        }


    }
}