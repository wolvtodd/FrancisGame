using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Francis
{
	[RequireComponent(typeof(PlayerController))]
	[RequireComponent(typeof(PlayerMotor))]
	[RequireComponent(typeof(PlayerSequencer))]
	public class Player : MonoBehaviour
	{
		#region Exposed
		public float walkSpeed		= 5.0f;
		public float runSpeed		= 10.0f;
		public float acceleration	= 10.0f;
		public float gravity		= 50.0f;
		public float jumpSpeed		= 20.0f;
		#endregion

		#region Field
		[HideInInspector] public PlayerController	controller = null;
		[HideInInspector] public PlayerMotor		motor = null;
		[HideInInspector] public PlayerSequencer	sequencer = null;

		[HideInInspector] public Planet planet;
		#endregion

		void Awake()
		{
			AwakeComponents();

			planet = FindObjectOfType<Planet>();
        }

		void AwakeComponents()
		{
			controller = GetComponent<PlayerController>();
			motor = GetComponent<PlayerMotor>();
			sequencer = GetComponent<PlayerSequencer>();
		}

		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{
			float dt = Time.deltaTime;

			if (controller)
				controller.UpdateController(dt);

			if (sequencer)
				sequencer.UpdateSequencer(dt);

			if (motor)
				motor.UpdateMotor(dt);
        }
	}
}