using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Francis
{
	public class CommandPlayerJump : CommandPlayer
	{
		public CommandPlayerJump(float start, float execute, float end, Player player, Vector2 rawInput)
			: base(start, execute, end, player)
		{

		}

		public override void Execute()
		{
			base.Execute();

			if (m_player && m_player.controller)
			{
				m_player.controller.ReceiveJumpInput();
			}
		}
	}
}