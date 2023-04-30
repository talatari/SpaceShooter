using UnityEngine;

namespace SpaceShooter
{
    public partial class ShipMovement : MonoBehaviour
    {
        [SerializeField] private SpaceShip _spaceShip;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private ControlType _controlType;

        private void Start()
        {
            if (Application.isMobilePlatform)
            {
                _controlType = ControlType.Touchscreen;
                _joystick.gameObject.SetActive(true);
            }
            else
            {
                _controlType = ControlType.Keyboard;
                _joystick.gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            if (_spaceShip == null)
                return;

            if (_controlType == ControlType.Keyboard)
                ControlKeyboard();

            if (_controlType == ControlType.Touchscreen)
                ControlTouchscreen();
        }

        private void ControlKeyboard()
        {
            SetThustContol();
            SetTorqueContol();
        }

        private void SetThustContol()
        {
            float thrust = 0.0f;

            if (Input.GetKey(KeyCode.W))
                thrust = 1.0f;

            if (Input.GetKey(KeyCode.S))
                thrust = -1.0f;

            _spaceShip.ThrustControl = thrust;
        }

        private void SetTorqueContol()
        {
            float torque = 0.0f;

            if (Input.GetKey(KeyCode.A))
                torque = 1.0f;

            if (Input.GetKey(KeyCode.D))
                torque = -1.0f;

            _spaceShip.TorqueControl = torque;
        }

        private void ControlTouchscreen()
        {
            var direction = _joystick.PositionJoyStick;

            _spaceShip.ThrustControl = direction.y;
            _spaceShip.TorqueControl = -1 * direction.x;
        }

        public void SetTargetShip(SpaceShip spaceShip)
        {
            _spaceShip = spaceShip;
        }


    }
}