using UnityEngine;

namespace SpaceShooter
{
    public class ShipExplosionSound : MonoBehaviour
    {
        [SerializeField] private SpaceShip _spaceShip;
        [SerializeField] private AudioSource _explosionSound;

        private void Start()
        {
            _spaceShip.OnDeath += OnSpaceShipDeath;
        }

        private void OnSpaceShipDeath()
        {
            _spaceShip.OnDeath -= OnSpaceShipDeath;

            _explosionSound.Play();
        }

        public void SetTargetShip(SpaceShip spaceShip)
        {
            _spaceShip = spaceShip;

            _spaceShip.OnDeath += OnSpaceShipDeath;
        }


    }
}