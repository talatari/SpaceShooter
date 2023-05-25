using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace SpaceShooter
{
    public class UILevelText : MonoBehaviour
    {
        [SerializeField] private TMP_Text _uILevel;

        private string _levelText = "Level ";

        private void Start()
        {
            _uILevel.text = _levelText + (SceneManager.GetActiveScene().buildIndex + 1).ToString();
        }
    }
}