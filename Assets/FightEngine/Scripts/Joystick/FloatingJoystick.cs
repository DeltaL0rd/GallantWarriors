using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine;

public class FloatingJoystick : MonoBehaviour,IDragHandler,IPointerDownHandler,IPointerUpHandler
{
    public JoyStickDirection joyStickDirection = JoyStickDirection.Both;
    public RectTransform Background;
    public RectTransform Handle;
    [Range(0, 2f)] public float HandleLimit = 1f;
    Vector2 input = Vector2.zero;

    public float Vertical { get { return input.y; } }
    public float Horizontal { get { return input.x; } }
   // public Vector2 direction {get {return input.x,input.y}}
    Vector2 JoyPosition = Vector2.zero;
    
    public void OnPointerDown(PointerEventData eventdata)
    {
        Background.gameObject.SetActive(true);
        OnDrag(eventdata);
        JoyPosition = eventdata.position;
        Background.position = eventdata.position;
        Handle.anchoredPosition = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventdata)
    {
        Vector2 JoyDirection = eventdata.position - JoyPosition;
                               input = (JoyDirection.magnitude>Background.sizeDelta.x/2f)? JoyDirection.normalized: JoyDirection /
            (Background.sizeDelta.x / 2f);
        if (joyStickDirection == JoyStickDirection.Horizontal)
            input = new Vector2(input.x ,0f);
        if (joyStickDirection == JoyStickDirection.Vertical)
            input = new Vector2(0f ,input.y);
        Handle.anchoredPosition = (input * Background.sizeDelta.x / 2f) * HandleLimit;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Background.gameObject.SetActive(false);
        input = Vector2.zero;
        Handle.anchoredPosition = Vector2.zero;
    }
}
