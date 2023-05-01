using UnityEngine;

namespace SpaceShooter
{
    public class CometSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _cometPrefab;
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private SpaceShip _spaceShip;
        [SerializeField] private Transform[] _targetsForComet;
        [SerializeField] private CometMovement _cometMovement;

        // TODO: reduce the value to 3 seconds
        private float _lifeTimeComet = 30.0f;
        private int _limitComet = 100;
        private int _amountComet = 0;

        private void Update()
        {
            if (_amountComet <= _limitComet)
                SpawnComet();
        }

        private void SpawnComet()
        {
            var randomIndex = Random.Range(0, _spawnPoints.Length);
            Vector2 positionCometWithoutZ = _spawnPoints[randomIndex].position;
            var comet = Instantiate(_cometPrefab, positionCometWithoutZ, Quaternion.identity);

            if (comet.TryGetComponent<CometMovement>(out CometMovement cometMovement))
            {
                var randomIndexComet = Random.Range(0, _targetsForComet.Length);
                cometMovement.SetTargetForComet(_targetsForComet[randomIndexComet].position);
            }

            _amountComet++;

            Destroy(comet, _lifeTimeComet);
        }


    }
}