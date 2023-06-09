using UnityEngine;

namespace SpaceShooter
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private int _amountLives;
        [SerializeField] private SpaceShip _spaceShip;
        [SerializeField] private GameObject _playerSpaceShipPrefab;
        [SerializeField] private CameraFollowShip _cameraFollowShip;
        [SerializeField] private ShipMovement _shipMovement;
        [SerializeField] private ShipExplosionSound _shipExplosionSound;
        [SerializeField] private UITimer _uITimer;
        [SerializeField] private CometSpawner _cometSpawner;

        private Vector3 _startPosition;
        private Quaternion _startRotation;

        private void Start()
        {
            _spaceShip.OnDeath += OnSpaceShipDeath;

            _startPosition = _spaceShip.transform.position;
            _startRotation = _spaceShip.transform.rotation;
        }

        private void OnSpaceShipDeath()
        {
            _spaceShip.OnDeath -= OnSpaceShipDeath;

            // TODO: reducing the number of lives
            // _amountLives--;
            _amountLives++;

            if (_amountLives > 0 && _amountLives < 50)
                RespawnNewSpaceShip();
        }

        private void RespawnNewSpaceShip()
        {
            var newSpaceShip = Instantiate(_playerSpaceShipPrefab, _startPosition, _startRotation);

            if (newSpaceShip.TryGetComponent(out SpaceShip spaceShip))
            {
                spaceShip.OnDeath += OnSpaceShipDeath;

                _cameraFollowShip.SetTarget(spaceShip.transform);
                _shipMovement.SetTargetShip(spaceShip);
                _shipExplosionSound.SetTargetShip(spaceShip);
                _uITimer.SetTargetShip(spaceShip);

                if (_cometSpawner != null)
                    _cometSpawner.SetTargetShip(spaceShip);
            }
        }


    }
}