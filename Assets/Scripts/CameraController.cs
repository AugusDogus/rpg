using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

	public Transform Target;

	public Vector3 Offset;
	public float ZoomSpeed = 4f;
	public float MinZoom = 5f;
	public float MaxZoom = 15f;

	public float Pitch = 2f;
	
	private float _currentZoom = 10f;

	private float _yawSpeed = 100f;
	private float _currentYaw = 0f;

	private void Update()
	{
		_currentZoom -= Input.GetAxis("Mouse ScrollWheel") * ZoomSpeed;
		_currentZoom = Mathf.Clamp(_currentZoom, MinZoom, MaxZoom);

		_currentYaw -= Input.GetAxis("Horizontal") * _yawSpeed * Time.deltaTime;
	}

	private void LateUpdate()
	{
		transform.position = Target.position - Offset * _currentZoom;
		transform.LookAt(Target.position + Vector3.up * Pitch);
		transform.RotateAround(Target.position, Vector3.up, _currentYaw);
	}
}
