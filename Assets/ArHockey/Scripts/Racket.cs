using Photon.Pun;
using UnityEngine;

namespace ArHockey
{
	public class Racket : MonoBehaviourPun
	{
		[SerializeField]
		Material _blueMat;

		[SerializeField]
		Material _redMat;

		[SerializeField]
		MeshRenderer _meshRenderer;

		public void SetTeam(bool blue)
		{
			_meshRenderer.material = blue ? _blueMat : _redMat;
		}
	}
}