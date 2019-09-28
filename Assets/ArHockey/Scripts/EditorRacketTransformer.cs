using UnityEngine;

namespace ArHockey
{
	public class EditorRacketTransformer : MonoBehaviour
	{
		[SerializeField]
		Rigidbody _racket;

		[SerializeField]
		float _strength;

		void FixedUpdate()
		{
			var delta = Vector3.zero;
			var deltaStrength = _strength * Time.fixedDeltaTime;

			if (Input.GetKey(KeyCode.W))
			{
				delta.z += deltaStrength;
			}

			if (Input.GetKey(KeyCode.A))
			{
				delta.x += deltaStrength;
			}

			if (Input.GetKey(KeyCode.S))
			{
				delta.z -= deltaStrength;
			}

			if (Input.GetKey(KeyCode.D))
			{
				delta.x -= deltaStrength;
			}

			_racket.MovePosition(_racket.position + delta);
			Debug.Log(delta);
		}
	}
}