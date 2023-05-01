using UnityEngine;

namespace SpaceShooter
{
    public class CometSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _cometPrefab;
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private SpaceShip _spaceShip;
        [SerializeField] private Transform _targetForComet;
        [SerializeField] private CometMovement _cometMovement;

        // TODO: reduce the value to 3 seconds
        private float _lifeTimeComet = 30.0f;

        private void Start()
        {
            SpawnComet();
        }

        private void SpawnComet()
        {
            var randomIndex = Random.Range(0, _spawnPoints.Length);
            Vector2 positionCometWithoutZ = _spawnPoints[randomIndex].position;
            var comet = Instantiate(_cometPrefab, positionCometWithoutZ, Quaternion.identity);

            if (comet.TryGetComponent<CometMovement>(out CometMovement cometMovement))
            {
                cometMovement.SetTargetForComet(_targetForComet.position);
            }

            Destroy(comet, _lifeTimeComet);
        }



    }
}