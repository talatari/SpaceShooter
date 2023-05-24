using UnityEngine;

namespace SpaceShooter
{
    [RequireComponent(typeof(MeshRenderer))]
    public class Space : MonoBehaviour
    {
        [SerializeField] private float _parallaxPower;
        [SerializeField] private float _textureScale;

        private Material _materialSpace;
        private Vector2 _initialOffset;

        private void Start()
        {
            if (TryGetComponent(out MeshRenderer meshRendererSpace))
            {
                _materialSpace = meshRendererSpace.material;
                _materialSpace.mainTextureScale = Vector2.one * _textureScale;
            }

            _initialOffset = Random.insideUnitCircle;
        }

        private void Update()
        {
            Vector2 offset = _initialOffset;

            offset.x += transform.position.x / transform.localScale.x / _parallaxPower;
            offset.y += transform.position.y / transform.localScale.y / _parallaxPower;

            _materialSpace.mainTextureOffset = offset;
        }


    }
}