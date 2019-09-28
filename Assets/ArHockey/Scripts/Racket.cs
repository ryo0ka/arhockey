using System;
using Photon.Pun;
using UnityEngine;

namespace ArHockey
{
	public class Racket : MonoBehaviourPun
	{
		[SerializeField]
		Transform _root;

		[SerializeField]
		Material _blueMat;

		[SerializeField]
		Material _redMat;

		[SerializeField]
		MeshRenderer _meshRenderer;

		[SerializeField]
		Rigidbody _rigidbody;

		void Start()
		{
			// master is blue
			var blue = photonView.Owner.IsMasterClient;
			_meshRenderer.material = blue ? _blueMat : _redMat;
		}

		public void SetRoot(Transform root)
		{
			_root = root;
		}

		void FixedUpdate()
		{
			if (photonView.IsMine)
			{
				_rigidbody.MovePosition(_root.position);
				_rigidbody.MoveRotation(_root.rotation);
			}
		}
	}
}