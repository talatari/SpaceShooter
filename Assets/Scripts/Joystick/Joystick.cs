using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace SpaceShooter
{
    public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
    {
        [SerializeField] private Image _imageJoyStickBackGround;
        [SerializeField] private Image _imageJoyStick;

        public Vector2 PositionJoyStick { get; private set; }

        public void OnDrag(PointerEventData eventData)
        {
            Vector2 position = Vector2.zero;

            float sizeDeltaX = _imageJoyStickBackGround.rectTransform.sizeDelta.x;
            float sizeDeltaY = _imageJoyStickBackGround.rectTransform.sizeDelta.y;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                rect: _imageJoyStickBackGround.rectTransform,
                screenPoint: eventData.position,
                cam: eventData.pressEventCamera,
                localPoint: out position);

            position.x = position.x / sizeDeltaX;
            position.y = position.y / sizeDeltaY;

            position.x = position.x * 2 - 1;
            position.y = position.y * 2 - 1;

            PositionJoyStick = new Vector2(position.x, position.y);

            if (PositionJoyStick.magnitude > 1)
            {
                PositionJoyStick = PositionJoyStick.normalized;
            }

            float offsetX = (sizeDeltaX / 2) - _imageJoyStick.rectTransform.sizeDelta.x / 2;
            float offsetY = (sizeDeltaY / 2) - _imageJoyStick.rectTransform.sizeDelta.y / 2;

            _imageJoyStick.rectTransform.anchoredPosition = new Vector2(
                PositionJoyStick.x * offsetX,
                PositionJoyStick.y * offsetY);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnDrag(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            PositionJoyStick = Vector2.zero;
            _imageJoyStick.rectTransform.anchoredPosition = Vector2.zero;
        }



    }
}