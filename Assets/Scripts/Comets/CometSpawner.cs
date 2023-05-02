using UnityEngine;

namespace SpaceShooter
{
    public class CometSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _cometPrefab;
        [SerializeField] private SpaceShip _spaceShip;
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private Transform[] _targetsForComet;

        // TODO: reduce the value to 3 seconds
        private float _lifeTimeComet = 5.0f;
        private int _limitComet = 100;
        private int _amountComet = 0;

        private void FixedUpdate()
        {
            if (_amountComet <= _limitComet)
                SpawnComet();
        }

        private void SpawnComet()
        {
            var indexSpawnPoint = Random.Range(0, _spawnPoints.Length);

            Vector2 spawnPositionCometWithoutZ = _spawnPoints[indexSpawnPoint].position;

            var comet = Instantiate(_cometPrefab, spawnPositionCometWithoutZ, Quaternion.identity);

            if (comet.TryGetComponent<CometMovement>(out CometMovement cometMovement))
                cometMovement.SetTargetForComet(_spaceShip.transform.position);

            _amountComet++;

            Destroy(comet, _lifeTimeComet);
        }

        public void SetTargetShip(SpaceShip spaceShip)
        {
            _spaceShip = spaceShip;
        }

    }
}