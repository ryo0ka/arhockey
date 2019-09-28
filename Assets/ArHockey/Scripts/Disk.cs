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

		void OnCollisionEnter(Collision collision)
		{
			var normal = collision.contacts.First().normal;
			_rigidbody.AddForce(normal * 10);
		}
	}
}