using UnityEngine;

namespace SpaceShooter
{
    public class Entity : MonoBehaviour
    {
        [Header("Fighter Pilot")]
        [SerializeField] private string _nickname;
        public string Nickname => _nickname;


    }
}