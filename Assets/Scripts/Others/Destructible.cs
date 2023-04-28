using UnityEngine;

namespace SpaceShooter
{
    public class Destructible : Entity
    {
        [Header("Space Ship")]
        [SerializeField] private bool _indestructible;
        [SerializeField] private int _hitPoints;

        public delegate void EventOnDeath();
        public event EventOnDeath OnDeath;

        public bool IsIndestructible => _indestructible;
        public int HitPoints => _currentHitPoints;
        private int _currentHitPoints;

        protected virtual void Start()
        {
            _currentHitPoints = _hitPoints;
        }

        public void ApplyDamage(int damage)
        {
            if (_indestructible)
                return;

            _currentHitPoints -= damage;
            _hitPoints = _currentHitPoints;

            if (_currentHitPoints <= 0)
                Death();
        }

        protected virtual void Death()
        {
            OnDeath?.Invoke();

            Destroy(gameObject);
        }


    }
}