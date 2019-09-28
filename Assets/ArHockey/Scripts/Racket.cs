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

		public void SetTeam(bool blue)
		{
			_meshRenderer.material = blue ? _blueMat : _redMat;
		}

		void FixedUpdate()
		{
			_rigidbody.MovePosition(_root.position);
			_rigidbody.MoveRotation(_root.rotation);
		}
	}
}