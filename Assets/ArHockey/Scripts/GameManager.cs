using Photon.Pun;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ArHockey
{
	public class GameManager : MonoBehaviourPun
	{
		public static GameManager Instance;

		[SerializeField, AssetsOnly]
		Racket _gamePlayerPrefab;

		[SerializeField, AssetsOnly]
		Disk _diskPrefab;

		[SerializeField]
		Transform _diskRoot;

		[SerializeField]
		Transform _camera;

		[SerializeField]
		Goal _blueGoal;

		[SerializeField]
		Goal _redGoal;

		[SerializeField]
		GameResultView _resultView;

		int _connectedPlayers;
		Disk _disk;

		void Awake()
		{
			Instance = this;
		}

		void Start()
		{
			_blueGoal.SetTeam(true);
			_redGoal.SetTeam(false);
		}

		public void OnLocalPlayerConnected()
		{
			var localPlayerGo = PhotonNetwork.Instantiate(_gamePlayerPrefab.name, Vector3.zero, Quaternion.identity);
			var localPlayer = localPlayerGo.GetComponent<Racket>();
			localPlayer.SetRoot(_camera);

			if (++_connectedPlayers == 2)
			{
				StartGame();
			}
		}

		public void OnRemotePlayerConnected()
		{
			if (++_connectedPlayers == 2)
			{
				StartGame();
			}
		}

		public void OnGoal(bool loser)
		{
			var winner = !loser;
			photonView.RPC(nameof(DoOnGoal), RpcTarget.All, winner);
		}

		[PunRPC]
		void DoOnGoal(bool winner)
		{
			GuiLogView.Instance.Log($"Goal: {winner}");

			_resultView.Show(winner);
		}

		public void Restart()
		{
			// reload this scene 
			SceneManager.LoadScene(0);
		}

		public void Replay()
		{
			photonView.RPC(nameof(DoReplay), RpcTarget.All);
		}

		void StartGame()
		{
			GuiLogView.Instance.Log("Game started!");

			if (PhotonNetwork.IsMasterClient)
			{
				var disk = PhotonNetwork.Instantiate(_diskPrefab.name, Vector3.zero, Quaternion.identity);
				disk.transform.position = _diskRoot.position;
				photonView.RPC(nameof(OnDiskSpawned), RpcTarget.All);
			}
		}

		[PunRPC]
		void OnDiskSpawned()
		{
			_disk = FindObjectOfType<Disk>();
			var diskCollider = _disk.GetComponent<Collider>();
			_blueGoal.SetDisk(diskCollider);
			_redGoal.SetDisk(diskCollider);
		}

		[PunRPC]
		void DoReplay()
		{
			_resultView.Hide();

			if (_disk != null && _disk)
			{
				DestroyImmediate(_disk.gameObject);
			}

			StartGame();
		}
	}
}