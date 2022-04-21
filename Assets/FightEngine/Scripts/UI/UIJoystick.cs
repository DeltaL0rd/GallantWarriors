using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(RectTransform))]
public class UIJoystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler {
	
	public RectTransform handle;
	public float radius = 40f;
	public float autoReturnSpeed = 8f;
	private bool returnToStartPos;
	public RectTransform joystick;
	private InputManager inputmanager;
	public RectTransform parent;
	public Image handleImg;
	void OnEnable(){
		returnToStartPos = true;
		//handle.transform.SetParent(transform);
	}
	private void Start()
	{
		handleImg.enabled = false;
	}
	void Update() {
		if(inputmanager == null) inputmanager = GameObject.FindObjectOfType<InputManager>();

		//return to start position
		if (returnToStartPos) {
			if (handle.anchoredPosition.magnitude > Mathf.Epsilon) {
				handle.anchoredPosition -= new Vector2 (handle.anchoredPosition.x * autoReturnSpeed, handle.anchoredPosition.y * autoReturnSpeed) * Time.deltaTime;
				inputmanager.OnTouchScreenJoystickEvent(Vector2.zero);
			} else {
				returnToStartPos = false;
			}
		}
	}

	//return coordinates
	public Vector2 Coordinates {
		get	{
			if (handle.anchoredPosition.magnitude < radius){
				return handle.anchoredPosition / radius;
			}
			return handle.anchoredPosition.normalized;
		}
	}

	//touch down
	void IPointerDownHandler.OnPointerDown(PointerEventData eventData) {
		handleImg.enabled = true;
		Vector2 anchoredPos;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(parent, Input.mousePosition, null, out anchoredPos);
		{
			joystick.anchoredPosition = anchoredPos;
		}
		returnToStartPos = false;
		var handleOffset = GetJoystickOffset(eventData);
		handle.anchoredPosition = handleOffset;
		if(inputmanager != null) inputmanager.OnTouchScreenJoystickEvent(handleOffset.normalized);
	}

	//touch drag
	void IDragHandler.OnDrag(PointerEventData eventData) {
		var handleOffset = GetJoystickOffset(eventData);
		if(inputmanager != null) inputmanager.OnTouchScreenJoystickEvent(handleOffset.normalized);
	}

	//touch up
	void IPointerUpHandler.OnPointerUp(PointerEventData eventData) {
		handleImg.enabled = false;
		returnToStartPos = true;
	}

	//get offset
	public Vector2 GetJoystickOffset(PointerEventData eventData) {
		
		Vector3 globalHandle;
		if (RectTransformUtility.ScreenPointToWorldPointInRectangle (joystick, eventData.position, eventData.pressEventCamera, out globalHandle)) {
			handle.position = globalHandle;
		}

		var handleOffset = handle.anchoredPosition;
		if (handleOffset.magnitude > radius) {
			handleOffset = handleOffset.normalized * radius;
			handle.anchoredPosition = handleOffset;
		}
		return handleOffset;
	}
}