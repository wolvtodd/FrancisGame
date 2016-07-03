using UnityEngine;
using System.Collections;

public class RoomRotator : MonoBehaviour
{
	[SerializeField]
	private Vector3 m_frontDirection = new Vector3(0.0f, 0.0f, -1.0f);

	void Start()
	{

	}

	void Update()
	{
		Debug.Log(m_frontDirection);
		UpdateRotation();
	}

	void UpdateInput()
	{
		float deadZone = 0.1f;
		if (Mathf.Abs(Input.GetAxis("Horizontal")) > deadZone)
		{

		}
		if (Mathf.Abs(Input.GetAxis("Vertical")) > deadZone)
		{

		}
	}

	void UpdateRotation()
	{
		transform.rotation = Quaternion.LookRotation(m_frontDirection, Vector3.up);
	}
}