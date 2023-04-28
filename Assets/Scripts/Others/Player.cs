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

        private void Start()
        {
            _spaceShip.OnDeath += OnSpaceShipDeath;
        }

        private void OnSpaceShipDeath()
        {
            _spaceShip.OnDeath -= OnSpaceShipDeath;

            _amountLives--;

            if (_amountLives > 0)
                RespawnNewSpaceShip();
        }

        private void RespawnNewSpaceShip()
        {
            var newSpaceShip = Instantiate(_playerSpaceShipPrefab);

            if (newSpaceShip.TryGetComponent<SpaceShip>(out SpaceShip spaceShip))
            {
                _spaceShip = spaceShip;
                _spaceShip.OnDeath += OnSpaceShipDeath;

                _cameraFollowShip.SetTarget(_spaceShip.transform);
                _shipMovement.SetTargetShip(_spaceShip);
            }
        }


    }
}