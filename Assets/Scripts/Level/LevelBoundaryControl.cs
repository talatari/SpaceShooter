using UnityEngine;

namespace SpaceShooter
{
    public class LevelBoundaryControl : MonoBehaviour
    {
        private void Update()
        {
            var levelBoudary = LevelBoundary.Instance;

            if (levelBoudary == null)
                return;

            var radius = levelBoudary.Radius;

            if (transform.position.magnitude > radius)
            {
                if (levelBoudary.LimitMode == LevelBoundary.Mode.Limit)
                {
                    transform.position = transform.position.normalized * radius;
                }

                if (levelBoudary.LimitMode == LevelBoundary.Mode.Teleport)
                {
                    transform.position = -1.0f * transform.position.normalized * radius;
                }
            }
        }



    }
}