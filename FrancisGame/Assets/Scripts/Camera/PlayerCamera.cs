using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Francis
{
	public class PlayerCamera : MonoBehaviour
	{

		private Transform m_playerTarget;
		private Vector3 m_desiredPosition;
		private Transform m_planetTransform;

		// Use this for initialization
		void Start()
		{
			m_playerTarget = FindObjectOfType<Player>().transform;
			m_planetTransform = FindObjectOfType<Planet>().transform;
        }

		// Update is called once per frame
		void Update()
		{
			m_desiredPosition = m_playerTarget.position + (m_playerTarget.position - m_planetTransform.position).normalized * 25.0f;
			transform.position = Vector3.MoveTowards(transform.position, m_desiredPosition, 25.0f * Time.deltaTime);
			transform.LookAt(m_planetTransform.position);
        }
	}
}