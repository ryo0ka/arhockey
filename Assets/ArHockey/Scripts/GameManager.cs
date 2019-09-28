using System;
using Photon.Pun;
using UnityEngine;

namespace ArHockey
{
	public class GameManager : MonoBehaviour
	{
		public static GameManager Instance;

		[SerializeField]
		Racket _racket;

		[SerializeField]
		Goal _blueGoal;

		[SerializeField]
		Goal _redGoal;

		void Awake()
		{
			Instance = this;
		}

		public void OnLocalPlayerConnected()
		{
			// master is blue
			_racket.SetTeam(PhotonNetwork.IsMasterClient);
		}

		public void OnRemotePlayerConnected()
		{
		}

		public void OnGoal(bool blue)
		{
			GuiLogView.Instance.Log($"Goal: {blue}");
		}
	}
}