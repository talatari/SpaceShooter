using UnityEngine;

namespace SpaceShooter
{
    public class SyncSpaceWithShip : MonoBehaviour
    {
        [SerializeField] private Transform _transformTarget;

        private void Update()
        {
            transform.position = new Vector3(
                _transformTarget.position.x, _transformTarget.position.y, transform.position.z);
        }


    }
}