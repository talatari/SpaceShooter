using UnityEngine;

namespace SpaceShooter
{
    public class CometSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _cometPrefab;
        [SerializeField] private SpaceShip _spaceShip;
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private Transform[] _targetsForComet;
        [SerializeField] private float _cooldownRespawn;

        private float _lifeTimeComet = 5.0f;
        private int _limitComet = 100;
        private int _amountComet = 0;
        private float _timeLeft;

        private void Start() => _timeLeft = _cooldownRespawn;

        private void FixedUpdate()
        {
            OnTimer();

            if (_amountComet <= _limitComet && _timeLeft == 0)
            {
                SpawnComet();
            }
        }

        private void OnTimer()
        {
            if (_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;

                if (_timeLeft < 0) _timeLeft = 0;
            }
            else
            {
                _timeLeft = _cooldownRespawn;
            }
        }

        private void SpawnComet()
        {
            int indexSpawnPoint = Random.Range(0, _spawnPoints.Length);

            Vector2 spawnPositionCometWithoutZ = _spawnPoints[indexSpawnPoint].position;

            var comet = Instantiate(_cometPrefab, spawnPositionCometWithoutZ, Quaternion.identity);

            if (comet.TryGetComponent(out CometMovement cometMovement))
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