using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public Transform target;
	float distance = -10;
	float height = 4;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 v = new Vector3 (0, height, distance);
		transform.position = target.position + v;
		transform.LookAt (target);
	}
}
