using UnityEngine;

namespace SpaceShooter
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class SpaceShip : Destructible
    {
        [SerializeField] private float _mass;
        [SerializeField] private float _thrust;
        [SerializeField] private float _mobility;
        [SerializeField] private float _maxLinearVelocity;
        [SerializeField] private float _maxAngularVelocity;
        [SerializeField] private float _inertia = 1.0f;

        private Rigidbody2D _rigiBodySpaceShip;
        private float _fixedDeltaTime;

        public float ThrustControl { get; set; }
        public float TorqueControl { get; set; }

        protected override void Start()
        {
            base.Start();

            if (TryGetComponent(out Rigidbody2D rigiBodySpaceShip))
            {
                _rigiBodySpaceShip = rigiBodySpaceShip;
                _rigiBodySpaceShip.mass = _mass;
                _rigiBodySpaceShip.inertia = _inertia;
            }
        }

        private void FixedUpdate()
        {
            UpdateRigidBodySpaceShip();
        }

        private void UpdateRigidBodySpaceShip()
        {
            _fixedDeltaTime = Time.fixedDeltaTime;

            _rigiBodySpaceShip.AddForce(
                force: ThrustControl * _thrust * transform.up * _fixedDeltaTime,
                mode: ForceMode2D.Force);

            _rigiBodySpaceShip.AddForce(
                force: -1 * _rigiBodySpaceShip.velocity * (_thrust / _maxLinearVelocity) * _fixedDeltaTime,
                mode: ForceMode2D.Force);

            _rigiBodySpaceShip.AddTorque(
                torque: TorqueControl * _mobility * _fixedDeltaTime,
                mode: ForceMode2D.Force);

            _rigiBodySpaceShip.AddTorque(
                torque: -1 * _rigiBodySpaceShip.angularVelocity * (_mobility / _maxAngularVelocity) * _fixedDeltaTime,
                mode: ForceMode2D.Force);
        }


    }
}