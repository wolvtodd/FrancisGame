using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Francis
{
	[RequireComponent(typeof(UnityEngine.CharacterController))]
	[RequireComponent(typeof(Player))]
	public class PlayerMotor : MonoBehaviour
	{
		#region Field
		private CharacterController m_characterController = null;
		private Player m_player = null;

		private Vector3 m_currentVelocity = Vector3.zero;
		private Vector3 m_moveVector = Vector3.zero;
		#endregion

		void Awake()
		{
			AwakeComponents();
		}

		void AwakeComponents()
		{
			m_characterController = GetComponent<CharacterController>();
			m_player = GetComponent<Player>();
		}


		public void Move(Vector3 moveVector)
		{
			m_moveVector = moveVector;
		}

		public void UpdateMotor(float dt)
		{
			UpdateMovements(dt);
			m_moveVector = Vector3.zero;
        }

		void UpdateMovements(float dt)
		{
			m_currentVelocity = Vector3.MoveTowards(m_currentVelocity, m_moveVector, m_player.acceleration * dt);

			Vector3 gravityVector = (transform.position - m_player.planet.transform.position).normalized;
			Quaternion rotation = Quaternion.FromToRotation(m_player.planet.transform.up, gravityVector);
			Vector3 actualVector = rotation * m_currentVelocity;
			gravityVector *= m_player.gravity;

			actualVector *= m_player.walkSpeed;

			if (m_characterController && m_player)
				m_characterController.Move(actualVector * dt);

			if (m_moveVector != Vector3.zero)
				transform.rotation = Quaternion.LookRotation(actualVector, -(m_player.planet.transform.position - transform.position).normalized);
        }
	}
}