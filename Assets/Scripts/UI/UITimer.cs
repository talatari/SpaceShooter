using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace SpaceShooter
{
    public class UITimer : MonoBehaviour
    {
        [SerializeField] private float _seconds;
        [SerializeField] private TMP_Text _timerText;
        [SerializeField] private SpaceShip _spaceShip;

        private float _timeLeft;
        private bool _timerOn;

        private void Start()
        {
            _timeLeft = _seconds;
            _timerOn = true;

            _spaceShip.OnDeath += ResetTimer;
        }

        private void Update()
        {
            if (_timerOn)
            {
                if (_timeLeft > 0)
                {
                    _timeLeft -= Time.deltaTime;
                    UpdateTimeText();
                }
                else
                {
                    _timeLeft = _seconds;
                    _timerOn = false;
                }
            }
        }

        private void UpdateTimeText()
        {
            if (_timeLeft < 0)
                _timeLeft = 0;

            float minutes = Mathf.FloorToInt(_timeLeft / 60);
            float seconds = Mathf.FloorToInt(_timeLeft % 60);

            _timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);

            if (_timeLeft == 0)
            {
                SceneManager.LoadScene(2);
            }
        }

        public void ResetTimer()
        {
            _timeLeft = _seconds;
        }

        public void SetTargetShip(SpaceShip spaceShip)
        {
            _spaceShip = spaceShip;

            _spaceShip.OnDeath += ResetTimer;
        }

    }
}