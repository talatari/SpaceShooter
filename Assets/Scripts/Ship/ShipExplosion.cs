using UnityEngine;

namespace SpaceShooter
{
    public class ShipExplosion : MonoBehaviour
    {
        [SerializeField] private GameObject _shipExplosionPrefab;
        [SerializeField] private SpaceShip _spaceShip;

        private float _lifeTime = 1.5f;

        private void Start()
        {
            _spaceShip.OnDeath += OnSpaceShipDeath;
        }

        private void OnSpaceShipDeath()
        {
            _spaceShip.OnDeath -= OnSpaceShipDeath;

            var newSpaceShip = Instantiate(_shipExplosionPrefab, _spaceShip.transform.position, Quaternion.identity);

            Destroy(newSpaceShip, _lifeTime);
        }


    }
}