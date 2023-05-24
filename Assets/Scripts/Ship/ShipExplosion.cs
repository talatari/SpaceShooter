using UnityEngine;

namespace SpaceShooter
{
    public class ShipExplosion : MonoBehaviour
    {
        [SerializeField] private GameObject _shipExplosionPrefab;
        [SerializeField] private SpaceShip _spaceShip;

        private float _lifeTimeEffectExplosion = 0.5f;

        private void Start()
        {
            _spaceShip.OnDeath += OnSpaceShipDeath;
        }

        private void OnSpaceShipDeath()
        {
            _spaceShip.OnDeath -= OnSpaceShipDeath;

            var shipExplosion = Instantiate(_shipExplosionPrefab, _spaceShip.transform.position, Quaternion.identity);

            Destroy(shipExplosion, _lifeTimeEffectExplosion);
        }


    }
}