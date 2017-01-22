using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Francis
{
	public class InputInterface : MonoBehaviour
	{
		[System.Serializable]
		public struct AxisSetting
		{
			public enum EAxisType
			{
				LeftAnalog,
				RightAnalog,
				LeftTrigger,
				RightTrigger,

				Unknown,
			}

			public string		name;
			public EAxisType	axisType;
			public float		threshold;
		}


		[System.Serializable]
		public struct ButtonSetting
		{
			public enum EButtonEvent
			{
				OnButtonDown,
				OnButtonHold,
				OnButtonUp,

				Unknown,
			}

			public string		name;
			public string		buttonName;
			public EButtonEvent buttonEvent;
		}

		[System.Serializable]
		public struct KeySetting
		{
			public enum EKeyEvent
			{
				OnKeyDown,
				OnKeyHold,
				OnKeyUp,

				Unknown,
			}

			public string		name;
			public string		keyName;
			public EKeyEvent	keyEvent;
		}

		#region Exposed
		public List<AxisSetting>	axisSettings	= null;
		public List<ButtonSetting>	buttonSettings	= null;
		public List<KeySetting>		keySettings		= null;
		#endregion
	}
}