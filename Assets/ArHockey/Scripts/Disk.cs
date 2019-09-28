using System;
using System.Linq;
using Photon.Pun;
using UnityEngine;

namespace ArHockey
{
	public class Disk : MonoBehaviourPun
	{
		[SerializeField]
		Rigidbody _rigidbody;

		[SerializeField]
		AudioSource _audioSource;

		[SerializeField]
		AudioClip _startAudio;

		[SerializeField]
		AudioClip _racketHitAudio;

		[SerializeField]
		AudioClip _wallHitAudio;

		[SerializeField]
		AudioClip _gameAudio;

		void OnCollisionEnter(Collision collision)
		{
			var normal = collision.contacts.First().normal;
			_rigidbody.AddForce(normal * 10);

			if (collision.collider.CompareTag("Racket"))
			{
				PlayAudio(_racketHitAudio);
				iOSHapticFeedback.Instance.Trigger(iOSHapticFeedback.iOSFeedbackType.ImpactHeavy);
			}
			else
			{
				PlayAudio(_wallHitAudio);
			}
		}

		public void PlayStartAudio()
		{
			PlayAudio(_startAudio);
		}

		public void PlayGameoverAudio()
		{
			PlayAudio(_gameAudio);
		}

		void PlayAudio(AudioClip clip)
		{
			_audioSource.Stop();
			_audioSource.clip = clip;
			_audioSource.Play();
		}
	}
}