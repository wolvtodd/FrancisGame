using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Francis
{
	public class CommandPlayer : CommandBase
	{
		#region Field
		protected Player m_player;
		#endregion

		public CommandPlayer(float start, float execute, float end, Player player)
			: base(start, execute, end)
		{
			m_player = player;
		}

		public override void Execute() { }
	}
}