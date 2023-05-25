using UnityEngine;

namespace SpaceShooter
{
    public static class TransformExt
    {
        public static void LookAt2D(this Transform transform, Vector3 positionTarget)
        {
            float signnedAngle = Vector2.SignedAngle(transform.up, (positionTarget - transform.position));

            if (Mathf.Abs(signnedAngle) >= 1e-3f)
            {
                Vector3 angles = transform.eulerAngles;
                angles.z += signnedAngle;
                transform.eulerAngles = angles;
            }
        }
    }
}