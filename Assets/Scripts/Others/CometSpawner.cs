using UnityEngine;

namespace SpaceShooter
{
    public class CometSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _cometPrefab;
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private SpaceShip _spaceShip;

        private float _lifeTimeComet = 30.0f;

        private void Start()
        {
            var comet = Instantiate(
                _cometPrefab, _spawnPoints[Random.Range(0, _spawnPoints.Length)].position, Quaternion.identity);

            Destroy(comet, _lifeTimeComet);
        }


    }
}