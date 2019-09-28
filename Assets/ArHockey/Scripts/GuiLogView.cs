using System.Collections.Generic;
using UnityEngine;

namespace ArHockey
{
	public class GuiLogView : MonoBehaviour
	{
		[SerializeField, Range(0, 20)]
		int _maxLineCount;

		[SerializeField]
		Transform _cameraTransform;

		public static GuiLogView Instance;

		readonly Queue<string> _linesQueue = new Queue<string>();

		void Awake()
		{
			Instance = this;
		}

		void OnGUI()
		{
			SetImguiReferenceResolution();

			GUILayout.BeginVertical("box", GUILayout.Width(300));
			foreach (var line in _linesQueue)
			{
				GUILayout.Label(line);
			}

			GUILayout.EndVertical();

			GUILayout.BeginVertical("box", GUILayout.Width(300));
			GUILayout.Label($"{_cameraTransform.position}, {_cameraTransform.eulerAngles}");
			GUILayout.EndVertical();
		}

		public void Log(string line)
		{
			Debug.Log(line);

			_linesQueue.Enqueue(line);

			while (_linesQueue.Count > _maxLineCount)
			{
				_linesQueue.Dequeue();
			}
		}

		public void SetCameraTransform(Transform cameraTransform)
		{
			_cameraTransform = cameraTransform;
		}

		static void SetImguiReferenceResolution(int width = 375, int height = 667)
		{
			var scale = new Vector2(
				(float) Screen.width / width,
				(float) Screen.height / height);

			GUIUtility.ScaleAroundPivot(scale, Vector2.zero);
		}
	}
}