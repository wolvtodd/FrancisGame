using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Francis
{
	public class CommandPlayerMovement : CommandPlayer
	{
		#region Field
		private Vector2 m_rawInput = Vector2.zero;
		#endregion

		public CommandPlayerMovement(float start, float execute, float end, Player player, Vector2 rawInput) 
			: base(start, execute, end, player)
		{
			m_rawInput = rawInput;
        }

		public override void Execute()
		{
			base.Execute();

			if (m_player && m_player.controller)
			{
				m_player.controller.ReceiveMovementInput(m_rawInput);
			}
		}
	}
}