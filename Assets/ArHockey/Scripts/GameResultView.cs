using UnityEngine;
using UnityEngine.UI;

namespace ArHockey
{
	public class GameResultView : MonoBehaviour
	{
		[SerializeField]
		Text _resultText;

		bool _initialized;

		void Start()
		{
			if (!_initialized)
			{
				_initialized = true;
				gameObject.SetActive(false);
			}
		}

		public void Show(bool blue)
		{
			gameObject.SetActive(true);
			_resultText.text = blue ? "BLUE" : "RED";
		}

		public void Hide()
		{
			gameObject.SetActive(false);
		}
	}
}