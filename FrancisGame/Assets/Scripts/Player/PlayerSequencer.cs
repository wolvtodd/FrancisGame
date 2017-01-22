using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Francis
{
	public class PlayerSequencer : MonoBehaviour
	{
		#region Field
		private List<CommandPlayer> m_commands = null;

		#endregion

		void Awake()
		{
			m_commands = new List<CommandPlayer>();
		}

		public void UpdateSequencer(float dt)
		{
			float currentTime = Time.time;

			if (m_commands != null)
			{
				for (int i = 0; i < m_commands.Count; ++i)
				{
					if (m_commands[i] != null && m_commands[i].executeTime <= currentTime)
					{
						m_commands[i].Execute();
						m_commands.RemoveAt(i);
					}
				}
			}
		}

		public void AddCommand(CommandPlayer command)
		{
			if (m_commands != null && command != null)
			{
				m_commands.Add(command);
			}
		}
	}
}