using System;
using UnityEngine;
using UnityEngine.UI;

namespace ArHockey
{
	public class ErrorView : MonoBehaviour
	{
		[SerializeField]
		GameObject _errorView;

		[SerializeField]
		Text _errorText;

		[SerializeField]
		Button _okButton;

		bool _initialized;

		void Start()
		{
			if (!_initialized)
			{
				_initialized = true;
				_errorView.SetActive(false);
			}
			
			_okButton.onClick.AddListener(() =>
			{
				_errorView.SetActive(false);
			});
		}

		public void Show(string message)
		{
			_initialized = true;
			_errorView.SetActive(true);
			_errorText.text = message;
		}
	}
}