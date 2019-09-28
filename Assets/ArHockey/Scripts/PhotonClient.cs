using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace ArHockey
{
	public class PhotonClient : MonoBehaviourPunCallbacks
	{
		[SerializeField]
		ErrorView _errorView;

		void Start()
		{
			GuiLogView.Instance.Log("connecting to photon server");
			PhotonNetwork.ConnectUsingSettings();
		}

		public override void OnConnectedToMaster()
		{
			GuiLogView.Instance.Log("PhotonClient.OnConnectedToMaster");
			OnJoinedMasterOrLobby();
		}

		public override void OnJoinedLobby()
		{
			GuiLogView.Instance.Log("PhotonClient.OnJoinedLobby");
			OnJoinedMasterOrLobby();
		}

		void OnJoinedMasterOrLobby()
		{
			GuiLogView.Instance.Log("PhotonClient.OnJoinedMasterOrLobby");

			var roomOptions = new RoomOptions
			{
				MaxPlayers = 2,
			};

			PhotonNetwork.JoinOrCreateRoom("arhockey", roomOptions, null);
		}

		public override void OnJoinRoomFailed(short returnCode, string message)
		{
			GuiLogView.Instance.Log($"PhotonClient.OnJoinRoomFailed: {returnCode} {message}");
			_errorView.Show($"OnJoinRoomFailed({returnCode} {message})");
		}

		public override void OnJoinedRoom()
		{
			GuiLogView.Instance.Log("PhotonClient.OnJoinedRoom");
			GameManager.Instance.OnLocalPlayerConnected();
		}

		public override void OnDisconnected(DisconnectCause cause)
		{
			GuiLogView.Instance.Log($"PhotonClient.OnDisconnected: {cause}");
			_errorView.Show($"OnDisconnected({cause})");
		}

		public override void OnPlayerEnteredRoom(Player newPlayer)
		{
			GuiLogView.Instance.Log($"player joined: {newPlayer.NickName}");
			GameManager.Instance.OnRemotePlayerConnected();
		}

		public override void OnPlayerLeftRoom(Player otherPlayer)
		{
			GuiLogView.Instance.Log($"player left: {otherPlayer.NickName}");
			_errorView.Show($"OnPlayerLeftRoom: {otherPlayer.NickName}");
		}
	}
}