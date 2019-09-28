using System;
using Photon.Pun;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ArHockey
{
	public class Goal : MonoBehaviourPun
	{
		[SerializeField, ReadOnly]
		Collider _diskCollider;

		[SerializeField, ReadOnly]
		bool _blue;

		void OnTriggerEnter(Collider other)
		{
			if (other == _diskCollider)
			{
				GameManager.Instance.OnGoal(_blue);
			}
		}

		public void RegisterDisk(Collider diskCollider)
		{
			_diskCollider = diskCollider;
		}

		public void SetTeam(bool blue)
		{
			_blue = blue;
		}
	}
}