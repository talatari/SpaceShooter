using UnityEngine;

namespace SpaceShooter
{
    public class LevelBoundary : MonoBehaviour
    {
        public static LevelBoundary Instance;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;

            DontDestroyOnLoad(gameObject);
        }


    }
}