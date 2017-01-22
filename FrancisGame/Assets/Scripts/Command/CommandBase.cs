using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Francis
{
	public abstract class CommandBase
	{
		#region Field
		public float startTime;
		public float executeTime;
		public float endTime;

		protected float m_currentTime;
		#endregion

		public CommandBase(float start, float execute, float end)
		{
			startTime = start;
			executeTime = execute;
			endTime = end;

			m_currentTime = startTime;
		}

		public abstract void Execute();
	}
}