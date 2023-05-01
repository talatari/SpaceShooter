using UnityEngine;

namespace SpaceShooter
{
    public class CometSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _cometPrefab;
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private SpaceShip _spaceShip;

        // TODO: reduce the value to 3 seconds
        private float _lifeTimeComet = 30.0f;

        private void Start()
        {
            var randomIndex = Random.Range(0, _spawnPoints.Length);

            var comet = Instantiate(
                _cometPrefab, _spawnPoints[randomIndex].position, Quaternion.identity);

            Destroy(comet, _lifeTimeComet);
        }


    }
}