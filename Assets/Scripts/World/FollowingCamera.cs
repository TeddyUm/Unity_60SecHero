using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{ 
	// player
	[SerializeField]
	private GameObject player;
	// clamp camera
	[SerializeField]
	private Vector3 minPos, maxPos;

	void FixedUpdate () {

		float posX = player.transform.position.x;
		float posY = player.transform.position.y;
		transform.position = new Vector3 (posX, posY, transform.position.z);

		// clamp camera
		transform.position = new Vector3 (
			Mathf.Clamp (transform.position.x, minPos.x, maxPos.x),
			Mathf.Clamp (transform.position.y, maxPos.y, minPos.y),
			Mathf.Clamp (transform.position.z, transform.position.z, transform.position.z));
		}
}