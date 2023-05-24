using UnityEngine;

namespace SpaceShooter
{
    public class LevelBoundaryControl : MonoBehaviour
    {
        private LevelBoundary _levelBoudary;

        private void Start()
        {
            _levelBoudary = LevelBoundary.Instance;
        }

        private void Update()
        {
            if (_levelBoudary == null)
                return;

            float radius = _levelBoudary.Radius;

            if (transform.position.magnitude > radius)
            {
                if (_levelBoudary.LimitMode == LevelBoundary.Mode.Limit)
                {
                    transform.position = transform.position.normalized * radius;
                }

                if (_levelBoudary.LimitMode == LevelBoundary.Mode.Teleport)
                {
                    transform.position = -1 * transform.position.normalized * radius;
                }
            }
        }


    }
}