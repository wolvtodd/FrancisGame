using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Francis
{
	[RequireComponent(typeof(Player))]
	public class PlayerController : MonoBehaviour
	{
		#region Field
		private Player m_player = null;
		#endregion

		void Awake()
		{
			AwakeComponents();
        }

		void AwakeComponents()
		{
			m_player = GetComponent<Player>();
		}

		public void ReceiveMovementInput(Vector2 rawInput)
		{
			Vector3 moveVector = ConvertMovementInput(rawInput);
			if (m_player && m_player.motor)
			{
				m_player.motor.Move(moveVector);
			}
		}

		public void ReceiveJumpInput()
		{
			if (m_player && m_player.motor)
			{
				//m_player.motor.Jump();
			}
		}

		Vector3 ConvertMovementInput(Vector2 rawInput)
		{
			Vector3 result = Vector3.zero;
			Vector3 direction = new Vector3(rawInput.x, 0.0f, rawInput.y);
			float length = rawInput.magnitude;

			Camera mainCam = Camera.main;
			if (mainCam)
			{
				direction.Normalize();
				direction = mainCam.transform.TransformDirection(direction);
				direction.y = 0.0f;
				direction.Normalize();

				result = direction * length;
			}

			return result;
		}


		// remove these methods
		public void UpdateController(float dt)
		{
			UpdateMovementInput();
			UpdateJumpInput();
		}

		void UpdateMovementInput()
		{
			const float threshold = 0.1f;
			Vector2 rawInput = Vector2.zero;

			float horizontal = Input.GetAxis("Horizontal");
			if (Mathf.Abs(horizontal) > threshold)
				rawInput.x = horizontal;

			float vertical = Input.GetAxis("Vertical");
			if (Mathf.Abs(vertical) > threshold)
				rawInput.y = vertical;

			if (rawInput.magnitude > 0.0f)
			{
				if (rawInput.magnitude > 1.0f)
					rawInput.Normalize();

				if (m_player && m_player.sequencer)
				{
					float time = Time.time;
					CommandPlayerMovement command = new CommandPlayerMovement(time, time, time, m_player, rawInput);
					m_player.sequencer.AddCommand(command);
				}
			}
		}

		void UpdateJumpInput()
		{
			if (Input.GetButtonDown("Jump"))
			{
				if (m_player && m_player.sequencer)
				{
					// add jump command
				}
			}
		}
	}
}